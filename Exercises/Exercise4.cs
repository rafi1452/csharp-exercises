public class Exercise4
{
    public Exercise4()
    {
    }

    public void run()
    {
        var languages = new List<string> { "Hindi", "English", "Kannada", "Urdu", "Punjabi", "Tamil"};
        char[] vowels = {'a','e','i','o','u' };
        foreach (string language in languages)
        {
            int count = 0;
            string a = language.ToLower();
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == 'a' || a[i] == 'e' || a[i] == 'i' || a[i] == 'o' || a[i] == 'u' )
                {
                    count++;
                }
            }
            Console.WriteLine($" number of vowels in {a} is {count}");
        }


    }
}