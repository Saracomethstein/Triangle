using System;

namespace TriangleDefinition
{
    class Program
    {
        static void Main()
        {
            InputSide();
            Console.ReadLine();
        }

        static void InputSide()
        {
            PrintMsg("Enter the lengths of the sides of the triangle.");
            double side1, side2, side3;

            #region Input Sides
            while (true)
            {
                PrintMsg("Enter the first side: ");
                if (double.TryParse(Console.ReadLine(), out side1) && IsValidSide(side1))
                {
                    break;
                }
                else
                {
                    ErrorPrint("[Error]: The range of numbers is from 0 to 99. Try again!");
                }
            }

            while (true)
            {
                PrintMsg("Enter the second side: ");
                if (double.TryParse(Console.ReadLine(), out side2) && IsValidSide(side2))
                {
                    break;
                }
                else
                {
                    ErrorPrint("[Error]: The range of numbers is from 0 to 99. Try again!");
                }
            }

            while (true)
            {
                PrintMsg("Enter third side: ");
                if (double.TryParse(Console.ReadLine(), out side3) && IsValidSide(side3))
                {
                    break;
                }
                else
                {
                    ErrorPrint("[Error]: The range of numbers is from 0 to 99. Try again!");
                }
            }
            #endregion

            #region IsTriangle?
            if (IsTriangle(side1, side2, side3))
            {
                string triangleType = GetTriangleType(side1, side2, side3);
                double area = CalculateTriangleArea(side1, side2, side3);
                PrintResult($"Triangle {triangleType} with area {area:F2}");
            }
            else
            {
                ErrorPrint("There is no triangle with such sides.");
            }
            #endregion
        }

        static bool IsValidSide(double side)
        {
            return side > 0 && side <= 99;
        }

        static bool IsTriangle(double side1, double side2, double side3)
        {
            return side1 + side2 > side3 && side1 + side3 > side2 && side2 + side3 > side1;
        }

        static string GetTriangleType(double side1, double side2, double side3)
        {
            if (side1 == side2 && side2 == side3)
            {
                return "equilateral";
            }
            else if (side1 == side2 || side1 == side3 || side2 == side3)
            {
                return "isosceles";
            }
            else
            {
                return "scalene";
            }
        }

        static double CalculateTriangleArea(double side1, double side2, double side3)
        {
            double P = (side1 + side2 + side3) / 2;
            return Math.Sqrt(P * (P - side1) * (P - side2) * (P - side3));
        }

        #region Print message
        static void ErrorPrint(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        static void PrintResult(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        static void PrintMsg(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
        #endregion
    }
}