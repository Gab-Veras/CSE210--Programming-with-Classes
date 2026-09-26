public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            //Replace only letters with underscores, keeping punctuation visible
            char[] hiddenChars = new char[_text.Length];

            for (int i = 0; i < _text.Length; i++)
            {
                hiddenChars[i] = char.IsLetter(_text[i]) ? '_' : _text[i];
            }

            return new string(hiddenChars);
        }
        else
        {
            return _text;
        }
    }
}
