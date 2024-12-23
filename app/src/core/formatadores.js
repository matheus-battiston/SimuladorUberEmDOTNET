export function formatarDataEHora(data) {
  if (!data) {
    return data;
  }
  const arrayDeData = data.replace('T', '-').replace('.', '-').split('-');
  return `${arrayDeData[2]}/${arrayDeData[1]}/${arrayDeData[0]} ${
    arrayDeData[3] ? arrayDeData[3] : ''
  }`;
}

export function formatarValorMonetario(valor) {
  if (valor === null) {
    return valor;
  }
  return valor.toLocaleString('pt-BR', {
    style: 'currency',
    currency: 'BRL',
  });
}

export function formatarNota(nota) {
  if (!nota) {
    return nota;
  }
  return Number(nota).toFixed(2);
}

export function formatarValorMonetarioParaSalvar(valor) {
  if (!valor) {
    return valor;
  }
  return valor.replace(',', '.');
}
