using System;
using System.Collections.Generic;

class Solutions {
    // 1. Container With Most Water
    public static int MaxArea(int[] height) {
        int left = 0, right = height.Length - 1, maxArea = 0;
        while (left < right) {
            maxArea = Math.Max(maxArea, Math.Min(height[left], height[right]) * (right - left));
            if (height[left] < height[right]) left++;
            else right--;
        }
        return maxArea;
    }
    
    // 2. Merge Intervals
    public static List<int[]> MergeIntervals(List<int[]> intervals) {
        intervals.Sort((a, b) => a[0] - b[0]);
        List<int[]> merged = new List<int[]>();
        foreach (var interval in intervals) {
            if (merged.Count == 0 || merged[merged.Count - 1][1] < interval[0])
                merged.Add(interval);
            else
                merged[merged.Count - 1][1] = Math.Max(merged[merged.Count - 1][1], interval[1]);
        }
        return merged;
    }
    
    // 3. Longest Substring Without Repeating Characters
    public static int LengthOfLongestSubstring(string s) {
        HashSet<char> set = new HashSet<char>();
        int left = 0, maxLength = 0;
        for (int right = 0; right < s.Length; right++) {
            while (set.Contains(s[right]))
                set.Remove(s[left++]);
            set.Add(s[right]);
            maxLength = Math.Max(maxLength, right - left + 1);
        }
        return maxLength;
    }
    
    // 4. Rotate Image
    public static void Rotate(int[][] matrix) {
        int n = matrix.Length;
        for (int i = 0; i < n; i++)
            for (int j = i; j < n; j++)
                (matrix[i][j], matrix[j][i]) = (matrix[j][i], matrix[i][j]);
        foreach (var row in matrix)
            Array.Reverse(row);
    }
    
    // 5. Valid Parentheses
    public static bool IsValid(string s) {
        Stack<char> stack = new Stack<char>();
        Dictionary<char, char> map = new Dictionary<char, char>() { { ')', '(' }, { '}', '{' }, { ']', '[' } };
        foreach (char c in s) {
            if (map.ContainsKey(c)) {
                if (stack.Count == 0 || stack.Pop() != map[c]) return false;
            } else stack.Push(c);
        }
        return stack.Count == 0;
    }
    
    // 6. Reverse Linked List
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null) { this.val = val; this.next = next; }
    }
    public static ListNode ReverseList(ListNode head) {
        ListNode prev = null, curr = head;
        while (curr != null) {
            ListNode next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }
        return prev;
    }
    
    // 7. Find Missing Number
    public static int FindMissingNumber(int[] nums) {
        int n = nums.Length + 1, sum = n * (n + 1) / 2;
        foreach (int num in nums) sum -= num;
        return sum;
    }
    
    // 8. Top K Frequent Elements
    public static List<int> TopKFrequent(int[] nums, int k) {
        Dictionary<int, int> freq = new Dictionary<int, int>();
        foreach (int num in nums) freq[num] = freq.GetValueOrDefault(num, 0) + 1;
        List<int> result = new List<int>();
        foreach (var pair in freq.OrderByDescending(p => p.Value).Take(k))
            result.Add(pair.Key);
        return result;
    }
    
    // 9. Search Insert Position
    public static int SearchInsert(int[] nums, int target) {
        int left = 0, right = nums.Length - 1;
        while (left <= right) {
            int mid = left + (right - left) / 2;
            if (nums[mid] == target) return mid;
            if (nums[mid] < target) left = mid + 1;
            else right = mid - 1;
        }
        return left;
    }
    
    // 10. Jump Game
    public static bool CanJump(int[] nums) {
        int maxReach = 0;
        for (int i = 0; i < nums.Length; i++) {
            if (i > maxReach) return false;
            maxReach = Math.Max(maxReach, i + nums[i]);
        }
        return true;
    }
}
