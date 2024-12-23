import './botao-enviar-form.css';

export function BotaoEnviarForm({ texto, click }) {
  return (
    <button className="estilo-botao-form" onClick={click}>
      {texto}
    </button>
  );
}
