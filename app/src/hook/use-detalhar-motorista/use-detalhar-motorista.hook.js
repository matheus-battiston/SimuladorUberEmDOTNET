import { useEffect, useState } from 'react';
import { detalharMotorista } from '../../api/motorista/detalhar-motorista.api';
import useGlobalErro from '../../context/erro/erro.context';

export function useDetalharMotorista(idMotorista, onError) {
  const [motorista, setMotorista] = useState();
  const [, setErro] = useGlobalErro();

  useEffect(() => {
    detalharMotoristaById(idMotorista);
  }, []);

  async function detalharMotoristaById(idMotorista) {
    try {
      const respostaApi = await detalharMotorista(idMotorista);
      setMotorista(respostaApi);
    } catch (error) {
      setErro(error.response.data.message || error.response.statusText);
      if (onError) {
        onError();
      }
    }
  }

  return { motorista, detalharMotoristaById };
}
