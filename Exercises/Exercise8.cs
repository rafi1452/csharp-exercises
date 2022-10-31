using System;
using System.Collections.ObjectModel;
using System.Globalization;

public class Exercise8
{
    public Exercise8()
    {
    }
    public void run()
    {
        Console.WriteLine("Enter epcoh time");
        long epoch = long.Parse(Console.ReadLine());

        DateTimeOffset dateTimeOffSet = DateTimeOffset.FromUnixTimeSeconds(epoch);
        DateTime dateTime = dateTimeOffSet.DateTime;
        Console.WriteLine(dateTime);
        Console.WriteLine(TimeZoneInfo.ConvertTimeBySystemTimeZoneId(dateTime , "UTC", "IST"));


        //var date = System.TimeZoneInfo.ConvertTimeFromUtc(dateTime, TimeZoneInfo.Utc);
        //Console.WriteLine(date);

    }
}
