class Word
{
    private string _value;
    private bool _isHidden;

    public Word(string value)
    {
        _value = value;
        _isHidden = false;
    }

    public void HideWord()
    {
        _isHidden = true;
    }

    public void ShowWord()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetRenderedText()
    {
        if (_isHidden)
        {
            // Return underscores equal to the number of letters in the word
            return new string('_', _value.Length);
        }
        else
        {
            return _value;
        }

    }
}
