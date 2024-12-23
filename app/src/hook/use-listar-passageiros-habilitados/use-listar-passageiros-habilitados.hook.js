import { useEffect, useState } from 'react';
import { listarPassageirosHabilitados } from '../../api/passageiro/listar-passageiros-habilitados.api';
import useGlobalErro from '../../context/erro/erro.context';

export function useListarPassageirosHabilitados(onError) {
  const [listaDePassageirosHabilitados, setListaDePassageirosHabilitados] =
    useState();
  const [, setErro] = useGlobalErro();

  useEffect(() => {
    obterPassageirosHabilitados();
  }, []);

  async function obterPassageirosHabilitados() {
    try {
      const respostaApi = await listarPassageirosHabilitados();
      setListaDePassageirosHabilitados(respostaApi);
    } catch (error) {
      setErro(error.response.data.message || error.response.statusText);
      if (onError) {
        onError();
      }
    }
  }

  return { listaDePassageirosHabilitados, obterPassageirosHabilitados };
}
