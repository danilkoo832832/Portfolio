using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    //*
    class Program
    {
        static void Main()
        {
            var consoleWnd = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            Console.WindowTop = 0;
            Console.WindowLeft = 0;
            
            Imports.SetWindowPos(consoleWnd, 0, 0, 0, 0, 0, Imports.SWP_NOSIZE | Imports.SWP_NOZORDER);
            Console.SetWindowSize(((Console.LargestWindowWidth-1)/2)*2+1, ((Console.LargestWindowHeight-1)/2)*2+1);
            Console.BufferWidth = ((Console.LargestWindowWidth - 1) / 2) * 2 + 1;
            Console.BufferHeight = ((Console.LargestWindowHeight - 1) / 2) * 2 + 1;
            Console.CursorVisible = false;

            //*
            //Point point = new Point(3, MyMath.DegToRad(0));
            Point point = new Point(10, 0);// Точка
            point.SetRelativePoint(new Point(Console.BufferWidth / 2 + 1, -(Console.BufferHeight / 2 + 1)));//назначение своей координатной сетки по точке в середине.
            Vector vector = new Vector(point); // Создание вектора(от начала координат до точки)
            vector = vector * 2;
            vector.Draw();
            Console.ReadKey(true);
            Console.ForegroundColor = ConsoleColor.Green;
            vector = new Vector(new Point//Новый вектор по точке
                                    (-10, 10,new Point //Указываются координаты и точка начала координат.
                                                (vector.GetPoint().GetX(vector.GetRelativePoint()),//
                                                vector.GetPoint().GetY(vector.GetRelativePoint()))//
                                    )
                               );// Изменить GetPoint or перегрузить or изменить что-то Для избежания этой конструкции
            vector.Draw();
            Console.ReadKey(true);
            Console.ForegroundColor = ConsoleColor.Red;
            vector = new Vector(new Point(-10, -10, new Point(vector.GetPoint().GetX(vector.GetRelativePoint()),vector.GetPoint().GetY(vector.GetRelativePoint()))));// Вах башня
            vector.Draw();
            Console.ReadKey(true);
            //*/
            //Переделать все Draw на алгоритм Брезенхема(В особенности круг)
        }
    }//*/



    static class MyMath
    {
        /// <summary>
        /// Округление. Не банковское, не к меньшему, не к большему, а обычное.
        /// </summary>
        public static int Okr(double num)
        {
            if (Math.Abs(num - Math.Truncate(num)) < 0.5d)
            {
                return (int)Math.Truncate(num);
            }
            else
            {
                return (int)Math.Truncate(num) + Math.Sign(num);
            }
        }
        /// <summary>
        /// Градусы к радианам
        /// </summary>
        public static double DegToRad(double angle)
        {
            return (Math.PI / 180) * angle;
        }
        /// <summary>
        /// Радианы к градусам
        /// </summary>
        public static double RadToDeg(double angle)
        {
            return (180 / Math.PI) * angle;
        }
    }

    class Point
    {
        // Todo Статик точка в середине экрана.
        public static Point point = new Point(0,0);
        private Point relativePoint = Point.point;
        private double distanse;
        private double angle;
        /// <summary>
        /// Создание точки по X Y
        /// </summary>
        public Point(int X, int Y)
        {
            distanse = Math.Pow(Math.Pow(X, 2) + Math.Pow(Y, 2), 0.5d);
            angle = Math.Atan2(Y,X);
        }
        /// <summary>
        /// Создание точки по X Y. С созданием новой координатной сетки для точки
        /// </summary>
        public Point(int X, int Y, Point point)
        {
            distanse = Math.Pow(Math.Pow(X, 2) + Math.Pow(Y, 2), 0.5d);
            angle = Math.Atan2(Y,X);
            this.relativePoint = point;
        }
        /// <summary>
        /// Создание точки в полярных координатах .С созданием новой координатной сетки для точки
        /// </summary>
        public Point(double Distanse, double Angle)
        {
            distanse = Distanse;
            angle = Angle;
        }
        /// <summary>
        /// Создание точки в полярных координатах .С созданием новой координатной сетки для точки
        /// </summary>
        public Point(double Distanse, double Angle,Point point)
        {
            distanse = Distanse;
            angle = Angle;
            this.relativePoint = point;
        }
        /// <summary>
        /// Получить X относительно начала координат.
        /// </summary>
        public int GetX() => MyMath.Okr(distanse * Math.Cos(angle));
        /// <summary>
        /// Получить Y относительно начала координат.
        /// </summary>
        public int GetY() => MyMath.Okr(distanse * Math.Sin(angle));
        /// <summary>
        /// Получить X относительно начала координат указанной точки.
        /// </summary>
        public int GetX(Point point) => MyMath.Okr(distanse * Math.Cos(angle) + point.GetDistanse() * Math.Cos(point.GetAngle()));
        /// <summary>
        /// Получить Y относительно начала координат указанной точки.
        /// </summary>
        public int GetY(Point point) => MyMath.Okr(distanse * Math.Sin(angle) + point.GetDistanse() * Math.Sin(point.GetAngle()));
        public double GetDistanse() => distanse;
        public double GetAngle() => angle;
        /// <summary>
        /// Получить точку начала координат.
        /// </summary>
        /// <returns></returns>
        public Point GetRelativePoint() => relativePoint;
        public void SetX(int X)
        {
            distanse = MyMath.Okr(Math.Pow(Math.Pow(X, 2) + Math.Pow(MyMath.Okr(distanse * Math.Sin(angle)), 2), 0.5d));
        }
        public void SetY(int Y)
        {
            distanse = MyMath.Okr(Math.Pow(Math.Pow(MyMath.Okr(distanse * Math.Cos(angle)), 2) + Math.Pow(Y, 2), 0.5d));
        }
        public void SetRelativePoint(Point point)
        {
            relativePoint = point;
        }
        public void SetDistanse(double Distanse)
        {
            distanse = Distanse;
        }
        public void SetAngle(double Angle)
        {
            angle = Angle;
        }
        public void Draw()
        {
            int x = this.GetX(relativePoint);
            int y = this.GetY(relativePoint)*-1;
            if (x >= 0 && y >= 0 && x < Console.BufferWidth && y < Console.BufferHeight)
            {
                Console.SetCursorPosition(x, y);
                Console.Write('█');
            }
        }
    }
    /// <summary>
    /// Вектор. Создаётся от начала координат до точки.
    /// </summary>
    class Vector
    {
        private Point point;
        private Point relativePoint;
        /// <summary>
        /// Создаёт вектор по точке с использованием её начала координат
        /// </summary>
        /// <param name="point"></param>
        public Vector(Point point)
        {
            this.point = point;
            relativePoint = point.GetRelativePoint();
        }
        public Point GetRelativePoint() => this.relativePoint;
        public Point GetPoint() => this.point;
        public void SetRelativePoint(Point point)
        {
            relativePoint = point;
        }
        /// <summary>
        /// Получить единичный вектор
        /// </summary>
        public Vector GetUnitVector()
        {
            return new Vector(new Point(1, this.point.GetAngle(),this.GetRelativePoint()));
        }
        /// <summary>
        /// Умножение вектора на целое число
        /// </summary>
        public static Vector operator *(Vector v, int i)
        {
            return new Vector(new Point(v.point.GetDistanse() * i, v.point.GetAngle(),v.relativePoint));
        }
        public void Draw()
        {
            //*
            double distanse = this.point.GetDistanse();
            this.point.Draw();
            for (int i = 0;i < distanse; i++)
            {
                this.point.SetDistanse(i);
                this.point.Draw();
            }//*/
            this.point.SetDistanse(distanse); 
        }
    }

    class Circle
    {
        private double radius;
        private Point relativePoint;

        public Circle(double Radius)
        {
            this.radius = Radius;
            this.relativePoint = Point.point;
        }
        public Circle(double Radius,Point Point)
        {
            this.radius = Radius;
            this.relativePoint = Point;
        }
        public void Draw()
        {
            Point point = new Point(this.radius,0,this.relativePoint);
            for (int i=0; i < this.radius * 2 * Math.PI; i++)
            {
                point.SetAngle(i* MyMath.DegToRad(360/(this.radius * 2 * Math.PI)));
                point.Draw();
            }
        }
    }

    static class Imports
    {
        public static IntPtr HWND_BOTTOM = (IntPtr)1;
        // public static IntPtr HWND_NOTOPMOST = (IntPtr)-2;
        public static IntPtr HWND_TOP = (IntPtr)0;
        // public static IntPtr HWND_TOPMOST = (IntPtr)-1;

        public static uint SWP_NOSIZE = 1;
        public static uint SWP_NOZORDER = 4;

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, uint wFlags);
    }
}