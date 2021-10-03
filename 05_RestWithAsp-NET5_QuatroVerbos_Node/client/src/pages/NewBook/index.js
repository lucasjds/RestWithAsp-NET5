import React, {useState, useEffect}  from 'react';
import './style.css';
import {Link, useHistory, useParams } from 'react-router-dom';
import {FiArrowLeft} from 'react-icons/fi';

import api from '../../services/api';
import logoImage from '../../assets/logo.svg';

export default function NewBook(){
    const [id, setId] = useState(null);
    const [author, setAuthor] = useState('');
    const [title, setTitle] = useState('');
    const [launchDate, setLaunchDate] = useState('');
    const [price, setPrice] = useState('');

    const {bookId} = useParams();
    const history = useHistory();

    const accessToken = localStorage.getItem('accessToken');

    const authorization = {
        headers :
        {
            Authorization: `Bearer ${accessToken}` 
        }
    };

    useEffect(() => {
        if(bookId === '0') return;
        else loadBook();
    }, bookId);

    async function loadBook(){
        try{
            const response = await api.get(`api/book/v1/${bookId}`, authorization);
            setId(response.data.id);
            setAuthor(response.data.author);
            setTitle(response.data.title);
            setPrice(response.data.price);
            setLaunchDate(response.data.launchDate.split("T", 10)[0]);

        }catch(error){
            alert('Erro');
            history.push('/books');
        }
    }

    async function createNewBook(e){
        e.preventDefault();

        const data = {
            title,
            author,
            launchDate,
            price,
        };
        try{
            await api.post('api/book/v1' , data , authorization);
        }catch(err){
            alert('Erro');
        };
        history.push('/books');
    }

    return (
        <div className="new-book-container">
            <div className="content">
                <section className="form">
                    <img src={logoImage} alt="Erudio"/>
                    <h1>Adicionar novo livro</h1>
                    <p>Preencha o formulário e clique em 'Adicionar' ${bookId}</p>
                    <Link className="back-link" to="/books">
                        <FiArrowLeft size={16} color="#251FC5"/>
                        Home
                    </Link>
                </section>
                <form onSubmit={createNewBook}>
                    <input placeholder="Titulo" value={title} onChange={e => setTitle(e.target.value)}/>
                    <input placeholder="Autor" value={author} onChange={e => setAuthor(e.target.value)}/>
                    <input placeholder="Preço" value={price} onChange={e => setPrice(e.target.value)}/>
                    <input type="date" value={launchDate} onChange={e => setLaunchDate(e.target.value)}/>
                    <button className="button" type="submit">Adicionar</button>
                </form>
            </div>
        </div>
    );

}