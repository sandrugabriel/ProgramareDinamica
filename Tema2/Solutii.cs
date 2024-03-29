﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema2
{
    public class Solutii
    {
        Functii functii = new Functii();

        /*An integer array is called arithmetic if it consists of at least three elements and if the difference between any two 
         * consecutive elements is the same.
For example, [1,3,5,7,9], [7,7,7,7], and [3,-1,-5,-9] are arithmetic sequences.
Given an integer array nums, return the number of arithmetic subarrays of nums.
A subarray is a contiguous subsequence of the array.
Example 1:
Input: nums = [1,2,3,4]
Output: 3
Explanation: We have 3 arithmetic slices in nums: [1, 2, 3], [2, 3, 4] and [1,2,3,4] itself.*/
        public void solutia1()
        {
            Console.WriteLine(functii.NumberOfArithmeticSlices([1, 2, 3, 4]));
        }

        /*Given two strings s1 and s2, return the lowest ASCII sum of deleted characters to make two strings equal.
Example 1
Input: s1 = "sea", s2 = "eat"
Output: 231
Explanation: Deleting "s" from "sea" adds the ASCII value of "s" (115) to the sum.
Deleting "t" from "eat" adds 116 to the sum.
At the end, both strings are equal, and 115 + 116 = 231 is the minimum sum possible to achieve this.
Example 2:
Input: s1 = "delete", s2 = "leet"
Output: 403
Explanation: Deleting "dee" from "delete" to turn the string into "let",
adds 100[d] + 101[e] + 101[e] to the sum.
Deleting "e" from "leet" adds 101[e] to the sum.
At the end, both strings are equal to "let", and the answer is 100+101+101+101 = 403.
If instead we turned both strings into "lee" or "eet", we would get answers of 433 or 417, which are higher.*/
        public void solutia2()
        {
            Console.WriteLine(functii.MinimumDeleteSum("delete","leet"));
        }

        /*Given an n x n array of integers matrix, return the minimum sum of any falling path through matrix.
A falling path starts at any element in the first row and chooses the element in the next row that is either directly 
below or diagonally left/right. Specifically, the next element from position (row, col) will be (row + 1, col - 1), 
(row + 1, col), or (row + 1, col + 1).
Example 1:
Input: matrix = [[2,1,3],[6,5,4],[7,8,9]]
Output: 13
Explanation: There are two falling paths with a minimum sum as shown.
Example 2:
Input: matrix = [[-19,57],[-40,-5]]
Output: -59
Explanation: The falling path with a minimum sum is shown.
*/
        public void solutia3()
        {
            Console.WriteLine(functii.MinFallingPathSum([[2, 1, 3], [6, 5, 4], [7, 8, 9]]));
        }

        /*Suppose you have n integers labeled 1 through n. A permutation of those n integers perm (1-indexed) is considered a 
         * beautiful arrangement if for every i (1 <= i <= n), either of the following is true:
perm[i] is divisible by i.
i is divisible by perm[i].
Given an integer n, return the number of the beautiful arrangements that you can construct.
Example 1:
Input: n = 2
Output: 2
Explanation: 
The first beautiful arrangement is [1,2]:
    - perm[1] = 1 is divisible by i = 1
    - perm[2] = 2 is divisible by i = 2
The second beautiful arrangement is [2,1]:
    - perm[1] = 2 is divisible by i = 1
    - i = 2 is divisible by perm[2] = 1
Example 2:
Input: n = 1
Output: 1*/
        public void solutia4()
        {
            Console.WriteLine(functii.CountArrangement(2));
        }

        /*There is a robot on an m x n grid. The robot is initially located at the top-left corner (i.e., grid[0][0]). The robot 
         * tries to move to the bottom-right corner (i.e., grid[m - 1][n - 1]). The robot can only move either down or right at any point in time
Given the two integers m and n, return the number of possible unique paths that the robot can take to reach the bottom-right corner.
The test cases are generated so that the answer will be less than or equal to 2 * 109.
Example 1:
Input: m = 3, n = 7
Output: 28
Example 2:
Input: m = 3, n = 2
Output: 3
Explanation: From the top-left corner, there are a total of 3 ways to reach the bottom-right corner:
1. Right -> Down -> Down
2. Down -> Down -> Right
3. Down -> Right -> Down
 */
        public void solutia5()
        {
            Console.WriteLine(functii.travelDinamic(2,3));
        }

        /*You are given an integer array coins representing coins of different denominations and an integer amount representing a total amount of money.
Return the number of combinations that make up that amount. If that amount of money cannot be made up by any combination of the coins, return 0.
You may assume that you have an infinite number of each kind of coin.
The answer is guaranteed to fit into a signed 32-bit integer.
Example 1:
Input: amount = 5, coins = [1,2,5]
Output: 4
Explanation: there are four ways to make up the amount:
5=5
5=2+2+1
5=2+1+1+1
5=1+1+1+1+1
Example 2
Input: amount = 3, coins = [2]
Output: 0
Explanation: the amount of 3 cannot be made up just with coins of 2.
Example 3:
Input: amount = 10, coins = [10]
Output: 1
*/
        public void solutia6()
        {
            Console.WriteLine(functii.Change(5, [1,2,5]));
        }

        /*Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right, which minimizes the sum of 
         * all numbers along its path.
Note: You can only move either down or right at any point in time.
Example 1:
Input: grid = [[1,3,1],[1,5,1],[4,2,1]]
Output: 7
Explanation: Because the path 1 → 3 → 1 → 1 → 1 minimizes the sum.
Example 2:

Input: grid = [[1,2,3],[4,5,6]]
Output: 12*/
        public void solutia7()
        {
            Console.WriteLine(functii.MinPathSum([[1, 3, 1], [1, 5, 1], [4, 2, 1]]));
        }

        /*Given a string s, find the longest palindromic subsequence's length in s.
A subsequence is a sequence that can be derived from another sequence by deleting some or no elements without changing the order of the remaining elements.
Example 1
Input: s = "bbbab"
Output: 4
Explanation: One possible longest palindromic subsequence is "bbbb".
Example 2:
Input: s = "cbbd"
Output: 2
Explanation: One possible longest palindromic subsequence is "bb".
 */
        public void solutia8()
        {
            Console.WriteLine(functii.LongestPalindromeSubseq("bbbab"));
        }

        /*A binary string is monotone increasing if it consists of some number of 0's (possibly none), followed by some number of 1's (also possibly none).
You are given a binary string s. You can flip s[i] changing it from 0 to 1 or from 1 to 0.
Return the minimum number of flips to make s monotone increasing.
Example 1:
Input: s = "00110"
Output: 1
Explanation: We flip the last digit to get 00111.
Example 2:
Input: s = "010110"
Output: 2
Explanation: We flip to get 011111, or alternatively 000111.
Example 3:
Input: s = "00011000"
Output: 2
Explanation: We flip to get 00000000.*/
        public void solutia9()
        {
            Console.WriteLine(functii.MinFlipsMonoIncr("00110"));
        }

        /*Given two strings word1 and word2, return the minimum number of steps required to make word1 and word2 the same.
In one step, you can delete exactly one character in either string.
Example 1:
Input: word1 = "sea", word2 = "eat"
Output: 2
Explanation: You need one step to make "sea" to "ea" and another step to make "eat" to "ea".
Example 2:
Input: word1 = "leetcode", word2 = "etco"
Output: 4*/
        public void solutia10()
        {
            Console.WriteLine(functii.MinDistance("sea","eat"));
        }

    }
}
