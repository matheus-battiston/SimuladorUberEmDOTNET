import { axiosInstance } from '../_base/axios-instance';

const URL_DETALHAR_PASSAGEIRO = '/passageiros/:id';

export async function detalharPassageiro(id) {
  const resposta = await axiosInstance.get(
    URL_DETALHAR_PASSAGEIRO.replace(':id', id)
  );
  return resposta.data;
}
