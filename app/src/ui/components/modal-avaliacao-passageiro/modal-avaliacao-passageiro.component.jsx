import { useEffect, useState } from 'react';
import { SeletorAvaliacaoComponent } from '../';
import { useAvaliarMotorista } from '../../../hook/use-avaliar-motorista/use-avaliar-motorista';

export function ModalAvaliacaoPassageiro({ idCorrida, fechar }) {
  const [valor, setValor] = useState(5);
  const { avaliar, response } = useAvaliarMotorista();

  function funcaoAvaliar() {
    avaliar(idCorrida, valor);
  }

  function mudarValor(event) {
    const { value } = event.target;
    setValor(value);
  }

  useEffect(() => {
    if (response != null) {
      fechar();
    }
  }, [response]);

  return (
    <SeletorAvaliacaoComponent
      mudarValor={mudarValor}
      funcaoAvaliar={funcaoAvaliar}
    />
  );
}
