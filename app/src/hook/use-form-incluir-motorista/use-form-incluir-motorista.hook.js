import { useState } from 'react';

export function useFormIncluirMotorista() {
  const [formInputs, setFormInputs] = useState({
    nome: null,
    cpf: null,
    nroCNH: null,
    dataNascimento: null,
    validadeCNH: null,
    categoria: null,
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
