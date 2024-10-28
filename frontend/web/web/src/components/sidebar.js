import React from "react";
import { Nav } from "react-bootstrap";

function sidebar() {
    return (
            <Nav defaultActiveKey="/home" className="flex-column Sidebar">
                <Nav.Link href="#home">Home</Nav.Link>
                <Nav.Link href="#features">Features</Nav.Link>
                <Nav.Link href="#pricing">Pricing</Nav.Link>
                <Nav.Link href="#faq">FAQ</Nav.Link>
                <Nav.Link href="#contact">Contact</Nav.Link>
            </Nav>
    );
}

export default sidebar;