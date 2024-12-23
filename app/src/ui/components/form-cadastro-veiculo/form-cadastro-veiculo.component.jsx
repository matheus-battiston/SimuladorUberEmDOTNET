import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import {
  BotaoEnviarForm,
  InputTexto,
  MensagemErroForm,
  SelectCategoria,
  WrapperForm,
} from '../';
import { validarDadosCadastroVeiculo } from '../../../core/validators';
import { useCadastrarVeiculo } from '../../../hook/use-cadastrar-veiculo/use-cadastrar-veiculo.hook';
import { useFormIncluirVeiculo } from '../../../hook/use-form-incluir-veiculo/use-form-incluir-veiculo';

export function FormCadastroVeiculo({ idMotorista }) {
  const { mudanca, dadosDosInputs } = useFormIncluirVeiculo();
  const { cadastrarVeiculo, response } = useCadastrarVeiculo();
  const [erro, setErro] = useState(false);
  const navigate = useNavigate();

  function enviar(event) {
    event.preventDefault();
    if (validarDadosCadastroVeiculo(dadosDosInputs, setErro)) {
      cadastrarVeiculo(dadosDosInputs, idMotorista);
    }
  }

  useEffect(() => {
    if (response) {
      navigate('/motoristas');
    }
  }, [response]);

  return (
    <WrapperForm enviar={enviar}>
      <InputTexto
        tipo="text"
        textoLabel="Placa"
        name="placa"
        mudanca={mudanca}
      />
      <InputTexto
        tipo="text"
        textoLabel="Modelo"
        name="modelo"
        mudanca={mudanca}
      />
      <InputTexto tipo="text" textoLabel="Cor" name="cor" mudanca={mudanca} />
      <InputTexto
        tipo="text"
        textoLabel="URL da foto"
        name="url"
        mudanca={mudanca}
      />
      <SelectCategoria mudanca={mudanca} />
      {erro ? <MensagemErroForm /> : null}
      <BotaoEnviarForm enviar={enviar} texto="Enviar" />
    </WrapperForm>
  );
}
