import loading from '../../../assets/loading.gif';
import './loading.css';

export function Loading() {
  return (
    <div className="loading-component">
      <img src={loading} alt="ícone carregando" />
    </div>
  );
}
