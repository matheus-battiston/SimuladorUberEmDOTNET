import { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router';
import { finalizarCorrida } from '../../../api/motorista/finalizar-corrida.api';
import { iniciarCorrida } from '../../../api/motorista/iniciar-corrida.api';
import useGlobalErro from '../../../context/erro/erro.context';
import useGlobalMensagem from '../../../context/mensagem/mensagem.context';
import { useDetalharCorrida } from '../../../hook/use-detalhar-corrida/use-detalhar-corrida.hook';
import {
  Botao,
  CaminhoCorrida,
  DetalheCorrida,
  Loading,
  Menu,
  ModalAvaliacao,
} from '../../components';
import './detalhar-corrida-motorista.css';

export function DetalharCorridaMotoristaScreen() {
  const [carregando, setCarregando] = useState(true);
  const [, setErro] = useGlobalErro();
  const { id } = useParams();
  const { corrida, detalharCorridaById } = useDetalharCorrida(id, () => {
    setCarregando(false);
  });
  const [mostrarModal, setMostrarModal] = useState(false);
  const [atualizar, setAtualizar] = useState(false);
  const [, setMensagem] = useGlobalMensagem();
  const navigate = useNavigate();

  useEffect(() => {
    if (atualizar) {
      detalharCorridaById(id);
      setAtualizar(false);
    }
  }, [atualizar]);

  function fecharModal() {
    setMostrarModal(false);
    setAtualizar(true);
  }

  async function onAvaliarPassageiroClick() {
    setMostrarModal(true);
  }

  useEffect(() => {
    if (corrida) {
      setCarregando(false);
    }
  }, [corrida]);

  async function onIniciarCorridaClick() {
    setCarregando(true);
    try {
      const resposta = await iniciarCorrida(corrida.idMotorista, id);
      await detalharCorridaById(id);
      setMensagem(
        `Tempo estimado para chegada no destino: ${resposta.tempoEstimado} segundos`
      );
    } catch (error) {
      setErro(
        error.response.data.errors ||
          error.response.data.message ||
          error.response.statusText
      );
    } finally {
      setCarregando(false);
    }
  }

  async function onFinalizarCorridaClick() {
    setCarregando(true);
    try {
      await finalizarCorrida(corrida.idMotorista, id);
      await detalharCorridaById(id);
    } catch (error) {
      setErro(
        error.response.data.notifications[0].message
      );
    } finally {
      setCarregando(false);
    }
  }

  return (
    <>
      {mostrarModal ? (
        <ModalAvaliacao idCorrida={id} fechar={fecharModal} />
      ) : null}
      <Menu />
      {carregando && <Loading />}
      {corrida && (
        <>
          <section className="detalhes-corrida-motorista-screen">
            <CaminhoCorrida status={corrida.status} />
            <div className="container-botoes">
              {corrida?.status === 'SOLICITADA' && (
                <Botao onClick={onIniciarCorridaClick}>Iniciar Corrida</Botao>
              )}
              {corrida?.status === 'INICIADA' && (
                <Botao onClick={onFinalizarCorridaClick}>
                  Finalizar Corrida
                </Botao>
              )}
              {corrida?.status === 'FINALIZADA' &&
                corrida.notaPassageiro === null && (
                  <Botao onClick={onAvaliarPassageiroClick}>
                    Avaliar Passageiro
                  </Botao>
                )}
              <Botao onClick={() => navigate(-1)}>Voltar</Botao>
            </div>
            <DetalheCorrida
              inicioY={corrida.longitudeInicio}
              finalY={corrida.longitudeFinal}
              inicioX={corrida.latitudeInicio}
              finalX={corrida.latitudeFinal}
              nome={corrida.nomePassageiro}
              nota={corrida.notaPassageiro}
              tipo="Passageiro"
              status={corrida.status}
              horarioInicio={corrida.horarioInicio}
              valorEstimado={corrida.valorEstimado}
              horarioChegada={corrida.horarioChegada}
              valorTotal={corrida.valorTotal}
            />
          </section>
        </>
      )}
    </>
  );
}
