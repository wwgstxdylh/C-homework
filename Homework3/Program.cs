using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Shape
{
    private string myId;
    public Shape(string s)
    {
        Id = s;
    }
    public string Id
    {
        get
        {
            return myId;
        }
        set
        {
            myId = value;
        }
    }
    public abstract double Area
    {
        get;
    }
    public virtual void Draw()
    {
        Console.WriteLine("Draw Shape Icon");
    }
    public override string ToString()
    {
        return Id + "Area=" + string.Format("{0:F2}", Area);
    }
}
public class Square : Shape
{
    private int mySide;
    public Square(int side,string id) : base(id)
    {
        mySide = side;
    }
    public override double Area
    {
        get
        {
            return mySide * mySide;
        }
    }
    public override void Draw()
    {
        Console.WriteLine("Draw 4 Side:" + mySide);
    }
}
public class Circle : Shape
{
    private int myRadius;
    public Circle(int radius, string id) : base(id)
    {
        myRadius = radius;
    }
    public override double Area
    {
        get
        {
            return myRadius * myRadius*System.Math.PI;
        }
    }
    public override void Draw()
    {
        Console.WriteLine("Draw Circle:" + myRadius);
    }
}
public class Rectangle : Shape
{
    private int myWidth;
    private int myHeight;
    public Rectangle(int width, int height,string id) : base(id)
    {
        myWidth = width;
        myHeight = height;
    }
    public override double Area
    {
        get
        {
            return myHeight * myHeight;
        }
    }
    public override void Draw()
    {
        Console.WriteLine("Draw Rectangle:");
    }
}
public class Triangle : Shape
{
    private int mySide;
    private int myHeight;
    public Triangle(int side, int height, string id) : base(id)
    {
        mySide = side;
        myHeight = height;
    }
    public override double Area
    {
        get
        {
            return myHeight * mySide/2;
        }
    }
    public override void Draw()
    {
        Console.WriteLine("Draw Triangle:");
    }
}
public class TestClass
{
    public static void Main()
    {
        Shape[] shapes =
        {
            new Square(5,"Square #1"),
            new Circle(3,"Circle #1"),
            new Rectangle(4,5,"Rectangle #1"),
            new Triangle(4,5,"Triangle #1")
        };
        System.Console.WriteLine("Shape Collection");
        foreach(Shape s in shapes)
        {
            System.Console.WriteLine(s);
        }
    }
}