import { formatarValorMonetarioParaSalvar } from '../../core/formatadores';
import { axiosInstance } from '../_base/axios-instance';

const URL_NOVO_MOTORISTA = '/passageiros';

export async function depositoPassageiro(input, idPassageiro) {
  const resposta = await axiosInstance.put(
    URL_NOVO_MOTORISTA + `/${idPassageiro}/saldo`,
    {
      valorDeposito: formatarValorMonetarioParaSalvar(input),
    }
  );
  return resposta.data;
}
