import { axiosInstance } from '../_base/axios-instance';

const URL_PEDIR_CORRIDA = '/corridas';

export async function pedirCorrida(inputs, idPassageiro) {
  const resposta = await axiosInstance.post(
    URL_PEDIR_CORRIDA + `/${idPassageiro}`,
    {
      LatitudeInicio: inputs.latitudeInicio,
      LongitudeInicio: inputs.longitudeInicio,
      LatitudeFinal: inputs.latitudeFinal,
      LongitudeFinal: inputs.longitudeFinal,
    }
  );
  return resposta.data;
}
