import useGlobalErro from '../../context/erro/erro.context';
import { useState } from 'react';
import { incluirVeiculo } from '../../api/veiculo/incluir-veiculo.api';

export function useCadastrarVeiculo(onError) {
  const [, setErro] = useGlobalErro();
  const [response, setResponse] = useState(null);

  async function cadastrarVeiculo(inputs, proprietarioId) {
    try {
      const respostaApi = await incluirVeiculo(inputs, proprietarioId);
      setResponse(respostaApi);
    } catch (error) {
      setErro(error.response.data.message || error.response.statusText);
      if (onError) {
        onError();
      }
    }
  }

  return { cadastrarVeiculo, response };
}
