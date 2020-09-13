import React, { Component } from 'react';
import { Modal, Button, Row, Col, Form } from 'react-bootstrap';

export class EditAuthorModal extends Component {
    constructor(props) {
        super(props);
    }

    handleSubmit(event) {
        event.preventDefault();
        fetch(window.location.origin +'/api/author/update', {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                AuthorID: event.target.AuthorID.value,
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
                        Edit Author
                </Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <div className="container">
                        <Row>
                            <Col sm={6}>
                            <Form onSubmit={this.handleSubmit}>
                            <Form.Group controlId="AuthorID">
                            <Form.Label>AuthorID</Form.Label>
                                        <Form.Control type="text" name="AuthorID" disabled defaultValue={this.props.authid} placeholder="AuthorID">
                            </Form.Control>
                            </Form.Group>

                            <Form.Group controlId="AuthorName">
                                <Form.Label>AuthorName</Form.Label>
                                        <Form.Control type="text" name="AuthorName" required defaultValue={this.props.authname} placeholder="AuthorName">
                            </Form.Control>
                            </Form.Group>
                            <Form.Group>
                                <Button variant="primary" type="submit">
                                    Edit Author
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