import {
  Background,
  BotaoVoltar,
  ContainerFormulario,
  FormCadastro,
  TituloForm,
} from '../../components';

export function TelaCadastroMotorista() {
  return (
    <Background>
      <ContainerFormulario>
        <section>
          <TituloForm texto="Cadastro de motorista" />
          <FormCadastro />
        </section>
      </ContainerFormulario>
      <BotaoVoltar />
    </Background>
  );
}
