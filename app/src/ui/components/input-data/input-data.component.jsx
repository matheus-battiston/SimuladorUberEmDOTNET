import './input-data.css';

export function InputData({ name, textoLabel, mudanca }) {
  return (
    <div className="data-input">
      <label className="estilo-label-data">{textoLabel}</label>
      <input
        className="estilo-input-data"
        type="date"
        name={name}
        onChange={mudanca}
      />
    </div>
  );
}
