SELECT * FROM Entidades;

SELECT * FROM EntidadesNomeadas;

SELECT e.cod_entidade, e.entidade, en.nome 
    FROM    EntidadesNomeadas en
    INNER JOIN Entidades e ON e.cod_entidade = en.cod_entidade;

INSERT INTO Entidades (entidade) VALUES ("DOENÇA");
INSERT INTO Entidades (entidade) VALUES ("SINTOMA");
INSERT INTO Entidades (entidade) VALUES ("MEDICAMENTO");
INSERT INTO Entidades (entidade) VALUES ("PESSOA");
INSERT INTO Entidades (entidade) VALUES ("PRINCÍPIO ATIVO");
INSERT INTO Entidades (entidade) VALUES ("OUTROS");

INSERT INTO EntidadesNomeadas (nome, cod_entidade) VALUES ("MEDICO", 1);
INSERT INTO EntidadesNomeadas (nome, cod_entidade) VALUES ("PACIENTE", 1);
INSERT INTO EntidadesNomeadas (nome, cod_entidade) VALUES ("PROFISSIONAL", 1);
INSERT INTO EntidadesNomeadas (nome, cod_entidade) VALUES ("DIPIRONA", 2);