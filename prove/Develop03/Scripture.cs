using System;
using System.Collections.Generic;
using System.Linq;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideWords()
    {
        // Get a list of visible words
        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();

        // Always hide at least one word, even when only one remains
        int wordsToHide = Math.Max(1, visibleWords.Count / 4);
        
        // Ensure that if only one word remains, it gets hidden
        wordsToHide = Math.Min(wordsToHide, visibleWords.Count);

        // Shuffle and hide random words
        for (int i = 0; i < wordsToHide; i++)
        {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].HideWord();
            visibleWords.RemoveAt(index);
        }
    }



    public string GetRenderedText()
    {
        return _reference.GetFullReference() + " - " + string.Join(" ", _words.Select(w => w.GetRenderedText()));
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}