import React from 'react';
import './style.css';

import logoImage from '../../assets/logo.svg';
import padlock from '../../assets/padlock.png';


export default function Login(){
    return (
        <div className="login-container">
            <section className="form">
                <img src={logoImage} alt="Erudio logo"/>
                <form>
                    <h1>Access your account</h1>
                    <input placeholder="username"></input>
                    <input type="password" placeholder="password"></input>
                    <button type="submit">Login</button>
                </form>
            </section>
            <img src={padlock} alt="Login"></img>
        </div>
    );
}