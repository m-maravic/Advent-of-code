namespace Day9;

public class Knot
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public Knot(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void Move(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public bool IsTouching(int x, int y)
    {
        if (x == this.X - 1 && (y == this.Y - 1 || y == this.Y || y == this.Y + 1))
        {
            return true;
        }

        if (x == this.X && (y == this.Y - 1 || y == this.Y || y == this.Y + 1))
        {
            return true;
        }

        if (x == this.X + 1 && (y == this.Y - 1 || y == this.Y || y == this.Y + 1))
        {
            return true;
        }

        return false;
    }
}

