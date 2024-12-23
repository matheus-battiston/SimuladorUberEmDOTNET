import { useEffect, useState } from 'react';
import { SeletorAvaliacaoComponent } from '../';
import { useAvaliarPassageiro } from '../../../hook/use-avaliar-passageiro/use-avaliar-passageiro';

export function ModalAvaliacao({ idCorrida, fechar }) {
  const [valor, setValor] = useState(5);
  const { avaliar, response } = useAvaliarPassageiro();

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
