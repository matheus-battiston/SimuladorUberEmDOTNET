import './wrapper-form.css';

export function WrapperForm({ children, enviar }) {
  return (
    <form className="estilo-form-cadastro" onSubmit={enviar}>
      {children}
    </form>
  );
}
