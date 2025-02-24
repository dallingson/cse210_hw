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

    public static Scripture ParseFromLine(string line)
    {
        var parts = line.Split(" - ");
        if (parts.Length == 2)
        {
            var reference = Reference.ParseFromText(parts[0]);
            var scriptureText = parts[1].Trim('"');

            if (reference != null)
            {
                return new Scripture(reference, scriptureText);
            }
        }
        return null;
    }

    public void HideWords()
    {
        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();
        int wordsToHide = Math.Max(1, visibleWords.Count / 4);
        wordsToHide = Math.Min(wordsToHide, visibleWords.Count);

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
