import { useState } from 'react';
import { useNavigate } from "react-router-dom"; // Import useNavigate
import RequestAPI from '../Api/RquicisaoPostAPI';
import { Link } from 'react-router-dom';
//import React from 'react';

const Cadastro = () => {
  const [email, setEmail] = useState("");
  const [senha, setSenha] = useState("");

  const URL = "http://localhost:5193/api/users/cadastro"

  const body = {
    Email: email,
    Senha: senha
  }
  
  const navigate = useNavigate(); // Declare navigate

  function EfetuarRequicisao(e) {
    e.preventDefault();
    
    RequestAPI(URL, body).then(response => {
      alert("Efetuado com sucesso!")
      alert("Sendo redirecionado para o Login...")
      console.log(response.data)
        navigate("/login")
        // Handle successful login here
      })
      .catch(error => {
        if (error.response && error.response.status === 404) {
          alert("Usuário não encontrado. Verifique suas credenciais.");
          setEmail("");
          setSenha("");
        } else {
          // Handle other errors if needed
          console.error("Erro na requisição:", error);
          setEmail("");
          setSenha("");
        }
      });
  }
    //navigate("/User")
  

  // Rest of the code ...


  return (
    <div className='container'>
      <h1>Tela de cadastro</h1>

      <input
        value={email}
        onChange={(e) => setEmail(e.target.value)}
        type="text"
        placeholder="Email"
        className="number"
      />
      <input
        value={senha}
        onChange={(e) => setSenha(e.target.value)}
        type="text"
        placeholder="Senha"
        className="number"
      />


      <button onClick={EfetuarRequicisao}>Enviar</button>

      <Link to="/login">Se ja tem cadastro, venha efetuar o Login!</Link>
    </div>
  );
};

export default Cadastro;
