import React from 'react';
import './Sidebar.css';
import { Nav } from 'react-bootstrap';
import { NavLink } from 'react-router-dom';

function Sidebar() {
  return (
    <Nav defaultActiveKey="/orders" className="flex-column Sidebar">
      <Nav.Link as={NavLink} to="/orders" eventKey="/orders" className="sidebar-link">Ordenes</Nav.Link>
      <Nav.Link as={NavLink} to="/operators" eventKey="/operators" className="sidebar-link">Operadores</Nav.Link>
      <Nav.Link as={NavLink} to="/supliers" eventKey="/supliers" className="sidebar-link">Proveedores</Nav.Link>
      <Nav.Link as={NavLink} to="/drivers" eventKey="/drivers" className="sidebar-link">Conductores</Nav.Link>
      <Nav.Link as={NavLink} to="/clientes" eventKey="/clientes" className="sidebar-link">Clientes</Nav.Link>
      <Nav.Link as={NavLink} to="/vehicles" eventKey="/vehicles" className="sidebar-link">Vehículos</Nav.Link>
      <Nav.Link as={NavLink} to="/policies" eventKey="/policies" className="sidebar-link">Pólizas</Nav.Link>
      <Nav.Link as={NavLink} to="/servicios" eventKey="/servicios" className="sidebar-link">Servicios</Nav.Link>
      <Nav.Link as={NavLink} to="/departments" eventKey="/departments" className="sidebar-link">Departamentos</Nav.Link>
      <Nav.Link as={NavLink} to="/notifications" eventKey="/notifications" className="sidebar-link">Notificaciones</Nav.Link>
    </Nav>
  );
}

export default Sidebar;
