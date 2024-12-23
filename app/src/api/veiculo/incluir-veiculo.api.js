import { axiosInstance } from '../_base/axios-instance';

const URL_VEICULOS = '/veiculos';

export async function incluirVeiculo(inputs, proprietarioId) {
  const resposta = await axiosInstance.post(URL_VEICULOS, {
    placa: inputs.placa,
    modelo: inputs.modelo,
    cor: inputs.cor,
    fotoUrl: inputs.url,
    categoria: inputs.categoria,
    proprietarioId: proprietarioId,
  });
  return resposta.data;
}
