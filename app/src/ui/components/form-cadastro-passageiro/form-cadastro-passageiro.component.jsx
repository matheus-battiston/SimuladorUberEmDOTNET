import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import {
  BotaoEnviarForm,
  InputData,
  InputTexto,
  MensagemErroForm,
  WrapperForm,
} from '../';
import { validarDadosCadastroPassageiro } from '../../../core/validators';
import { useCadastrarPassageiro } from '../../../hook/use-cadastrar-passageiro/use-cadastrar-motorista.hook';
import { useFormIncluirPassageiro } from '../../../hook/use-form-incluir-passageiro/use-form-incluir-passageiro.hook';
import './form-cadastro-passageiro.css';

export function FormCadastroPassageiro() {
  const { mudanca, dadosDosInputs } = useFormIncluirPassageiro();
  const [erro, setErro] = useState(false);
  const { cadastrarPassageiro, response } = useCadastrarPassageiro();
  const navigate = useNavigate();

  function enviar(event) {
    event.preventDefault();
    if (validarDadosCadastroPassageiro(dadosDosInputs, setErro)) {
      cadastrarPassageiro(dadosDosInputs);
    }
  }

  useEffect(() => {
    if (response != null) {
      navigate('/passageiros');
    }
  }, [response]);

  return (
    <WrapperForm enviar={enviar}>
      <InputTexto tipo="text" textoLabel="Nome" name="nome" mudanca={mudanca} />
      <InputTexto tipo="text" textoLabel="CPF" name="cpf" mudanca={mudanca} />
      <div className="data-aniversario">
        <InputData
          textoLabel="Data de nascimento"
          mudanca={mudanca}
          name="dataNascimento"
        />
      </div>
      {erro ? <MensagemErroForm /> : null}
      <BotaoEnviarForm texto="Enviar" />
    </WrapperForm>
  );
}
