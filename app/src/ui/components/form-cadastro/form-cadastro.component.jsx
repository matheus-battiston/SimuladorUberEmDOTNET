import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import {
  BotaoEnviarForm,
  InputData,
  InputTexto,
  MensagemErroForm,
  SelectCategoria,
  WrapperForm,
} from '../';
import { validarDadosCadastroMotorista } from '../../../core/validators';
import { useCadastrarMotorista } from '../../../hook/use-cadastrar-motorista/use-cadastrar-motorista.hook';
import { useFormIncluirMotorista } from '../../../hook/use-form-incluir-motorista/use-form-incluir-motorista.hook';
import './form-cadastro.css';

export function FormCadastro() {
  const { mudanca, dadosDosInputs } = useFormIncluirMotorista();
  const { cadastrarMotorista, response } = useCadastrarMotorista();
  const [erro, setErro] = useState(false);
  const navigate = useNavigate();

  function enviar(event) {
    event.preventDefault();
    if (validarDadosCadastroMotorista(dadosDosInputs, setErro)) {
      cadastrarMotorista(dadosDosInputs);
    }
  }

  useEffect(() => {
    if (response != null) {
      navigate('/motoristas');
    }
  }, [response]);

  return (
    <WrapperForm enviar={enviar}>
      <InputTexto tipo="text" textoLabel="Nome" name="nome" mudanca={mudanca} />
      <InputTexto tipo="text" textoLabel="CPF" name="cpf" mudanca={mudanca} />
      <InputTexto
        tipo="text"
        textoLabel="Numero habilitação"
        name="nroCNH"
        mudanca={mudanca}
      />

      <div className="datas">
        <InputData
          textoLabel="Data de nascimento"
          mudanca={mudanca}
          name="dataNascimento"
        />
        <InputData
          textoLabel="Validade da CNH"
          mudanca={mudanca}
          name="validadeCNH"
        />
      </div>

      <SelectCategoria mudanca={mudanca} />

      {erro ? <MensagemErroForm /> : null}
      <BotaoEnviarForm texto="Enviar" />
    </WrapperForm>
  );
}
