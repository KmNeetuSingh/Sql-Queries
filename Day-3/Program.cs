### **1. Sum of Array Elements**
**Manual Approach**:
- Iterate through the array and add each element to a sum variable.

```csharp
public static int ArraySum(int[] arr)
{
    int sum = 0;
    foreach (int num in arr)
    {
        sum += num;
    }
    return sum;
}
```

---

### **2. Find the Missing Number**
**Manual Approach**:
- Calculate the expected sum of numbers from `1` to `n` using the formula `n * (n + 1) / 2`.
- Subtract the sum of the array from the expected sum to find the missing number.

```csharp
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
```

---

### **3. Reverse an Array in Place**
**Manual Approach**:
- Use two pointers (`left` and `right`) to swap elements from the start and end of the array until they meet in the middle.

```csharp
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
```

---

### **4. Find First Non-Repeating Character in a String**
**Manual Approach**:
- Use a dictionary to count the occurrences of each character.
- Iterate through the string and return the first character with a count of `1`.

```csharp
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
```

---

### **5. Find the Majority Element**
**Manual Approach**:
- Use the Boyer-Moore Voting Algorithm to find the majority element.

```csharp
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
```

---

### **6. Rotate an Array by K Positions**
**Manual Approach**:
- Reverse the entire array, then reverse the first `k` elements and the remaining elements.

```csharp
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
```

---

### **7. Find the Longest Consecutive Sequence**
**Manual Approach**:
- Use a hash set to track elements and find the longest sequence.

```csharp
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
```

---

### **8. Find K-th Smallest Element in an Unsorted Array**
**Manual Approach**:
- Sort the array and return the `k-1` index element.

```csharp
public static int KthSmallestElement(int[] arr, int k)
{
    Array.Sort(arr);
    return arr[k - 1];
}
```

---

### **9. Find the Maximum Product of Three Numbers**
**Manual Approach**:
- Sort the array and consider the product of the two smallest and the largest or the three largest numbers.

```csharp
public static int MaxProductOfThree(int[] arr)
{
    Array.Sort(arr);
    int n = arr.Length;
    return Math.Max(arr[0] * arr[1] * arr[n - 1], arr[n - 3] * arr[n - 2] * arr[n - 1]);
}
```

---

### **10. Merge Two Sorted Arrays**
**Manual Approach**:
- Use two pointers to merge the arrays into one sorted array.

```csharp
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
```

---

### **11. Find Pair with Given Sum in a Sorted Array**
**Manual Approach**:
- Use two pointers to find the pair.

```csharp
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
```

---

### **12. Find the Peak Element in an Array**
**Manual Approach**:
- Use binary search to find the peak element.

```csharp
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
```

---

### **13. Check If an Array is a Subset of Another**
**Manual Approach**:
- Use a hash set to check if all elements of `arr2` are in `arr1`.

```csharp
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
```

---

### **14. Trapping Rain Water**
**Manual Approach**:
- Use two pointers to calculate trapped water.

```csharp
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
```

---

### **15. Find the Smallest Window in a String Containing All Characters of Another String**
**Manual Approach**:
- Use a sliding window approach to find the smallest substring.

```csharp
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
```

---

### **16. Find All Anagrams of a String in Another String**
**Manual Approach**:
- Use a sliding window to compare character counts.

```csharp
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
```

---

### **17. Find the K Closest Numbers to a Target**
**Manual Approach**:
- Use a custom comparator to sort the array based on the absolute difference from `x`.

```csharp
public static int[] KClosestNumbers(int[] arr, int k, int x)
{
    return arr.OrderBy(num => Math.Abs(num - x)).Take(k).OrderBy(num => num).ToArray();
}
```

---

### **18. Find Duplicates in an Array**
**Manual Approach**:
- Use a hash set to track duplicates.

```csharp
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
```

---

### **19. Find the Longest Palindromic Substring**
**Manual Approach**:
- Expand around each character to find the longest palindrome.

```csharp
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
```

---

### **20. Find the Median of Two Sorted Arrays**
**Manual Approach**:
- Merge the two arrays and find the median.

```csharp
public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
{
    int[] merged = nums1.Concat(nums2).OrderBy(x => x).ToArray();
    int n = merged.Length;
    if (n % 2 == 0)
        return (merged[n / 2 - 1] + merged[n / 2]) / 2.0;
    else
        return merged[n / 2];
}
```

---