import './App.css';
import React from 'react';
import Header from './components/header';
import Sidebar from './components/sidebar';
import 'bootstrap/dist/css/bootstrap.min.css';
function App() {
  return (
    <div className="App">
      <Header/>
      <div className="App-body d-flex">
        <Sidebar/>
        <div className="content p-4">
          <h1>Bienvenido a GruasUcab</h1>
          <p>Contenido principal aquí.</p>
        </div>
      </div>
    </div>
  );
}

export default App;
