import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import App from './App.jsx';
import './index.css';
import InforUser from './components/InforUser.jsx';
import Login from './components/Login.jsx';// Import the PrivateRoute component
import AlterarSenha from './components/UsuarioInformacoes.jsx';
import PrivateRoute from './components/PrivateRoute/PrivateRouteLogin .jsx';

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<App />} />
        <Route path="/login" element={<Login />} />
        {/* Use PrivateRoute inside a Route for the protected "/User" route */}
        <Route
          path="/User"
          element={<PrivateRoute element={<InforUser />} />}
        />

        <Route
          path="/AlterarSenha"
          element={<PrivateRoute element={<AlterarSenha />} />}
        />
       

      </Routes>
    </BrowserRouter>
  </React.StrictMode>,
);
