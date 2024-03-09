using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3
{
    public class Functii
    {

        /*Given an integer n, return a list of all possible full binary trees with n nodes. Each node of each tree in the answer must have Node.val == 0.
Each element of the answer is the root node of one possible tree. You may return the final list of trees in any order.
A full binary tree is a binary tree where each node has exactly 0 or 2 children.
Example 1:
Input: n = 7
Output: [[0,0,0,null,null,0,0,null,null,0,0],[0,0,0,null,null,0,0,0,0],[0,0,0,0,0,0,0],[0,0,0,0,0,null,null,null,null,0,0],[0,0,0,0,0,null,null,0,0]]
Example 2:

Input: n = 3
Output: [[0,0,0]]
 */
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
        public IList<TreeNode> AllPossibleFBT(int n)
        {
            List<TreeNode> result = new List<TreeNode>();

            if (n % 2 == 0)
            {
                return result;
            }

            if (n == 1)
            {
                result.Add(new TreeNode(0));
                return result;
            }

            for (int leftNodes = 1; leftNodes < n; leftNodes += 2)
            {
                IList<TreeNode> leftTrees = AllPossibleFBT(leftNodes);
                IList<TreeNode> rightTrees = AllPossibleFBT(n - 1 - leftNodes);

                foreach (TreeNode left in leftTrees)
                {
                    foreach (TreeNode right in rightTrees)
                    {
                        TreeNode root = new TreeNode(0);
                        root.left = left;
                        root.right = right;
                        result.Add(root);
                    }
                }
            }

            return result;
        }

        /*You are given a 0-indexed m x n integer matrix grid consisting of distinct integers from 0 to m * n - 1. 
         * You can move in this matrix from a cell to any other cell in the next row. That is, if you are in cell 
         * (x, y) such that x < m - 1, you can move to any of the cells (x + 1, 0), (x + 1, 1), ..., (x + 1, n - 1).
         * Note that it is not possible to move from cells in the last row.
Each possible move has a cost given by a 0-indexed 2D array moveCost of size (m * n) x n, where moveCost[i][j] is 
        the cost of moving from a cell with value i to a cell in column j of the next row. The cost of moving from 
        cells in the last row of grid can be ignored.
The cost of a path in grid is the sum of all values of cells visited plus the sum of costs of all the moves made. Return 
        the minimum cost of a path that starts from any cell in the first row and ends at any cell in the last row.
Example 1:


Input: grid = [[5,3],[4,0],[2,1]], moveCost = [[9,8],[1,5],[10,12],[18,6],[2,4],[14,3]]
Output: 17
Explanation: The path with the minimum possible cost is the path 5 -> 0 -> 1.
- The sum of the values of cells visited is 5 + 0 + 1 = 6.
- The cost of moving from 5 to 0 is 3.
- The cost of moving from 0 to 1 is 8.
So the total cost of the path is 6 + 3 + 8 = 17.
Example 2:

Input: grid = [[5,1,2],[4,0,3]], moveCost = [[12,10,15],[20,23,8],[21,7,1],[8,1,13],[9,10,25],[5,3,2]]
Output: 6
Explanation: The path with the minimum possible cost is the path 2 -> 3.
- The sum of the values of cells visited is 2 + 3 = 5.
- The cost of moving from 2 to 3 is 1.
So the total cost of this path is 5 + 1 = 6.
 */
        public int MinPathCost(int[][] grid, int[][] moveCost)
        {

            int m = grid.Length;
            int n = grid[0].Length;

            int[,] dp = new int[m, n];

            for (int col = 0; col < n; col++)
            {
                dp[0, col] = grid[0][col];
            }

            for (int row = 1; row < m; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    dp[row, col] = int.MaxValue;

                    for (int prevCol = 0; prevCol < n; prevCol++)
                    {
                        int cost = dp[row - 1, prevCol] + moveCost[grid[row - 1][prevCol]][col];
                        dp[row, col] = Math.Min(dp[row, col], cost);
                    }

                    dp[row, col] += grid[row][col];
                }
            }

            int result = int.MaxValue;
            for (int col = 0; col < n; col++)
            {
                result = Math.Min(result, dp[m - 1, col]);
            }

            return result;
        }

        /*You are given two integer arrays nums1 and nums2. We write the integers of nums1 and nums2 (in the order they are given) on two separate horizontal lines.

We may draw connecting lines: a straight line connecting two numbers nums1[i] and nums2[j] such that:

nums1[i] == nums2[j], and
the line we draw does not intersect any other connecting (non-horizontal) line.
Note that a connecting line cannot intersect even at the endpoints (i.e., each number can only belong to one connecting line).

Return the maximum number of connecting lines we can draw in this way.

 

Example 1:


Input: nums1 = [1,4,2], nums2 = [1,2,4]
Output: 2
Explanation: We can draw 2 uncrossed lines as in the diagram.
We cannot draw 3 uncrossed lines, because the line from nums1[1] = 4 to nums2[2] = 4 will intersect the line from nums1[2]=2 to nums2[1]=2.
Example 2:

Input: nums1 = [2,5,1,2,5], nums2 = [10,5,2,1,5,2]
Output: 3
Example 3:

Input: nums1 = [1,3,7,1,7,5], nums2 = [1,9,2,5,1]
Output: 2*/
        public int MaxUncrossedLines(int[] nums1, int[] nums2)
        {
            int m = nums1.Length;
            int n = nums2.Length;

            int[,] dp = new int[m + 1, n + 1];

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (nums1[i - 1] == nums2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            return dp[m, n];
        }

        /*There is a survey that consists of n questions where each question's answer is either 0 (no) or 1 (yes).

The survey was given to m students numbered from 0 to m - 1 and m mentors numbered from 0 to m - 1. The answers of the students are represented by a 2D integer array students where students[i] is an integer array that contains the answers of the ith student (0-indexed). The answers of the mentors are represented by a 2D integer array mentors where mentors[j] is an integer array that contains the answers of the jth mentor (0-indexed).

Each student will be assigned to one mentor, and each mentor will have one student assigned to them. The compatibility score of a student-mentor pair is the number of answers that are the same for both the student and the mentor.

For example, if the student's answers were [1, 0, 1] and the mentor's answers were [0, 0, 1], then their compatibility score is 2 because only the second and the third answers are the same.
You are tasked with finding the optimal student-mentor pairings to maximize the sum of the compatibility scores.

Given students and mentors, return the maximum compatibility score sum that can be achieved.



Example 1:

Input: students = [[1,1,0],[1,0,1],[0,0,1]], mentors = [[1,0,0],[0,0,1],[1,1,0]]
Output: 8
Explanation: We assign students to mentors in the following way:
- student 0 to mentor 2 with a compatibility score of 3.
- student 1 to mentor 0 with a compatibility score of 2.
- student 2 to mentor 1 with a compatibility score of 3.
The compatibility score sum is 3 + 2 + 3 = 8.
Example 2:

Input: students = [[0,0],[0,0],[0,0]], mentors = [[1,1],[1,1],[1,1]]
Output: 0
Explanation: The compatibility score of any student-mentor pair is 0.*/
        private int maxCompatibilitySum;
        public int MaxCompatibilitySum(int[][] students, int[][] mentors)
        {
            int m = students.Length;
            int n = students[0].Length;
            bool[] visitedMentors = new bool[m];
            Backtrack(students, mentors, 0, visitedMentors, 0);
            return maxCompatibilitySum;
        }
        private void Backtrack(int[][] students, int[][] mentors, int studentIndex, bool[] visitedMentors, int currentSum)
        {
            if (studentIndex == students.Length)
            {
                maxCompatibilitySum = Math.Max(maxCompatibilitySum, currentSum);
                return;
            }

            for (int i = 0; i < mentors.Length; i++)
            {
                if (!visitedMentors[i])
                {
                    visitedMentors[i] = true;
                    int compatibilityScore = CalculateCompatibility(students[studentIndex], mentors[i]);
                    Backtrack(students, mentors, studentIndex + 1, visitedMentors, currentSum + compatibilityScore);
                    visitedMentors[i] = false;
                }
            }
        }
        private int CalculateCompatibility(int[] student, int[] mentor)
        {
            int score = 0;
            for (int i = 0; i < student.Length; i++)
            {
                if (student[i] == mentor[i])
                {
                    score++;
                }
            }
            return score;
        }

        /*You are given an array of words where each word consists of lowercase English letters.

wordA is a predecessor of wordB if and only if we can insert exactly one letter anywhere in wordA without changing the order of the other characters to make it equal to wordB.

For example, "abc" is a predecessor of "abac", while "cba" is not a predecessor of "bcad".
A word chain is a sequence of words [word1, word2, ..., wordk] with k >= 1, where word1 is a predecessor of word2, word2 is a predecessor of word3, and so on. A single word is trivially a word chain with k == 1.

Return the length of the longest possible word chain with words chosen from the given list of words.



Example 1:

Input: words = ["a","b","ba","bca","bda","bdca"]
Output: 4
Explanation: One of the longest word chains is ["a","ba","bda","bdca"].
Example 2:

Input: words = ["xbc","pcxbcf","xb","cxbc","pcxbc"]
Output: 5
Explanation: All the words can be put in a word chain ["xb", "xbc", "cxbc", "pcxbc", "pcxbcf"].
Example 3:

Input: words = ["abcd","dbqca"]
Output: 1
Explanation: The trivial word chain ["abcd"] is one of the longest word chains.
["abcd","dbqca"] is not a valid word chain because the ordering of the letters is changed.
*/
        public int LongestStrChain(string[] words)
        {
            Array.Sort(words, (a, b) => a.Length - b.Length);

            Dictionary<string, int> wordChainLength = new Dictionary<string, int>();
            int maxLength = 1;

            foreach (string word in words)
            {
                int currentLength = 1;

                for (int i = 0; i < word.Length; i++)
                {
                    StringBuilder predecessor = new StringBuilder(word);
                    predecessor.Remove(i, 1);

                    if (wordChainLength.TryGetValue(predecessor.ToString(), out int chainLength))
                    {
                        currentLength = Math.Max(currentLength, chainLength + 1);
                    }
                }

                wordChainLength[word] = currentLength;
                maxLength = Math.Max(maxLength, currentLength);
            }

            return maxLength;
        }

        /*Given an integer n, return the number of structurally unique BST's (binary search trees) which has exactly n nodes of unique values from 1 to n.

 

Example 1:


Input: n = 3
Output: 5
Example 2:

Input: n = 1
Output: 1*/
        public int NumTrees(int n)
        {
            if (n <= 1)
            {
                return 1;
            }

            long catalan = 1;
            for (int i = 0; i < n; ++i)
            {
                catalan = catalan * 2 * (2 * i + 1) / (i + 2);
            }

            return (int)catalan;
        }

        /*You have n dice, and each dice has k faces numbered from 1 to k.

Given three integers n, k, and target, return the number of possible ways (out of the kn total ways) to roll the dice, so the sum of the face-up numbers equals target. Since the answer may be too large, return it modulo 109 + 7.



Example 1:

Input: n = 1, k = 6, target = 3
Output: 1
Explanation: You throw one die with 6 faces.
There is only one way to get a sum of 3.
Example 2:

Input: n = 2, k = 6, target = 7
Output: 6
Explanation: You throw two dice, each with 6 faces.
There are 6 ways to get a sum of 7: 1+6, 2+5, 3+4, 4+3, 5+2, 6+1.
Example 3:

Input: n = 30, k = 30, target = 500
Output: 222616187
Explanation: The answer must be returned modulo 109 + 7.
*/
        private const int MOD = 1000000007;
        public int NumRollsToTarget(int n, int k, int target)
        {
            int[,] dp = new int[n + 1, target + 1];
            dp[0, 0] = 1;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= target; j++)
                {
                    for (int x = 1; x <= k; x++)
                    {
                        if (j - x >= 0)
                        {
                            dp[i, j] = (dp[i, j] + dp[i - 1, j - x]) % MOD;
                        }
                    }
                }
            }

            return dp[n, target];
        }

        /*Given an integer n, break it into the sum of k positive integers, where k >= 2, and maximize the product of those integers.

Return the maximum product you can get.



Example 1:

Input: n = 2
Output: 1
Explanation: 2 = 1 + 1, 1 × 1 = 1.
Example 2:

Input: n = 10
Output: 36
Explanation: 10 = 3 + 3 + 4, 3 × 3 × 4 = 36.
*/
        public int IntegerBreak(int n)
        {
            if (n == 2)
            {
                return 1;
            }
            if (n == 3)
            {
                return 2;
            }

            int product = 1;

            while (n > 4)
            {
                product *= 3;
                n -= 3;
            }

            product *= n;

            return product;
        }

        /*You are given an array of n pairs pairs where pairs[i] = [lefti, righti] and lefti < righti.

A pair p2 = [c, d] follows a pair p1 = [a, b] if b < c. A chain of pairs can be formed in this fashion.

Return the length longest chain which can be formed.

You do not need to use up all the given intervals. You can select pairs in any order.



Example 1:

Input: pairs = [[1,2],[2,3],[3,4]]
Output: 2
Explanation: The longest chain is [1,2] -> [3,4].
Example 2:

Input: pairs = [[1,2],[7,8],[4,5]]
Output: 3
Explanation: The longest chain is [1,2] -> [4,5] -> [7,8].
*/
        public int FindLongestChain(int[][] pairs)
        {
            Array.Sort(pairs, (a, b) => a[1] - b[1]);

            int n = pairs.Length;
            int[] dp = new int[n];
            Array.Fill(dp, 1);

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (pairs[i][0] > pairs[j][1])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
            }

            return dp.Max();
        }

        /*You are given an integer array nums. The absolute sum of a subarray [numsl, numsl+1, ..., numsr-1, numsr] is abs(numsl + numsl+1 + ... + numsr-1 + numsr).

Return the maximum absolute sum of any (possibly empty) subarray of nums.

Note that abs(x) is defined as follows:

If x is a negative integer, then abs(x) = -x.
If x is a non-negative integer, then abs(x) = x.
 

Example 1:

Input: nums = [1,-3,2,3,-4]
Output: 5
Explanation: The subarray [2,3] has absolute sum = abs(2+3) = abs(5) = 5.
Example 2:

Input: nums = [2,-5,1,-4,3,-2]
Output: 8
Explanation: The subarray [-5,1,-4] has absolute sum = abs(-5+1-4) = abs(-8) = 8.
 */
        public int MaxAbsoluteSum(int[] nums)
        {
            int maxEndingHere = 0;
            int minEndingHere = 0;
            int maxAbsSum = 0;

            foreach (int num in nums)
            {
                maxEndingHere = Math.Max(num, maxEndingHere + num);
                minEndingHere = Math.Min(num, minEndingHere + num);

                maxAbsSum = Math.Max(maxAbsSum, Math.Max(Math.Abs(maxEndingHere), Math.Abs(minEndingHere)));
            }

            return maxAbsSum;
        }


    }
}
