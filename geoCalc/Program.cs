using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace geoCalc
{
    abstract class SquareFigure
    {
        public double aSide { get; set; }
        public double bSide { get; set; }
        public double cSide { get; set; }
        public double hSide { get; set; }
        public double sinAlpha { get; set; }
        public double radBig { get; set; }


        public abstract double FindSquare();
    }

    class BySideHeight : SquareFigure
    {
        public override double FindSquare()
        {
            Console.WriteLine("Формула площади треугольника по стороне и высоте");
            return (aSide * hSide)/2;
        }
    }

        class Herone : SquareFigure
        {
            
            public override double FindSquare()
            {
                Console.WriteLine("Формула площади треугольника по трем сторонам");
                double pvar = (aSide + bSide + cSide) / 2;
                return Math.Round(Math.Sqrt(pvar * (pvar - aSide) * (pvar - bSide) * (pvar - cSide)));
            }
        }

        class ByTwoSideandAngle : SquareFigure
        {
            public override double FindSquare()
            {
                Console.WriteLine("Формула площади треугольника по стороне и высоте");
                return (Math.Sin(sinAlpha) * aSide * bSide) / 2;
            }
        }

        class ByThreeSidesandRadBig : SquareFigure
        {
            public override double FindSquare()
            {
                Console.WriteLine("Формула площади треугольника по трем сторонам и радиусу описанной окружности");
                return (aSide * bSide * cSide) / (4 * radBig);
            }
        }

    class ByThreeSidesandRadSmall : ByThreeSidesandRadBig
    {
        public override double FindSquare()
        {
            Console.WriteLine("Формула площади треугольника по трем сторонам и радиусу вписанной окружности");
            double pvar = (aSide + bSide + cSide) / 2;
            return Math.Round(Math.Sqrt(pvar * (pvar - aSide) * (pvar - bSide) * (pvar - cSide)))*radBig;
        }
    }

    class Program
        {
            static void Main(string[] args)
            {
            double var1, var2, var3, var4, var5, var6, var7;
            byte choice;

            Console.WriteLine("ВВедите номер варианта нахождения площади треугольника");
            Console.WriteLine("1.Если хотите найти по стороне и высоте ");
            Console.WriteLine("2.Если хотите найти по по трем сторонам ");
            Console.WriteLine("3.Если хотите найти по двум сторонам и углу между ними ");
            Console.WriteLine("4.Если хотите найти по трем сторонам и радиусу описанной окружности ");
            Console.WriteLine("5.Если хотите найти по трем сторонам и радиусу вписанной окружности ");
            byte.TryParse(Console.ReadLine(), out choice);


            switch (choice)
            {
                case 1:
                    Console.WriteLine("ВВедите размер стороны А");
                    Double.TryParse(Console.ReadLine(), out var1);
                    Console.WriteLine("ВВедите размер высоты H");
                    Double.TryParse(Console.ReadLine(), out var4);
                    BySideHeight avar = new BySideHeight() { aSide = var1, hSide = 4 };
                    Console.WriteLine("Площадь треугольника {0} квадртаных единиц.", avar.FindSquare());
                    break;

                case 2:
                    Console.WriteLine("ВВедите размер стороны А");
                    Double.TryParse(Console.ReadLine(), out var1);
                    Console.WriteLine("ВВедите размер стороны B");
                    Double.TryParse(Console.ReadLine(), out var2);
                    Console.WriteLine("ВВедите размер стороны C");
                    Double.TryParse(Console.ReadLine(), out var3);
                    Herone bvar = new Herone() { aSide = var1, bSide = var2, cSide = var3 };
                    Console.WriteLine("Площадь треугольника {0} квадртаных единиц.", bvar.FindSquare());
                    break;

                case 3:
                    Console.WriteLine("ВВедите размер стороны А");
                    Double.TryParse(Console.ReadLine(), out var1);
                    Console.WriteLine("ВВедите размер стороны B");
                    Double.TryParse(Console.ReadLine(), out var2);
                    Console.WriteLine("ВВедите размер синуса угла Аlpha");
                    Double.TryParse(Console.ReadLine(), out var5);
                    ByTwoSideandAngle cvar = new ByTwoSideandAngle() { aSide = var1, bSide = var2, sinAlpha = var5 };
                    Console.WriteLine("Площадь треугольника {0} квадртаных единиц.", cvar.FindSquare());
                    break;

                case 4:
                    Console.WriteLine("ВВедите размер стороны А");
                    Double.TryParse(Console.ReadLine(), out var1);
                    Console.WriteLine("ВВедите размер стороны B");
                    Double.TryParse(Console.ReadLine(), out var2);
                    Console.WriteLine("ВВедите размер стороны C");
                    Double.TryParse(Console.ReadLine(), out var3);
                    Console.WriteLine("ВВедите размер радиуса окружности R");
                    Double.TryParse(Console.ReadLine(), out var6);
                    ByThreeSidesandRadBig dvar = new ByThreeSidesandRadBig() { aSide = var1, bSide = var2, cSide = var3, radBig = var6 };
                    Console.WriteLine("Площадь треугольника {0} квадртаных единиц.", dvar.FindSquare());
                    break;
                case 5:
                    Console.WriteLine("ВВедите размер стороны А");
                    Double.TryParse(Console.ReadLine(), out var1);
                    Console.WriteLine("ВВедите размер стороны B");
                    Double.TryParse(Console.ReadLine(), out var2);
                    Console.WriteLine("ВВедите размер стороны C");
                    Double.TryParse(Console.ReadLine(), out var3);
                    Console.WriteLine("ВВедите размер радиуса окружности R");
                    Double.TryParse(Console.ReadLine(), out var6);
                    ByThreeSidesandRadSmall evar = new ByThreeSidesandRadSmall() { aSide = var1, bSide = var2, cSide = var3, radBig = var6 };
                    Console.WriteLine("Площадь треугольника {0} квадртаных единиц.", evar.FindSquare());
                    break;
                default:
                    Console.WriteLine("Было введено недопустимое значение.");
                    break;
            }

            Console.Read();
            }
        }
    }
