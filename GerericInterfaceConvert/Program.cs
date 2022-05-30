using System;

namespace GerericInterfaceConvert
{
    public interface BaseInterface { }
    public interface ChildInterface : BaseInterface { }

    public interface IAbstractClass<out T> where T : BaseInterface { }
    public abstract class AbstractClass<T> : IAbstractClass<T> where T : BaseInterface { }
    public class ConcreteClass : AbstractClass<ChildInterface> { }


    public interface IGenericRepository<T> : IDisposable
        where T : class

    {
    }

    public class DbContext
    {
    }

    public class DatabaseContext : DbContext
    {
    }

    public class MemoryContext : DbContext
    {
    }

    public class Teacher
    {
    }

    public interface ICRUDRepository<TEntity, TContext> where TEntity : class
        where TContext : DbContext , IGenericRepository<TEntity>
    { }

    public abstract class CRUDRepository< TEntity, TContext> : IGenericRepository<TEntity>
       where TEntity : class
       where TContext : DbContext
    {

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }


    public class TeacherDatabaseRepo<TEntity, TContext> : CRUDRepository<Teacher, DbContext>
    { }

    public class TeacherInMemoryDatabaseRepo<TEntity, TContext> : CRUDRepository<Teacher, DbContext>
    {
    }



    class Program
    {
        static void Main(string[] args)
        {
            IAbstractClass<BaseInterface> c = new ConcreteClass();


            CRUDRepository<Teacher, DbContext> iCRUDDatabase = new TeacherDatabaseRepo<Teacher, DatabaseContext>();
            CRUDRepository<Teacher, DbContext> iCRUDMemory = new TeacherDatabaseRepo<Teacher, MemoryContext>();


            ICRUDRepository<Teacher, DbContext> repo = iCRUDDatabase;
        }
    }
}
