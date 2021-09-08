import React from 'react';
import './style.css';
import {Link} from 'react-router-dom';
import {FiArrowLeft} from 'react-icons/fi';
import logoImage from '../../assets/logo.svg';

export default function NewBook(){
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
                <form>
                    <input placeholder="Titulo"/>
                    <input placeholder="Autor"/>
                    <input placeholder="Preço"/>
                    <input type="date"/>
                    <button className="button" type="submit">Adicionar</button>
                </form>
            </div>
        </div>
    );

}