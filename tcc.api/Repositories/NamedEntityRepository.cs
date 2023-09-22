using System;
using Microsoft.EntityFrameworkCore;
using tcc.api.Data;
using tcc.api.Models;
using tcc.api.Repositories.Interfaces;

namespace tcc.api.Repositories
{
    public class NamedEntityRepository : IDbRepository<NamedEntityModel>
    {
        private readonly DataContext _dbContext;

        public NamedEntityRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<NamedEntityModel>> GetItems()
        {
            var result = await _dbContext.NamedEntities.AsNoTracking().ToListAsync();   
            return result;
        }

        public NamedEntityModel Insert(NamedEntityModel item)
        {
            _dbContext.NamedEntities.Add(item);
            _dbContext.SaveChanges();
            return item;
        }

        public string ResetDB()
        {
            FormattableString sql = $"""
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

            """;
            _dbContext.Database.ExecuteSql(sql);
            
            return "Banco resetado!";
        }
    }
}
