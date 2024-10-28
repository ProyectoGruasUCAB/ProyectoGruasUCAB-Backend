import React from 'react';
import { Navbar, Container, Form, FormControl } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';

function Header() {
  const navigate = useNavigate();

  const handleLogout = () => {
    navigate('/Login');
  };

  return (
    <Navbar className="App-header" bg="dark" variant="dark">
      <Container fluid className="d-flex justify-content-between align-items-center">
        <Navbar.Brand className="logo text-white ms-2">GruasUcab</Navbar.Brand>
        <Form className="d-flex mx-auto search-bar">
          <FormControl
            type="search"
            placeholder="Buscar clientes, conductores, ordenes y más..."
            className="me-2"
            aria-label="Buscar"
          />
        </Form>
        <div className="icons">
          <i className="fa-solid fa-circle-info me-3"></i>
          <i className="fa-solid fa-gear me-3"></i>
          <i className="fa-solid fa-power-off me-3" onClick={handleLogout}></i>
        </div>
      </Container>
    </Navbar>
  );
}

export default Header