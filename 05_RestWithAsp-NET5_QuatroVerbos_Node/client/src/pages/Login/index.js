import React, {useState} from 'react';
import './style.css';

import {useHistory} from 'react-router-dom';

import api from '../../services/api';

import logoImage from '../../assets/logo.svg';
import padlock from '../../assets/padlock.png';


export default function Login(){
    const [userName, setUserName] = useState('');
    const [password, setPassword] = useState('');

    const history = useHistory();

    async function login(e){
        e.preventDefault();

        const data = {
            userName,
            password,
        };

        try{
            const response = await api.post('api/auth/v1/signin' , data);
            localStorage.setItem('userName', userName);
            localStorage.setItem('accessToken', response.data.accessToken);
            localStorage.setItem('refreshToken', response.data.refreshToken);

            history.push('/books');
        }catch(error){
            alert('login falhou');
        }
    }

    return (
        <div className="login-container">
            <section className="form">
                <img src={logoImage} alt="Erudio logo"/>
                <form onSubmit={login}>
                    <h1>Access your account</h1>
                    <input placeholder="username" value="{userName}" 
                           onChange={e => setUserName(e.target.value)}></input>
                    <input type="password" placeholder="password" value="{password}" 
                           onChange={e => setPassword(e.target.value)}></input>
                    <button className="button" type="submit">Login</button>
                </form>
            </section>
            <img src={padlock} alt="Login"></img>
        </div>
    );
}