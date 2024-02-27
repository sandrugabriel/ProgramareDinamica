using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Probleme
{
    public class Functii
    {

        /*
        Given an integer n, return an array ans of length n + 1 such that for each i (0 <= i <= n), ans[i] is the number 
         of 1's in the binary representation of i.
    Example 1:
    Input: n = 2
    Output: [0,1,1]
    Explanation:
    0 --> 0
    1 --> 1
    2 --> 10
    Example 2:
    Input: n = 5
    Output: [0,1,1,2,1,2]
    Explanation:
    0 --> 0
    1 --> 1
    2 --> 10
    3 --> 11
    4 --> 100
    5 --> 101*/
        public int[] CountBits(int n)
        {
            int[] ans = new int[n + 1];

            for (int i = 1; i <= n; i++)
            {
                ans[i] = ans[i / 2] + (i % 2);
            }

            return ans;
        }

        /*Given an integer numRows, return the first numRows of Pascal's triangle.
In Pascal's triangle, each number is the sum of the two numbers directly above it as shown:
Example 1:

Input: numRows = 5
Output: [[1],[1,1],[1,2,1],[1,3,3,1],[1,4,6,4,1]]
Example 2:

Input: numRows = 1
Output: [[1]]
         */
        public IList<IList<int>> Generate(int numRows)
        {

            if (numRows == 1)
            {

                return new List<IList<int>>() { new List<int> { 1 } };
            }
            else
            {
                IList < IList<int> > triangle= Generate(numRows-1);

                IList<int> lastRow = triangle[numRows - 2];
                IList<int> newRow = new List<int> { 1 };

                for(int i = 1; i < numRows - 1; i++)
                {
                    newRow.Add(lastRow[i - 1] + lastRow[i]);
                }
                newRow.Add(1);


                triangle.Add(newRow);
                return triangle;

            }
        }

        /*The Fibonacci numbers, commonly denoted F(n) form a sequence, called the Fibonacci sequence, such that each number is 
         * the sum of the two preceding ones, starting from 0 and 1. That is,
F(0) = 0, F(1) = 1
F(n) = F(n - 1) + F(n - 2), for n > 1.
Given n, calculate F(n).
Example 1:
Input: n = 2
Output: 1
Explanation: F(2) = F(1) + F(0) = 1 + 0 = 1.
Example 2:
Input: n = 3
Output: 2
Explanation: F(3) = F(2) + F(1) = 1 + 1 = 2.
Example 3:
Input: n = 4
Output: 3
Explanation: F(4) = F(3) + F(2) = 2 + 1 = 3.*/
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

        /*1025. Divisor Game
    Alice and Bob take turns playing a game, with Alice starting first.
    Initially, there is a number n on the chalkboard.On each player's turn, that player makes a move consisting of:
    Choosing any x with 0 < x<n and n % x == 0.
    Replacing the number n on the chalkboard with n - x.
    Also, if a player cannot make a move, they lose the game.
    Return true if and only if Alice wins the game, assuming both players play optimally.
Example 1:
Input: n = 2
Output: true
Explanation: Alice chooses 1, and Bob has no more moves.
        */
        public bool DivisorGame(int n)
        {
            if (n == 1) return false;
            else
            {
                bool alice = true, bob = false;
                int ct = 0;
                for (int i = 1; i <= n; i++)
                {
                    if (n > i && n % i == 0)
                    {
                        if (ct % 2 == 0)
                        {
                            bob = false;
                            alice = true;
                        }
                        else
                        {
                            alice = false;
                            bob = true;
                        }
                        n = n - i;
                        i = 0;
                        ct++;
                    }
                }

                return alice;
            }

        }

        /*746. Min Cost Climbing Stairs
You are given an integer array cost where cost[i] is the cost of ith step on a staircase. Once you pay the cost, you can either climb one or two steps.
You can either start from the step with index 0, or the step with index 1.
Return the minimum cost to reach the top of the floor.
Example 1:
Input: cost = [10,15,20]
Output: 15
Explanation: You will start at index 1.
- Pay 15 and climb two steps to reach the top.
The total cost is 15.
Example 2:
Input: cost = [1,100,1,1,1,100,1,1,100,1]
Output: 6
Explanation: You will start at index 0.
- Pay 1 and climb two steps to reach index 2.
- Pay 1 and climb two steps to reach index 4.
- Pay 1 and climb two steps to reach index 6.
- Pay 1 and climb one step to reach index 7.
- Pay 1 and climb two steps to reach index 9.
- Pay 1 and climb one step to reach the top.
The total cost is 6.
 */
        public int MinCostClimbingStairs(int[] cost)
        {
            int n = cost.Length;

            int[] dp = new int[n + 1];

            dp[0] = cost[0];
            dp[1] = cost[1];

            for (int i = 2; i <= n; i++)
            {
                int currentCost = (i == n) ? 0 : cost[i];
                dp[i] = Math.Min(dp[i - 1] + currentCost, dp[i - 2] + currentCost);
            }

            return Math.Min(dp[n - 1], dp[n]);
        }

        /*You are given a string array words and a binary array groups both of length n, where words[i] is associated with groups[i].
Your task is to select the longest alternating 
subsequence
from words. A subsequence of words is alternating if for any two consecutive strings in the sequence, their corresponding elements in the 
binary array groups differ. Essentially, you are to choose strings such that adjacent elements have non-matching corresponding bits in the groups array.
Formally, you need to find the longest subsequence of an array of indices [0, 1, ..., n - 1] denoted as [i0, i1, ..., ik-1], such that 
groups[ij] != groups[ij+1] for each 0 <= j < k - 1 and then find the words corresponding to these indices.
Return the selected subsequence. If there are multiple answers, return any of them.
Note: The elements in words are distinct.
Example 1:
Input: words = ["e","a","b"], groups = [0,0,1]
Output: ["e","b"]
Explanation: A subsequence that can be selected is ["e","b"] because groups[0] != groups[2]. Another subsequence that can be 
selected is ["a","b"] because groups[1] != groups[2]. It can be demonstrated that the length of the longest subsequence 
of indices that satisfies the condition is 2.
Example 2:
Input: words = ["a","b","c","d"], groups = [1,0,1,1]
Output: ["a","b","c"]
Explanation: A subsequence that can be selected is ["a","b","c"] because groups[0] != groups[1] and groups[1] != groups[2]. 
Another subsequence that can be selected is ["a","b","d"] because groups[0] != groups[1] and groups[1] != groups[3]. 
It can be shown that the length of the longest subsequence of indices that satisfies the condition is 3.

*/
        public IList<string> GetLongestSubsequence(string[] words, int[] groups)
        {
            List<string> result = new List<string>();
            int n = words.Length;

            for (int i = 0; i < n; i++)
            {
                List<string> currentSubsequence = new List<string>();
                currentSubsequence.Add(words[i]);

                for (int j = i + 1; j < n; j++)
                {
                    if (groups[j] != groups[j - 1])
                    {
                        currentSubsequence.Add(words[j]);
                    }
                }

                if (currentSubsequence.Count > result.Count)
                {
                    result = currentSubsequence;
                }
            }

            return result;
        }

        /*Given an integer rowIndex, return the rowIndexth (0-indexed) row of the Pascal's triangle.
In Pascal's triangle, each number is the sum of the two numbers directly above it as shown:
Example 1:
Input: rowIndex = 3
Output: [1,3,3,1]
Example 2:
Input: rowIndex = 0
Output: [1]
Example 3:
Input: rowIndex = 1
Output: [1,1]*/
        public IList<int> GetRow(int rowIndex)
        {
            if (rowIndex == 0) return [1];
            if (rowIndex == 1) return [1,1];
            return Generate(rowIndex)[rowIndex-1];
        }

        /*You are given an array prices where prices[i] is the price of a given stock on the ith day.
You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.
Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
Example 1:
Input: prices = [7,1,5,3,6,4]
Output: 5
Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.
Example 2:
Input: prices = [7,6,4,3,1]
Output: 0
Explanation: In this case, no transactions are done and the max profit = 0.*/
        public int MaxProf(int[] prices)
        {
            int n = prices.Length;
            int minPrice = int.MaxValue;
            int maxProfit = 0;

            for (int i = 0; i < n; i++)
            {
                minPrice = Math.Min(minPrice, prices[i]);

                maxProfit = Math.Max(maxProfit, prices[i] - minPrice);
            }

            return maxProfit;
        }

        /*70. Climbing Stairs
You are climbing a staircase. It takes n steps to reach the top.
Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?
Example 1:
Input: n = 2
Output: 2
Explanation: There are two ways to climb to the top.
1. 1 step + 1 step
2. 2 steps
Example 2:
Input: n = 3
Output: 3
Explanation: There are three ways to climb to the top.
1. 1 step + 1 step + 1 step
2. 1 step + 2 steps
3. 2 steps + 1 step
*/
        public int ClimbStairs(int n)
        {
            if (n <= 2)
            {
                return n;
            }

            int[] dp = new int[n + 1];
            dp[1] = 1;
            dp[2] = 2;

            for (int i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[n];
        }

        /*392. Is Subsequence
Given two strings s and t, return true if s is a subsequence of t, or false otherwise.
A subsequence of a string is a new string that is formed from the original string by deleting some (can be none) 
of the characters without disturbing the relative positions of the remaining characters. (i.e., "ace" is a subsequence of "abcde" while "aec" is not).
Example 1:
Input: s = "abc", t = "ahbgdc"
Output: true
Example 2:
Input: s = "axc", t = "ahbgdc"
Output: false

*/
        public bool IsSubsequence(string s, string t)
        {
            int sIndex = 0, tIndex = 0;

            while (sIndex < s.Length && tIndex < t.Length)
            {
                if (s[sIndex] == t[tIndex])
                {
                    sIndex++;
                }

                tIndex++;
            }

            return sIndex == s.Length;
        }

        /*Given an integer n, return the number of strings of length n that consist only of vowels (a, e, i, o, u) and are lexicographically sorted.
A string s is lexicographically sorted if for all valid i, s[i] is the same as or comes before s[i+1] in the alphabet.
Example 1:
Input: n = 1
Output: 5
Explanation: The 5 sorted strings that consist of vowels only are ["a","e","i","o","u"].
Example 2:
Input: n = 2
Output: 15
Explanation: The 15 sorted strings that consist of vowels only are
["aa","ae","ai","ao","au","ee","ei","eo","eu","ii","io","iu","oo","ou","uu"].
Note that "ea" is not a valid string since 'e' comes after 'a' in the alphabet.
Example 3:
Input: n = 33
Output: 66045*/
        public int CountVowelStrings(int n)
        {
            int[,] dp = new int[n + 1, 5];

            for (int i = 0; i < 5; i++)
            {
                dp[1, i] = 1;
            }

            for (int i = 2; i <= n; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int k = j; k < 5; k++)
                    {
                        dp[i, j] += dp[i - 1, k];
                    }
                }
            }

            int result = 0;
            for (int i = 0; i < 5; i++)
            {
                result += dp[n, i];
            }

            return result;
        }

        /*1043. Partition Array for Maximum Sum
Given an integer array arr, partition the array into (contiguous) subarrays of length at most k. After partitioning, each subarray 
        has their values changed to become the maximum value of that subarray.
Return the largest sum of the given array after partitioning. Test cases are generated so that the answer fits in a 32-bit integer.
Example 1:
Input: arr = [1,15,7,9,2,5,10], k = 3
Output: 84
Explanation: arr becomes [15,15,15,9,10,10,10]
Example 2:
Input: arr = [1,4,1,5,7,3,6,1,9,9,3], k = 4
Output: 83
Example 3:
Input: arr = [1], k = 1
Output: 1*/
        public int MaxSumAfterPartitioning(int[] arr, int k)
        {
            int n = arr.Length;
            int[] dp = new int[n + 1];

            for (int i = 1; i <= n; i++)
            {
                int currentMax = 0;
                for (int j = 1; j <= Math.Min(k, i); j++)
                {
                    currentMax = Math.Max(currentMax, arr[i - j]);
                    dp[i] = Math.Max(dp[i], dp[i - j] + currentMax * j);
                }
            }

            return dp[n];
        }

        /*Given a m * n matrix of ones and zeros, return how many square submatrices have all ones.
Example 1:
Input: matrix =
[
  [0,1,1,1],
  [1,1,1,1],
  [0,1,1,1]
]
Output: 15
Explanation: 
There are 10 squares of side 1.
There are 4 squares of side 2.
There is  1 square of side 3.
Total number of squares = 10 + 4 + 1 = 15.
Example 2:
Input: matrix = 
[
  [1,0,1],
  [1,1,0],
  [1,1,0]
]
Output: 7
Explanation: 
There are 6 squares of side 1.  
There is 1 square of side 2. 
Total number of squares = 6 + 1 = 7.*/
        public int CountSquares(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            int[,] dp = new int[m, n];
            int count = 0;

            for (int i = 0; i < m; i++)
            {
                dp[i, 0] = matrix[i][0];
                count += dp[i, 0];
            }

            for (int j = 1; j < n; j++)
            {
                dp[0, j] = matrix[0][j];
                count += dp[0, j];
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (matrix[i][j] == 1)
                    {
                        dp[i, j] = Math.Min(dp[i - 1, j], Math.Min(dp[i, j - 1], dp[i - 1, j - 1])) + 1;
                        count += dp[i, j];
                    }
                }
            }

            return count;
        }

        /*Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
Example 1:
Input: n = 3
Output: ["((()))","(()())","(())()","()(())","()()()"]
Example 2:
Input: n = 1
Output: ["()"]
 */
        public IList<string> GenerateParenthesis(int n)
        {
            List<string> result = new List<string>();
            GenerateParen(n, n, "", result);
            return result;
        }
        private void GenerateParen(int left, int right, string current, List<string> result)
        {
            if (left == 0 && right == 0)
            {
                result.Add(current);
                return;
            }

            if (left > 0)
            {
                GenerateParen(left - 1, right, current + "(", result);
            }

            if (right > left)
            {
                GenerateParen(left, right - 1, current + ")", result);
            }
        }

        /*You are given two identical eggs and you have access to a building with n floors labeled from 1 to n.
You know that there exists a floor f where 0 <= f <= n such that any egg dropped at a floor higher than f will break, 
        and any egg dropped at or below floor f will not break.
In each move, you may take an unbroken egg and drop it from any floor x (where 1 <= x <= n). If the egg breaks, you 
        can no longer use it. However, if the egg does not break, you may reuse it in future moves.
Return the minimum number of moves that you need to determine with certainty what the value of f is.
Example 1:
Input: n = 2
Output: 2
Explanation: We can drop the first egg from floor 1 and the second egg from floor 2.
If the first egg breaks, we know that f = 0.
If the second egg breaks but the first egg didn't, we know that f = 1.
Otherwise, if both eggs survive, we know that f = 2.
Example 2:
Input: n = 100
Output: 14
Explanation: One optimal strategy is:
- Drop the 1st egg at floor 9. If it breaks, we know f is between 0 and 8. Drop the 2nd egg starting from floor 1 and going 
        up one at a time to find f within 8 more drops. Total drops is 1 + 8 = 9.
- If the 1st egg does not break, drop the 1st egg again at floor 22. If it breaks, we know f is between 9 and 21. Drop the
        2nd egg starting from floor 10 and going up one at a time to find f within 12 more drops. Total drops is 2 + 12 = 14.
- If the 1st egg does not break again, follow a similar process dropping the 1st egg from floors 34, 45, 55, 64, 72, 79, 85, 90, 94, 97, 99, and 100.
Regardless of the outcome, it takes at most 14 drops to determine f.*/
            public int TwoEggDrop(int n)
            {

                int moves = 0;
                int k = 2;

                while (n > 0)
                {
                    moves++;
                    n -= moves;
                }

                return moves;
            }

        /*Given two strings s and t, find the number of ways you can choose a non-empty substring of s and replace a 
         * single character by a different character such that the resulting substring is a substring of t. In 
         * other words, find the number of substrings in s that differ from some substring in t by exactly one character.
For example, the underlined substrings in "computer" and "computation" only differ by the 'e'/'a', so this is a valid way.
Return the number of substrings that satisfy the condition above.
A substring is a contiguous sequence of characters within a string.
Example 1:
Input: s = "aba", t = "baba"
Output: 6
Explanation: The following are the pairs of substrings from s and t that differ by exactly 1 character:
("aba", "baba")
("aba", "baba")
("aba", "baba")
("aba", "baba")
("aba", "baba")
("aba", "baba")
The underlined portions are the substrings that are chosen from s and t.
​​Example 2:
Input: s = "ab", t = "bb"
Output: 3
Explanation: The following are the pairs of substrings from s and t that differ by 1 character:
("ab", "bb")
("ab", "bb")
("ab", "bb")
​​​​The underlined portions are the substrings that are chosen from s and t.*/
        public int CountSubstrings(string s, string t)
        {
            int result = 0;
            int m = s.Length;
            int n = t.Length;

            for (int len = 1; len <= m; len++)
            {
                for (int i = 0; i + len - 1 < m; i++)
                {
                    string substringS = s.Substring(i, len);

                    for (int j = 0; j + len - 1 < n; j++)
                    {
                        string substringT = t.Substring(j, len);

                        if (CountDifferences(substringS, substringT) == 1)
                        {
                            result++;
                        }
                    }
                }
            }

            return result;
        }
        private int CountDifferences(string s1, string s2)
        {
            int differences = 0;

            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    differences++;
                }
            }

            return differences;
        }

        /*Alice and Bob play a game with piles of stones. There are an even number of piles arranged in a row, and each 
         * pile has a positive integer number of stones piles[i].
The objective of the game is to end with the most stones. The total number of stones across all the piles is odd, so there are no ties.
Alice and Bob take turns, with Alice starting first. Each turn, a player takes the entire pile of stones 
        either from the beginning or from the end of the row. This continues until there are no more piles 
        left, at which point the person with the most stones wins.
Assuming Alice and Bob play optimally, return true if Alice wins the game, or false if Bob wins.
Example 1:
Input: piles = [5,3,4,5]
Output: true
Explanation: 
Alice starts first, and can only take the first 5 or the last 5.
Say she takes the first 5, so that the row becomes [3, 4, 5].
If Bob takes 3, then the board is [4, 5], and Alice takes 5 to win with 10 points.
If Bob takes the last 5, then the board is [3, 4], and Alice takes 4 to win with 9 points.
This demonstrated that taking the first 5 was a winning move for Alice, so we return true.
Example 2:
Input: piles = [3,7,2,3]
Output: true*/
        public bool StoneGame(int[] piles)
        {
            int n = piles.Length;
            int[,] dp = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                dp[i, i] = piles[i];
            }

            for (int len = 2; len <= n; len++)
            {
                for (int i = 0; i <= n - len; i++)
                {
                    int j = i + len - 1;

                    int pickStart = piles[i] - dp[i + 1, j];
                    int pickEnd = piles[j] - dp[i, j - 1];
                    dp[i, j] = Math.Max(pickStart, pickEnd);
                }
            }

            return dp[0, n - 1] > 0;
        }

        /*Given a string s, return the number of palindromic substrings in it.
A string is a palindrome when it reads the same backward as forward.
A substring is a contiguous sequence of characters within the string.
Example 1:
Input: s = "abc"
Output: 3
Explanation: Three palindromic strings: "a", "b", "c".
Example 2:
Input: s = "aaa"
Output: 6
Explanation: Six palindromic strings: "a", "a", "a", "aa", "aa", "aaa".*/
        public int CountSubstrings(string s)
        {
            int count = 0;

            for (int i = 0; i < 2 * s.Length - 1; i++)
            {
                int left = i / 2;
                int right = left + i % 2;

                while (left >= 0 && right < s.Length && s[left] == s[right])
                {
                    count++;
                    left--;
                    right++;
                }
            }

            return count;
        }

        /*The power of an integer x is defined as the number of steps needed to transform x into 1 using the following steps:
if x is even then x = x / 2
if x is odd then x = 3 * x + 1
For example, the power of x = 3 is 7 because 3 needs 7 steps to become 1 (3 --> 10 --> 5 --> 16 --> 8 --> 4 --> 2 --> 1).

Given three integers lo, hi and k. The task is to sort all integers in the interval [lo, hi] by the power value in 
        ascending order, if two or more integers have the same power value sort them by ascending order.

Return the kth integer in the range [lo, hi] sorted by the power value.

Notice that for any integer x (lo <= x <= hi) it is guaranteed that x will transform into 1 using these steps and 
        that the power of x is will fit in a 32-bit signed integer.
Example 1:

Input: lo = 12, hi = 15, k = 2
Output: 13
Explanation: The power of 12 is 9 (12 --> 6 --> 3 --> 10 --> 5 --> 16 --> 8 --> 4 --> 2 --> 1)
The power of 13 is 9
The power of 14 is 17
The power of 15 is 17
The interval sorted by the power value [12,13,14,15]. For k = 2 answer is the second element which is 13.
Notice that 12 and 13 have the same power value and we sorted them in ascending order. Same for 14 and 15.
Example 2:

Input: lo = 7, hi = 11, k = 4
Output: 7
Explanation: The power array corresponding to the interval [7, 8, 9, 10, 11] is [16, 3, 19, 6, 14].
The interval sorted by power is [8, 10, 11, 7, 9].
The fourth number in the sorted array is 7.*/
        public int GetKth(int lo, int hi, int k)
        {
            List<int> nums = new List<int>();

            for (int i = lo; i <= hi; i++)
            {
                nums.Add(i);
            }

            nums.Sort((a, b) => {
                int powerA = GetPower(a);
                int powerB = GetPower(b);

                if (powerA != powerB)
                {
                    return powerA.CompareTo(powerB);
                }
                else
                {
                    return a.CompareTo(b);
                }
            });

            return nums[k - 1];
        }
        private int GetPower(int num)
        {
            int steps = 0;

            while (num != 1)
            {
                if (num % 2 == 0)
                {
                    num /= 2;
                }
                else
                {
                    num = 3 * num + 1;
                }
                steps++;
            }

            return steps;
        }
        /*You are given a string s.
A split is called good if you can split s into two non-empty strings sleft and sright where their concatenation is equal 
        to s (i.e., sleft + sright = s) and the number of distinct letters in sleft and sright is the same.
Return the number of good splits you can make in s.
Example 1:
Input: s = "aacaba"
Output: 2
Explanation: There are 5 ways to split "aacaba" and 2 of them are good. 
("a", "acaba") Left string and right string contains 1 and 3 different letters respectively.
("aa", "caba") Left string and right string contains 1 and 3 different letters respectively.
("aac", "aba") Left string and right string contains 2 and 2 different letters respectively (good split).
("aaca", "ba") Left string and right string contains 2 and 2 different letters respectively (good split).
("aacab", "a") Left string and right string contains 3 and 1 different letters respectively.
Example 2:
Input: s = "abcd"
Output: 1
Explanation: Split the string as follows ("ab", "cd").*/
        public int NumSplits(string s)
        {
            int n = s.Length;
            int[] leftDistinct = new int[n];
            int[] rightDistinct = new int[n];

            HashSet<char> leftSet = new HashSet<char>();
            HashSet<char> rightSet = new HashSet<char>();

            for (int i = 0; i < n; i++)
            {
                leftSet.Add(s[i]);
                leftDistinct[i] = leftSet.Count;
            }

            for (int i = n - 1; i >= 0; i--)
            {
                rightSet.Add(s[i]);
                rightDistinct[i] = rightSet.Count;
            }

            int goodSplits = 0;

            for (int i = 0; i < n - 1; i++)
            {
                if (leftDistinct[i] == rightDistinct[i + 1])
                {
                    goodSplits++;
                }
            }

            return goodSplits;
        }

        /*You are given an array prices where prices[i] is the price of a given stock on the ith day, and an integer fee representing a transaction fee.
Find the maximum profit you can achieve. You may complete as many transactions as you like, but you need to pay the transaction fee for each transaction.
Note:
You may not engage in multiple transactions simultaneously (i.e., you must sell the stock before you buy again).
The transaction fee is only charged once for each stock purchase and sale.
Example 1:
Input: prices = [1,3,2,8,4,9], fee = 2
Output: 8
Explanation: The maximum profit can be achieved by:
- Buying at prices[0] = 1
- Selling at prices[3] = 8
- Buying at prices[4] = 4
- Selling at prices[5] = 9
The total profit is ((8 - 1) - 2) + ((9 - 4) - 2) = 8.
Example 2:

Input: prices = [1,3,7,5,10,3], fee = 3
Output: 6*/
        public int MaxProfit(int[] prices, int fee)
        {
            int n = prices.Length;

            int[,] dp = new int[n, 2];

            dp[0, 0] = 0;
            dp[0, 1] = -prices[0] - fee;

            for (int i = 1; i < n; i++)
            {
                dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]);

                dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 1, 0] - prices[i] - fee);
            }

            return dp[n - 1, 0];
        }

        /*Alice and Bob continue their games with piles of stones.  There are a number of piles arranged in a row, and each pile
         * has a positive integer number of stones piles[i].  The objective of the game is to end with the most stones. 
Alice and Bob take turns, with Alice starting first.  Initially, M = 1.
On each player's turn, that player can take all the stones in the first X remaining piles, where 1 <= X <= 2M.  Then, we set M = max(M, X).
The game continues until all the stones have been taken.
Assuming Alice and Bob play optimally, return the maximum number of stones Alice can get.
Example 1:
Input: piles = [2,7,9,4,4]
Output: 10
Explanation:  If Alice takes one pile at the beginning, Bob takes two piles, then Alice takes 2 piles again. Alice can get 2 + 4 + 4 = 10 piles in total. If Alice takes two piles at the beginning, then Bob can take all three piles left. In this case, Alice get 2 + 7 = 9 piles in total. So we return 10 since it's larger. 
Example 2:

Input: piles = [1,2,3,4,5,100]
Output: 104
 */
        public int StoneGameII(int[] piles)
        {
            int n = piles.Length;

            int[,] dp = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                dp[i, i] = piles[i];
            }

            for (int len = 2; len <= n; len++)
            {
                for (int i = 0; i <= n - len; i++)
                {
                    int j = i + len - 1;
                    int takeFirst = piles[i] - dp[i + 1, j];
                    int takeLast = piles[j] - dp[i, j - 1];
                    dp[i, j] = Math.Max(takeFirst, takeLast);
                }
            }

            return dp[0, n - 1];
        }

        /*Given an array arr of positive integers, consider all binary trees such that:
Each node has either 0 or 2 children;
The values of arr correspond to the values of each leaf in an in-order traversal of the tree.
The value of each non-leaf node is equal to the product of the largest leaf value in its left and right subtree, respectively.
Among all possible binary trees considered, return the smallest possible sum of the values of each non-leaf node. It is 
        guaranteed this sum fits into a 32-bit integer.
A node is a leaf if and only if it has zero children
Example 1:
Input: arr = [6,2,4]
Output: 32
Explanation: There are two possible trees shown.
The first has a non-leaf node sum 36, and the second has non-leaf node sum 32.
Example 2:
Input: arr = [4,11]
Output: 44*/
        public int MctFromLeafValues(int[] arr)
        {
            int n = arr.Length;

            int[,] dp = new int[n, n];

            int[,] maxLeaf = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                int maxVal = arr[i];

                for (int j = i; j < n; j++)
                {
                    maxVal = Math.Max(maxVal, arr[j]);
                    maxLeaf[i, j] = maxVal;
                }
            }

            for (int len = 2; len <= n; len++)
            {
                for (int i = 0; i <= n - len; i++)
                {
                    int j = i + len - 1;
                    dp[i, j] = int.MaxValue;

                    for (int k = i; k < j; k++)
                    {
                        dp[i, j] = Math.Min(dp[i, j], dp[i, k] + dp[k + 1, j] + maxLeaf[i, k] * maxLeaf[k + 1, j]);
                    }
                }
            }

            return dp[0, n - 1];
        }

        /*Given a string s, partition s such that every 
substring
of the partition is a 
palindrome
. Return all possible palindrome partitioning of s.
Example 1:
Input: s = "aab"
Output: [["a","a","b"],["aa","b"]]
Example 2:
Input: s = "a"
Output: [["a"]]*/
        public IList<IList<string>> Partition(string s)
        {
            IList<IList<string>> result = new List<IList<string>>();
            List<string> currentPartition = new List<string>();
            Backtrack(result, currentPartition, s, 0);
            return result;
        }
        private void Backtrack(IList<IList<string>> result, List<string> currentPartition, string s, int start)
        {
            if (start == s.Length)
            {
                result.Add(new List<string>(currentPartition));
                return;
            }

            for (int end = start; end < s.Length; end++)
            {
                if (IsPalindrome(s, start, end))
                {
                    currentPartition.Add(s.Substring(start, end - start + 1));
                    Backtrack(result, currentPartition, s, end + 1);
                    currentPartition.RemoveAt(currentPartition.Count - 1);
                }
            }
        }
        private bool IsPalindrome(string s, int start, int end)
        {
            while (start < end)
            {
                if (s[start] != s[end])
                {
                    return false;
                }
                start++;
                end--;
            }
            return true;
        }

        /*Given a binary array nums, you should delete one element from it.
Return the size of the longest non-empty subarray containing only 1's in the resulting array. Return 0 if there is no such subarray.
Example 1:
Input: nums = [1,1,0,1]
Output: 3
Explanation: After deleting the number in position 2, [1,1,1] contains 3 numbers with value of 1's.
Example 2:
Input: nums = [0,1,1,1,0,1,1,0,1]
Output: 5
Explanation: After deleting the number in position 4, [0,1,1,1,1,1,0,1] longest subarray with value of 1's is [1,1,1,1,1].
Example 3:
Input: nums = [1,1,1]
Output: 2
Explanation: You must delete one element.
*/
        public int LongestSubarray(int[] nums)
        {
            int left = 0;
            int right = 0;
            int maxCount = 0;
            int zeroCount = 0;

            while (right < nums.Length)
            {
                if (nums[right] == 0)
                {
                    zeroCount++;
                }

                while (zeroCount > 1)
                {
                    if (nums[left] == 0)
                    {
                        zeroCount--;
                    }
                    left++;
                }

                maxCount = Math.Max(maxCount, right - left);

                right++;
            }

            return maxCount;
        }

        /*n passengers board an airplane with exactly n seats. The first passenger has lost the ticket and picks a seat randomly.
 * But after that, the rest of the passengers will:
Take their own seat if it is still available, and
Pick other seats randomly when they find their seat occupied
Return the probability that the nth person gets his own seat.
Example 1:
Input: n = 1
Output: 1.00000
Explanation: The first person can only get the first seat.
Example 2:
Input: n = 2
Output: 0.50000
Explanation: The second person has a probability of 0.5 to get the second seat (when first person gets the first seat).
*/
        public double NthPersonGetsNthSeat(int n)
        {
            return n == 1 ? 1.0 : 0.5;
        }

        /*There are n soldiers standing in a line. Each soldier is assigned a unique rating value.
You have to form a team of 3 soldiers amongst them under the following rules:
Choose 3 soldiers with index (i, j, k) with rating (rating[i], rating[j], rating[k]).
A team is valid if: (rating[i] < rating[j] < rating[k]) or (rating[i] > rating[j] > rating[k]) where (0 <= i < j < k < n).
Return the number of teams you can form given the conditions. (soldiers can be part of multiple teams).
Example 1:
Input: rating = [2,5,3,4,1]
Output: 3
Explanation: We can form three teams given the conditions. (2,3,4), (5,4,1), (5,3,1). 
Example 2:
Input: rating = [2,1,3]
Output: 0
Explanation: We can't form any team given the conditions.
Example 3:
Input: rating = [1,2,3,4]
Output: 4
*/
        public int NumTeams(int[] rating)
        {
            int n = rating.Length;
            int count = 0;

            for (int j = 0; j < n; j++)
            {
                int leftSmaller = 0, rightLarger = 0, leftLarger = 0, rightSmaller = 0;

                for (int i = 0; i < j; i++)
                {
                    if (rating[i] < rating[j])
                    {
                        leftSmaller++;
                    }
                    else if (rating[i] > rating[j])
                    {
                        leftLarger++;
                    }
                }

                for (int k = j + 1; k < n; k++)
                {
                    if (rating[j] < rating[k])
                    {
                        rightLarger++;
                    }
                    else if (rating[j] > rating[k])
                    {
                        rightSmaller++;
                    }
                }

                count += (leftSmaller * rightLarger) + (leftLarger * rightSmaller);
            }

            return count;
        }

        /*You are given an integer array prices where prices[i] is the price of a given stock on the ith day.
On each day, you may decide to buy and/or sell the stock. You can only hold at most one share of the stock at any time. 
However, you can buy it then immediately sell it on the same day.
Find and return the maximum profit you can achieve.
Example 1:
Input: prices = [7,1,5,3,6,4]
Output: 7
Explanation: Buy on day 2 (price = 1) and sell on day 3 (price = 5), profit = 5-1 = 4.
Then buy on day 4 (price = 3) and sell on day 5 (price = 6), profit = 6-3 = 3.
Total profit is 4 + 3 = 7.
Example 2:
Input: prices = [1,2,3,4,5]
Output: 4
Explanation: Buy on day 1 (price = 1) and sell on day 5 (price = 5), profit = 5-1 = 4.
Total profit is 4.
Example 3:
Input: prices = [7,6,4,3,1]
Output: 0
Explanation: There is no way to make a positive profit, so we never buy the stock to achieve the maximum profit of 0.
*/
        public int MaxProfit(int[] prices)
        {
            int n = prices.Length;
            int maxProfit = 0;

            for (int i = 1; i < n; i++)
            {
                if (prices[i] > prices[i - 1])
                {
                    maxProfit += prices[i] - prices[i - 1];
                }
            }

            return maxProfit;
        }

        /*The Tribonacci sequence Tn is defined as follows: 
T0 = 0, T1 = 1, T2 = 1, and Tn+3 = Tn + Tn+1 + Tn+2 for n >= 0. // Tn = (Tn+1+Tn+2)-Tn+3
Given n, return the value of Tn.
Example 1:
Input: n = 4
Output: 4
Explanation:
T_3 = 0 + 1 + 1 = 2
T_4 = 1 + 1 + 2 = 4
Example 2:
Input: n = 25
Output: 1389537
 */
        public int TribonacciRecursiv(int n)
        {
            if(n==0) return 0;
            else if (n<= 2) return 1;

            return (TribonacciRecursiv(n-1) + TribonacciRecursiv(n-2)) + TribonacciRecursiv(n-3);
        }
        public int TribonacciDinamic(int n, Dictionary<int, int> map=null)
        {
            if(map == null) map = new Dictionary<int, int>();
            if(map.ContainsKey(n)) return map[n];
            if (n == 0) return 0;
            else if (n <= 2) return 1; 

            map[n] = (TribonacciDinamic(n - 1,map) + TribonacciDinamic(n - 2,map)) + TribonacciDinamic(n - 3,map);
            return map[n];
        }

        //
        //?????
        /*You are given an integer array cookies, where cookies[i] denotes the number of cookies in the ith bag. You are 
         * also given an integer k that denotes the number of children to distribute all the bags of cookies to. All 
         * the cookies in the same bag must go to the same child and cannot be split up.
The unfairness of a distribution is defined as the maximum total cookies obtained by a single child in the distribution.
Return the minimum unfairness of all distributions.
Example 1:

Input: cookies = [8,15,10,20,8], k = 2
Output: 31
Explanation: One optimal distribution is [8,15,8] and [10,20]
- The 1st child receives [8,15,8] which has a total of 8 + 15 + 8 = 31 cookies.
- The 2nd child receives [10,20] which has a total of 10 + 20 = 30 cookies.
The unfairness of the distribution is max(31,30) = 31.
It can be shown that there is no distribution with an unfairness less than 31.
Example 2:

Input: cookies = [6,1,3,2,2,4,1,2], k = 3
Output: 7
Explanation: One optimal distribution is [6,1], [3,2,2], and [4,1,2]
- The 1st child receives [6,1] which has a total of 6 + 1 = 7 cookies.
- The 2nd child receives [3,2,2] which has a total of 3 + 2 + 2 = 7 cookies.
- The 3rd child receives [4,1,2] which has a total of 4 + 1 + 2 = 7 cookies.
The unfairness of the distribution is max(7,7,7) = 7.
It can be shown that there is no distribution with an unfairness less than 7.
 */

        //cookies = [8,15,10,20,8], k = 2
        public int DistributeCookies(int[] cookies, int k)
        {

            int Distribute(int index, int[] children)
            {
                if (index == cookies.Length)
                {
                    int maximCookies = 0;
                    foreach(var child in  children)
                    {
                        maximCookies = Math.Max(maximCookies, child);
                    }
                    return maximCookies;
                }

                int min = Int32.MaxValue;
                for(int i = 0; i < k; i++)
                {
                    children[i] += cookies[index];
                    min=Math.Min(min, Distribute(index+1,children));
                    children[i] -= cookies[index];
                }
                return min;
             }


            int[] children = new int[k];


            return Distribute(0, children);

        }

        /*You have planned some train traveling one year in advance. The days of the year in which you will travel are given as an 
         * integer array days. Each day is an integer from 1 to 365.
Train tickets are sold in three different ways:
a 1-day pass is sold for costs[0] dollars,
a 7-day pass is sold for costs[1] dollars, and
a 30-day pass is sold for costs[2] dollars.
The passes allow that many days of consecutive travel.
For example, if we get a 7-day pass on day 2, then we can travel for 7 days: 2, 3, 4, 5, 6, 7, and 8.
Return the minimum number of dollars you need to travel every day in the given list of days.
Example 1:
Input: days = [1,4,6,7,8,20], costs = [2,7,15]
Output: 11*/
        public int MincostTickets(int[] days, int[] costs)
        {
            int[] validZile = new int[366];

            foreach (int day in days)
            {
                validZile[day] = 1;
            }

            //Console.WriteLine(validZile.Min);
            int[] suma = new int[366];

            for(int i = days[0]; i <= 365; i++)
            {
                if (validZile[i] != 1)
                {
                    suma[i] = suma[i - 1];
                }
                else
                {
                    int ziua1 = suma[i-1] + costs[0];
                    int ziua7 = suma[Math.Max(0,i-7)] + costs[1];
                    int ziua30 = suma[Math.Max(0,i-30)] + costs[2];

                   // Console.WriteLine($"{ziua1} {ziua7} {ziua30}");
                    if (Math.Min(ziua1, ziua7) > Math.Min(ziua1, ziua30))
                    {
                        suma[i] = Math.Min(ziua1, ziua30);
                    }
                    else
                    {
                        suma[i] = Math.Min(ziua1, ziua7);

                    }

                }
            }

            return suma[365];
        }

        /*Given a string expression of numbers and operators, return all possible results from computing all the different possible
         * ways to group numbers and operators. You may return the answer in any order.
The test cases are generated such that the output values fit in a 32-bit integer and the number of different results does not exceed 104.
Example 1:
Input: expression = "2-1-1"
Output: [0,2]
Explanation:
((2-1)-1) = 0 
(2-(1-1)) = 2
Example 2:
Input: expression = "2*3-4*5"
Output: [-34,-14,-10,-10,10]
Explanation:
(2*(3-(4*5))) = -34 
((2*3)-(4*5)) = -14 
((2*(3-4))*5) = -10 
(2*((3-4)*5)) = -10 
(((2*3)-4)*5) = 10*/
        public IList<int> DiffWaysToCompute(string expression)
        {
            return Ways(expression, new Dictionary<string, List<int>>());
        }

        private IList<int> Ways(string expression, Dictionary<string, List<int>> memo)
        {
            if (memo.ContainsKey(expression))
            {
                return memo[expression];
            }

            var result = new List<int>();
            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];
                if (c == '+' || c == '-' || c == '*')
                {
                    var left = Ways(expression.Substring(0, i), memo);
                    var right = Ways(expression.Substring(i + 1), memo);

                    foreach (var l in left)
                    {
                        foreach (var r in right)
                        {
                            switch (c)
                            {
                                case '+':
                                    result.Add(l + r);
                                    break;
                                case '-':
                                    result.Add(l - r);
                                    break;
                                case '*':
                                    result.Add(l * r);
                                    break;
                            }
                        }
                    }
                }
            }

            if (!result.Any())
            {
                result.Add(int.Parse(expression));
            }

            memo[expression] = result;
            return result;
        }

    }
}
