using System;

class Reference
{
    // Private fields
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    // Public properties for encapsulation
    public string Book => _book;
    public int Chapter => _chapter;
    public int StartVerse => _startVerse;
    public int EndVerse => _endVerse;

    // Constructor
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    // Static method to parse reference from text
    public static Reference ParseFromText(string referenceText)
    {
        var referenceParts = referenceText.Split(':');
        if (referenceParts.Length == 2)
        {
            var bookAndChapter = referenceParts[0].Trim();
            var verseRange = referenceParts[1].Trim();

            var bookAndChapterParts = bookAndChapter.Split(' ');
            if (bookAndChapterParts.Length == 2)
            {
                string book = bookAndChapterParts[0];
                if (int.TryParse(bookAndChapterParts[1], out int chapter))
                {
                    var verses = verseRange.Split('-');
                    int startVerse = int.Parse(verses[0]);
                    int endVerse = verses.Length == 2 ? int.Parse(verses[1]) : startVerse;

                    return new Reference(book, chapter, startVerse, endVerse);
                }
            }
        }
        return null;
    }

    // Method to get the full reference as a string
    public string GetFullReference()
    {
        if (_startVerse == _endVerse)
        {
            return $"{_book} {_chapter}:{_startVerse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        }
    }
}
