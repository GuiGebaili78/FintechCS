using Fintech.Models;
using Microsoft.EntityFrameworkCore;

namespace Fintech.Repository.Context
{
    public class CategoriaRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public CategoriaRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        public IList<CategoriaModel> Listar()
        {
            var lista = new List<CategoriaModel>();

            try
            {

                lista = dataBaseContext.tb_categoria.ToList();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Ocorreu um erro ao listar as categorias: {ex.Message}");

            }

            return lista;
        }



        public CategoriaModel Consultar(int id)
        {
            return dataBaseContext.tb_categoria.Find(id) ?? throw new Exception("Categoria não encontrada");
        }


        public void Inserir(CategoriaModel categoria)
        {
            try
            {
                dataBaseContext.tb_categoria.Add(categoria);
                dataBaseContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro ao inserir a categoria: " + ex.Message);
                
                throw;
            }
        }


        public void Alterar(CategoriaModel categoria)
        {
            dataBaseContext.Entry(categoria).State = EntityState.Modified;
            dataBaseContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            var categoria = dataBaseContext.tb_categoria.Find(id);
            if (categoria != null)
            {
                dataBaseContext.tb_categoria.Remove(categoria);
                dataBaseContext.SaveChanges();
            }
        }
    }
}
