using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramareDinamica
{
    public class Tabulare
    {

        //PROBLEMA 1
        public long fibDinamic(int n)
        {
            if (n <= 1)
            {
                return n;
            }

            long[] table = new long[n + 1];
            table[1] = 1;

            for (int i = 0; i <= n; i++)
            {
                if (i + 1 <= n)
                {
                    table[i + 1] += table[i];
                }

                if (i + 2 <= n)
                {
                    table[i + 2] += table[i];
                }
            }

            return table[n];
        }

        //PROBLEMA 2 
        public long travelDinamic(int n, int m)
        {
            long[,] table = new long[m + 1, n + 1];
            table[1, 1] = 1;

            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    long current = table[i, j];

                    if (j + 1 <= n)
                    {
                        table[i, j + 1] += current;
                    }

                    if (i + 1 <= m)
                    {
                        table[i + 1, j] += current;
                    }
                }
            }

            return table[m, n];
        }

        //PROBLEMA 3
        public bool canSumDinamic(int targetSum, int[] numbers)
        {
            bool[] table = new bool[targetSum + 1];
            table[0] = true;

            for (int i = 0; i <= targetSum; i++)
            {
                if (table[i])
                {
                    foreach (int num in numbers)
                    {
                        if (i + num <= targetSum)
                        {
                            table[i + num] = true;
                        }
                    }
                }
            }

            return table[targetSum];
        }

        //PROBLEMA 4
        public List<int> howSumDinamic(int targetSum, int[] numbers)
        {

            List<int>[] table = new List<int>[targetSum + 1];
            table[0] = new List<int>();

            for (int i = 0; i <= targetSum; i++)
            {
                if (table[i] != null)
                {
                    foreach (int num in numbers)
                    {
                        if (i + num <= targetSum)
                        {
                            List<int> currentList = new List<int>(table[i]);
                            currentList.Add(num);
                            table[i + num] = currentList;
                        }
                    }
                }
            }

            return table[targetSum];
        }

        //PROBLEMA 5  
        public List<int> bestSumDinamic(int targetSum, int[] numbers)
        {

            List<int>[] table = new List<int>[targetSum + 1];
            table[0] = new List<int>();

            for (int i = 0; i <= targetSum; i++)
            {
                if (table[i] != null)
                {
                    foreach (int num in numbers)
                    {
                        if (i + num <= targetSum)
                        {
                            List<int> combination = new List<int>(table[i]);
                            combination.Add(num);

                            if (table[i + num] == null || table[i + num].Count > combination.Count)
                            {
                                table[i + num] = combination;
                            }
                        }
                    }
                }
            }

            return table[targetSum];
        }

        //PROBLEMA 6
        public bool canConstructDinamic(string target, string[] wordBank)
        {

            bool[] table = new bool[target.Length + 1];
            table[0] = true;

            for (int i = 0; i <= target.Length; i++)
            {
                if (table[i])
                {
                    foreach (string word in wordBank)
                    {
                        if (i + word.Length <= target.Length && target.Substring(i, word.Length) == word)
                        {
                            table[i + word.Length] = true;
                        }
                    }
                }
            }

            return table[target.Length];
        }

        //PROBLEMA 7
        public int countConstructDinamic(string target, string[] wordBank)
        {

            int[] table = new int[target.Length + 1];
            table[0] = 1;

            for (int i = 0; i <= target.Length; i++)
            {
                foreach (string word in wordBank)
                {
                    if (i + word.Length <= target.Length && target.Substring(i, word.Length) == word)
                    {
                        table[i + word.Length] += table[i];
                    }
                }
            }

            return table[target.Length];
        }

        //PROBLEMA 8
        public List<List<string>> allConstructDinamic(string target, string[] wordBank)
        {
            List<List<string>>[] table = new List<List<string>>[target.Length + 1];
            for (int i = 0; i <= target.Length; i++)
            {
                table[i] = new List<List<string>>();
            }

            table[0].Add(new List<string>());

            for (int i = 0; i <= target.Length; i++)
            {
                foreach (string word in wordBank)
                {
                    if (i + word.Length <= target.Length && target.Substring(i, word.Length) == word)
                    {
                        List<List<string>> newCombinations = new List<List<string>>(table[i]);
                        foreach (List<string> combination in newCombinations)
                        {
                            List<string> newCombination = new List<string>(combination);
                            newCombination.Add(word);
                            table[i + word.Length].Add(newCombination);
                        }
                    }
                }
            }

            return table[target.Length];
        }

    }
}
