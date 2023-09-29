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
            var lista = new List<UsuarioModel>();

            try
            {
               
                lista = dataBaseContext.tb_usuario.ToList();
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"Ocorreu um erro ao listar os usuários: {ex.Message}");
              
            }

            return lista;
        }



        public UsuarioModel Consultar(int id)
        {
            return dataBaseContext.tb_usuario.Find(id) ?? throw new Exception("Usuário não encontrado");
        }


        public void Inserir(UsuarioModel usuario)
        {
            try
            {
                dataBaseContext.tb_usuario.Add(usuario);
                dataBaseContext.SaveChanges();
            }
            catch (Exception ex)
            {
                // Trate a exceção aqui, você pode fazer log do erro ou tomar outras medidas necessárias.
                Console.WriteLine("Ocorreu um erro ao inserir o usuário: " + ex.Message);
                // Ou lançar a exceção novamente se for apropriado.
                throw;
            }
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
