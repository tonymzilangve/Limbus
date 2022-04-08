using System;
using System.Collections.Generic;

namespace _3___Decorator__coffee_
{
    abstract class IBeverage   
    {
        public abstract string getDescription();
        public abstract double getCost();
    }

    class HouseBlend : IBeverage
    {
        const double price = 5.50;

        public override string getDescription()
        {
            return "HouseBlend";
        }

        public override double getCost()    
        {
            return price;
        }
    }

    class DarkRoast : IBeverage
    {
        const double price = 4.50;

        public override string getDescription()
        {
            return "DarkRoast";
        }

        public override double getCost()
        {
            return price;
        }
    }

    class Decaf : IBeverage
    {
        const double price = 3.00;

        public override string getDescription()
        {
            return "Decaf";
        }

        public override double getCost()
        {
            return price;
        }
    }

    class Espresso : IBeverage
    {
        const double price = 3.50;

        public override string getDescription()
        {
            return "Espresso";
        }

        public override double getCost()
        {
            return price;
        }
    }

    abstract class IDeco : IBeverage
    {
        protected IBeverage order;
        public void Add(IBeverage order)
        {
            this.order = order;
        }

        public override string getDescription()
        {
            if (order != null)
                return order.getDescription();
            return "error";
        }
        public override double getCost()
        {
            return order.getCost();
        }
    }



    class Milk : IDeco
    {
        const double price = 2.50;

        public Milk(IBeverage order)  
        {
            this.order = order;
        }

        public override string getDescription()
        {
            return base.getDescription() + " with Milk";
        }

        public override double getCost()
        {
            return base.getCost() + price;
        }
    }

    class Mocha : IDeco
    {
        const double price = 2.50;

        public Mocha(IBeverage order)
        {
            this.order = order;
        }

        public override string getDescription()
        {
            return base.getDescription() + " with Mocha";
        }

        public override double getCost()
        {
            return base.getCost() + price;
        }
    }

    class Soy : IDeco
    {
        const double price = 1.50;

        public Soy(IBeverage order)
        {
            this.order = order;
        }

        public override string getDescription()
        {
            return base.getDescription() + " with Soy";
        }

        public override double getCost()
        {
            return base.getCost() + price;
        }
    }

    class Whip : IDeco
    {
        const double price = 0.50;
        public Whip(IBeverage order)
        {
            this.order = order;
        }

        public override string getDescription()
        {
            return base.getDescription() + " with Whip";
        }
        public override double getCost()
        {
            return base.getCost() + price;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте,\nВыберите напиток:\n1) HouseBlend ($5.50)\t 2) DarkRoast ($4.50)\t 3) Decaf ($3.00)\t 4) Espresso ($3.00)\n");
            var a = int.Parse(Console.ReadLine());

            IBeverage order = new HouseBlend();

            switch (a)
            {
                case 1:
                    order = new HouseBlend();
                    break;
                case 2:
                    order = new DarkRoast();
                    break;
                case 3:
                    order = new Decaf();
                    break;
                case 4:
                    order = new Espresso();
                    break;
            }

            Console.WriteLine("Желаете добавить эти ингредиенты в кофе?\n 1) Milk ($2.50)\t2) Mocha ($2.50)\t3) Soy ($1.50)\t4) Whip ($0.50)\n");
            
            int[] numbers = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            foreach (var n in numbers)
            {
                switch (n)
                {
                    case 1:
                        order = new Milk(order);
                        break;
                    case 2:
                        order = new Mocha(order);
                        break;
                    case 3:
                        order = new Soy(order);
                        break;
                    case 4:
                        order = new Whip(order);
                        break;
                }
            }

            Console.WriteLine("You've ordered " + order.getDescription());
            Console.WriteLine("Overall price is $" + order.getCost());

            Console.ReadLine();
        }
    }
}
