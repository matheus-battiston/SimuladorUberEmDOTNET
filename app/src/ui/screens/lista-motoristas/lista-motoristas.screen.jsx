import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router';
import { useListarMotoristas } from '../../../hook/use-listar-motoristas/use-listar-motoristas.hook';
import {
  BotaoEnviarForm,
  Loading,
  Menu,
  Pessoa,
  Titulo,
} from '../../components';
import './lista-motoristas.css';

export function ListaMotoristasScreen() {
  const [carregando, setCarregando] = useState(true);
  const { listaDeMotoristas } = useListarMotoristas(() => {
    setCarregando(false);
  });
  const navigate = useNavigate();

  useEffect(() => {
    if (listaDeMotoristas) {
      setCarregando(false);
    }
  }, [listaDeMotoristas]);

  function onMotoristaClick(id) {
    navigate(`/motoristas/${id}`);
  }

  function clickCadastroMotorista() {
    navigate('/incluirMotorista');
  }

  return (
    <>
      <div className="botao-criar-motorista">
        <BotaoEnviarForm
          texto="Cadastrar motorista"
          click={clickCadastroMotorista}
        />
      </div>
      <Menu />
      {carregando && <Loading />}
      <section className="lista-motoristas-screen">
        <Titulo>Motoristas</Titulo>
        {listaDeMotoristas &&
          (listaDeMotoristas.length === 0 ? (
            <p className="mensagem-nao-encontrado">
              Nenhum motorista encontrado.
            </p>
          ) : (
            listaDeMotoristas
              .sort((a, b) => (a.nome > b.nome ? 1 : -1))
              .map((motorista) => {
                return (
                  <Pessoa
                    key={motorista.id}
                    nome={motorista.nome}
                    nota={motorista.nota}
                    status={motorista.status}
                    onClick={() => onMotoristaClick(motorista.id)}
                  />
                );
              })
          ))}
      </section>
    </>
  );
}
