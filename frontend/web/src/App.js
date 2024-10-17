import React from 'react';
import './App.css';
import Header from './components/Header/Header';
import Sidebar from './components/Sidebar/Sidebar'
import 'bootstrap/dist/css/bootstrap.min.css';

function App() {
  return (
    <div className="App">
      <Header />
      <div className="App-body d-flex">
        <Sidebar />
        <div className="content p-4">
          <h1>Bienvenido a GruasUcab</h1>
          <p>Contenido principal aquí.</p>
        </div>
      </div>
    </div>
  );
}

export default App;
