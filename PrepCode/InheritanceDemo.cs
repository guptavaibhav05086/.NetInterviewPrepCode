using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepCode
{
    class InheritanceDemo
    {
    }
    public class Parent
    {
        //In every child
        public Parent()
        {
            Console.WriteLine("First call is always for Parent Constructor");
        }
        public Parent(int VisibleEveryWhere)
        {
            Console.WriteLine("First call is for VisibleEveryWhere Parent Constructor");
        }
        
        //Private members are visible only in derived classes that are nested in their base class. 
        //Otherwise, they are not visible in derived classes
        private int notShownInChildClass=10;

        //Protected members are visible only in derived classes.
        protected int visibleOnlyInChildClass;

        //Internal members are visible only in derived classes that are located in the same assembly as the base class.
        //They are not visible in derived classes located in a different assembly from the base class.
        internal int visibleOnlyInChildClassinSameAssembly=15;

        //Public members are visible in derived classes and are part of the derived class' public interface.
        //Public inherited members can be called just as if they were defined in the derived class
        public int VisibleEveryWhere;

        //Error in below line 'Parent.Show()' must declare a body because it is not marked abstract, extern, or partial 
        //public void Show();

        //Run time polymorshim example. 
        //It works like method with same name and same signature but with different implemention in Parent and child class.
        //This is achived by using Virtual and overide keywords in C# 
       public virtual void ShowBio()
        {
            Console.WriteLine("Inside parent Class Bio method" + notShownInChildClass + visibleOnlyInChildClassinSameAssembly);
        }

        public void NoOverideMethod()
        {
            Console.WriteLine("Inside parent Class NoOverideMethod" + notShownInChildClass + visibleOnlyInChildClassinSameAssembly);
        }
        
    }

    public class Child : Parent
    {
        public static int demoVal = 10;
        public int referncetypeDemo;
        public Child()
        {
            Console.WriteLine("Second call is for child Constructor");
        }

        //Every Constructor of child class only calls the default constructor of the parent class.
        //To call the specific constructor we need to call the base constructor specifically
        public Child(int VisibleEveryWhere) : base(VisibleEveryWhere)
        {
            this.VisibleEveryWhere = VisibleEveryWhere;
        }

        public override void ShowBio()
        {
            Console.WriteLine("Inside child Class Bio method");
        }
        public new void NoOverideMethod()
        {
            Console.WriteLine("Inside child Class NoOverideMethod"  + visibleOnlyInChildClassinSameAssembly);
        }
    }

    public class SubChild : Child
    {
        public SubChild()
        {

        }

        
    }

    public static class Stat
    {
        public static int a;

    }

     public class DelegateDemo
    {
        //A delegate is a type that holds a reference to a method. A delegate is declared with a signature that shows the return type
        //and parameters for the methods it references, and can hold references only to methods that match its signature. 
        public delegate void Logger(string log);

        public void ProcessLog(Logger logHandler)
        {
            logHandler("Error Generated");
        }
    }
}
