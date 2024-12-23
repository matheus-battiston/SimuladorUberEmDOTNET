import { useEffect, useState } from 'react';
import { detalharPassageiro } from '../../api/passageiro/detalhar-passageiro.api';
import useGlobalErro from '../../context/erro/erro.context';

export function useDetalharPassageiro(idPassageiro, onError) {
  const [passageiro, setPassageiro] = useState();
  const [, setErro] = useGlobalErro();

  useEffect(() => {
    detalharPassageiroById(idPassageiro);
  }, []);

  async function detalharPassageiroById(idPassageiro) {
    try {
      const respostaApi = await detalharPassageiro(idPassageiro);
      setPassageiro(respostaApi);
    } catch (error) {
      setErro(error.response.data.message || error.response.statusText);
      if (onError) {
        onError();
      }
    }
  }

  return { passageiro, detalharPassageiroById };
}
