using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumSum_SuchThat_NoTwoElements_AreAdjacent_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 5, 5, 10, 100, 10, 5 };
            Console.WriteLine(MaxSum_Recursive(arr, arr.Length - 1));
            Console.WriteLine(MaxSum_DP(arr));
        }



        private static int MaxSum_Recursive(int[] arr, int i)
        {
            if (i == 0)
            {
                return arr[0];
            }
            else if (i == 1)
            {
                return Math.Max(arr[0], arr[1]);
            }
            return Math.Max(MaxSum_Recursive(arr, i - 2) + arr[i], MaxSum_Recursive(arr, i - 1));
        }


        private static int MaxSum_DP(int[] arr)
        {
            int size = arr.Length;
            int[] sum = new int[size];
            int i;

            for (i = 0; i < size; i++)
            {
                if (i == 0)
                {
                    sum[0] = arr[0];
                }
                else if (i == 1)
                {
                    sum[1] = Math.Max(sum[0], arr[1]);
                }
                else
                {
                    sum[i] = Math.Max(sum[i - 2] + arr[i], sum[i - 1]);
                }
            }
            return sum[size - 1];
        }
    }
}

/*
 * Average Difficulty : 3.3/5.0
Based on 235 vote(s) 
DO NOT USE IT FOR CODING. JUST FOR A REFERENCE. UNDERSTAND STACK OVERFLOW SOLUTION BELOW INSTEAD.(http://www.geeksforgeeks.org/maximum-sum-such-that-no-two-elements-are-adjacent/)

 * http://stackoverflow.com/a/4907427
 * 
 * Let A be the given array and Sum be another array such that Sum[i] represents the maximum sum of non-consecutive elements from arr[0]..arr[i].

We have:

Sum[0] = arr[0]
Sum[1] = max(Sum[0],arr[1])
Sum[2] = max(Sum[0]+arr[2],Sum[1])
...
Sum[i] = max(Sum[i-2]+arr[i],Sum[i-1]) when i>=2
If size is the number of elements in arr then sum[size-1] will be the answer.

One can code a simple recursive method in top down order as:

int sum(int *arr,int i) {
        if(i==0) {
                return arr[0];
        }else if(i==1) {
                return max(arr[0],arr[1]);
        }
        return max(sum(arr,i-2)+arr[i],sum(arr,i-1));
}
The above code is very inefficient as it makes exhaustive duplicate recursive calls. To avoid this we use memoization by using an auxiliary array called sum as:

int sum(int *arr,int size) {
        int *sum = malloc(sizeof(int) * size);
        int i;

        for(i=0;i<size;i++) {
                if(i==0) {
                        sum[0] = arr[0];
                }else if(i==1) {
                        sum[1] = max(sum[0],arr[1]);
                }else{
                        sum[i] = max(sum[i-2]+arr[i],sum[i-1]);
                }
        }    
        return sum[size-1];
}
Which is O(N) in both space and time.
 */
