import useGlobalErro from '../../../context/erro/erro.context';
import './erro.css';

export function Erro() {
  const [erro, setErro] = useGlobalErro();

  return (
    erro && (
      <div className="erro-component">
        <div className="container-erro">
          <span>{erro}</span>
          <button onClick={() => setErro(false)}>Ok</button>
        </div>
      </div>
    )
  );
}
