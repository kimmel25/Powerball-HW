using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Powerball_Homework
{
    internal class PowerballModel
    {
        public List<int> WinningNumbers { get; private set; }

        public PowerballModel()
        {
            WinningNumbers = GenerateRandomPowerballNumbers();
        }

        public bool CheckPowerballNumbers(List<int> userNumbers)
        {
            int powerballNumber = WinningNumbers.Last();
            List<int> winningNumbersWithoutPowerball = WinningNumbers.Take(5).ToList();

            int matchingNumbersCount = userNumbers.Intersect(winningNumbersWithoutPowerball).Count();
            bool powerballMatch = userNumbers.Contains(powerballNumber);

            return matchingNumbersCount == 5 && powerballMatch;
        }

        public List<int> GenerateRandomPowerballNumbers()
        {
            List<int> numbers = new List<int>();
            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                int randomNumber = random.Next(1, 100);
                numbers.Add(randomNumber);
            }

            return numbers;
        }

        public List<int> GetWinningNumbers()
        {
            return WinningNumbers;
        }

        public void ResetFields()
        {
            WinningNumbers = GenerateRandomPowerballNumbers();

        }
    }
}
