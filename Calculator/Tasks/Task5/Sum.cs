using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Tasks.Task5
{
    public class Sum
    {

        public void initList(List<int> numbers, int lenght = 10)
        {
            Random random = new Random();
            for (int i = 0; i < lenght; i++)
            {
                numbers.Add(random.Next(1, 10));
                Console.WriteLine(numbers[i]);
            }
        }
        public bool IsSumExist(List<int> numbers, int k)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] <= k)
                {
                    for (int j = i + 1; j < numbers.Count; j++)
                    {
                        if (numbers[i] + numbers[j] == k)
                        {
                            Console.WriteLine($"{numbers[i]} + {numbers[j]} = {k}");
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public bool IsSumExistV2(List<int> numbers, int k)
        {
            foreach (int numer in numbers)
            {
                if (numbers.Contains(k - numer))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsSumExistV3(List<int> numbers, int k)
        {
            return numbers.Any(x => numbers.Contains(k - x) && (numbers.LastIndexOf(k - x) != numbers.IndexOf(x)));
        }

    }
}
