import React, { Component } from 'react';
import { Table } from 'react-bootstrap';
import { Button, ButtonToolbar } from 'react-bootstrap';

import { AddBookModal } from './AddBookModal';
import { EditBookModal } from './EditBookModal';

export class Book extends Component {

    constructor(props) {
        super(props);
        this.onChangeRadionButtonValue = this.onChangeRadionButtonValue.bind(this);
        this.handleSearchInputChange = this.handleSearchInputChange.bind(this);
        this.handleSearchSubmit = this.handleSearchSubmit.bind(this);
        this.state = { books: [], AddModalShow: false, EditModalShow: false, searchParams:"Books", searchText:"" }
    }

onChangeRadionButtonValue(event) {

      var schP = event.target.value;
      this.setState({ searchParams: schP });    
      
    }

    handleSearchInputChange(event) {
        if (event.target.value == "") {
            console.log("empty$$$$$$$$$");
            this.refreshList("","")
        }
        var schT = event.target.value;
        this.setState({ searchText: schT });

    }

    handleSearchSubmit(event) {
        event.preventDefault();
        this.refreshList(this.state.searchParams, this.state.searchText);        
    }

    componentDidMount() {
        console.log(this.state)
        this.refreshList(this.state.searchParams, this.state.searchText);
    }

    refreshList(srchP, srcT) {

        fetch(window.location.origin + '/api/book/page?pageIndex=0&SearchPropertyName=' + srchP + '&SearchTerm=' + srcT)
            .then(response => response.json())
            .then(data => {
                this.setState({
                    books: data.records
                });
            })
        /*this.setState({
            auths: [{ "AuthorID": 1, "AuthorName": "Kairat" },
                { "AuthorID": 2, "AuthorName": "Kairat1" }]
        })*/
    }
    componentDidUpdate() {
        //this.refreshList();
    }

    deleteBook(bookid) {
        if (window.confirm('Are you sure?')) {
            fetch(window.location.origin + '/api/book/delete?id=' + bookid,
                {
                    method: 'DELETE',
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json',
                    }
                })

        }
    }

    render() {
        const { books, bookid, bookname, bookdesc, bookdate, price, auths, publs, publsid, publsnm  } = this.state;
        let AddModalClose = () => this.setState({ AddModalShow: false }, this.refreshList("",""));
        let EditModalClose = () => this.setState({ EditModalShow: false }, this.refreshList("",""));
        console.log(books)
        return (
            <div className="container">
                <div onChange={this.onChangeRadionButtonValue}>
                    <input type="radio" value="Book" name="gender" defaultChecked /> Search by title
                    <input type="radio" value="Author.Name" name="gender" /> Search by author 
                    <input type="radio" value="Publisher.Name" name="gender" /> Search by publisher
                    
                </div>
                <form onSubmit={this.handleSearchSubmit}>
                    <input type="input" value={this.state.searchText} onChange={this.handleSearchInputChange} name="gender" /> 
                <input type="submit" value="Search" />
                </form>
                <Table className="mt-4" striped dordered="true" hover size="sm">
                    <thead>
                        <tr>
                            <th>BookID</th>
                            <th>Name</th>
                            <th>Description</th>
                            <th>Publisher</th>
                            <th>Price</th>
                            <th>Data</th>
                            <th>Authors</th>
                        </tr>
                    </thead>
                    <tbody>
                        {books.map(book =>
                            <tr key={book.id}>
                                <td>{book.id}</td>
                                <td>{book.name}</td>
                                <td>{book.description}</td>
                                <td>{book.publisher.name}</td>
                                <td>{book.price}</td>
                                <td>{book.publishedAt}</td>
                                <td><ul>{book.authors.map(item => <li key={item.authorID}>{item.name} </li>)}</ul></td>
                                <td>
                                    <ButtonToolbar>
                                        <Button className="mr-2" variant="info"
                                            onClick={() => this.setState({
                                                EditModalShow: true,
                                                bookid: book.id,
                                                bookname: book.name,
                                                bookdesc: book.description,
                                                publs: book.publisher,
                                                bookdate: book.publishedAt,
                                                price: book.price,
                                                auths: book.authors,
                                                publsid: book.publisherID,
                                                publsnm: book.publisher.name,
                                                publs: book.publisher
                                            })}>
                                            Edit
                            </Button>
                                        <Button className="mr-2" variant="danger"
                                            onClick={() => this.deleteBook(book.id)} >
                                            Delete
                            </Button>
                                        
                                    </ButtonToolbar>
                                </td>
                            </tr>
                        )}
                    </tbody>

                </Table>
                <ButtonToolbar>
                    <Button
                        variant='primary'
                        onClick={() => this.setState({ AddModalShow: true })}
                    >
                        Add Book
                </Button>
                    <AddBookModal
                        show={this.state.AddModalShow}
                        onHide={AddModalClose}
                    />
                    <EditBookModal
                        show={this.state.EditModalShow}
                        onHide={EditModalClose}
                        bookid={bookid}
                        bookname={bookname}
                        bookdesc={bookdesc}
                        bookdate={bookdate}
                        bookprice={price}
                        publsid={publsid}
                        publsnm={publsnm}
                        auths={auths}
                        publs={publs}
                    />


                </ButtonToolbar>
            </div>
        )
    }
}

/**/

/**/