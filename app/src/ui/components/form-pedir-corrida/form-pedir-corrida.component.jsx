import { useState } from 'react';
import {
  BotaoEnviarForm,
  BotaoFecharModal,
  InputTexto,
  MensagemErroForm,
  TituloForm,
  WrapperForm,
} from '../';
import { validarDadosPedirCorrida } from '../../../core/validators';
import { useFormPedirCorrida } from '../../../hook/use-form-pedir-corrida/use-form-pedir-corrida.hook';
import { usePedirCorrida } from '../../../hook/use-pedir-corrida/use-pedir-corrida';
import './form-pedir-corrida.css';

export function FormPedirCorrida({ idPassageiro, fechar }) {
  const { mudanca, dadosDosInputs } = useFormPedirCorrida();
  const [erro, setErro] = useState(false);
  const { requisitarCorrida, response } = usePedirCorrida();

  function enviar(event) {
    event.preventDefault();
    if (validarDadosPedirCorrida(dadosDosInputs, setErro)) {
      requisitarCorrida(dadosDosInputs, idPassageiro);
    }
  }

  function fecharModal() {
    fechar();
  }

  function exibirResponse() {
    return (
      <div className='conteudo-response'>
        <BotaoFecharModal funcaoFechar={fecharModal} />
        <img
          className="foto-do-carro"
          src={response.veiculo.fotoUrl}
          alt="foto de um carro"
        />
        <p className="estilo-descricao-veiculo">
          Placa do carro: {response.veiculo.placa}
        </p>
        <p className="estilo-descricao-veiculo">
          Modelo do veículo: {response.veiculo.modelo}
        </p>
        <p className="estilo-descricao-veiculo">
          Cor do veículo: {response.veiculo.cor}
        </p>
        <p className="estilo-descricao-veiculo">
          Nome do motorista: {response.nomeMotorista}
        </p>
        <p className="estilo-descricao-veiculo">
          Motorista chegará em: {response.tempoEsperado} minutos
        </p>
      </div>
    );
  }

  function exibirFormulario() {
    return (
      <>
        <BotaoFecharModal funcaoFechar={fecharModal} />
        <TituloForm texto="Pedir uma corrida" />
        <WrapperForm enviar={enviar}>
          <InputTexto
            tipo="texto"
            textoLabel="Latitude inicio"
            name="latitudeInicio"
            mudanca={mudanca}
          />
          <InputTexto
            tipo="texto"
            textoLabel="Longitude inicio"
            name="longitudeInicio"
            mudanca={mudanca}
          />
          <InputTexto
            tipo="texto"
            textoLabel="Latitude final"
            name="latitudeFinal"
            mudanca={mudanca}
          />
          <InputTexto
            tipo="texto"
            textoLabel="Longitude final"
            name="longitudeFinal"
            mudanca={mudanca}
          />
          {erro ? <MensagemErroForm /> : null}
          <BotaoEnviarForm texto="Chamar" />
        </WrapperForm>
      </>
    );
  }

  return response === null ? exibirFormulario() : exibirResponse();
}
