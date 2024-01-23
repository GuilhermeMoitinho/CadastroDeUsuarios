import { useState } from 'react';
import { useNavigate } from "react-router-dom";
import RequestAPI from '../Api/RquicisaoPostAPI';
import { Link } from 'react-router-dom';

const Cadastro = () => {
  const [email, setEmail] = useState("");
  const [senha, setSenha] = useState("");

  const URL = "http://localhost:5193/api/users/cadastro"

  const body = {
    Email: email,
    Senha: senha
  }
  
  const navigate = useNavigate(); 
  
  const handleKeyDown = (e) => {
    if (e.key === 'Enter') {
      EfetuarRequicisao();
    }
  };

  function EfetuarRequicisao(e) {
    e.preventDefault();
    
    RequestAPI(URL, body).then(response => {
      alert("Efetuado com sucesso!")
      alert("Sendo redirecionado para o Login...")
      console.log(response.data)
        navigate("/login")

      })
      .catch(error => {
        if(email === "" || senha === "")
        {
          alert("Erro! Verifique se preencheu todos os campos.");
        }
        if (error.response && error.response.status === 404) {
          alert("Erro! Verifique suas credenciais.");
          setEmail("");
          setSenha("");
        } else {

          alert("Erro na requisição, tente novamente mais tarde.");
          setEmail("");
          setSenha("");
        }
      });
  }

  

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
        onKeyDown={handleKeyDown}
      />


      <button onClick={EfetuarRequicisao}>Enviar</button>

      <Link to="/login">Se ja tem cadastro, venha efetuar o Login!</Link>
    </div>
  );
};

export default Cadastro;
