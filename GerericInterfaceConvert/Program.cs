using System;

namespace GerericInterfaceConvert
{
    public interface BaseInterface { }
    public interface ChildInterface : BaseInterface { }

    
    public abstract class AbstractClass<T> : IAbstractClass<T> where T : BaseInterface { }

    
    
    public class ConcreteClass : AbstractClass<ChildInterface> { }


    
    public interface IAbstractClass<out T> where T : BaseInterface { }
   





    class Program
    {
        static void Main(string[] args)
        {
            IAbstractClass<BaseInterface> c = new ConcreteClass();
        }
    }
}
