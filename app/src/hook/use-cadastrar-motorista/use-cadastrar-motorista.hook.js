import useGlobalErro from '../../context/erro/erro.context';
import { incluirMotorista } from '../../api/motorista/incluir-motorista.api';
import { useState } from 'react';

export function useCadastrarMotorista(onError) {
  const [, setErro] = useGlobalErro();
  const [response, setResponse] = useState(null);

  async function cadastrarMotorista(inputs) {
    try {
      const respostaApi = await incluirMotorista(inputs);
      setResponse(respostaApi);
    } catch (error) {
      setErro(error.response.data.message || error.response.statusText);
      if (onError) {
        onError();
      }
    }
  }

  return { cadastrarMotorista, response };
}
