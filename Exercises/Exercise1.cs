using System;

public class Exercise1
{
	public Exercise1()
	{
	}

	public void run()
	{
        double sum = 1d;
        for (int i = 2; i < 10; i++)
        {
            sum += i / Math.Pow(7, i - 1);
        }
        Console.WriteLine(sum);
    }
}
