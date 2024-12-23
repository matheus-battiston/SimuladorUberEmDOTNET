import { axiosInstance } from '../_base/axios-instance';

const URL_LISTAR_MOTORISTAS = '/motoristas';

export async function listarMotoristas() {
  const resposta = await axiosInstance.get(URL_LISTAR_MOTORISTAS);
  return resposta.data;
}
