using System;

class Reference
{

    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }
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

    public string GetFullReference()
    {
        if (_startVerse == _endVerse)
            return $"{_book} {_chapter}:{_startVerse}";
        else
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
    }
}
