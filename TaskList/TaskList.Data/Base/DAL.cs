using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.Data.Base
{
    public class DAL<T> where T : class
    {
        public DAL(TaskContext context) 
        { 
            taskContext = context;
        }

        public readonly TaskContext taskContext;

        public IEnumerable<T> Listar()
        {
            return taskContext.Set<T>().ToList();
        }
        public void Cadastrar(T objeto)
        {
            taskContext.Set<T>().Add(objeto);
            taskContext.SaveChanges();
        }
        public void Alterar(T objeto)
        {
                taskContext.Set<T>().Update(objeto);
                taskContext.SaveChanges();
        }
        public void Deletar(T objeto)
        {
            taskContext.Set<T>().Remove(objeto);
            taskContext.SaveChanges();
        }
        public T? RecuperarPor(Func<T, bool> func)
        {
            return taskContext.Set<T>().FirstOrDefault(func);
        }

    }
}
