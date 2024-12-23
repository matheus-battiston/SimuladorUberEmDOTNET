import { useState } from 'react';

export function useFormPedirCorrida() {
  const [formInputs, setFormInputs] = useState({
    latitudeInicio: null,
    longitudeInicio: null,
    latitudeFinal: null,
    longitudeFinal: null,
  });

  function handleChange(event) {
    const { name, value } = event.target;
    setFormInputs((oldFormInputs) => ({
      ...oldFormInputs,
      [name]: value,
    }));
  }
  return {
    mudanca: handleChange,
    dadosDosInputs: formInputs,
  };
}
