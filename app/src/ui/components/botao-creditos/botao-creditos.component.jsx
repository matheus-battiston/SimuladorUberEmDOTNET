import './botao-creditos.css';

export function BotaoCreditos({ children, onClick }) {
  return (
    <button className="botao-creditos-component" onClick={onClick}>
      <i className="fa-solid fa-sack-dollar"></i>
      {children}
    </button>
  );
}
