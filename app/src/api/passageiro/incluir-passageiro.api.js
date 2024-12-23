import { axiosInstance } from '../_base/axios-instance';

const URL_NOVO_PASSAGEIRO = '/passageiros';

export async function incluirPassageiro(inputs) {
  const resposta = await axiosInstance.post(URL_NOVO_PASSAGEIRO, {
    nome: inputs.nome,
    cpf: inputs.cpf,
    dataNascimento: inputs.dataNascimento,
  });
  return resposta.data;
}
