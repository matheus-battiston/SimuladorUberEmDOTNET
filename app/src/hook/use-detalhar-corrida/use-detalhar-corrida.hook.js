import { useEffect, useState } from 'react';
import { detalharCorrida } from '../../api/corrida/detalhar-corrida.api';
import useGlobalErro from '../../context/erro/erro.context';

export function useDetalharCorrida(idCorrida, onError) {
  const [corrida, setCorrida] = useState();
  const [, setErro] = useGlobalErro();

  useEffect(() => {
    detalharCorridaById(idCorrida);
  }, []);

  async function detalharCorridaById(idCorrida) {
    try {
      const respostaApi = await detalharCorrida(idCorrida);
      setCorrida(respostaApi);
    } catch (error) {
      setErro(error.response.data.message || error.response.statusText);
      if (onError) {
        onError();
      }
    }
  }

  return { corrida, detalharCorridaById };
}
