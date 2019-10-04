import React from 'react';
import Button from '@material-ui/core/Button';

import './App.css';


class MyComponent extends React.Component {
    constructor(props) {
        super(props);
        this.bearerToken = '';

        this.handleLogin = this.handleLogin.bind(this);
        this.handleApiCall = this.handleApiCall.bind(this);
    }

    handleLogin(e) {
        e.preventDefault();
        const request = require('request');
        request('https://localhost:3001/authentication', function (error, response, body) {
            if (error) {
                console.log(error);
            }
            this.bearerToken = body;
            console.log(body);
        });
    }

    handleApiCall(e) {
        e.preventDefault();
        console.log(this.bearerToken);
        const request = require('request');

        const options = {
            url: 'https://localhost:6001/api/commitments',
            headers: {
                'Authentication': 'Bearer ' + this.bearerToken,
                'Access-Control-Allow-Origin': '*'
            }
        };

        request(options, function (error, response, body) {
            if (error) {
                console.log(error);
            }
        });
    }

    render() {
        return (
            <div>
                <Button variant="contained" color="primary" onClick={this.handleLogin}>Login</Button>
                <Button variant="contained" color="primary" onClick={this.handleApiCall}>Call API</Button>
            </div>
        );
    }
}


function App() {


    return (
        <div className="App">
            <MyComponent />
        </div>
    );
}

export default App;
