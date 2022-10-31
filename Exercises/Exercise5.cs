
public class Exercise5
{
    public Exercise5()
    {
    }

    public void run()
    {
        int[] a = { 1, 2, 3, 4 };
        string[] b = { "st", "nd", "th", "th" };
        var result = new List<string>();
        for (int i = 0; i < a.Length; i++)
        {
             Console.WriteLine(String.Join("", a[i], b[i]));
        }
        //foreach (string item in result)
        //{
        //    Console.WriteLine(item);        
        //}
    }
}