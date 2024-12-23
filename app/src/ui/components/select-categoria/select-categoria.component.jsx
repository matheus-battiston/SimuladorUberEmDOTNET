import './select-categoria.css';

const categorias = ['A', 'B', 'C'];

export function SelectCategoria({ mudanca }) {
  return (
    <select
      className="estilo-select"
      onChange={mudanca}
      name="categoria"
      defaultValue=""
    >
      <option value="" disabled>
        Selecione a categoria da CNH
      </option>
      {categorias.map((categoria) => {
        return (
          <option key={categoria} value={categorias.indexOf(categoria) + 1}>
            {' '}
            {categoria}
          </option>
        );
      })}
    </select>
  );
}
