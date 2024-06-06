using System.Drawing;
//Disposable Inteface
using (Person person = new Person())
{
    Console.WriteLine("In disposable object scope");
}
Console.WriteLine("Out of disposable object scope");

// Interface
IFigure square = new Square();
IFigure rectangle = new Rectangle();
List<IFigure> figures = new List<IFigure>();
figures.Add(square);
figures.Add(rectangle);
foreach(IFigure figure in figures)
{
    figure.PrintSurface();
}

square.PrintSurface();
rectangle.PrintSurface();

public interface IFigure
{ 
    void PrintSurface();
}
public class Square : IFigure
{
    public Square()
    {
        Side = 4;
    }

    public int Side { get; set; }

    public void PrintSurface()
    {
        Console.WriteLine(Side * Side);
    }
}

public class Rectangle : IFigure
{
    public Rectangle()
    {
        Width = 5;
        Hight = 10;
    }

    public int Width { get; set; }
    public int Hight { get; set; }

    public void PrintSurface()
    {
        Console.WriteLine(Width * Hight);
    }
}
//Disposable Inteface


public class Person : IDisposable
{
    public void Dispose()
    {
        Console.WriteLine("Disposing.");
    }
}