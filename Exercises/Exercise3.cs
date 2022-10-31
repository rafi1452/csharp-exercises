using System;

public class Exercise3
{
    public Exercise3()
    {
    }
/*Given a string "ABCD", print the following:
       A
      AB
     ABC
    ABCD
*/
    public void run()
    {
        string a = "ABCD";
        for (int i = 0; i < a.Length; i++)
        {
            Console.WriteLine(a.Substring(0,i+1).PadLeft(a.Length));
        }
    }
}
