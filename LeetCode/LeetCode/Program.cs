using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class Program
    {
        public static int[] TwoSum(int[] nums, int target)
        {
            
            int[] indexes = new int[2];
            for(int i = 0; i<nums.Length; i++)
            {
                for(int j =0; j< nums.Length; j++)
                {
                    if(j != i && (nums[i] + nums[j] ==target))
                    {
                        indexes[0] = i;
                        indexes[1] = j;
                    }
                }
            }
            return indexes;
        }
        //public static ListNode AddTwoNumbers(int[] l1, int[] l2)
        //{
        //    int num1, num2;
        //    string num1_str = "";
        //    string num2_str = "";
        //    for (int i = l1.Length -1; i>= 0; i--)
        //    {
        //        num1_str += l1[i];  
        //    }
        //    for (int i = l2.Length - 1; i >= 0; i--)
        //    {
        //        num2_str += l2[i];
        //    }
        //    num1 = int.Parse(num1_str);
        //    num2 = int.Parse(num2_str); 

        //    return num1 + num2;
        //}
        public static int LengthOfLongestSubstring(string s)
        {
            int n = s.Length;
            List<int> list = new List<int>();
            string str = ""; 
            for(int i = 0; i< n; i++)
            {
                str += s[i];
                for(int j = i+1; j<n; j++)
                {
                    if (!str.Contains(s[j]))
                    {
                        str += s[j];
                        if (j == n - 1)
                        {
                            list.Add(str.Length);
                            str = "";
                            break;
                        }
                    }
                    else
                    {
                        list.Add(str.Length);
                        str = "";
                        break;
                    }
                }
            }
            return s.Count() == 0 ? 0 : list.Max();
        }
        //public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        //{
        //    int[] mergerd_arr = new int[nums1.Length + nums2.Length];
        //    int n = mergerd_arr.Length;
        //    int n1 = nums1.Length;
        //    int n2 = nums2.Length;

        //    //Merge nums and nums 2
        //    Array.Copy(nums1, 0, mergerd_arr, 0, n1);
        //    Array.Copy(nums2, 0, mergerd_arr, n1, n2);
        //    //Sort merged array
        //    Array.Sort(mergerd_arr);
        //    //Find median
        //    double median;
        //    int median_pos = (n + 1) / 2;
        //    if (n % 2 == 1)
        //    {
        //        median = mergerd_arr[median_pos - 1];
        //    }
        //    else
        //    {
        //        median = (double)(mergerd_arr[median_pos - 1] + mergerd_arr[median_pos]) / 2;
        //    }
        //    return median;
        //}
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            // Ensure nums1 is the smaller array
            if (nums1.Length > nums2.Length)
            {
                return FindMedianSortedArrays(nums2, nums1);
            }

            int x = nums1.Length;
            int y = nums2.Length;
            int low = 0, high = x;

            while (low <= high)
            {
                int partitionX = (low + high) / 2;
                int partitionY = (x + y + 1) / 2 - partitionX;

                int maxX = (partitionX == 0) ? int.MinValue : nums1[partitionX - 1];
                int maxY = (partitionY == 0) ? int.MinValue : nums2[partitionY - 1];

                int minX = (partitionX == x) ? int.MaxValue : nums1[partitionX];
                int minY = (partitionY == y) ? int.MaxValue : nums2[partitionY];

                if (maxX <= minY && maxY <= minX)
                {
                    // Found the correct partitions
                    if ((x + y) % 2 == 0)
                    {
                        return ((double)Math.Max(maxX, maxY) + Math.Min(minX, minY)) / 2;
                    }
                    else
                    {
                        return (double)Math.Max(maxX, maxY);
                    }
                }
                else if (maxX > minY)
                {
                    // Move towards left in nums1
                    high = partitionX - 1;
                }
                else
                {
                    // Move towards right in nums1
                    low = partitionX + 1;
                }
            }

            throw new ArgumentException("Input arrays are not sorted or valid");
        }

        static void Main(string[] args)
        {
            int[] nums1 = { 1,2};
            int[] nums2 = {3,4};
            double median = FindMedianSortedArrays(nums1, nums2);
            //int x = 5;
            //int y = ++x * 2;
            Console.WriteLine(median);
        }
    }
}
