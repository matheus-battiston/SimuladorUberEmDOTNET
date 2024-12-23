import { axiosInstance } from '../_base/axios-instance';

const URL_LISTAR_PASSAGEIROS = '/passageiros';

export async function listarPassageiros() {
  const resposta = await axiosInstance.get(URL_LISTAR_PASSAGEIROS);
  return resposta.data;
}
