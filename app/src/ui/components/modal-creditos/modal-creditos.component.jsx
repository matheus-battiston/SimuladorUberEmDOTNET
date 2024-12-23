import { useEffect, useState } from 'react';
import { BotaoEnviarForm, BotaoFecharModal, MensagemErroForm } from '../';
import { validarCreditos } from '../../../core/validators';
import { useDepositar } from '../../../hook/use-depositar/use-depositar';
import { useFormCredito } from '../../../hook/use-input-credito/use-input-credito';
import { useSacar } from '../../../hook/use-sacar/use-sacar';
import './modal-creditos.css';

export function ModalCreditos({ textoBotao, id, fecharModal, tipo }) {
  const { mudanca, dadosDosInputs } = useFormCredito();
  const [erro, setErro] = useState(false);
  const { sacar, responseSacar } = useSacar();
  const { depositar, responseDepositar } = useDepositar();

  useEffect(() => {
    if (responseSacar != null || responseDepositar != null) {
      fecharModal();
    }
  }, [responseSacar, responseDepositar]);

  function manipular(event) {
    event.preventDefault();
    if (validarCreditos(dadosDosInputs, setErro)) {
      if (tipo === 'sacar') {
        sacar(dadosDosInputs, id);
      } else if (tipo === 'depositar') {
        depositar(dadosDosInputs, id);
      }
    }
  }

  return (
    <div className="fundo-modal-creditos">
      <div className="estilo-modal-creditos">
        <BotaoFecharModal funcaoFechar={fecharModal} />
        <h1 className="titulo-modal-credito">Digite o valor</h1>
        <form className="form-credito" onSubmit={manipular}>
          <input type="text" className="texto-credito" onChange={mudanca} />
          {erro ? <MensagemErroForm /> : null}
          <BotaoEnviarForm texto={textoBotao} />
        </form>
      </div>
    </div>
  );
}
