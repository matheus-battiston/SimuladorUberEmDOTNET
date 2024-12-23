import { axiosInstance } from '../_base/axios-instance';

const URL_AVALIAR_PASSAGEIRO = '/motoristas/avaliar-passageiro';

export async function avaliarPassageiro(idCorrida, nota) {
  const resposta = await axiosInstance.put(URL_AVALIAR_PASSAGEIRO, {
    nota: nota,
    idDaCorrida: idCorrida,
  });
  return resposta.data;
}
