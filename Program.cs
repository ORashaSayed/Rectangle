internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Rectangle rect1 = new Rectangle(0, 0, 100, 100);
        Rectangle rect2 = new Rectangle(50, 50, 50, 50);

        Rectangle? intersectionMe = Rectangle.GetIntersection(rect1, rect2);

        if (intersectionMe != null)
        {
            Console.WriteLine($"Intersection: {intersectionMe}");
        }
        else
        {
            Console.WriteLine("No intersection.");
        }
    }
}


//My Approach 
public class Rectangle
{
    public int Left { get; set; }
    public int Top { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public Rectangle(int left, int top, int width, int height)
    {
        Left = left;
        Top = top;
        Width = width;
        Height = height;
    }

    //My approach 
    public static Rectangle? GetIntersection(Rectangle rect1, Rectangle rect2)
    {
        // Check if there is no horizontal overlap
        if (rect1.Left > rect2.Left + rect2.Width || rect2.Left > rect1.Left + rect1.Width)
        {
            return null; // No horizontal overlap, no intersection
        }

        // Check if there is no vertical overlap
        if (rect1.Top > rect2.Top + rect2.Height || rect2.Top > rect1.Top + rect1.Height)
        {
            return null; // No vertical overlap, no intersection
        }

        // Calculate the intersection rectangle
        int intersectLeft = Math.Max(rect1.Left, rect2.Left);
        int intersectTop = Math.Max(rect1.Top, rect2.Top);
        int intersectRight = Math.Min(rect1.Left + rect1.Width, rect2.Left + rect2.Width);
        int intersectBottom = Math.Min(rect1.Top + rect1.Height, rect2.Top + rect2.Height);

        return new Rectangle(intersectLeft, intersectTop, intersectRight - intersectLeft, intersectBottom - intersectTop);
    }

    public override string ToString()
    {
        return $"Left: {Left}, Top: {Top}, Width: {Width}, Height: {Height}";
    }
}

// Open AI 
//public class Rectangle
//{
//    public double X { get; set; }
//    public double Y { get; set; }
//    public double Width { get; set; }
//    public double Height { get; set; }

//    public Rectangle(double x, double y, double width, double height)
//    {
//        X = x;
//        Y = y;
//        Width = width;
//        Height = height;
//    }

//    // ... Other methods like GetTopLeft, GetTopRight ...

//    // Method to check for intersection with another rectangle
//    public Rectangle Intersection(Rectangle other)
//    {
//        double x1 = Math.Max(this.X, other.X);
//        double y1 = Math.Max(this.Y, other.Y);
//        double x2 = Math.Min(this.X + this.Width, other.X + other.Width);
//        double y2 = Math.Min(this.Y + this.Height, other.Y + other.Height);

//        if (x2 >= x1 && y2 >= y1)
//        {
//            return new Rectangle(x1, y1, x2 - x1, y2 - y1);
//        }

//        return null; // No intersection
//    }
//}


//Another way Chagept
//public static Rectangle GetIntersection(Rectangle rect1, Rectangle rect2)
//{
//    int minX = int.MaxValue, maxX = int.MinValue, minY = int.MaxValue, maxY = int.MinValue;
//    bool intersectionFound = false;

//    // Iterate through each point on the perimeter of rect1
//    for (int x = rect1.Left; x <= rect1.Left + rect1.Width; x++)
//    {
//        for (int y = rect1.Top; y <= rect1.Top + rect1.Height; y++)
//        {
//            // Check if the point is within rect2
//            if (rect2.ContainsPoint(x, y))
//            {
//                minX = Math.Min(minX, x);
//                maxX = Math.Max(maxX, x);
//                minY = Math.Min(minY, y);
//                maxY = Math.Max(maxY, y);
//                intersectionFound = true;
//            }
//        }
//    }

//    if (intersectionFound)
//    {
//        return new Rectangle(minX, minY, maxX - minX, maxY - minY);
//    }

//    return null;
//}
