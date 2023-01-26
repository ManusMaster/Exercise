using System;

namespace Rectangles
{
    public static class RectanglesTask
    {
        // Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
        public static bool AreIntersected(Rectangle r1, Rectangle r2)
        {
            // так можно обратиться к координатам левого верхнего угла первого прямоугольника: r1.Left, r1.Top
            var positionX1 = r1.Left + r1.Width;
            var positionX2 = r2.Left + r2.Width;
            var positionY1 = r1.Top + r1.Height;
            var positionY2 = r2.Top + r2.Height;
            var heightLength = (positionY1 <= positionY2) && (positionY2 >= r1.Top);
            var widthLength = (positionX1 < r2.Left) || (positionX2 >= r1.Left);
            return (heightLength || widthLength);
        }

        // Площадь пересечения прямоугольников
        public static int IntersectionSquare(Rectangle r1, Rectangle r2)
        {
            var positionX1 = r1.Left + r1.Width;
            var positionX2 = r2.Left + r2.Width;
            var positionY1 = r1.Top + r1.Height;
            var positionY2 = r2.Top + r2.Height;
            var maxLeft = Math.Max(r1.Left, r2.Left);
            var maxTop = Math.Max(r1.Top, r2.Top);
            int width = SideOfRectangle(positionX1, positionX2, maxLeft);
            int height = SideOfRectangle(positionY1, positionY2, maxTop);
            if (AreIntersected(r1, r2)) return width * height; 
            else return 0;
        }

        private static int SideOfRectangle(int length1, int length2, int maxPoint)
        {
            var maxLength = Math.Max(length1, length2);
            var minLength = Math.Min(length1, length2);
            var lengthBetween = maxLength - minLength;
            var otherSide = maxLength - lengthBetween;
            var length = otherSide - maxPoint;
            return length;
        }

        // Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
        // Иначе вернуть -1
        // Если прямоугольники совпадают, можно вернуть номер любого из них.
        public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
        {
            var firstBigger = (r1.Top + r1.Height >= r2.Top + r2.Height) && (r1.Left + r1.Width >= r2.Left + r2.Width);
            var secondBigger = (r2.Top + r2.Height >= r1.Top + r1.Height) && (r2.Left + r2.Width >= r1.Left + r1.Width);
            if (firstBigger && (r2.Top >= r1.Top) && (r2.Left >= r1.Left)) return 1;
            else if (secondBigger && (r1.Top >= r2.Top) && (r1.Left >= r2.Left)) return 0;
            else return -1;
        }
    }
}