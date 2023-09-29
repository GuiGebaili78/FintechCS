﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fintech.Models
{
    [Table("TB_USUARIO")]
    public class UsuarioModel
    {
        [Key]
        [Column("CD_USUARIO")]
        public int Cd_usuario { get; set; }

        [Column("DS_LOGIN")]
        [Required(ErrorMessage = "Login é obrigatório!")]
        [StringLength(50, ErrorMessage = "O login deve ter no máximo 50 caracteres")]
        public string Ds_login { get; set; }

        [Column("DS_SENHA")]
        [Required(ErrorMessage = "Senha é obrigatória!")]
        [StringLength(50, ErrorMessage = "A senha deve ter no máximo 50 caracteres")]
        public string Ds_senha { get; set; }

        [Column("NM_USUARIO")]
        [Required(ErrorMessage = "O nome de usuário é obrigatório!")]
        [StringLength(50, ErrorMessage = "O nome de usuário deve ter no máximo 50 caracteres")]
        public string Nm_usuario { get; set; }

        [Column("DS_EMAIL")]
        [Required(ErrorMessage = "O email é obrigatório!")]
        [StringLength(50, ErrorMessage = "O email deve ter no máximo 50 caracteres")]
        public string Ds_email { get; set; }

        [Column("NR_CELULAR")]
        [Required(ErrorMessage = "Um número de celular é obrigatório!")]
        [StringLength(50, ErrorMessage = "O número de celular deve ter no máximo 50 caracteres")]
        public string Nr_celular { get; set; }

        [Column("DATA")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Data { get; set; }

        public UsuarioModel()
        {
        }

        public UsuarioModel(int cd_usuario, string ds_login, string ds_senha, string nm_usuario, string ds_email, string nr_celular, DateTime data)
        {
            Cd_usuario = cd_usuario;
            Ds_login = ds_login;
            Ds_senha = ds_senha;
            Nm_usuario = nm_usuario;
            Ds_email = ds_email;
            Nr_celular = nr_celular;
            Data = data;
        }
    }
}
