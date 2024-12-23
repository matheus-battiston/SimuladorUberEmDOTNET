import { useEffect, useState } from 'react';
import { useListarPassageirosHabilitados } from '../../../hook/use-listar-passageiros-habilitados/use-listar-passageiros-habilitados.hook';
import {
  Loading,
  Menu,
  ModalPedirCorrida,
  Pessoa,
  Titulo,
} from '../../components';
import './solicitar-corrida.css';

export function SolicitarCorridaScreen() {
  const [idPassageiroCorrida, setIdPassageiroCorrida] = useState(null);
  const [abrirModal, setAbrirModal] = useState(false);
  const [carregando, setCarregando] = useState(true);
  const { listaDePassageirosHabilitados, obterPassageirosHabilitados } =
    useListarPassageirosHabilitados(() => {
      setCarregando(false);
    });

  function fecharModal() {
    setIdPassageiroCorrida(null);
    setAbrirModal(false);
  }

  useEffect(() => {
    if (listaDePassageirosHabilitados) {
      setCarregando(false);
    }
  }, [listaDePassageirosHabilitados]);

  function onPassageiroHabilitadoClick(id) {
    setIdPassageiroCorrida(id);
  }

  useEffect(() => {
    if (!abrirModal) {
      obterPassageirosHabilitados();
    }
  }, [abrirModal]);

  useEffect(() => {
    if (idPassageiroCorrida) {
      setAbrirModal(true);
    }
  }, [idPassageiroCorrida]);

  return (
    <>
      {abrirModal ? (
        <ModalPedirCorrida
          idPassageiro={idPassageiroCorrida}
          fechar={fecharModal}
        />
      ) : null}
      <Menu />
      {carregando && <Loading />}
      <section className="solicitar-corrida-screen">
        <Titulo>Passageiros Habilitados</Titulo>
        {listaDePassageirosHabilitados &&
          (listaDePassageirosHabilitados.length === 0 ? (
            <p className="mensagem-nao-encontrado">
              Nenhum passageiro encontrado.
            </p>
          ) : (
            listaDePassageirosHabilitados
              .sort((a, b) => (a.nome > b.nome ? 1 : -1))
              .map((passageiro) => {
                return (
                  <Pessoa
                    key={passageiro.id}
                    nome={passageiro.nome}
                    nota={passageiro.nota}
                    status={passageiro.status}
                    onClick={() => onPassageiroHabilitadoClick(passageiro.id)}
                  />
                );
              })
          ))}
      </section>
    </>
  );
}
