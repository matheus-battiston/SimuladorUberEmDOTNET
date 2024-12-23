import { RouterProvider } from 'react-router-dom';
import { GlobalErroProvider } from './context/erro/erro.context';
import { GlobalMensagemProvider } from './context/mensagem/mensagem.context';
import { router } from './router/index';
import { Erro } from './ui/components';
import { Mensagem } from './ui/components/modal-mensagem/modal-mensagem.component';

function App() {
  return (
    <GlobalErroProvider>
      <GlobalMensagemProvider>
        <Erro />
        <Mensagem />
        <RouterProvider router={router} />
      </GlobalMensagemProvider>
    </GlobalErroProvider>
  );
}

export default App;
