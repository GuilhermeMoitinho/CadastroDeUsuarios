import  { useEffect, useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import RequestGetAPI from '../Api/RequicisaoGetAPI';

const InforUser = () => {
  const [dados, setDados] = useState([]);
  let redirect = useNavigate();
  const URL = "http://localhost:5193/api/employees";
  const token = localStorage.getItem("token");
  const usuario = localStorage.getItem("NomeUsuario")

  const headers = {
    headers: {
      Authorization: `Bearer ${token}`
    }
  };

  useEffect(() => {
    RequestGetAPI(URL, headers)
      .then(response => {
        setDados(response.data.lista.result);

      })
      .catch(error => {
        console.error("Erro na requisição:", error);
        redirect("/login");
      });
  }, []);

  useEffect(() => {
      console.log(dados);
  }, [dados]);


  return (
    <div>
      <Link to="/AlterarSenha">Alterar sua senha</Link>
      <p>User: {usuario}</p>
      <h2>Informacoes dos Funcionarios</h2>
      

      {dados.length > 0 &&
      dados.map((item, index) => (
    <div className='ListaDeFuncionarios'key={index}>
      <p>Nome do Funcionário: {item.name}</p>
      <p>Idade do Funcionário: {item.age}</p>
      {item.imageURL && (
        <div>
          <p>URL da Imagem do Funcionário: {item.imageURL}</p>
          <img src={item.imageURL} alt="Imagem" />
          
          <div className="DivisaInfo"></div>
        </div>
        
      )}
    </div>
  ))
}



      <Link to="/">Voltar para a tela de cadastro</Link>
    </div>
  );
};

export default InforUser;
