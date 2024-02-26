using System;

class task9
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Фигуры: ладья, конь, слон, ферзь, король");
            Console.WriteLine("Введите исходные данные (например: ферзь d3 слон e1 d8): ");
            string input = Console.ReadLine();

            string[] inputData = input.Split(' ');
            string whiteFigure = inputData[0];
            string whiteFigurePosition = inputData[1];
            string blackFigure = inputData[2];
            string blackFigurePosition = inputData[3];
            string targetPosition = inputData[4];

            char whiteXChar = whiteFigurePosition[0];
            char whiteYChar = whiteFigurePosition[1];
            char blackXChar = blackFigurePosition[0];
            char blackYChar = blackFigurePosition[1];
            char targetXChar = targetPosition[0];
            char targetYChar = targetPosition[1];

            if (!IsValidCoordinate(whiteXChar, whiteYChar) || !IsValidCoordinate(blackXChar, blackYChar) ||
                !IsValidCoordinate(targetXChar, targetYChar) || inputData.Length != 5)
            {
                Console.WriteLine("Введены некорректные координаты");
                return;
            }

            if (CanWhiteFigureReachTarget(whiteFigure, whiteFigurePosition, blackFigurePosition, targetPosition))
            {
                Console.WriteLine($"Результат: {whiteFigure} дойдет до {targetPosition}\n");
            }
            else
            {
                Console.WriteLine($"Результат: {whiteFigure} не дойдет до {targetPosition}\n");
            }
        }
    }

    static bool IsValidCoordinate(char x, char y)
    {
        return x >= 'a' && x <= 'h' && y >= '1' && y <= '8';
    }

    static bool CanWhiteFigureReachTarget(string whiteFigure, string whiteFigurePosition, string blackFigurePosition, string targetPosition)
    {
        char whiteX = whiteFigurePosition[0];
        char whiteY = whiteFigurePosition[1];
        char blackX = blackFigurePosition[0];
        char blackY = blackFigurePosition[1];
        char targetX = targetPosition[0];
        char targetY = targetPosition[1];

        if (whiteFigure == "ферзь")
        {
            // Проверяем, находится ли целевая позиция на одной линии или диагонали с ферзем
            if (whiteX == targetX || whiteY == targetY || Math.Abs(whiteX - targetX) == Math.Abs(whiteY - targetY))
            {
                // Проверяем, не попадает ли ферзь под удар черной фигуры
                if (targetX != blackX || targetY != blackY)
                {
                    return true;
                }
            }
        }
        else if (whiteFigure == "ладья")
        {
            if (whiteX == targetX || whiteY == targetY)
            {
                if (targetX != blackX || targetY != blackY)
                {
                    return true;
                }
            }
        }
        else if (whiteFigure == "слон")
        {
            if (Math.Abs(whiteX - targetX) == Math.Abs(whiteY - targetY))
            {
                if (targetX != blackX || targetY != blackY)
                {
                    return true;
                }
            }
        }
        else if (whiteFigure == "конь")
        {
            if ((Math.Abs(whiteX - targetX) == 1) && (Math.Abs(whiteY - targetY) == 2)
                || (Math.Abs(whiteX - targetX) == 2) && (Math.Abs(whiteY - targetY) == 1))
            {
                if (targetX != blackX || targetY != blackY)
                {
                    return true;
                }
            }
        }

        else if (whiteFigure == "король")
        {
            if ((Math.Abs(whiteX - targetX) <= 1) && (Math.Abs(whiteY - targetY) <= 1))
            {
                if (targetX != blackX || targetY != blackY)
                {
                    return true;
                }
            }
        }
        else
        {
            Console.WriteLine("Неизвестная фигура");
            return false;
        }

        return false;
    }
}

