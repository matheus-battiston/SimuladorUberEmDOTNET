import { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router';
import {
  formatarDataEHora,
  formatarNota,
  formatarValorMonetario,
} from '../../../core/formatadores';
import { useDetalharPassageiro } from '../../../hook/use-detalhar-passageiro/use-detalhar-passageiro.hook';
import {
  BotaoCreditos,
  Corrida,
  Loading,
  Menu,
  ModalCreditos,
  Titulo,
} from '../../components';
import './detalhar-passageiro.css';

export function DetalharPassageiroScreen() {
  const [mostarModal, setMostrarModal] = useState(false);
  const [carregando, setCarregando] = useState(true);
  const { id } = useParams();
  const { passageiro, detalharPassageiroById } = useDetalharPassageiro(
    id,
    () => {
      setCarregando(false);
    }
  );
  const navigate = useNavigate();

  useEffect(() => {
    if (passageiro) {
      setCarregando(false);
    }
  }, [passageiro]);

  function fecharModal() {
    setMostrarModal(false);
    detalharPassageiroById(id);
  }

  function onCorridaClick(id) {
    navigate(`/passageiros/corridas/${id}`);
  }

  function funcaoDepositar() {
    setMostrarModal(true);
  }

  return (
    <>
      {mostarModal ? (
        <ModalCreditos
          textoBotao="Depositar"
          id={id}
          fecharModal={fecharModal}
          tipo="depositar"
        />
      ) : null}
      <Menu />
      {carregando && <Loading />}
      {passageiro && (
        <>
          <section className="detalhes-passageiro-screen">
            <div className="infos-passageiro">
              <div>
                <h1>{passageiro.nome}</h1>
                <span>{formatarValorMonetario(passageiro.saldoEmConta)}</span>
                <BotaoCreditos onClick={funcaoDepositar}>
                  Adicionar créditos
                </BotaoCreditos>
              </div>
              <div>
                <p className="nota">
                  <i className="fa fa-star"></i> {formatarNota(passageiro.nota)}
                </p>
                <p>{passageiro.numeroDeCorridas} corridas solicitadas</p>
              </div>
            </div>
          </section>
          <section className="detalhes-corridas-passageiro-screen">
            <Titulo>Histórico de Corridas</Titulo>
            {passageiro?.corridas?.length > 0 ? (
              passageiro.corridas.map((corrida) => {
                console.log(corrida)
                return (
                  <Corrida
                    key={corrida.id}
                    nome={`Motorista: ${corrida.nomeMotorista}`}
                    dataInicio={formatarDataEHora(corrida.horarioInicio)}
                    status={corrida.status}
                    onClick={() => onCorridaClick(corrida.id)}
                  />
                );
              })
            ) : (
              <p className="nenhuma-corrida">Nenhuma corrida realizada</p>
            )}
          </section>
        </>
      )}
    </>
  );
}
