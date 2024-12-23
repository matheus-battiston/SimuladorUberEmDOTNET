import { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router';
import {
  formatarDataEHora,
  formatarNota,
  formatarValorMonetario,
} from '../../../core/formatadores';
import { useDetalharMotorista } from '../../../hook/use-detalhar-motorista/use-detalhar-motorista.hook';
import {
  Botao,
  BotaoCreditos,
  Corrida,
  Loading,
  Menu,
  ModalCreditos,
  Titulo,
} from '../../components';
import './detalhar-motorista.css';

export function DetalharMotoristaScreen() {
  const [mostrarModal, setMostrarModal] = useState(false);
  const [carregando, setCarregando] = useState(true);
  const { id } = useParams();
  const { motorista, detalharMotoristaById } = useDetalharMotorista(id, () => {
    setCarregando(false);
  });
  const navigate = useNavigate();

  useEffect(() => {
    if (motorista) {
      setCarregando(false);
    }
  }, [motorista]);

  function onCorridaClick(id) {
    navigate(`/motoristas/corridas/${id}`);
  }

  function clickAdicionarVeiculo() {
    navigate(`/incluirVeiculo/${id}`);
  }

  function fecharModal() {
    setMostrarModal(false);
    detalharMotoristaById(id);
  }

  function funcaoSacar() {
    setMostrarModal(true);
  }

  return (
    <>
      {mostrarModal ? (
        <ModalCreditos
          textoBotao="Sacar"
          id={id}
          tipo="sacar"
          fecharModal={fecharModal}
        />
      ) : null}
      <Menu />
      {carregando && <Loading />}
      {motorista && (
        <>
          <section className="detalhes-motorista-screen">
            <div className="infos-motorista">
              <div>
                <h1>{motorista.nome}</h1>
                <span>{formatarValorMonetario(motorista.saldoEmConta)}</span>
                <BotaoCreditos onClick={funcaoSacar}>
                  Sacar Créditos
                </BotaoCreditos>
                <p>Habilitação</p>
                <p>
                  {`Data vencimento: ${formatarDataEHora(
                    motorista.habilitacaoDataVencimento
                  )}`}
                </p>
                <p>Categoria: {motorista.habilitacaoCategoria}</p>
              </div>
              <div>
                <p className="nota">
                  <i className="fa fa-star"></i> {formatarNota(motorista.nota)}
                </p>
                <p>{motorista.numeroDeCorridas} corridas realizadas</p>
              </div>
            </div>
            <div className="infos-veiculo">
              {motorista.veiculo ? (
                <>
                  <img
                    src={motorista.veiculo.fotoUrl}
                    alt={`foto do carro ${motorista.veiculo.modelo}`}
                    className="imagem-carro"
                  />
                  <div className="detalhes-veiculo">
                    <p>Modelo: {motorista.veiculo.modelo}</p>
                    <p>Cor: {motorista.veiculo.cor}</p>
                    <p>Placa: {motorista.veiculo.placa}</p>
                  </div>
                </>
              ) : (
                <Botao onClick={clickAdicionarVeiculo}>
                  <i className="fa-solid fa-car-side icone-adicionar-veiculo"></i>
                  Adicionar Veículo
                </Botao>
              )}
            </div>
          </section>
          <section className="detalhes-corridas-motorista-screen">
            <Titulo>Histórico de Corridas</Titulo>
            {motorista?.corridas?.length > 0 ? (
              motorista.corridas.map((corrida) => {
                return (
                  <Corrida
                    key={corrida.id}
                    nome={`Passageiro: ${corrida.nomePassageiro}`}
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
