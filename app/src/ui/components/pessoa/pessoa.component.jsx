import { formatarNota } from '../../../core/formatadores';
import './pessoa.css';

export function Pessoa({ nome, nota, status, onClick }) {
  return (
    <div onClick={onClick} className="pessoa-component">
      <span className="nome">
        {nome}{' '}
        <span className="nota">
          <i className="fa fa-star"></i>
          {formatarNota(nota)}
        </span>
      </span>
      <span className="status">{status}</span>
    </div>
  );
}
