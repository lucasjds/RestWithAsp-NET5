import React from 'react';
import {Link} from 'react-router-dom';
import {FiPower, FiEdit, FiTrash2} from 'react-icons/fi';
import logoImage from '../../assets/logo.svg';
import './style.css';

export default function Book(){
    return (
        <div className="book-container">
            <header>
                <img src={logoImage} alt="Erudio"/>
                <span>Welcome, <strong>Lucas</strong>!</span>
                <Link className="button" to="book/new">Add new book</Link>
                <button type="button"><FiPower size={18} color="#251FC5"/></button>
            </header>
            <h1>Livros registrados</h1>
            <ul>
                <li>
                    <strong>Titulo:</strong>
                    <p>Historia da inquisiçao</p>
                    <strong>Autor:</strong>
                    <p>Joao</p>
                    <strong>Preço:</strong>
                    <p>R$ 40</p>
                    <strong>Data lançamento:</strong>
                    <p>10/10/2010</p>
                    <button type="button"><FiEdit size={20} color="#251FC5"/></button>
                    <button type="button"><FiTrash2 size={20} color="#251FC5"/></button>
                </li>
            </ul>
        </div>
    );
}