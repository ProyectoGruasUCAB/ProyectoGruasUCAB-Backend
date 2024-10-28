import React from "react";
import { Container, Navbar, Form, FormControl } from 'react-bootstrap';

function header() {
    return(
        <Navbar bg="dark" variant="dark" className="App-header">
            <Container>
                <Navbar.Brand className="logo">GruasUCAB</Navbar.Brand>
                <Form className="d-flex search-bar">
                    <FormControl type="search" placeholder="Buscar ..." className="me-2" aria-label="Buscar"/>
                </Form>
            </Container>
        </Navbar>
    )
}

export default header;