using Microsoft.EntityFrameworkCore;
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


    public abstract class DatabaseContext : DbContext
    {
    }

    public abstract class InMemoryContext : DbContext
    {
    }

    public class Teacher
    {
    }

    public interface ICRUDRepository<TEntity, TContext> : IGenericRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    { }

  /*  public abstract class CRUDRepository< TEntity, TContext> : IGenericRepository<TEntity>
       where TEntity : class
       where TContext : DbContext
    {

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }*/


    public abstract class DatabaseRepo<TEntity, TContext> : ICRUDRepository<Teacher, DbContext>
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class InMemoryRepo<TEntity, TContext> : ICRUDRepository<Teacher, DbContext>
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    public class TeacherDatabaseRepo : DatabaseRepo<Teacher, DatabaseContext>
    { }

    public class TeacherInMemoryDatabaseRepo : InMemoryRepo<Teacher,InMemoryContext>
    {
    }



    class Program
    {
        static void Main(string[] args)
        {
            IAbstractClass<BaseInterface> c = new ConcreteClass();

            ICRUDRepository<Teacher, DbContext> teacherDatabaseRepo = new TeacherDatabaseRepo();
            ICRUDRepository <Teacher, DbContext> teacherInMemoryDatabaseRepo = new TeacherInMemoryDatabaseRepo();

            ICRUDRepository<Teacher, DbContext> repo = teacherDatabaseRepo;
            repo = teacherInMemoryDatabaseRepo;
        }
    }
}
