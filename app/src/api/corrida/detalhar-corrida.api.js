import { axiosInstance } from '../_base/axios-instance';

const URL_DETALHAR_CORRIDA = '/corridas/:id';

export async function detalharCorrida(id) {
  const resposta = await axiosInstance.get(
    URL_DETALHAR_CORRIDA.replace(':id', id)
  );
  return resposta.data;
}
