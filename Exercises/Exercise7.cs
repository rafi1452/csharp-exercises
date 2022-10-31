using System;

public class Exercise7
{
	public Exercise7()
	{
	}
    public void run()
    {
        //string s1 = "121";
        //string s2 = "";
        //for (int i = s1.Length - 1; i >= 0; i--)
        //{
        //    s2 += s1[i];
        //}
        //if (s2 == s1)
        //    Console.WriteLine("Polindrome");
        //else
        //    Console.WriteLine("Not Polindrome");


        string name = "liriterl";
        char[] nameArray = name.ToCharArray();
        Array.Reverse(nameArray);
        string reverse = new string(nameArray);
        if (name.Equals(reverse))
        {
            Console.WriteLine($"{name} is Palindrome");
        }
        else
        {
            Console.WriteLine($"{name} is not Palindrome");
        }




        //string name1 = "malayalam";
        //string reverse1 = string.Empty;
        //foreach (char c in name1)
        //{
        //    reverse1 = c + reverse1;
        //}
        //if (name1 == reverse1)
        //{
        //    Console.WriteLine($"{name1} is Palindrome");
        //}
        //else
        //{
        //    Console.WriteLine($"{name1} is not Palindrome");
        //}
    }
}
