import { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router';
import { useDetalharCorrida } from '../../../hook/use-detalhar-corrida/use-detalhar-corrida.hook';
import {
  Botao,
  CaminhoCorrida,
  DetalheCorrida,
  Loading,
  Menu,
  ModalAvaliacaoPassageiro,
} from '../../components';
import './detalhar-corrida-passageiro.css';

export function DetalharCorridaPassageiroScreen() {
  const [carregando, setCarregando] = useState(true);
  const { id } = useParams();
  const { corrida, detalharCorridaById } = useDetalharCorrida(id, () => {
    setCarregando(false);
  });
  const [mostrarModal, setMostrarModal] = useState(false);
  const [atualizar, setAtualizar] = useState(false);
  const navigate = useNavigate();

  useEffect(() => {
    if (corrida) {
      setCarregando(false);
    }
  }, [corrida]);

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

  async function onAvaliarMotoristaClick() {
    setMostrarModal(true);
  }

  return (
    <>
      {mostrarModal ? (
        <ModalAvaliacaoPassageiro idCorrida={id} fechar={fecharModal} />
      ) : null}
      <Menu />
      {carregando && <Loading />}
      {corrida && (
        <>
          <section className="detalhes-corrida-passageiro-screen">
            <CaminhoCorrida status={corrida.status} />
            <div className="container-botoes">
              {corrida?.status === 'FINALIZADA' &&
                corrida.notaMotorista === null && (
                  <Botao onClick={onAvaliarMotoristaClick}>
                    Avaliar Motorista
                  </Botao>
                )}
              <Botao onClick={() => navigate(-1)}>Voltar</Botao>
            </div>

            <DetalheCorrida
              inicioY={corrida.longitudeInicio}
              finalY={corrida.longitudeFinal}
              inicioX={corrida.latitudeInicio}
              finalX={corrida.latitudeFinal}
              nome={corrida.nomeMotorista}
              nota={corrida.notaMotorista}
              tipo="Motorista"
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
