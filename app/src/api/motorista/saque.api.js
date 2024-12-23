import { formatarValorMonetarioParaSalvar } from '../../core/formatadores';
import { axiosInstance } from '../_base/axios-instance';

const URL_NOVO_MOTORISTA = '/motoristas';

export async function saqueMotorista(input, idMotorista) {
  const resposta = await axiosInstance.put(
    URL_NOVO_MOTORISTA + `/${idMotorista}/sacar`,
    {
      valorSaque: formatarValorMonetarioParaSalvar(input),
    }
  );
  return resposta.data;
}
