import React from 'react';
import './Sidebar.css'
import { Nav } from 'react-bootstrap';

function Sidebar() {
  return (
    <Nav defaultActiveKey="/home" className="flex-column Sidebar">
      <Nav.Link href="/home">Ordenes</Nav.Link>
      <Nav.Link href="/servicios">Operadores</Nav.Link>
      <Nav.Link href="/contacto">Proveedores</Nav.Link>
      <Nav.Link href="/acerca">Conductores</Nav.Link>
      <Nav.Link href="/acerca">Clientes</Nav.Link>
      <Nav.Link href="/acerca">Vehículos</Nav.Link>
      <Nav.Link href="/acerca">Pólizas</Nav.Link>
      <Nav.Link href="/acerca">Servicios</Nav.Link>
      <Nav.Link href="/acerca">Departamentos</Nav.Link>
      <Nav.Link href="/acerca">Notificaciones</Nav.Link>
    </Nav>
  );
}

export default Sidebar;
