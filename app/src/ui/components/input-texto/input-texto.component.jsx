import "./input-texto.css"

export function InputTexto({tipo, textoLabel, name, mudanca}){
    return (
        <>
            <label className="label-form">{textoLabel}</label>
            <input className="estilo-input" type={tipo} name={name} onChange={mudanca}/>
        </>
        
    )
}