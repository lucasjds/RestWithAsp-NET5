import axios from 'axios';
import https from 'https';

const httpsAgent = new https.Agent({
    rejectUnauthorized: false, // (NOTE: this will disable client verification)
})

const api = axios.create({
    baseURL :'https://localhost:44300', httpsAgent
});


export default api;