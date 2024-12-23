import { useParams } from 'react-router-dom';
import {
  Background,
  BotaoVoltar,
  ContainerFormulario,
  FormCadastroVeiculo,
  TituloForm,
} from '../../components';

export function TelaCadastroVeiculo() {
  const { idMotorista } = useParams();

  return (
    <Background>
      <ContainerFormulario>
        <section>
          <TituloForm texto="Cadastro de veículo" />
          <FormCadastroVeiculo idMotorista={idMotorista} />
        </section>
      </ContainerFormulario>
      <BotaoVoltar />
    </Background>
  );
}
