using System;
using System.Globalization;
using System.Reflection.Emit;

public class Exercise9
{
    public Exercise9()
    {
    }
    public void run()
    {
        /*A bag has thirty fruits of three types: oranges, guavas and apples. Each orange weighs 75 grams. 
         *Each guava weighs 88 grams. Each apple weighs 107 grams. The total weight of all thirty fruits is 3000 grams.
         *Write a program to find how many oranges, guavas and apples are there in the bag.
         */
        int totalWeight = 0 , numOfFruits = 0;
        int count = 0;
        for(int i = 1; i <= 30; i++)
        {
            for(int j = 1; i+j <= 30; j++)
            {
                for (int k = 1; i+j+k <= 30; k++)
                {
                    totalWeight = 75 * i + 88 * j + 107 * k;
                    numOfFruits = i + j + k;
                    if (totalWeight == 3000 && numOfFruits == 30)
                    {
                        Console.WriteLine("i={0}, j={1}, k={2}", i, j, k);
                    }
                    else if(totalWeight >= 3000 || numOfFruits >= 30)
                    {
                        break;
                    }
                    count++;
                }
            }   
        }Console.WriteLine(count);
    }
}
