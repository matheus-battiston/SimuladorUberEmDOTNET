import imagemCarro from '../../../assets/carro.svg';
import './caminho-corrida.css';

export function CaminhoCorrida({ status }) {
  return (
    <div className="caminho-component" data-selecionado={status}>
      <div className="etapa etapa-solicitado">
        <span>Solicitada</span>
        <img src={imagemCarro} className="carro" alt="carro" />
        <div className="linha">
          <div className="linha-metade invisivel"></div>
          <div className="linha-metade direita"></div>
          <div className="circulo"></div>
        </div>
      </div>
      <div className="etapa etapa-iniciado">
        <span>Iniciada</span>
        <img src={imagemCarro} className="carro" alt="carro" />
        <div className="linha">
          <div className="linha-metade esquerda"></div>
          <div className="linha-metade direita"></div>
          <div className="circulo"></div>
        </div>
      </div>
      <div className="etapa etapa-finalizado">
        <span>Finalizada</span>
        <img src={imagemCarro} className="carro" alt="carro" />
        <div className="linha">
          <div className="linha-metade esquerda"></div>
          <div className="linha-metade invisivel"></div>
          <div className="circulo"></div>
        </div>
      </div>
    </div>
  );
}
