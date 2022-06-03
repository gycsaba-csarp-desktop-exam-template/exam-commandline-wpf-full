using Microsoft.EntityFrameworkCore;
using System;

namespace GerericInterfaceConvert
{
    /*  public interface BaseInterface { }
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

    public abstract class CRUDRepository< TEntity, TContext> : IGenericRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
     {

         public void Dispose()
         {
             throw new NotImplementedException();
         }
     }


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
    */

    // https://docs.microsoft.com/en-us/aspnet/web-api/overview/testing-and-debugging/mocking-entity-framework-when-unit-testing-aspnet-web-api-2#add-dependency-injection

    public interface IDbContext : IDisposable
    {
        public DbSet<Jarmu> Jarmuvek { get; set; }
    }


    public class Jarmu { }

    

    public class JKContext : DbContext, IDbContext
    {
        public JKContext()
        {
        }

        public JKContext(DbContextOptions<JKContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Jarmu> Jarmuvek { get; set; }
    }

    public class JKInMemoryContext : DbContext, IDbContext
    {
        public JKInMemoryContext()
        {
        }

        public JKInMemoryContext( DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Jarmu> Jarmuvek { get; set; }
    }

    public interface IGenericRepository<T> where T : class
    { 
    }

    public interface ICRUDGenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    { }



    public abstract class GenericRepository<TEntity, TContext> : ICRUDGenericRepository<TEntity,TContext>
        where TEntity : class
        where TContext : DbContext
    {
        protected TContext context;
        public GenericRepository(TContext context)
        {
            context = context;
        }
    }

    public class JarmuRepository : GenericRepository<Jarmu, JKContext>
    {
        public JarmuRepository(JKContext context) : base(context)
        {
        }
    }

    public class JarmuInMemoryRepository : GenericRepository<Jarmu, JKInMemoryContext>
    {
        public JarmuInMemoryRepository(JKInMemoryContext context) : base(context)
        {
        }
    }


    class Program
    {
        static void Main(string[] args)
        {


            JKContext jKContext = new JKContext();
            JKInMemoryContext jKInMemoryContext = new JKInMemoryContext();

            ICRUDGenericRepository<Jarmu, DbContext> repo;

            ICRUDGenericRepository<Jarmu, JKContext> jarmuRepo = new JarmuRepository(jKContext);
            ICRUDGenericRepository<Jarmu, JKInMemoryContext> jarmuInMemoryRepository = new JarmuInMemoryRepository(jKInMemoryContext);

            repo = jarmuRepo;
            repo = jarmuInMemoryRepository;


            /* IAbstractClass<BaseInterface> c = new ConcreteClass();

             ICRUDRepository <Teacher, DbContext> teacherDatabaseRepo = new TeacherDatabaseRepo();
             ICRUDRepository <Teacher, DbContext> teacherInMemoryDatabaseRepo = new TeacherInMemoryDatabaseRepo();

             ICRUDRepository<Teacher, DbContext> repo = teacherDatabaseRepo;
             repo = teacherInMemoryDatabaseRepo;*/
        }
    }
}
