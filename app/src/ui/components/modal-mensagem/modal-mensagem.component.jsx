import useGlobalMensagem from '../../../context/mensagem/mensagem.context';
import './modal-mensagem.css';

export function Mensagem() {
  const [mensagem, setMensagem] = useGlobalMensagem();

  return (
    mensagem && (
      <div className="mensagem-component">
        <div className="container-mensagem">
          <span>{mensagem}</span>
          <button onClick={() => setMensagem(null)}>Ok</button>
        </div>
      </div>
    )
  );
}
