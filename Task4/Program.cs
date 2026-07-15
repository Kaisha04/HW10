/*Використовуючи Visual Studio, створіть проект за шаблоном Console Application. 
Створіть метод, що розширює: public static T[] GetArray(this MyList list) Застосуйте розширюючий метод до екземпляра типу MyList, розробленого в домашньому завданні 2 для даного уроку. 
Виведіть на екран значення елементів масиву, який повернув метод GetArray(), що розширює метод.*/

using System;
using System.Collections;

namespace Task4;

class Program
{
    static void Main()
    {
        MyList<int> test = new MyList<int>();
        test.Add(1);
        test.Add(2);
        test.Add(3);
        int[] array = test.GetArray<int>();
        foreach (int i in array)
        {
            Console.WriteLine(i);
        }
    }
}

static class ExtensionClass
{
    public static T[] GetArray<T>(this MyList<T> list)
    {
        T[] array = new T[list.Length];
        for (int i = 0; i < list.Length; i++)
        {
            array[i] = list[i];
        }
        return array;
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
        get
        {
            if (i < 0 || i > array.Length - 1)
            {
                Console.WriteLine("Поза межами списку");
            }
            return array[i];
        }
        set
        {
            if (i < 0 || i > array.Length - 1)
            {
                Console.WriteLine("Поза межами списку");
                return;
            }

            array[i] = value;
        }
    }

    public MyList() { }
    public MyList(T[] array)
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