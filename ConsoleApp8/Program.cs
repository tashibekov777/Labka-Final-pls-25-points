using System;

public class Complex
{

    public static readonly Complex Zero = new Complex(0, 0);
    public static readonly Complex One = new Complex(1, 0);
    public static readonly Complex ImOne = new Complex(0, 1);
    public double X { get; }
    public double Y { get; }
    public Complex(double x, double y)
    {
        X = x;
        Y = y;
    }

    public Complex(double x) : this(x, 0) { }
    public Complex() : this(0) { }
    public double Length => Math.Sqrt(X * X + Y * Y);

    public static Complex operator +(Complex a, Complex b) => new Complex(a.X + b.X, a.Y + b.Y);
    public static Complex operator -(Complex a, Complex b) => new Complex(a.X - b.X, a.Y - b.Y);
    public static Complex operator *(Complex a, Complex b) => new Complex(a.X * b.X - a.Y * b.Y, a.X * b.Y + a.Y * b.X);
    public static Complex operator /(Complex a, Complex b)
    {
        if (b.X == 0 && b.Y == 0)
            throw new DivideByZeroException("Division by zero in Complex numbers.");

        double denominator = b.X * b.X + b.Y * b.Y;
        double realPart = (a.X * b.X + a.Y * b.Y) / denominator;
        double imaginaryPart = (a.Y * b.X - a.X * b.Y) / denominator;

        return new Complex(realPart, imaginaryPart);
    }

    public static Complex operator +(Complex a) => a;
    public static Complex operator -(Complex a) => new Complex(-a.X, -a.Y);
    public override string ToString() => $"{X} + {Y}i";
    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is Complex))
            return false;

        Complex other = (Complex)obj;
        return X == other.X && Y == other.Y;
    }

    public override int GetHashCode() => HashCode.Combine(X, Y);
}
