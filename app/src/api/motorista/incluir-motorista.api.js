import { axiosInstance } from '../_base/axios-instance';

const URL_NOVO_MOTORISTA = '/motoristas';

export async function incluirMotorista(inputs) {
  const resposta = await axiosInstance.post(URL_NOVO_MOTORISTA, {
    nome: inputs.nome,
    cpf: inputs.cpf,
    dataNascimento: inputs.dataNascimento,
    habilitacaoNumero: inputs.nroCNH,
    habilitacaoCategoria: inputs.categoria,
    habilitacaoDataVencimento: inputs.validadeCNH,
  });
  return resposta.data;
}
