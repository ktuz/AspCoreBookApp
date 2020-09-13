import React, { Component } from 'react';
import { Modal, Button, Row, Col, Form } from 'react-bootstrap';
import { Table } from 'react-bootstrap';


import styled from '@emotion/styled';
import Select from 'react-dropdown-select';

export class AddBookModal extends Component {
    constructor(props) {
        super(props);
        this.state = { publishers:[], authors:[], addAuthors:[]}
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    componentDidMount() {
        fetch(window.location.origin + '/api/publisher/list')
            .then(response => response.json())
            .then(data => {
                this.setState({ publishers: data });
            });
        fetch(window.location.origin + '/api/author/list')
            .then(response => response.json())
            .then(data => {
                this.setState({ authors: data });
            });
    }

    handleSubmit(event) {
        event.preventDefault();
        fetch(window.location.origin +'/api/book/post', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                ID: 0,
                Name: event.target.BookName.value,
                Description: event.target.BookDescription.value,
                PublisherID: event.target.BookPublisher.value,
                Price: event.target.BookPrice.value,
                Authors: this.addAuthors

            })
        })

    }

    render() {
        return (
            <Modal
                {...this.props}
                size="lg"
                aria-labelledby="contained-modal-title-vcenter"
                centered
            >
                <Modal.Header closeButton>
                    <Modal.Title id="contained-modal-title-vcenter">
                        Add Book
                </Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <div className="container">
                        <Row>
                            <Col sm={6}>
                            <Form onSubmit={this.handleSubmit}>
                            <Form.Group controlId="BookName">
                                <Form.Label>BookName</Form.Label>
                                <Form.Control type="text" name="BookName" required placeholder="BookName">
                            </Form.Control>
                            </Form.Group>
                            <Form.Group controlId="BookDescription">
                                <Form.Label>BookDescription</Form.Label>
                                <Form.Control type="text" name="BookDescription" required placeholder="BookDescription">
                                </Form.Control>
                            </Form.Group>
                            <Form.Group controlId="BookPublisher">
                                        <Form.Label>BookPublisher</Form.Label>
                                        <Form.Control as="select" defaultValue={1} >
                                    {
                                                this.state.publishers.map(pub =>
                                                    <option value={pub.publisherID} key={pub.name}>{pub.name}</option> 
                                    )}
                            </Form.Control>
                            </Form.Group>
                                    <Select
                                        required
                                        multi
                                        options={this.state.authors}
                                        values={[]}
                                        placeholder="Add Authors"
                                        labelField="name"
                                        valueField="name"
                                        placeholder="Search authors"
                                        dropdownPosition="top"
                                        keepSelectedInList="true"
                                        dropdownPosition="bottom"
                                        direction= "ltr"
                                        dropdownHeight= "250px"
                                        dropdownHandleRenderer={({ state }) => (
                                            // if dropdown is open show "–" else show "+"
                                            <span>{state.dropdown ? '–' : '+'}</span>
                                        )}
                                        onChange={(value) => this.addAuthors = value}
                                    />
                                    <div className="container">
                                       
                                    </div>
                            <Form.Group controlId="BookPrice">
                                <Form.Label>BookPrice</Form.Label>
                                <Form.Control type="text" name="BookPrice" required placeholder="BookPrice">
                                </Form.Control>
                            </Form.Group>
                                    <Form.Group>
                                        <Button variant="primary" type="submit">
                                            Add Author
                                        </Button>
                                    </Form.Group>
                                    
                            </Form>
                            </Col>

                        </Row>
                    </div>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="danger" onClick={this.props.onHide}>Close</Button>
                </Modal.Footer>
            </Modal>
        )
    }
}