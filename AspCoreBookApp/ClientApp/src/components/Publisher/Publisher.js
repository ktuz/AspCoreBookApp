import React, { Component } from 'react';
import { Table } from 'react-bootstrap';
import { Button, ButtonToolbar } from 'react-bootstrap';

import { AddPublisherModal } from './AddPublisherModal';
import { EditPublisherModal } from './EditPublisherModal';


export class Publisher extends Component {

    constructor(props) {
        super(props);
        this.state = { auths: [], AddModalShow: false, EditModalShow: false }
    }

    componentDidMount() {
        this.refreshList();
    }

    refreshList() {

        fetch(window.location.origin + '/api/publisher/page?pageIndex=0')
            .then(response => response.json())
            .then(data => {
                this.setState({
                    auths: data.records
                });
            })
        /*this.setState({
            auths: [{ "AuthorID": 1, "AuthorName": "Kairat" },
                { "AuthorID": 2, "AuthorName": "Kairat1" }]
        })*/
    }
    /*componentDidUpdate(prevProps, prevState) {
        this.refreshList();
    }*/
    componentDidUpdate() {
        //this.refreshList();
    }
    deleteAuthor(authid) {
        if (window.confirm('Are you sure?')) {
            fetch(window.location.origin + '/api/publisher/delete?id=' + authid,
                {
                    method: 'DELETE',
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json',
                    }
                });
            this.refreshList();
        }

    }

    render() {

        const { auths, authid, authname } = this.state;
        let AddModalClose = () => this.setState({ AddModalShow: false }, this.refreshList);
        let EditModalClose = () => this.setState({ EditModalShow: false }, this.refreshList);
        return (
            <div className="container">
                <Table className="mt-4" striped dordered='true' hover size="sm">
                    <thead>
                        <tr>
                            <th>AuthorID</th>
                            <th>AuthorName</th>
                            <th>Option</th>
                        </tr>
                    </thead>
                    <tbody>
                        {auths.map(auth =>
                            <tr key={auth.publisherID}>
                                <td>{auth.publisherID}</td>
                                <td>{auth.name}</td>
                                <td>
                                    <ButtonToolbar>
                                        <Button className="mr-2" variant="info"
                                            onClick={() => this.setState({ EditModalShow: true, authid: auth.authorID, authname: auth.name })}>
                                            Edit
                            </Button>
                                        <Button className="mr-2" variant="danger"
                                            onClick={() => this.deleteAuthor(auth.publisherID)} >
                                            Delete
                            </Button>
                                        <EditPublisherModal
                                            show={this.state.EditModalShow}
                                            onHide={EditModalClose}
                                            authid={authid}
                                            authname={authname}
                                        />
                                    </ButtonToolbar>
                                </td>
                            </tr>
                        )}
                    </tbody>
                    <div className="container">
                        <ButtonToolbar>
                            <Button
                                variant='primary'
                                onClick={() => this.setState({ AddModalShow: true })}
                            >
                                Add Author
                             </Button>

                            <AddPublisherModal
                                show={this.state.AddModalShow}
                                onHide={AddModalClose}
                            />
                        </ButtonToolbar>
                    </div>
                </Table>
            </div>

        )
    }
}