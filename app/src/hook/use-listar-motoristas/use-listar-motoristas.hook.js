import { useEffect, useState } from 'react';
import { listarMotoristas } from '../../api/motorista/listar-motoristas.api';
import useGlobalErro from '../../context/erro/erro.context';

export function useListarMotoristas(onError) {
  const [listaDeMotoristas, setListaDeMotoristas] = useState();
  const [, setErro] = useGlobalErro();

  useEffect(() => {
    obterMotoristas();
  }, []);

  async function obterMotoristas() {
    try {
      const respostaApi = await listarMotoristas();
      setListaDeMotoristas(respostaApi);
    } catch (error) {
      setErro(error.response.data.message || error.response.statusText);
      if (onError) {
        onError();
      }
    }
  }

  return { listaDeMotoristas, obterMotoristas };
}
