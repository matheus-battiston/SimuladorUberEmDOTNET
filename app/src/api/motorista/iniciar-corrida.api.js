import { axiosInstance } from '../_base/axios-instance';

const URL_INICIAR_CORRIDA = '/corridas/iniciar/:idCorrida';

export async function iniciarCorrida(idMotorista, idCorrida) {
  const resposta = await axiosInstance.put(
    URL_INICIAR_CORRIDA.replace(':idMotorista', idMotorista).replace(
      ':idCorrida',
      idCorrida
    )
  );
  return resposta.data;
}
