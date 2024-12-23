import { useNavigate } from 'react-router';
import './botao-voltar.css';

export function BotaoVoltar({ onClick }) {
  const navigate = useNavigate();

  return (
    <button
      onClick={onClick ? onClick : () => navigate(-1)}
      className="botao-voltar-component"
    >
      <i className="fa-solid fa-arrow-rotate-left"></i>
    </button>
  );
}
