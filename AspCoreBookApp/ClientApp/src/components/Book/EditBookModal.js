import React, { Component } from 'react';
import { Modal, Button, Row, Col, Form } from 'react-bootstrap';
import { Table } from 'react-bootstrap';


import styled from '@emotion/styled';
import Select from 'react-dropdown-select';

export class EditBookModal extends Component {
    constructor(props) {
        super(props);
        this.state = { publishers: [], authors: [], addAuthors: [] }
        this.handleSubmit = this.handleSubmit.bind(this);

        //console.log(this.props)
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

    addAuthor() {
        this.setState({ addAuthors: [{ AuthorID: "", Name: "" }] })
    }

    handleRemove(index) {
        this.state.addAuthors.splice(index, 1);
        this.setState({ addAuthors: this.state.addAuthors })
    }

    handleSubmit(event) {
        //console.log(this.state.addAuthors)
        event.preventDefault();
        fetch(window.location.origin + '/api/book/update', {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                ID: event.target.BookId.value,
                Name: event.target.BookName.value,
                Description: event.target.BookDescription.value,
                PublisherID: event.target.BookPublisher.value,
                Price: event.target.BookPrice.value,
                PublishedAt: event.target.BookDate.value,
                Authors: this.addAuthors

            })
        })
        //console.log(this.addAuthors);
    }

    render() {

        return (
            <div className="container">
            <Modal
                {...this.props}
                size="lg"
                aria-labelledby="contained-modal-title-vcenter"
                centered
            >
                <Modal.Header closeButton>
                    <Modal.Title id="contained-modal-title-vcenter">
                        Edit Book
                </Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <div className="container">
                        <Row>
                            <Col sm={6}>
                                <Form onSubmit={this.handleSubmit}>
                                    <Form.Group controlId="BookId">
                                        <Form.Label>BookId</Form.Label>
                                        <Form.Control
                                            type="text"
                                            name="BookId"
                                            disabled
                                            defaultValue={this.props.bookid}
                                            placeholder="BookId">
                                        </Form.Control>
                                    </Form.Group>
                                    <Form.Group controlId="BookName">
                                        <Form.Label>BookName</Form.Label>
                                        <Form.Control
                                            type="text"
                                            name="BookName"
                                            required
                                            defaultValue={this.props.bookname}
                                            placeholder="BookName">
                                        </Form.Control>
                                    </Form.Group>
                                    <Form.Group controlId="BookDescription">
                                        <Form.Label>BookDescription</Form.Label>
                                        <Form.Control
                                            type="text"
                                            name="BookDescription"
                                            required
                                            defaultValue={this.props.bookdesc}
                                            placeholder="BookDescription">
                                        </Form.Control>
                                    </Form.Group>
                                    <Form.Group controlId="BookDate">
                                        <Form.Label>BookDate</Form.Label>
                                        <Form.Control
                                            type="date"
                                            name="BookDate"
                                            required
                                            defaultValue={this.props.bookdate}
                                            placeholder="BookDate"
                                            >   
                                        </Form.Control>
                                    </Form.Group>
                                    <Form.Group controlId="BookPublisher">
                                        <Form.Label>BookPublisher</Form.Label>
                                            <Form.Control as="select" defaultValue={this.props.publsid} >
                                            {
                                                this.state.publishers.map(pub =>
                                                    <option key={pub.publisherID} value={pub.publisherID}>{pub.name}</option>
                                                )}
                                        </Form.Control>
                                    </Form.Group>
                                    <Form.Group>

                                        <div className="container">
                                                <Select
                                                    required
                                                    multi
                                                    options={this.state.authors}
                                                    values={this.props.auths}
                                                    placeholder="Add Authors"
                                                    labelField="name"
                                                    valueField="name"
                                                    placeholder="Search authors"
                                                    dropdownPosition="top"
                                                    keepSelectedInList="true"
                                                    dropdownPosition="bottom"
                                                    direction="ltr"
                                                    dropdownHeight="250px"
                                                    dropdownHandleRenderer={({ state }) => (
                                                        // if dropdown is open show "–" else show "+"
                                                        <span>{state.dropdown ? '–' : '+'}</span>
                                                    )}
                                                    onChange={(value) => this.addAuthors= value}
                                    />
                                        </div>



                                    </Form.Group>
                                    <Form.Group controlId="BookPrice">
                                        <Form.Label>BookPrice</Form.Label>
                                        <Form.Control
                                            type="text"
                                            name="BookPrice"
                                            required
                                            defaultValue={this.props.bookprice}
                                            placeholder="BookPrice">
                                        </Form.Control>
                                    </Form.Group>
                                    <Form.Group>
                                        <Button variant="primary" type="submit">
                                            Update Author
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
            </div>
        )
    }
}