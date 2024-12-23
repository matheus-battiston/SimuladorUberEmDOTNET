import { axiosInstance } from '../_base/axios-instance';

const URL_LISTAR_PASSAGEIROS_HABILITADOS = '/passageiros/habilitados';

export async function listarPassageirosHabilitados() {
  const resposta = await axiosInstance.get(URL_LISTAR_PASSAGEIROS_HABILITADOS);
  return resposta.data;
}
