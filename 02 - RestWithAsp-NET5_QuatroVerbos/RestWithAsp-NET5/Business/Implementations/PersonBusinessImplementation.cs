﻿using RestWithAsp_NET5.Data.Converter.Implementations;
using RestWithAsp_NET5.Data.VO;
using RestWithAsp_NET5.Hypermedia.Utils;
using RestWithAsp_NET5.Model;
using RestWithAsp_NET5.Repository;
using System.Collections.Generic;

namespace RestWithAsp_NET5.Business.Implementations
{
  public class PersonBusinessImplementation : IPersonBusiness
  {
    private readonly IPersonRepository _repository;

    private readonly PersonConverter _converter;

    public PersonBusinessImplementation(IPersonRepository repository)
    {
      _repository = repository;
      _converter = new PersonConverter();
    }

    public List<PersonVO> FindAll()
    {
      return _converter.Parse(_repository.FindAll());
    }

    public PersonVO FindByID(long id)
    {
      return _converter.Parse(_repository.FindByID(id));
    }

    public PersonVO Create(PersonVO person)
    {
      var personEntity = _converter.Parse(person);
      personEntity = _repository.Create(personEntity);
      return _converter.Parse(personEntity);
    }

    public PersonVO Update(PersonVO person)
    {
      var personEntity = _converter.Parse(person);
      personEntity = _repository.Update(personEntity);
      return _converter.Parse(personEntity);
    }

    public void Delete(long id)
    {
      _repository.Delete(id);
    }

    public PersonVO Disable(long id)
    {
      var personEntity = _repository.Disable(id);
      return _converter.Parse(personEntity);
    }

    public List<PersonVO> FindByName(string firstName, string lastName)
    {
      return _converter.Parse(_repository.FindByName(firstName, lastName));
    }

    public PagedSearchVO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
    {
      var offset = page > 0 ? (page - 1) * pageSize : 0;
      var sort = (!string.IsNullOrWhiteSpace(sortDirection)) && !sortDirection.Equals("desc") ? "asc" : "desc";
      var size = (pageSize < 1) ? 1 : pageSize;

      string query = @"select * from Person p where 1 = 1 and p.name like '%LEO%' order by p.name asc limit 10 offset 1";
      string countQuery = string.Empty;
      var persons = _repository.FindWithPagedSearch(query);
      int totalResults = _repository.GetCount(countQuery);

      return new PagedSearchVO<PersonVO>
      {
        CurrentPage = offset,
        List = _converter.Parse(persons),
        PageSize = size,
        SortDirections = sort,
        TotalResults = totalResults
      };
    }
  }
}
