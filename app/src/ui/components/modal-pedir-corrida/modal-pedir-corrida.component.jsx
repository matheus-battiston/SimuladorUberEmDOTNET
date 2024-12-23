import { ContainerFormulario, FormPedirCorrida } from '../';
import './modal-pedir-corrida.css';

export function ModalPedirCorrida({ idPassageiro, fechar }) {
  return (
    <div className="fundo-modal">
      <ContainerFormulario>
        <section>
          <FormPedirCorrida idPassageiro={idPassageiro} fechar={fechar} />
        </section>
      </ContainerFormulario>
    </div>
  );
}
