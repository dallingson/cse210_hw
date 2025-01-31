using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts = new List<string> // create a list of prompts
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What made me smile today?",
        "What made me frown today?",
        "What is something new I learned today?",
        "How did I help someone today?",
        "What is one thing I am grateful for today?",
        "What challenged me the most today?",
        "What was a moment of peace or joy I experienced today?",
        "If I could describe today in one word, what would it be and why?",
        "What is one goal I want to accomplish tomorrow?",
        "How did I push myself out of my comfort zone today?"
    };
    public string GetRandomPrompt() // generate random prompts
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}
