import React from 'react';
import {BrowserRouter, Route, Switch} from 'react-router-dom';

import Login from './pages/Login';
import Book from './pages/Book';

export default function Routes(){
    return (
        <BrowserRouter>
            <switch>
                <Route path="/" exact component={Login}/>
                <Route path="/book" exact component={Book}/>
            </switch>
        </BrowserRouter>

    );

}