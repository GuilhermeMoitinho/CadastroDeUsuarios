import  { useState, useEffect  } from 'react';
import { useNavigate } from 'react-router-dom';
import RequestAPI from '../Api/RequicisaoPutAPI';
import { Link } from 'react-router-dom';

const AlterarSenha = () => {
  const [email, setEmail] = useState('');
  const [senha, setSenhaAtual] = useState('');
  const [novaSenha, setNovaSenha] = useState('');
  const usuario = localStorage.getItem("NomeUsuario")

  const URL = 'http://localhost:5193/api/users/esqueciSenha';

  const token = localStorage.getItem('token');
  const headers = {
    headers: {
      Authorization: `Bearer ${token}`
    }
  };

  const body = {
    EmailEsqueciSenha: email,
    PassWord: senha,
    ConfirmPassWord: novaSenha,
  };

  const navigate = useNavigate();

  
  const handleKeyDown = (e) => {
    if (e.key === 'Enter') {
      efetuarRequisicao();
    }
  };

  useEffect(() => {
    
    setEmail(usuario || ''); 
  }, [usuario]);


  async function efetuarRequisicao(e) {
    e.preventDefault();

    try {
      await RequestAPI(URL, body, headers);
      alert('Senha alterada com sucesso!');
      navigate('/User');
    } catch (error) {
      console.error('Erro na requisição:', error);
      
      alert('Erro ao alterar a senha. Tente novamente mais tarde.');
      setSenhaAtual("")
      setNovaSenha("")
    }
  }

  return (
    <div className="container">
      <h1>Alterar Senha</h1>

      <input
        value={email}
        onChange={(e) => setEmail(e.target.value)}
        type="text"
        placeholder="E-mail do Usuário"
        className="text"
           
      />
      <input
        value={senha}
        onChange={(e) => setSenhaAtual(e.target.value)}
        type="password"
        placeholder="Nova Senha"
        className="number"
      />
      <input
        value={novaSenha}
        onChange={(e) => setNovaSenha(e.target.value)}
        type="password"
        placeholder="Confirmar Nova Senha"
        className="number"
        onKeyDown={handleKeyDown}
      />

      <button onClick={efetuarRequisicao}>Alterar Senha</button>

      <Link to="/User">Voltar para as informações do usuário</Link>
    </div>
  );
};

export default AlterarSenha;
