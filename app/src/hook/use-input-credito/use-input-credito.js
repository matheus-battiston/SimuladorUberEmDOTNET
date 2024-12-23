import { useState } from 'react';

export function useFormCredito() {
  const [formInputs, setFormInputs] = useState('');

  function handleChange(event) {
    const { value } = event.target;
    setFormInputs(value);
  }
  return {
    mudanca: handleChange,
    dadosDosInputs: formInputs,
  };
}
