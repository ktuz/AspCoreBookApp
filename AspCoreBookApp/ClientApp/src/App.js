import React from 'react';
import './App.css';

import { Home } from './components/Home';
import { Book } from './components/Book/Book';
import { Author } from './components/Author/Author';
import { Publisher } from './components/Publisher/Publisher';
import { Navigation } from './components/Navigation';
import { BrowserRouter, Route, Switch } from 'react-router-dom';

//export default class App extends Component {
function App() {
//render() {
    return (
            <BrowserRouter>
            <div className="container">
                <h3 className="m-3 d-flex justify-contnet-center">
                    ReactJs
                </h3>
                <h5 className="m-3 d-flex justify-contnet-center">
                    test
                </h5>
                <Navigation />
                    <Switch>
                    <Route path='/' component={Home} exact />
                    <Route path='/book' component={Book} />
                    <Route path='/author' component={Author} />
                    <Route path='/publisher' component={Publisher} />
                    </Switch>
                </div>
            </BrowserRouter>
    );
//  }
}
export default App;