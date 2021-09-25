import React, {useState}  from 'react';
import './style.css';
import {Link, useHistory} from 'react-router-dom';
import {FiArrowLeft} from 'react-icons/fi';

import api from '../../services/api';

import logoImage from '../../assets/logo.svg';

export default function NewBook(){
    const [author, setAuthor] = useState('');
    const [title, setTitle] = useState('');
    const [launchDate, setLaunchDate] = useState('');
    const [price, setPrice] = useState('');

    const history = useHistory();

    async function createNewBook(e){
        e.preventDefault();

        const data = {
            title,
            author,
            launchDate,
            price,
        };
        
        const accessToken = localStorage.getItem('accessToken');

        try{
            await api.post('api/book/v1' , data , {
                headers:{
                    Authorization: `Bearer ${accessToken}` 
                }
            });
        }catch(err){
            alert('Erro')
        };
        history.push('/books');
    }

    return (
        <div className="new-book-container">
            <div className="content">
                <section className="form">
                    <img src={logoImage} alt="Erudio"/>
                    <h1>Adicionar novo livro</h1>
                    <p>Preencha o formulário e clique em 'Adicionar'</p>
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