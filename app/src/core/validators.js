export function validarDadosCadastroMotorista(input, setErro) {
  if (input.nome === '' || input.nome === null) {
    setErro(true);
    return false;
  }
  if (input.cpf === '' || input.cpf === null) {
    setErro(true);
    return false;
  }
  if (input.cnh === '' || input.cnh === null) {
    setErro(true);
    return false;
  }
  if (input.nascimento === '' || input.nascimento === null) {
    setErro(true);
    return false;
  }
  if (input.validadeCNH === '' || input.validadeCNH === null) {
    setErro(true);
    return false;
  }
  if (input.categoria === '' || input.categoria === null) {
    setErro(true);
    return false;
  }

  return true;
}

export function validarDadosCadastroPassageiro(input, setErro) {
  if (input.nome === '' || input.nome === null) {
    setErro(true);
    return false;
  }
  if (input.cpf === '' || input.cpf === null) {
    setErro(true);
    return false;
  }
  if (input.nascimento === '' || input.nascimento === null) {
    setErro(true);
    return false;
  }

  return true;
}

export function validarDadosCadastroVeiculo(input, setErro) {
  if (input.placa === '' || input.placa === null) {
    setErro(true);
    return false;
  }

  if (input.cor === '' || input.cor === null) {
    setErro(true);
    return false;
  }

  if (input.modelo === '' || input.modelo === null) {
    setErro(true);
    return false;
  }

  if (input.categoria === '' || input.categoria === null) {
    setErro(true);
    return false;
  }

  if (input.url === '' || input.url === null) {
    setErro(true);
    return false;
  }

  return true;
}

export function validarDadosPedirCorrida(input, setErro) {
  if (input.latitudeInicio === '' || input.latitudeInicio === null) {
    setErro(true);
    return false;
  }

  if (input.longitudeInicio === '' || input.longitudeInicio === null) {
    setErro(true);
    return false;
  }

  if (input.latitudeFinal === '' || input.latitudeFinal === null) {
    setErro(true);
    return false;
  }

  if (input.longitudeFinal === '' || input.longitudeFinal === null) {
    setErro(true);
    return false;
  }

  return true;
}

export function validarCreditos(input, setErro) {
  if (input === '' || input === null) {
    setErro(true);
    return false;
  }
  return true;
}
