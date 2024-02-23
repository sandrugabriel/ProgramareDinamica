using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProgramareDinamica
{
    public class Memorare
    {

        //PROBLEMA 1 
        //Scrieti o functie fib(int n) in care trebuie sa retueneze al n- lea numar din Fibocnacci.
        //Ex: fib(7) = 13
        public int fibRecursiv(int n)
        {

            if (n <= 2) return 1;
            return fibRecursiv(n - 1) + fibRecursiv(n - 2);

        }

        public long fibDinamic(int n, Dictionary<int, long> map = null)
        {
            if (map == null)
                map = new Dictionary<int, long>() { };
            if (map.ContainsKey(n))
                return map[n];
            if (n <= 2) 
                return 1;
            map[n] = fibDinamic(n - 1, map) + fibDinamic(n - 2, map);
            return map[n];
        }

        //PROBLEMA 2 
        //Un calatoar este pe o grila 2d. Incepeti in coltul din stanga sus, iar scopul dvs. este sa calatoriti in cotul din dreapte jos. Va puteti deplase doar
        //in jos sau la dreapata. Returneti cate trasee poate sa parcurga
        //Ex: travel(2,3) = 3
        public int travelRecursiv(int n, int m)
        {
            if (n == 1 && m == 1) return 1;
            if (n == 0 || m == 0) return 0;
            return travelRecursiv(n - 1, m) + travelRecursiv(n, m - 1);

        }

        public long travelDinamic(int n, int m, Dictionary<string, long> map = null)
        {
            string key = n.ToString() + "," + m.ToString();
            if (map == null) map = new Dictionary<string, long>();
            if (n == 1 && m == 1) return 1;
            if (n == 0 || m == 0) return 0;
            if (map.ContainsKey(key)) return map[key];
            map[key] = travelDinamic(n - 1, m,map) + travelDinamic(n, m - 1,map);

            return map[key];
        }

        //PROBLEMA 3
        //Screti o functie canSum(int target, int[] nrs), trebuie sa retureneze un boolean care sa indice daca este sau nu posibil sa se genereze target folosind
        //numere din matrice. Putem utiliza un elemet al vectorului ori de cate ori este necesar.
        public bool canSumRecursiv(int target, int[] numbers)
        {

            if (target == 0) return true;
            if (target < 0) return false;

            for (int i = 0; i < numbers.Length; i++)
            {
                int remainder = target - numbers[i];
                if (canSumRecursiv(remainder, numbers)) return true;
            }

            return false;
        }

        public bool canSumDinamic(int target, int[] numbers, Dictionary<int, bool> map = null)
        {
            if (map == null) { map = new Dictionary<int, bool>(); }
            if (map.ContainsKey(target)) return map[target];
            if (target == 0) return true;
            if (target < 0) return false;

            for (int i = 0; i < numbers.Length; i++)
            {
                int remainder = target - numbers[i];
                if (canSumDinamic(remainder, numbers, map))
                {
                    map[target] = true;
                    return true;
                }
            }

            map[target] = false;
            return false;
        }

        //PROBLEMA 4
        //Scrieti o functie howSum(int target,int[] nrs), trebuie sa returneze un vector care sa contina oricare combinatie de elemente care se aduna exact la
        //target, astfel null.
        public List<int> howSumRecursiv(int target, int[] numbers)
        {

            if (target == 0) return [];
            if (target < 0) return null;

            for (int i = 0; i < numbers.Length; i++)
            {
                int remainder = target - numbers[i];

                List<int> sum = howSumRecursiv((int)remainder, numbers);
                if (sum != null)
                {
                    sum.Add(numbers[i]);
                    return sum;

                }
            }

            return null;
        }

        public List<int> howSumDinamic(int target, int[] numbers, Dictionary<int, List<int>> map = null)
        {
            if (map == null) map = new Dictionary<int, List<int>>();
            if (map.ContainsKey(target)) return map[target];
            if (target == 0) return [];
            if (target < 0) return null;

            for (int i = 0; i < numbers.Length; i++)
            {
                int remainder = target - numbers[i];

                List<int> sum = howSumDinamic((int)remainder, numbers);
                if (sum != null)
                {
                    sum.Add(numbers[i]);
                    map[target] = sum;
                    return sum;

                }
            }

            map[target] = null;
            return null;
        }

        //PROBLEMA 5  
        //Scrieti o functie bestSum(int target,int[] nrs), trebuie sa returneze un vector care sa contina cea mai scurta oricare combinatie de
        //elemente care se aduna exact la target, astfel null.
        public List<int> bestSumRecursiv(int target, int[] numbers)
        {

            if (target == 0) return [];
            if (target < 0) return null;

            List<int> best = null;

            for (int i = 0; i < numbers.Length; i++)
            {
                int remainder = target - numbers[i];
                List<int> comb = bestSumRecursiv((int)remainder, numbers);

                if (comb != null)
                {
                    comb.Add(numbers[i]);

                    if (best == null || comb.Count < best.Count)
                        best = comb;

                }
            }

            return best;
        }

        public List<int> bestSumDinamic(int target, int[] numbers, Dictionary<int, List<int>> map = null)
        {
            if (map == null) map = new Dictionary<int, List<int>>();
            if (map.ContainsKey(target)) return map[target];
            if (target == 0) return [];
            if (target < 0) return null;

            List<int> best = null;

            for (int i = 0; i < numbers.Length; i++)
            {
                int remainder = target - numbers[i];
                List<int> comb = bestSumDinamic(remainder, numbers, map);

                if (comb != null)
                {
                    List<int> combs = comb;
                    combs.Add(numbers[i]);

                    if (best == null || combs.Count < best.Count)
                        best = combs;

                }
            }

            map[target] = best;
            return best;
        }

        //PROBLEMA 6
        public bool canConstructRecurisv(string target, string[] wordBank)
        {

            if (target == "") return true;

            for (int i = 0; i < wordBank.Length; i++)
            {
                if (target.IndexOf(wordBank[i]) == 0)
                {
                    string sufix = target.Substring(wordBank[i].Length);
                    if (canConstructRecurisv(sufix, wordBank)) return true;
                }
            }

            return false;
        }

        public bool canConstructDinamic(string target, string[] wordBank, Dictionary<string, bool> map = null)
        {
            if (map == null) map = new Dictionary<string, bool>();
            if (map.ContainsKey(target)) return map[target];
            if (target == "") return true;

            for (int i = 0; i < wordBank.Length; i++)
            {
                if (target.IndexOf(wordBank[i]) == 0)
                {
                    string sufix = target.Substring(wordBank[i].Length);
                    if (canConstructDinamic(sufix, wordBank, map))
                    {
                        map[target] = true;
                        return true;
                    }
                }
            }

            map[target] = false;
            return false;
        }

        //PROBLEMA 7
        public int countConstructRecurisv(string target, string[] wordBank)
        {

            if (target == "") return 1;

            int ct = 0;

            for (int i = 0; i < wordBank.Length; i++)
            {
                if (target.IndexOf(wordBank[i]) == 0)
                {
                    string sufix = target.Substring(wordBank[i].Length);
                    ct += countConstructRecurisv(sufix, wordBank);
                }
            }

            return ct;
        }

        public int countConstructDinamic(string target, string[] wordBank, Dictionary<string, int> map = null)
        {
            if (map == null) map = new Dictionary<string, int>();
            if (map.ContainsKey(target)) return map[target];
            if (target == "") return 1;

            int ct = 0;
            for (int i = 0; i < wordBank.Length; i++)
            {
                if (target.IndexOf(wordBank[i]) == 0)
                {
                    string sufix = target.Substring(wordBank[i].Length);

                    map[target] = countConstructDinamic(sufix, wordBank, map);
                    ct += map[target];
                }
            }

            map[target] = ct;
            return ct;
        }

        //PROBLEMA 8
        public List<List<string>> allConstructRecurisv(string target, string[] wordBank)
        {

            if (target == "") return [[]];

            List<List<string>> result = [];

            for (int i = 0; i < wordBank.Length; i++)
            {
                if (target.IndexOf(wordBank[i]) == 0)
                {
                    string suffix = target.Substring(wordBank[i].Length);
                    List<List<string>> suffixWays = allConstructRecurisv(suffix, wordBank);

                    List<List<string>> targetWays = new List<List<string>>();
                    foreach (List<string> way in suffixWays)
                    {
                        List<string> newWay = new List<string> { wordBank[i] };
                        newWay.AddRange(way);
                        targetWays.Add(newWay);
                    }

                    result.AddRange(targetWays);
                }
            }

            return result;
        }

        public List<List<string>> allConstructDinamic(string target, string[] wordBank, Dictionary<string, List<List<string>>> map = null)
        {
            if (map == null) map = new Dictionary<string, List<List<string>>>();
            if (map.ContainsKey(target)) return map[target];
            if (target == "") return [[]];

            List<List<string>> result = [];

            for (int i = 0; i < wordBank.Length; i++)
            {
                if (target.IndexOf(wordBank[i]) == 0)
                {
                    string suffix = target.Substring(wordBank[i].Length);
                    List<List<string>> suffixWays = allConstructDinamic(suffix, wordBank, map);

                    List<List<string>> targetWays = new List<List<string>>();
                    foreach (List<string> way in suffixWays)
                    {
                        List<string> newWay = new List<string> { wordBank[i] };
                        newWay.AddRange(way);
                        targetWays.Add(newWay);
                    }

                    map[target] = targetWays;
                    result.AddRange(targetWays);
                }
            }
            map[target] = result;
            return result;
        }


    }
}
