using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Windows.UI.Xaml;

public class Exercise13
{
    private readonly HttpClient _httpClient = new HttpClient();

    [HttpGet, Route("DotNetCount")]
    public async Task<int> GetDotNetCount()
    {
        // Suspends GetDotNetCount() to allow the caller (the web server)
        // to accept another request, rather than blocking on this one.
        var html = await _httpClient.GetStringAsync("https://dotnetfoundation.org");

        return Regex.Matches(html, @"\.NET").Count;
    }

    //private async void OnSeeTheDotNetsButtonClick(object sender, RoutedEventArgs e)
    //{
    //    // Capture the task handle here so we can await the background task later.
    //    var getDotNetFoundationHtmlTask = _httpClient.GetStringAsync("https://dotnetfoundation.org");

    //    // Any other work on the UI thread can be done here, such as enabling a Progress Bar.
    //    // This is important to do here, before the "await" call, so that the user
    //    // sees the progress bar before execution of this method is yielded.
    //    NetworkProgressBar.IsEnabled = true;
    //    NetworkProgressBar.Visibility = Visibility.Visible;

    //    // The await operator suspends OnSeeTheDotNetsButtonClick(), returning control to its caller.
    //    // This is what allows the app to be responsive and not block the UI thread.
    //    var html = await getDotNetFoundationHtmlTask;
    //    int count = Regex.Matches(html, @"\.NET").Count;

    //    DotNetCountLabel.Text = $"Number of .NETs on dotnetfoundation.org: {count}";

    //    NetworkProgressBar.IsEnabled = false;
    //    NetworkProgressBar.Visibility = Visibility.Collapsed;
    //}


    public async Task<int> GetUrlContentLengthAsync()
    {
        var client = new HttpClient();

        Task<string> getStringTask =
            client.GetStringAsync("https://docs.microsoft.com/dotnet");

        DoIndependentWork();
        Console.WriteLine("Hello");
        string contents = await getStringTask;

        return contents.Length;
        
    }

    void DoIndependentWork()
    {
        Console.WriteLine("Working...");
    }
}