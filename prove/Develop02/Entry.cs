using System;

public class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Date { get; set; }

    public Entry(String prompt, string response, DateTime date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}