import { useState } from 'react';

export function useFormIncluirPassageiro() {
  const [formInputs, setFormInputs] = useState({
    nome: null,
    cpf: null,
    dataNascimento: null,
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
