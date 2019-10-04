import React from 'react';
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
        request('http://localhost:3000/authentication', function (error, response, body) {
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
                <button onClick={this.handleLogin}>Login</button>
                <button onClick={this.handleApiCall}>Call API</button>
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
