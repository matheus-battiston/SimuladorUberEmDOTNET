import {
  formatarDataEHora,
  formatarNota,
  formatarValorMonetario,
} from '../../../core/formatadores';
import { Mapa, Titulo } from '../index';
import './detalhe-corrida.css';

export function DetalheCorrida({
  inicioX,
  inicioY,
  finalX,
  finalY,
  nome,
  nota,
  tipo,
  status,
  horarioInicio,
  valorEstimado,
  horarioChegada,
  valorTotal,
}) {
  return (
    <div className="detalhe-corrida-component">
      <Titulo>Detalhes da corrida</Titulo>
      <div className="mapas">
        <Mapa
          titulo="Percurso"
          latitudeInicio={inicioX}
          longitudeInicio={inicioY}
          latitudeFim={finalX}
          longitudeFim={finalY}
        />
      </div>
      <div className="dados">
        <p className="nome">{nome}</p>
        <p className="tipo">{tipo}</p>
        {        console.log(valorEstimado)
}
        {status !== 'SOLICITADA' && (
          <span>Data início: {formatarDataEHora(horarioInicio)}</span>
        )}
        {status === 'INICIADA' && (
          <span>Valor estimado: {formatarValorMonetario(valorEstimado)}</span>
        )}
        {status === 'FINALIZADA' && (
          <span>Data fim: {formatarDataEHora(horarioChegada)}</span>
        )}
        {status === 'FINALIZADA' && (
          <span>Valor total: {formatarValorMonetario(valorTotal)}</span>
        )}
        {status === 'FINALIZADA' && <span>Nota: {formatarNota(nota)}</span>}
      </div>
    </div>
  );
}
