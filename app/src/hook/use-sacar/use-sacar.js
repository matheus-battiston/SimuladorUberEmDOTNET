import useGlobalErro from '../../context/erro/erro.context';
import { useState } from 'react';
import { saqueMotorista } from '../../api/motorista/saque.api';
export function useSacar(onError) {
  const [, setErro] = useGlobalErro();
  const [responseSacar, setResponseSacar] = useState(null);

  async function sacar(inputs, idMotorista) {
    try {
      const respostaApi = await saqueMotorista(inputs, idMotorista);
      setResponseSacar(respostaApi);
    } catch (error) {
      setErro(error.response.data.message || error.response.statusText);
      if (onError) {
        onError();
      }
    }
  }

  return { sacar, responseSacar };
}
