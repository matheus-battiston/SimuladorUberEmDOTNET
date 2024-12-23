import { NavLink } from 'react-router-dom';
import logotipo from '../../../assets/logotipo.png';
import './inicio.css';

export function InicioScreen() {
  return (
    <section className="inicio-screen">
      <div className="opcoes">
        <img src={logotipo} alt="logotipo" />
        <h1 className="titulo-principal">me leva aí</h1>
        <NavLink to="/solicitar-corrida" className="botao-solicitar">
          Solicitar Corrida
        </NavLink>
        <span>Para mais ações</span>
        <p>Quem é você?</p>
        <NavLink to="/motoristas">Motorista</NavLink>
        <NavLink to="/passageiros">Passageiro</NavLink>
      </div>
    </section>
  );
}
