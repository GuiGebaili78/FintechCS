using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fintech.Models


{
        [Table("TB_CATEGORIA")]
    public class CategoriaModel
    {
        [HiddenInput]
        [Key]
        [Column("CD_CATEG")]
        public int Cd_categ { get; set; }

        [Column("TP_CATEG")]
        [Required(ErrorMessage = "Tipo de categoria é obrigatório!")]
        [StringLength(50, ErrorMessage = "A categoria deve ter no máximo 50 caracteres")]
        public string Tp_categ { get; set; }

        [Column("DS_CATEG")]
        [Required(ErrorMessage = "Descrição de categoria é obrigatório!")]
        [StringLength(50, ErrorMessage = "A descrição da categoria deve ter no máximo 50 caracteres")]
        public string Ds_categ { get; set; }

        [Column("DS_SUBCATEG")]
        [Required(ErrorMessage = "A descrição de sub categoria é obrigatório")]
        [StringLength(50, ErrorMessage = "A descrição de sub categoria deve ter no máximo 50 caracteres")]
        public string Ds_subCateg { get; set; }

        [Column("DATA")]
        [Required(ErrorMessage = "Data é obrigatório!")]
        public DateTime Data { get; set; } = DateTime.Now;

        public CategoriaModel()
        {
        }

        public CategoriaModel(int cd_categ, string tp_categ, string ds_categ, string ds_subCateg, DateTime data)
        {
            Cd_categ = cd_categ;
            Tp_categ = tp_categ;
            Ds_categ = ds_categ;
            Ds_subCateg = ds_subCateg;
            Data = data;
        }
    }





}
