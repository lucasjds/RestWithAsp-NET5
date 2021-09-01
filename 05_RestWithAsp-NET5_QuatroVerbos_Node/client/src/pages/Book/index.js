import React from 'react';
import {Link} from 'react-router-dom';
import {FiPower} from 'react-icons/fi';
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
        </div>
    );
}