import './corrida.css';

export function Corrida({ nome, dataInicio, status, onClick }) {
  return (
    <div onClick={onClick} className="corrida-component">
      <span className="nome">{nome}</span>
      <span className="data">
        Início da Corrida: {dataInicio || 'Aguardando'}
      </span>
      <span className="status">{status}</span>
    </div>
  );
}
