using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tcc.api.Models
{
    [Table("entidades")]
    public class EntityModel
    {
        [Column("cod_entidade")]
        [Key]
        public int CodEntidade { get; set; }
        [Column("entidade")]
        public string? Entidade { get; set; }

        public EntityModel()
        { 
        }

        public EntityModel(string? entidade)
        {
            Entidade = entidade;
        }

        public EntityModel(string? entidade, int codEntidade = 0) : this(entidade)
        {
            CodEntidade = codEntidade;
        }

        public override string ToString()
        {
            return $"Código: {CodEntidade}, Entidade: {Entidade}";
        }
    }
}
