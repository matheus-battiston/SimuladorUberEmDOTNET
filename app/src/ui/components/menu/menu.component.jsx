import { NavLink } from 'react-router-dom';
import logotipo from '../../../assets/logotipo.png';
import './menu.css';

export function Menu() {
  return (
    <nav className="menu-component">
      <div className="logo">
        <img src={logotipo} alt="Logotipo do me leva aí" />
        <span>me leva aí</span>
      </div>
      <div>
        <NavLink to="/">Início</NavLink>
      </div>
    </nav>
  );
}
