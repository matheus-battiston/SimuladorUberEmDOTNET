import createGlobalState from 'react-create-global-state';

const initialState = null;

const [useGlobalMensagem, Provider] = createGlobalState(initialState);

export const GlobalMensagemProvider = Provider;

export default useGlobalMensagem;
