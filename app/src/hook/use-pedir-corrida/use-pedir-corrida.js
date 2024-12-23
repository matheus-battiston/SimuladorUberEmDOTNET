import useGlobalErro from '../../context/erro/erro.context';
import { useState } from 'react';
import { pedirCorrida } from '../../api/corrida/pedir-corrida.api';

export function usePedirCorrida(onError) {
  const [, setErro] = useGlobalErro();
  const [response, setResponse] = useState(null);

  async function requisitarCorrida(inputs, idPassageiro) {
    try {
      const respostaApi = await pedirCorrida(inputs, idPassageiro);
      setResponse(respostaApi);
    } catch (error) {
      setErro(error.response.data.message || error.response.statusText);
      if (onError) {
        onError();
      }
    }
  }

  return { requisitarCorrida, response };
}
