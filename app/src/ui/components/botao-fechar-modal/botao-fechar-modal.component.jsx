import botaoFechar from '../../../assets/botao-fechar.png';
import './botao-fechar-modal.css';

export function BotaoFecharModal({ funcaoFechar }) {
  return (
    <label className="label-botao-fechar">
      <img
        src={botaoFechar}
        alt="Botão fechar"
        className="imagem-botao-fechar"
      />
      <button className="botao-fechar" onClick={funcaoFechar} />
    </label>
  );
}
