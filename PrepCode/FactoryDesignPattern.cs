using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepCode
{
    class FactoryDesignPattern
    {
    }

    //Create a interface and its sub classes whose object will our Factory return based on Type
    public interface IProduct
    {
        void CreateProduct();
    }
    public class ProductA : IProduct
    {
        public void CreateProduct()
        {
            Console.WriteLine("New Product A is  Created");
        }
    }

    public class ProductB : IProduct
    {
        public void CreateProduct()
        {
            Console.WriteLine("New Product B is  Created");
        }
    }

    //Create an abstract Class which our factory class will inherit from 
    public abstract class Creator
    {
        public abstract IProduct FactoryMethod(string type);
        
    }

    public class Factory : Creator
    {
        public override IProduct FactoryMethod(string type)
        {
            
            if (type.Equals("A"))
            {
                return new ProductA();
            }
            else if (type.Equals("B"))
            {
                return new ProductB();
            }
            else
            {
                throw new ArgumentException("Incorrect Type");
            }
        }
    }
}
