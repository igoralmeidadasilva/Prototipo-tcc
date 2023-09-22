using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tcc.api.Models
{
    [Table("EntidadesNomeadas")]
    public class NamedEntityModel
    {
        [Column("nome")]
        [Key]
        public string? Nome { get; set; }
        [Column("cod_entidade")]
        public int CodEntidade { get; set; }

        // [ForeignKey("CodEntidade")]
        // public EntityModel? Entidade { get; set; }

        public NamedEntityModel()
        {
        }
        public NamedEntityModel(string? nome)
        {
            Nome = nome;
        }
        public NamedEntityModel(string? nome, int codEntidade) : this(nome)
        {
            CodEntidade = codEntidade;
        }
        // public NamedEntityModel(string? nome, EntityModel? entidade) : this(nome)
        // {
        //     Entidade = entidade;
        // }
        // public override string ToString()
        // {
        //     return $"Entidade: {Nome}, Classificação: {Entidade}";
        // }
    }
}
