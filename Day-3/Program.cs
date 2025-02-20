﻿using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    // 1. Sum of Array Elements
    public static int ArraySum(int[] arr)
    {
        int sum = 0;
        foreach (int num in arr)
        {
            sum += num;
        }
        return sum;
    }

    // 2. Find the Missing Number
    public static int FindMissNumber(int[] arr, int n)
    {
        int expectedSum = n * (n + 1) / 2;
        int actualSum = 0;
        foreach (int num in arr)
        {
            actualSum += num;
        }
        return expectedSum - actualSum;
    }

    // 3. Reverse an Array in Place
    public static void ReverseArray(int[] arr)
    {
        int left = 0, right = arr.Length - 1;
        while (left < right)
        {
            int temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
            left++;
            right--;
        }
    }

    // 4. Find First Non-Repeating Character in a String
    public static char FirstUniqueChar(string str)
    {
        var charCount = new Dictionary<char, int>();
        foreach (char c in str)
        {
            if (charCount.ContainsKey(c))
                charCount[c]++;
            else
                charCount[c] = 1;
        }
        foreach (char c in str)
        {
            if (charCount[c] == 1)
                return c;
        }
        return '\0'; // If no unique character found
    }

    // 5. Find the Majority Element
    public static int MajorityElement(int[] arr)
    {
        int count = 0, candidate = 0;
        foreach (int num in arr)
        {
            if (count == 0)
                candidate = num;
            count += (num == candidate) ? 1 : -1;
        }
        return candidate;
    }

    // 6. Rotate an Array by K Positions
    public static void RotateArray(int[] arr, int k)
    {
        k %= arr.Length;
        ReverseArray(arr, 0, arr.Length - 1);
        ReverseArray(arr, 0, k - 1);
        ReverseArray(arr, k, arr.Length - 1);
    }

    private static void ReverseArray(int[] arr, int start, int end)
    {
        while (start < end)
        {
            int temp = arr[start];
            arr[start] = arr[end];
            arr[end] = temp;
            start++;
            end--;
        }
    }

    // 7. Find the Longest Consecutive Sequence
    public static int LongestConsecutive(int[] arr)
    {
        var set = new HashSet<int>(arr);
        int longestStreak = 0;
        foreach (int num in set)
        {
            if (!set.Contains(num - 1))
            {
                int currentNum = num;
                int currentStreak = 1;
                while (set.Contains(currentNum + 1))
                {
                    currentNum++;
                    currentStreak++;
                }
                longestStreak = Math.Max(longestStreak, currentStreak);
            }
        }
        return longestStreak;
    }

    // 8. Find K-th Smallest Element in an Unsorted Array
    public static int KthSmallestElement(int[] arr, int k)
    {
        Array.Sort(arr);
        return arr[k - 1];
    }

    // 9. Find the Maximum Product of Three Numbers
    public static int MaxProductOfThree(int[] arr)
    {
        Array.Sort(arr);
        int n = arr.Length;
        return Math.Max(arr[0] * arr[1] * arr[n - 1], arr[n - 3] * arr[n - 2] * arr[n - 1]);
    }

    // 10. Merge Two Sorted Arrays
    public static int[] MergeSortedArrays(int[] arr1, int[] arr2)
    {
        int[] result = new int[arr1.Length + arr2.Length];
        int i = 0, j = 0, k = 0;
        while (i < arr1.Length && j < arr2.Length)
        {
            if (arr1[i] < arr2[j])
                result[k++] = arr1[i++];
            else
                result[k++] = arr2[j++];
        }
        while (i < arr1.Length)
            result[k++] = arr1[i++];
        while (j < arr2.Length)
            result[k++] = arr2[j++];
        return result;
    }

    // 11. Find Pair with Given Sum in a Sorted Array
    public static int[] TwoSumSorted(int[] arr, int target)
    {
        int left = 0, right = arr.Length - 1;
        while (left < right)
        {
            int sum = arr[left] + arr[right];
            if (sum == target)
                return new int[] { left, right };
            else if (sum < target)
                left++;
            else
                right--;
        }
        return new int[] { -1, -1 }; // If no pair found
    }

    // 12. Find the Peak Element in an Array
    public static int FindPeakElement(int[] arr)
    {
        int left = 0, right = arr.Length - 1;
        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (arr[mid] < arr[mid + 1])
                left = mid + 1;
            else
                right = mid;
        }
        return left;
    }

    // 13. Check If an Array is a Subset of Another
    public static bool IsSubset(int[] arr1, int[] arr2)
    {
        var set = new HashSet<int>(arr1);
        foreach (int num in arr2)
        {
            if (!set.Contains(num))
                return false;
        }
        return true;
    }

    // 14. Trapping Rain Water
    public static int TrapRainWater(int[] height)
    {
        int left = 0, right = height.Length - 1;
        int leftMax = 0, rightMax = 0;
        int water = 0;
        while (left < right)
        {
            if (height[left] < height[right])
            {
                if (height[left] >= leftMax)
                    leftMax = height[left];
                else
                    water += leftMax - height[left];
                left++;
            }
            else
            {
                if (height[right] >= rightMax)
                    rightMax = height[right];
                else
                    water += rightMax - height[right];
                right--;
            }
        }
        return water;
    }

    // 15. Find the Smallest Window in a String Containing All Characters of Another String
    public static string MinWindowSubstring(string s, string t)
    {
        var targetMap = new Dictionary<char, int>();
        foreach (char c in t)
        {
            if (targetMap.ContainsKey(c))
                targetMap[c]++;
            else
                targetMap[c] = 1;
        }
        int left = 0, right = 0, count = t.Length;
        int minLen = int.MaxValue, minStart = 0;
        while (right < s.Length)
        {
            if (targetMap.ContainsKey(s[right]) && --targetMap[s[right]] >= 0)
                count--;
            right++;
            while (count == 0)
            {
                if (right - left < minLen)
                {
                    minLen = right - left;
                    minStart = left;
                }
                if (targetMap.ContainsKey(s[left]) && ++targetMap[s[left]] > 0)
                    count++;
                left++;
            }
        }
        return minLen == int.MaxValue ? "" : s.Substring(minStart, minLen);
    }

    // 16. Find All Anagrams of a String in Another String
    public static List<int> FindAnagrams(string s, string t)
    {
        var result = new List<int>();
        if (s.Length < t.Length) return result;
        int[] targetMap = new int[26];
        int[] windowMap = new int[26];
        foreach (char c in t)
            targetMap[c - 'a']++;
        for (int i = 0; i < s.Length; i++)
        {
            windowMap[s[i] - 'a']++;
            if (i >= t.Length)
                windowMap[s[i - t.Length] - 'a']--;
            if (windowMap.SequenceEqual(targetMap))
                result.Add(i - t.Length + 1);
        }
        return result;
    }

    // 17. Find the K Closest Numbers to a Target
    public static int[] KClosestNumbers(int[] arr, int k, int x)
    {
        return arr.OrderBy(num => Math.Abs(num - x)).Take(k).OrderBy(num => num).ToArray();
    }

    // 18. Find Duplicates in an Array
    public static List<int> FindDuplicates(int[] arr)
    {
        var duplicates = new List<int>();
        var set = new HashSet<int>();
        foreach (int num in arr)
        {
            if (set.Contains(num))
                duplicates.Add(num);
            else
                set.Add(num);
        }
        return duplicates;
    }

    // 19. Find the Longest Palindromic Substring
    public static string LongestPalindrome(string s)
    {
        if (string.IsNullOrEmpty(s)) return "";
        int start = 0, end = 0;
        for (int i = 0; i < s.Length; i++)
        {
            int len1 = ExpandAroundCenter(s, i, i);
            int len2 = ExpandAroundCenter(s, i, i + 1);
            int len = Math.Max(len1, len2);
            if (len > end - start)
            {
                start = i - (len - 1) / 2;
                end = i + len / 2;
            }
        }
        return s.Substring(start, end - start + 1);
    }

    private static int ExpandAroundCenter(string s, int left, int right)
    {
        while (left >= 0 && right < s.Length && s[left] == s[right])
        {
            left--;
            right++;
        }
        return right - left - 1;
    }

    // 20. Find the Median of Two Sorted Arrays
    public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        int[] merged = nums1.Concat(nums2).OrderBy(x => x).ToArray();
        int n = merged.Length;
        if (n % 2 == 0)
            return (merged[n / 2 - 1] + merged[n / 2]) / 2.0;
        else
            return merged[n / 2];
    }

    // Main method to test the functions
    public static void Main()
    {
        // Test ArraySum
        int[] arr = { 1, 2, 3, 4, 10, 11 };
        Console.WriteLine("Sum of array elements: " + ArraySum(arr));

        // Test FindMissNumber
        int[] arr2 = { 1, 2, 4, 5, 6 };
        Console.WriteLine("Missing number: " + FindMissNumber(arr2, 6));

        // Test ReverseArray
        int[] arr3 = { 1, 2, 3, 4 };
        ReverseArray(arr3);
        Console.WriteLine("Reversed array: " + string.Join(", ", arr3));

        // Test FirstUniqueChar
        string str = "swiss";
        Console.WriteLine("First unique character: " + FirstUniqueChar(str));

        // Test MajorityElement
        int[] arr4 = { 3, 3, 4, 2, 3, 3, 3, 1 };
        Console.WriteLine("Majority element: " + MajorityElement(arr4));

        // Test RotateArray
        int[] arr5 = { 1, 2, 3, 4, 5, 6, 7 };
        RotateArray(arr5, 3);
        Console.WriteLine("Rotated array: " + string.Join(", ", arr5));

        // Test LongestConsecutive
        int[] arr6 = { 100, 4, 200, 1, 3, 2 };
        Console.WriteLine("Longest consecutive sequence: " + LongestConsecutive(arr6));

        // Test KthSmallestElement
        int[] arr7 = { 7, 10, 4, 3, 20, 15 };
        Console.WriteLine("3rd smallest element: " + KthSmallestElement(arr7, 3));

        // Test MaxProductOfThree
        int[] arr8 = { 1, 10, -5, 1, -100 };
        Console.WriteLine("Maximum product of three numbers: " + MaxProductOfThree(arr8));

        // Test MergeSortedArrays
        int[] arr9 = { 1, 3, 5 };
        int[] arr10 = { 2, 4, 6 };
        Console.WriteLine("Merged sorted arrays: " + string.Join(", ", MergeSortedArrays(arr9, arr10)));

        // Test TwoSumSorted
        int[] arr11 = { 1, 2, 3, 4, 6 };
        Console.WriteLine("Indices of two numbers with sum 6: " + string.Join(", ", TwoSumSorted(arr11, 6)));

        // Test FindPeakElement
        int[] arr12 = { 1, 2, 3, 1 };
        Console.WriteLine("Peak element: " + FindPeakElement(arr12));

        // Test IsSubset
        int[] arr13 = { 1, 2, 3, 4, 5 };
        int[] arr14 = { 2, 3, 4 };
        Console.WriteLine("Is arr14 a subset of arr13? " + IsSubset(arr13, arr14));

        // Test TrapRainWater
        int[] arr15 = { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
        Console.WriteLine("Trapped rainwater: " + TrapRainWater(arr15));

        // Test MinWindowSubstring
        string s = "ADOBECODEBANC";
        string t = "ABC";
        Console.WriteLine("Smallest window substring: " + MinWindowSubstring(s, t));

        // Test FindAnagrams
        string s2 = "cbaebabacd";
        string t2 = "abc";
        Console.WriteLine("Start indices of anagrams: " + string.Join(", ", FindAnagrams(s2, t2)));

        // Test KClosestNumbers
        int[] arr16 = { 1, 2, 3, 4, 5 };
        Console.WriteLine("2 closest numbers to 3: " + string.Join(", ", KClosestNumbers(arr16, 2, 3)));

        // Test FindDuplicates
        int[] arr17 = { 4, 3, 2, 7, 8, 2, 3, 1 };
        Console.WriteLine("Duplicate numbers: " + string.Join(", ", FindDuplicates(arr17)));

        // Test LongestPalindrome
        string s3 = "babad";
        Console.WriteLine("Longest palindromic substring: " + LongestPalindrome(s3));

        // Test FindMedianSortedArrays
        int[] nums1 = { 1, 3 };
        int[] nums2 = { 2 };
        Console.WriteLine("Median of two sorted arrays: " + FindMedianSortedArrays(nums1, nums2));
    }
}