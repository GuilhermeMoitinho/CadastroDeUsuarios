import { useState, useEffect } from 'react';
import RequestAPI from '../Api/RquicisaoPostAPI';
import { useNavigate } from "react-router-dom";
import { Link } from 'react-router-dom';

const Login = () => {
  const [email, setEmail] = useState("");
  const [senha, setSenha] = useState("");

  const URL = "http://localhost:5193/api/users/login";

  const body = {
    Email: email,
    Senha: senha
  };

  useEffect(() => {
    console.log("Componente Login montado");
    alert("Efetue seu Login!");
  }, []);
  
  let redirect = useNavigate();

  const handleKeyDown = (e) => {
    if (e.key === 'Enter') {
      EfetuarRequicisao();
    }
  };

  function EfetuarRequicisao(e) {
    if (e) {
      e.preventDefault();
    }

    RequestAPI(URL, body)
      .then(response => {
        console.log(response.data);
        alert("Efetuado com sucesso!")

        let token = response.data.token

        localStorage.setItem('token', token);
        localStorage.setItem("NomeUsuario", email)
        redirect("/User")
        // Handle successful login here
      })
      .catch(error => {
        if (email === "" || senha === "") {
          alert("Erro! Verifique se preencheu todos os campos.");
        }
        if (error.response && error.response.status === 500) {
          alert("Usuário não encontrado. Verifique suas credenciais.");
          setEmail("");
          setSenha("");
        } else {
          // Handle other errors if needed
          alert("Verifique suas credenciais, usuários pode não existir.", error);
          setEmail("");
          setSenha("");
        }
      });
  }

  return (
    <div className='container'>
      <h1>Tela de Login</h1>

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
        type="password"
        placeholder="Senha"
        className="number"
        onKeyDown={handleKeyDown}
      />

      <button onClick={EfetuarRequicisao}>Enviar</button>

      <Link to="/">Se não possui cadastro, venha efetuá-lo!</Link>
    </div>
  );
};

export default Login;
