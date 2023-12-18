import  { useEffect, useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import RequestGetAPI from '../Api/RequicisaoGetAPI';

const InforUser = () => {
  const [dados, setDados] = useState([]);
  let redirect = useNavigate();
  const URL = "http://localhost:5193/api/employees";
  const token = localStorage.getItem("token");

  const headers = {
    headers: {
      Authorization: `Bearer ${token}`
    }
  };

  useEffect(() => {
    RequestGetAPI(URL, headers)
      .then(response => {
        setDados(response.data.lista);

      })
      .catch(error => {
        console.error("Erro na requisição:", error);
        redirect("/login");
      });
  }, []);

  useEffect(() => {
    console.log(dados); // mostrará o array com os dados da API
  }, [dados]);


  return (
    <div>
      <h1>Informacoes dos Funcionarios</h1>
      

      {dados.length > 0 &&
      dados.map((item, index) => (
        <div key={index}>
          <p>Nome do Funcionario: {item.name}</p>
          <img src={item.imageURL} alt="Imagem" />
    </div>
  ))}



      <Link to="/">Voltar para a tela de cadastro</Link>
    </div>
  );
};

export default InforUser;
