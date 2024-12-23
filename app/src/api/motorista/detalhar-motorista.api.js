import { axiosInstance } from '../_base/axios-instance';

const URL_DETALHAR_MOTORISTA = '/motoristas/:id';

export async function detalharMotorista(id) {
  const resposta = await axiosInstance.get(
    URL_DETALHAR_MOTORISTA.replace(':id', id)
  );
  return resposta.data;
}
