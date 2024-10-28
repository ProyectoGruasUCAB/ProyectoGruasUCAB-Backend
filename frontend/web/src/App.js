import React from 'react';
import './App.css';
import Header from './components/Header/Header';
import Sidebar from './components/Sidebar/Sidebar';
import Orders from './components/Order/order';
import Operator from './components/Operator/operator';
import Suplier from './components/Suplier/suplier';
import Driver from './components/Driver/driver';
import Cliente from './components/Cliente/cliente';
import Vehicle from './components/Vehicle/vehicle';
import Policies from './components/Policies/policies';
import Servicios from './components/Servicios/servicios';
import Department from './components/Department/department';
import Notification from './components/Notifications/notifications';
import 'bootstrap/dist/css/bootstrap.min.css';
import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom'
import LoginForm from './components/Login/login';
import AddOperator from './components/Operator/addOpeator';

function App() {
  return (
    <Router>
      <div className="App">
        <Header />
        <div className="App-body d-flex">
          <Sidebar />
          <div className="content">
            <Routes>
              <Route path="/orders" element={<Orders/>} />
              <Route path="/operators" element={<Operator/>} />
              <Route path="/supliers" element={<Suplier/>} />
              <Route path="/drivers" element={<Driver/>} />
              <Route path="/clientes" element={<Cliente/>} />
              <Route path="/vehicles" element={<Vehicle/>} />
              <Route path="/policies" element={<Policies/>} />
              <Route path="/servicios" element={<Servicios/>} />
              <Route path="/departments" element={<Department/>} />
              <Route path="/notifications" element={<Notification/>} />
              <Route path="/Login" element={<LoginForm/>} />
              <Route path="/addOperator" element={<AddOperator/>} />
              <Route path="*" element={<Navigate to="/orders" replace/>} />
            </Routes>  
          </div>
        </div>
      </div>
    </Router>
  );
}

export default App;
