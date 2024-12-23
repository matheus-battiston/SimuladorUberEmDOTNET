import {
  Background,
  BotaoVoltar,
  ContainerFormulario,
  FormCadastroPassageiro,
  TituloForm,
} from '../../components';

export function TelaCadastroPassageiro() {
  return (
    <Background>
      <ContainerFormulario>
        <section>
          <TituloForm texto="Cadastro de passageiro" />
          <FormCadastroPassageiro />
        </section>
      </ContainerFormulario>
      <BotaoVoltar />
    </Background>
  );
}
