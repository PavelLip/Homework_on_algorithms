using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_and_data_structures
{
    class Program
    {
        static void Main(string[] args)
        {
            int countNumber = 100000;
            Random rnd = new Random();
            int[] array = new int[countNumber];

            for (int i = 0; i < countNumber; i++)
            {
                array[i] = rnd.Next(1, 201);
            }
            int[] BucketSortArray = BucketSort(array);

            foreach (var item in array)
                Console.Write($" {item}");
            Console.WriteLine();
            foreach (var item in BucketSortArray)
                Console.Write($" {item}");

            Console.ReadLine();
        }

        static int [] BucketSort (int [] array)
        {
            int countBlocks = 4;
            int minNumberArray = array.Min();
            int maxNumberArray = array.Max();
            int[] newArray = new int[array.Length];
            int serialNumberArray = 0;
            int range = (maxNumberArray - minNumberArray+1) / countBlocks;
            int minNumber, maxNumber;
            // в случае есть кол-во блоков меньше чем кол-во уникальных значений
            if ((maxNumberArray - minNumberArray) < countBlocks) 
            {
                range = 1;
                countBlocks = maxNumberArray - minNumberArray + 1;
            }
            minNumber = minNumberArray - 1;
            maxNumber = minNumber + range;

            for (int i = 0; i < countBlocks; i++)
            {
                int[] newBlok = new int[array.Length];
                int serialNumber = 0; //счетчик для нового блока 
                if (i+1 == countBlocks) // для нивилирования некорректного подсчета диапазона на последнем блоке
                    maxNumber = maxNumberArray;

                for (int j = 0; j < array.Length; j++)// добавление в блок элементов которые входят в диапазон
                {
                    if (array[j] > minNumber && array[j]<= maxNumber)
                    {
                        newBlok[serialNumber] = array[j];
                        serialNumber += 1;
                    }
                }

                if (range > 1) 
                    Array.Sort(newBlok); // в интернете предлагают создавать кол-во блоков равное кол-ву уникальных значений, тогда сортировка не нужна

                for (int j = 0; j < newBlok.Length; j++) // добавление отсортированного блока в массив
                {
                    if (newBlok[j] != 0)
                    {
                        newArray[serialNumberArray] = newBlok[j];
                        serialNumberArray += 1;
                    }
                }
                minNumber = maxNumber;
                maxNumber = maxNumber + range;
            }
            return newArray;
        }
    }
}
