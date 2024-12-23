import { BotaoEnviarForm } from '../botao-enviar-form/botao-enviar-form.component.jsx';
import './seletor-avaliacao.css';

export function SeletorAvaliacaoComponent({ mudarValor, funcaoAvaliar }) {
  return (
    <div className="fundo-modal-avaliacao">
      <div className="apresentar-opcoes">
        <div className="avaliacao">
          <input
            type="radio"
            id="star5"
            name="avaliacao"
            value="5"
            onChange={mudarValor}
            defaultChecked
          />
          <label htmlFor="star5" title="text">
            5 estrela
          </label>
          <input
            type="radio"
            id="star4"
            name="avaliacao"
            value="4"
            onChange={mudarValor}
          />
          <label htmlFor="star4" title="text">
            4 estrela
          </label>
          <input
            type="radio"
            id="star3"
            name="avaliacao"
            value="3"
            onChange={mudarValor}
          />
          <label htmlFor="star3" title="text">
            3 estrela
          </label>
          <input
            type="radio"
            id="star2"
            name="avaliacao"
            value="2"
            onChange={mudarValor}
          />
          <label htmlFor="star2" title="text">
            2 estrela
          </label>
          <input
            type="radio"
            id="star1"
            name="avaliacao"
            value="1"
            onChange={mudarValor}
          />
          <label htmlFor="star1" title="text">
            1 estrela
          </label>
        </div>
        <BotaoEnviarForm texto="Avaliar" click={funcaoAvaliar} />
      </div>
    </div>
  );
}
