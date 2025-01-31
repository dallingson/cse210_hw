using System;

public class Entry
{
    // Properties with TitleCase
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Date { get; set; }

    // Constructor with parameters using camelCase
    public Entry(string prompt, string response, DateTime date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    // Overrides ToString to format entry display
    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}
