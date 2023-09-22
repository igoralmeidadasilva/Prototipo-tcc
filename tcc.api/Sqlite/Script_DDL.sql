DROP TABLE IF EXISTS EntidadesNomeadas;
DROP TABLE IF EXISTS Entidades;

CREATE TABLE Entidades (
    cod_entidade INTEGER PRIMARY KEY AUTOINCREMENT,
    entidade VARCHAR NOT NULL,
    UNIQUE(entidade)
);

CREATE TABLE EntidadesNomeadas (
    nome VARCHAR PRIMARY KEY NOT NULL,
    cod_entidade INTEGER NOT NULL,
    FOREIGN KEY(cod_entidade) REFERENCES entidades(cod_entidade)
);

INSERT INTO Entidades (entidade) VALUES ("DOENÇA");
INSERT INTO Entidades (entidade) VALUES ("SINTOMA");
INSERT INTO Entidades (entidade) VALUES ("MEDICAMENTO");
INSERT INTO Entidades (entidade) VALUES ("PESSOA");
INSERT INTO Entidades (entidade) VALUES ("PRINCÍPIO ATIVO");
INSERT INTO Entidades (entidade) VALUES ("OUTROS");