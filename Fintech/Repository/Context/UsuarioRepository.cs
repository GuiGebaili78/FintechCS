using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Fintech.Models;
using Microsoft.EntityFrameworkCore;

namespace Fintech.Repository.Context
{
    public class UsuarioRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public UsuarioRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        public IList<UsuarioModel> Listar()
        {
            return dataBaseContext.tb_usuario.ToList();
        }

        [return: NotNull]
        public UsuarioModel Consultar(int id)
        {
            return dataBaseContext.tb_usuario.Find(id) ?? throw new Exception("Usuário não encontrado");
        }


        public void Inserir(UsuarioModel usuario)
        {
            dataBaseContext.tb_usuario.Add(usuario);
            dataBaseContext.SaveChanges();
        }

        public void Alterar(UsuarioModel usuario)
        {
            dataBaseContext.Entry(usuario).State = EntityState.Modified;
            dataBaseContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            var usuario = dataBaseContext.tb_usuario.Find(id);
            if (usuario != null)
            {
                dataBaseContext.tb_usuario.Remove(usuario);
                dataBaseContext.SaveChanges();
            }
        }
    }
}
