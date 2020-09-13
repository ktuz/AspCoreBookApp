import React, { Component } from 'react';
import { Modal, Button, Row, Col, Form } from 'react-bootstrap';
import { Table } from 'react-bootstrap';

export class AddAuthorModal extends Component {
    constructor(props) {
        super(props);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleSubmit(event) {
        event.preventDefault();
        fetch(window.location.origin +'/api/author/post', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                AuthorID: null,
                Name: event.target.AuthorName.value
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
                        Add Author
                </Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <div className="container">
                        <Row>
                            <Col sm={6}>
                            <Form onSubmit={this.handleSubmit}>
                            <Form.Group controlId="AuthorName">
                                <Form.Label>AuthorName</Form.Label>
                                <Form.Control type="text" name="AuthorName" required placeholder="AuthorName">
                            </Form.Control>
                            </Form.Group>
                            <Form.Group>
                                    <Button variant="primary" type="submit" >
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