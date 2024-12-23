import { createBrowserRouter } from 'react-router-dom';
import {
  DetalharCorridaMotoristaScreen,
  DetalharCorridaPassageiroScreen,
  DetalharMotoristaScreen,
  DetalharPassageiroScreen,
  InicioScreen,
  ListaMotoristasScreen,
  ListaPassageirosScreen,
  SolicitarCorridaScreen,
  TelaCadastroMotorista,
  TelaCadastroPassageiro,
  TelaCadastroVeiculo,
} from '../ui/screens/index';

export const router = createBrowserRouter([
  {
    path: '/',
    element: <InicioScreen />,
  },
  {
    path: '/solicitar-corrida',
    element: <SolicitarCorridaScreen />,
  },
  {
    path: '/motoristas',
    element: <ListaMotoristasScreen />,
  },
  {
    path: '/incluirMotorista',
    element: <TelaCadastroMotorista />,
  },
  {
    path: '/incluirPassageiro',
    element: <TelaCadastroPassageiro />,
  },
  {
    path: '/incluirVeiculo/:idMotorista',
    element: <TelaCadastroVeiculo />,
  },
  {
    path: '/motoristas/:id',
    element: <DetalharMotoristaScreen />,
  },
  {
    path: '/motoristas/corridas/:id',
    element: <DetalharCorridaMotoristaScreen />,
  },
  {
    path: '/passageiros',
    element: <ListaPassageirosScreen />,
  },
  {
    path: '/passageiros/:id',
    element: <DetalharPassageiroScreen />,
  },
  {
    path: '/passageiros/corridas/:id',
    element: <DetalharCorridaPassageiroScreen />,
  },
]);
