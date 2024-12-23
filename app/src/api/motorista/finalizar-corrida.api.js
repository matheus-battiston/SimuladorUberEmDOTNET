import { axiosInstance } from '../_base/axios-instance';

const URL_FINALIZAR_CORRIDA = 'corridas/finalizar/:idCorrida';

export async function finalizarCorrida(idMotorista, idCorrida) {
  const resposta = await axiosInstance.put(
    URL_FINALIZAR_CORRIDA.replace(':idCorrida', idCorrida)
  );
  return resposta.data;
}
