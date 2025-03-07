using System;

class Reference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int StartVerse { get; private set; }
    public int EndVerse { get; private set; }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
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
        if (StartVerse == EndVerse)
            return $"{Book} {Chapter}:{StartVerse}";
        else
            return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
    }
}
