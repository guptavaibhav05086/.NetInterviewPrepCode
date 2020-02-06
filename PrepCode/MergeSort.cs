using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepCode
{
    class MergeSort
    {

        void merge(int[] arr, int l, int m, int r)
        {
            // Find sizes of two subarrays to be merged 
            int n1 = m - l + 1;
            int n2 = r - m;
            Console.WriteLine($"Left index {l} Middle Point {m} Rigth index {r} ");

            /* Create temp arrays */
            int[] L = new int[n1];
            int[] R = new int[n2];

            /*Copy data to temp arrays*/
            for (int p = 0; p < n1; ++p)
                L[p] = arr[l + p];
            for (int q = 0; q < n2; ++q)
                R[q] = arr[m + 1 + q];


            /* Merge the temp arrays */

            // Initial indexes of first and second subarrays 
            int i = 0, j = 0;

            // Initial index of merged subarry array 
            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            /* Copy remaining elements of L[] if any */
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            /* Copy remaining elements of R[] if any */
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        // Main function that sorts arr[l..r] using 
        // merge() 
        public void sort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                // Find the middle point 
                int m = (l + r) / 2;
                //Console.WriteLine(m);
                // Sort first and second halves 
                //Console.WriteLine($"First Half ({l} , {m})");
                sort(arr, l, m);
                //Console.WriteLine($"Second Half ( {m+1} , {r})");
                sort(arr, m + 1, r);

                // Merge the sorted halves 
                merge(arr, l, m, r);
            }
        }
    }


//    Console.WriteLine("Hello World!");
//		int size = Convert.ToInt32(Console.ReadLine());
//    int result = Convert.ToInt32(Console.ReadLine());
//    int[] arr = new int[size];
		
//		for(int i = 0; i<size;i++){
//		    arr[i]=Convert.ToInt32(Console.ReadLine());
//		    //Console.WriteLine(arr[i]);
//		}

//int s = 0, e = 0, sum = 0, k = 0;
//		while(k<size){
//		    for(int j = k; j<size;j++){
//		        sum = sum + arr[j];
//		        if(sum == result){
//		            s=k;e=j;
//		            	Console.WriteLine ($"{s} {e}");
//		            	break;
//		        }
//		        k++;
//		    }
//		}
}
