using System;
using System.Collections.Generic;

namespace Tools.Helper
{
    /// <summary>
    /// Stellt mathematische Hilfsmethoden zur Verfügung.
    /// </summary>
    public static class MathHelper
    {
        /// <summary>
        /// Überprüft ob der Wert zwischen min und max liegt und passt diesen ggf. an.
        /// </summary>
        /// <param name="value">Wert der überprüft werden soll.</param>
        /// <param name="min">Kleinst möglicher Wert.</param>
        /// <param name="max">Größt möglichster Wert.</param>
        public static int Clamp(int value, int min, int max)
        {
            if (value < min)
            {
                value = min;
            }
            if (value > max)
            {
                value = max;
            }

            return value;
        }

        /// <summary>
        /// Überprüft ob der Wert zwischen min und max liegt und passt diesen ggf. an.
        /// </summary>
        /// <param name="value">Wert der überprüft werden soll.</param>
        /// <param name="min">Kleinst möglicher Wert.</param>
        /// <param name="max">Größt möglichster Wert.</param>
        public static float Clamp(float value, float min, float max)
        {
            if (value < min)
            {
                value = min;
            }
            if (value > max)
            {
                value = max;
            }

            return value;
        }

        /// <summary>
        /// Überprüft ob der Wert zwischen min und max liegt und passt diesen ggf. an.
        /// </summary>
        /// <param name="value">Wert der überprüft werden soll.</param>
        /// <param name="min">Kleinst möglicher Wert.</param>
        /// <param name="max">Größt möglichster Wert.</param>
        public static double Clamp(double value, double min, double max)
        {
            if (value < min)
            {
                value = min;
            }
            if (value > max)
            {
                value = max;
            }

            return value;
        }

        /// <summary>
        /// Gibt den kleineren Wert zurück.
        /// </summary>
        /// <param name="a">Erster Wert</param>
        /// <param name="b">Zweiter Wert</param>
        public static int Min(int a, int b)
        {
            if (a <= b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        /// <summary>
        /// Gibt den größeren Wert zurück.
        /// </summary>
        /// <param name="a">Erster Wert</param>
        /// <param name="b">Zweiter Wert</param>
        public static int Max(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        /// <summary>
        /// Gibt den kleineren Wert zurück.
        /// </summary>
        /// <param name="a">Erster Wert</param>
        /// <param name="b">Zweiter Wert</param>
        public static float Min(float a, float b)
        {
            if (a <= b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        /// <summary>
        /// Gibt den größeren Wert zurück.
        /// </summary>
        /// <param name="a">Erster Wert</param>
        /// <param name="b">Zweiter Wert</param>
        public static float Max(float a, float b)
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        /// <summary>
        /// Gibt den kleineren Wert zurück.
        /// </summary>
        /// <param name="a">Erster Wert</param>
        /// <param name="b">Zweiter Wert</param>
        public static double Min(double a, double b)
        {
            if (a <= b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        /// <summary>
        /// Gibt den größeren Wert zurück.
        /// </summary>
        /// <param name="a">Erster Wert</param>
        /// <param name="b">Zweiter Wert</param>
        public static double Max(double a, double b)
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        /// <summary>
        /// Berechnet alle möglichen Kombinationen, mit denen die angegebenen Punkte im Array verteilt werden können.
        /// </summary>
        /// <param name="arrayLength">Größe des Arrays</param>
        /// <param name="points">Die Anzahl an Punkte, die verteilt werden sollen.</param>
        public static int[][] FindCombinations(int arrayLength, int points)
        {
            List<int[]> result = new List<int[]>();

            int[] stats = new int[arrayLength];
            while (ArrayHelper.IncrementArray(ref stats, points))
            {
                if (ArrayHelper.Sum(stats) == points)
                {
                    int[] comb = new int[stats.Length];
                    Array.Copy(stats, comb, arrayLength);
                    result.Add(comb);
                }
            }

            return result.ToArray();
        }
    }
}