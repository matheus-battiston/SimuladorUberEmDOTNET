import useGlobalErro from '../../context/erro/erro.context';
import { avaliarMotorista } from '../../api/passageiro/avaliar-motorista.api';
import { useState } from 'react';

export function useAvaliarMotorista(onError) {
  const [, setErro] = useGlobalErro();
  const [response, setResponse] = useState(null);

  async function avaliar(idCorrida, nota) {
    try {
      await avaliarMotorista(idCorrida, nota);
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
