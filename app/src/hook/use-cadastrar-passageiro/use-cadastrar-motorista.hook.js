import useGlobalErro from '../../context/erro/erro.context';
import { useState } from 'react';
import { incluirPassageiro } from '../../api/passageiro/incluir-passageiro.api';

export function useCadastrarPassageiro(onError) {
  const [, setErro] = useGlobalErro();
  const [response, setResponse] = useState(null);

  async function cadastrarPassageiro(inputs) {
    try {
      const respostaApi = await incluirPassageiro(inputs);
      setResponse(respostaApi);
    } catch (error) {
      setErro(error.response.data.message || error.response.statusText);
      if (onError) {
        onError();
      }
    }
  }

  return { cadastrarPassageiro, response };
}
