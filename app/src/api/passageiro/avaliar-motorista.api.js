import { axiosInstance } from '../_base/axios-instance';

const URL_AVALIAR_MOTORISTA = '/passageiros/avaliar-motorista';

export async function avaliarMotorista(idCorrida, nota) {
  const resposta = await axiosInstance.put(URL_AVALIAR_MOTORISTA, {
    nota: nota,
    idDaCorrida: idCorrida,
  });
  return resposta.data;
}
