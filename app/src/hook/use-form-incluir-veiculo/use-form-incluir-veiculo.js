import { useState } from 'react';

export function useFormIncluirVeiculo() {
  const [formInputs, setFormInputs] = useState({
    placa: null,
    modelo: null,
    cor: null,
    url: null,
    categoria: null,
  });

  function handleChange(event) {
    const { name, value } = event.target;
    console.log(name, value);
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
