import useGlobalErro from '../../context/erro/erro.context';
import { avaliarPassageiro } from '../../api/motorista/avaliar-passageiro.api';
import { useState } from 'react';

export function useAvaliarPassageiro(onError) {
  const [, setErro] = useGlobalErro();
  const [response, setResponse] = useState(null);

  async function avaliar(idCorrida, nota) {
    try {
      await avaliarPassageiro(idCorrida, nota);
      setResponse(true);
    } catch (error) {
      setErro(error.response.data.message || error.response.statusText);
      if (onError) {
        onError();
      }
    }
  }

  return { avaliar, response };
}
