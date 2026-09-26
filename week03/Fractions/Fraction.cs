public class Fraction
{
    private int _topNumber;
    private int _bottomNumber;

    public Fraction()
    {
        _topNumber = 1;
        _bottomNumber = 1;
    }

    public Fraction(int wholeNumber)
    {
        _topNumber = wholeNumber;
        _bottomNumber = 1;
    }

    public Fraction(int top, int bottom)
    {
        _topNumber = top;
        _bottomNumber = bottom;
    }

    public int GetTop()
    {
        return _topNumber;
    }

    public int GetBottom()
    {
        return _bottomNumber;
    }

    public void SetTop(int top)
    {
        _topNumber = top;
    }

    public void SetBottom(int bottom)
    {
        _bottomNumber = bottom;
    }

    public void GetFractionString()
    {
        Console.WriteLine($"Your fraction is {_topNumber}/{_bottomNumber}");
    }

    public double GetDecimalValue()
    {
        return (double)_topNumber / _bottomNumber;
    }
}






