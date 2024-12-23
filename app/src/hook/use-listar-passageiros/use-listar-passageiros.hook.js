import { useEffect, useState } from 'react';
import { listarPassageiros } from '../../api/passageiro/listar-passageiros.api';
import useGlobalErro from '../../context/erro/erro.context';

export function useListarPassageiros(onError) {
  const [listaDePassageiros, setListaDePassageiros] = useState();
  const [, setErro] = useGlobalErro();

  useEffect(() => {
    obterPassageiros();
  }, []);

  async function obterPassageiros() {
    try {
      const respostaApi = await listarPassageiros();
      console.log(respostaApi);
      setListaDePassageiros(respostaApi);
    } catch (error) {
      setErro(error.response.data.message || error.response.statusText);
      if (onError) {
        onError();
      }
    }
  }

  return { listaDePassageiros, obterPassageiros };
}
