using System;

Primjeni Dekorater na ovaj set klasa:
namespace DekoraterExtraZadatak
{
    public interface IMeal
    {
        void AddIngredient();
    }
    public class Noodles:IMeal
    {
        public void AddIngredient()
        {
            Console.WriteLine("Add Noodles");
        }
    }

    public class Beef: IMeal
    {
        public void AddIngredient()
        {
            Console.WriteLine("Add Beef");
        }
    }

    public class Mushrooms: IMeal
    {
        public void AddIngredient()
        {
            Console.WriteLine("Add Mushrooms");
        }
    }

    public class Water: IMeal
    {
        public void AddIngredient()
        {
            Console.WriteLine("Add Water");
        }
    }
    public class Decorator : IMeal
    {
        private readonly IMeal imeal;

        public SpiceDecorator(IMeal mealComponent)
        {
            imeal = mealComponent;
        }

        public void AddIngredient()
        {
            imeal.AddIngredient();
            Console.WriteLine("Add Spice");
        }
    }
    public class NoodlesDecorator : Decorator
    {
        public NoodlesDecorator(IMeal mealComponent) : base(mealComponent) { }
    }

    public class BeefDecorator : Decorator
    {
        public BeefDecorator(IMeal mealComponent) : base(mealComponent) { }
    }

    public class MushroomsDecorator : Decorator
    {
        public MushroomsDecorator(IMeal mealComponent) : base(mealComponent) { }
    }

    public class WaterDecorator : SpiceDecorator
    {
        public WaterDecorator(IMeal mealComponent) : base(mealComponent) { }
    }

    public class Meal
    {
        Beef beef;
        Mushrooms mushrooms;
        Noodles noodles;
        Water water;
        public Meal()
        {
            beef = new Beef();
            mushrooms = new Mushrooms();
            noodles = new Noodles();
            water = new Water();
        }
        public void MakeMushroomNoodleSoup()
        {
            water.AddWater();
            mushrooms.AddMushrooms();
            noodles.AddNoddles();
        }

        public void MakeBeefNoodleSoup()
        {
            water.AddWater();
            beef.AddBeef();
            noodles.AddNoddles();
        }

        public void MakeMushroomBeefSoup()
        {
            water.AddWater();
            beef.AddBeef();
            mushrooms.AddMushrooms();
        }
    }

    public static class ClientCode
    {
        public static void Run()
        {
            IMeal meal = new Meal();
            meal.AddIngredient();

            Console.WriteLine();

            IMeal noodles = new NoodlesDecorator(new Noodles());
            noodles.AddIngredient();

            Console.WriteLine();

            IMeal beefMushrooms = new MushroomsDecorator(new BeefDecorator(new Meal()));
            beefMushrooms.AddIngredient();
        }
    }
}