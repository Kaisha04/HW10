/*Створіть проект Console Application, де реалізуйте типізований клас "Чарівний мішок". Чарівність полягає в тому, що подарунок сам з'являється у мішку та залежить від того, хто намагається відкрити мішок.
Причому подарунок для однієї істоти може з'явитись лише 1 раз на день. Використовуйте обмеження типу - інтерфейс із властивістю, що зберігає тип істоти, яка намагається отримати подарунок із мішка.*/

using System;

class Program
{ 
    static void Main()
    {
        MagicBag<ICreature> bag = new MagicBag<ICreature>();

        Elf dobby = new Elf();
        Human aragorn = new Human();

        Console.WriteLine("--- Підходять вперше ---");
        bag.GetPresent(dobby); 
        bag.GetPresent(aragorn);

        Console.WriteLine("\n--- Підходять вдруге за день ---");
        bag.GetPresent(dobby); 
    }
}

public class Elf : ICreature
{
    public string Present { get => "Мішок з грошима"; }


}

public class Ogr : ICreature
{
    public string Present { get => "Мішок з буловою"; }
}
public class Human : ICreature
{
    public string Present { get => "Мішок з їжою"; }
}

public interface ICreature
{
    public string Present { get; }
}

class MagicBag<T> where T : ICreature
{
    Dictionary<string, DateTime> time = new Dictionary<string, DateTime>();
    public void GetPresent(T person)
    {

        if (!time.ContainsKey(person.GetType().Name))
        {
            Console.WriteLine(person.Present);
            time.Add(person.GetType().Name, DateTime.Now);
        }
        else if (DateTime.Now.Date > time[person.GetType().Name].Date)
        {
            Console.WriteLine(person.Present);
            time[person.GetType().Name] = DateTime.Now;
        }else Console.WriteLine("День ще не минув ");

    }
}