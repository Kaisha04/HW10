/*Використовуючи Visual Studio, створіть проект за шаблоном Console Application. Створіть клас MyList.
Реалізуйте у найпростішому наближенні можливість використання його екземпляра аналогічно екземпляру класу List. 
Мінімально необхідний інтерфейс взаємодії з екземпляром повинен включати метод додавання елемента, 
індексатор для отримання значення елемента за вказаним індексом і властивість тільки для читання для отримання загальної кількості елементів.*/

using System;

namespace Task2;

class Program
{
    static void Main()
    {
        MyList<int> test = new MyList<int>();
    }
}

class MyList<T>
{
    T[] array = new T[0];

    public int Length
    {
        get
        {
            return array.Length;
        }
    }

    public T this[int i]
    {
        get {
            if (i < 0  || i > array.Length - 1)
            {
                Console.WriteLine("Поза межами списку");
            }
            return array[i]; 
        }
        set {
            if (i < 0  || i > array.Length -1 )
            {
                Console.WriteLine("Поза межами списку");
                return;
            }

            array[i] = value; 
        }
    }

    public MyList() { }
    public MyList (T[] array)
    {
        this.array = array;
    }

    public void Add(T value)
    {
       

            T[] newArray = new T[array.Length + 1];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }
            newArray[newArray.Length - 1] = value;
            array = newArray;
        
    }

    public void Delete(int index)
    {
        if (index >= 0 && index < array.Length)
        {
            T[] newArray = new T[array.Length - 1];
            for (int i = 0, j = 0; i < array.Length; i++)
            {
                if (i == index) continue;
                newArray[j] = array[i];
                j++;

            }
            array = newArray;
        }
        else
        {
            Console.WriteLine("Немає такого елементу");
        }
    }
}