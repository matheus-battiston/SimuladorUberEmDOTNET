import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router';
import { useListarPassageiros } from '../../../hook/use-listar-passageiros/use-listar-passageiros.hook';
import {
  BotaoEnviarForm,
  Loading,
  Menu,
  Pessoa,
  Titulo,
} from '../../components';
import './lista-passageiros.css';

export function ListaPassageirosScreen() {
  const [carregando, setCarregando] = useState(true);
  const { listaDePassageiros } = useListarPassageiros(() => {
    setCarregando(false);
  });
  const navigate = useNavigate();

  useEffect(() => {
    if (listaDePassageiros) {
      setCarregando(false);
    }
  }, [listaDePassageiros]);

  function onPassageiroClick(id) {
    navigate(`/passageiros/${id}`);
  }

  function clickCadastrarPassageiro() {
    navigate('/incluirPassageiro');
  }

  return (
    <>
      <div className="botao-criar-passageiro">
        <BotaoEnviarForm
          texto="Cadastrar passageiro"
          click={clickCadastrarPassageiro}
        />
      </div>
      <Menu />
      {carregando && <Loading />}
      <section className="lista-passageiros-screen">
        <Titulo>Passageiros</Titulo>
        {listaDePassageiros &&
          (listaDePassageiros.length === 0 ? (
            <p className="mensagem-nao-encontrado">
              Nenhum passageiro encontrado.
            </p>
          ) : (
            listaDePassageiros
              .sort((a, b) => (a.nome > b.nome ? 1 : -1))
              .map((passageiro) => {
                return (
                  <Pessoa
                    key={passageiro.id}
                    nome={passageiro.nome}
                    nota={passageiro.nota}
                    status={passageiro.status}
                    onClick={() => onPassageiroClick(passageiro.id)}
                  />
                );
              })
          ))}
      </section>
    </>
  );
}
