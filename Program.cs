using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaldDuck        
{   
    interface IQuackStrategy
    { 
        void quack();
    }

    class LoudQuack : IQuackStrategy
    {
        public void quack()
        {
            Console.WriteLine("quAAAAAAAAAAck!!!!");
        }
    }
    class NormalQuack : IQuackStrategy
    {
        public void quack()
        {
            Console.WriteLine("quack");
        }
    }

    class SilentQuack : IQuackStrategy
    {
        public void quack()
        {

        }
    }

    interface ISwimStrategy
    {
        void swim();
    }

    class NormalSwim : ISwimStrategy
    {
        public void swim()
        {
            Console.WriteLine("normal swimming splashes");
        }
    }

    class CuteSwim : ISwimStrategy
    {
        public void swim()
        {
            Console.WriteLine("cute swimming splashes");
        }
    }

    class NoSwim : ISwimStrategy
    {
        public void swim()
        {

        }
    }

    interface IFlyStrategy
    {
        void fly();
    }

    class HighFly : IFlyStrategy
    {
        public void fly()
        {
            Console.WriteLine("fly so high in the sky");
        }
    }

    class HedgeHopFly : IFlyStrategy
    {
        public void fly()
        {
            Console.WriteLine("fly touching the water");
        }
    }

    class NoFly : IFlyStrategy
    {
        public void fly()
        {

        }
    }

    interface IDisplayStrategy
    {
        void display();
    }

    class AngryMode : IDisplayStrategy
    {
        public void display()
        {
            Console.WriteLine("Duck goes furious");
        }
    }

    class BraveMode : IDisplayStrategy
    {
        public void display()
        {
            Console.WriteLine("I'm Hero!!");
        }
    }

    class Serenity : IDisplayStrategy
    {
        public void display()
        {
            Console.WriteLine("Smile and Wave");
        }
    }



    class Duck
    {
        private IQuackStrategy quackStrategy;
        private ISwimStrategy swimStrategy;
        private IFlyStrategy flyStrategy;
        private IDisplayStrategy displayStrategy;

        public Duck(IQuackStrategy quackStrategy, ISwimStrategy swimStrategy, IFlyStrategy flyStrategy, IDisplayStrategy displayStrategy) 
        {   
            this.quackStrategy = quackStrategy;
            this.swimStrategy = swimStrategy;
            this.flyStrategy = flyStrategy;
            this.displayStrategy = displayStrategy;
        }

        public void Quack()
        {
            quackStrategy.quack();
        }

        public void Swim()
        {
            swimStrategy.swim();
        }

        public void Fly()
        {
            flyStrategy.fly();
        }

        public void Display()
        {
            displayStrategy.display();
        }
    }

    class Program
    {
        static void TestDuck(Duck duck)
        {
            duck.Quack();
            duck.Swim();
            duck.Fly();
            duck.Display();
        }

        static void Main(string[] args)
        {
            Duck mallardDuck = new Duck(new LoudQuack(), new NoSwim(), new NoFly(), new AngryMode());
            Duck silentDuck = new Duck(new SilentQuack(), new NoSwim(), new NoFly(), new Serenity());
            Duck rubberDuck = new Duck(new NormalQuack(), new NormalSwim(), new HedgeHopFly(), new Serenity());
            Duck decoyDuck = new Duck(new NormalQuack(), new CuteSwim(), new HighFly(), new BraveMode());

            Program.TestDuck(mallardDuck);
            Program.TestDuck(silentDuck);
            Program.TestDuck(rubberDuck);
            Program.TestDuck(decoyDuck);

            Console.ReadLine();
        }
    }
}

