using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallongeNet.TestProject
{
    public static class Utilities
    {
        private static readonly Random Random = new Random((int)DateTime.Now.Ticks); // Thanks to McAden

        internal static string RandomName(int size = 16)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                char ch = Convert.ToChar(Convert.ToInt32(Math.Floor((26 * Random.NextDouble()) + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        internal static void AssertDateTimeWithin(DateTime exptected, DateTime actual, TimeSpan delta)
        {
            string failMessage = String.Format("Actual {0} is not within {1} and {2}", exptected.ToLongTimeString(), exptected.Subtract(delta).ToLongTimeString(), exptected.Add(delta).ToLongTimeString());
            Assert.IsTrue(actual >= exptected.Subtract(delta), "Actual is bigger than expected. " + failMessage);
            Assert.IsTrue(actual <= exptected.Add(delta), "Actual is less than expected. " + failMessage);
        }
    }
}
