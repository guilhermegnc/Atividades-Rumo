CREATE TABLE Usuario(
    UsuarioId INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    EmailUsuario VARCHAR(255) NOT NULL,
    NomeUsuario VARCHAR(255) NOT NULL,
    SenhaUsuario VARCHAR(255) NOT NULL,
    CargoId INT
);

CREATE TABLE Cargos(
    CargoId INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    Descricao VARCHAR(255) NOT NULL 
);

CREATE TABLE Funcionarios(
    FuncionarioId INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    NomeDoFuncionario VARCHAR(255) NOT NULL,
    Cpf VARCHAR(14) NOT NULL,
    NascimentoFuncionario DATE NOT NULL,
    DataDeAdmissao DATE NOT NULL,
    CelularFuncionario VARCHAR(11) NOT NULL,
    EmailFuncionario VARCHAR(255) NOT NULL,
    CargoId int,
    FOREIGN KEY (CargoId) REFERENCES cargos(CargoId)
);

CREATE TABLE Liderancas(
    LiderancaId INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    FuncionarioId int,
    FOREIGN KEY (FuncionarioId) REFERENCES Funcionarios(FuncionarioId),
    DescricaoEquipe VARCHAR(255) NOT NULL
);

CREATE TABLE Equipes(
    EquipeId INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    LiderancaId int,
    FuncionarioId int,
    FOREIGN KEY (LiderancaId) REFERENCES Liderancas(LiderancaId),
    FOREIGN KEY (FuncionarioId) REFERENCES Funcionarios(FuncionarioId)
);

CREATE TABLE Ponto(
    PontoId BIGINT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    DataHorarioPonto DATETIME NOT NULL,
    Justificativa VARCHAR(255),
    FuncionarioId int, 
    FOREIGN KEY (FuncionarioId) REFERENCES Funcionarios(FuncionarioId)
);