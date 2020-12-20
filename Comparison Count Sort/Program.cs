using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Comparison_Count_Sort
{
	class Program
	{

		static void Comparisoncountsort(int[] arr)
		{
			int n = arr.Length;

			// The output character array that 
			// will have sorted arr 
			int[] output = new int[n];

			// Create a count array to store 
			// count of inidividul characters 
			// and initialize count array as 0 
			int[] count = new int[256];

			for (int i = 0; i < 256; ++i)
				count[i] = 0;

			// store count of each character 
			for (int i = 0; i < n; ++i)
				++count[arr[i]];

			// Change count[i] so that count[i] 
			// now contains actual position of 
			// this character in output array 
			for (int i = 1; i <= 255; ++i)
				count[i] += count[i - 1];

			// Build the output character array 
			// To make it stable we are operating in reverse order. 
			for (int i = n - 1; i >= 0; i--)
			{
				output[count[arr[i]] - 1] = arr[i];
				--count[arr[i]];
			}

			// Copy the output array to arr, so 
			// that arr now contains sorted 
			// characters 
			for (int i = 0; i < n; ++i)
				arr[i] = output[i];
		}

		public static int[] DistributionCountSort(int[] input, int l, int u)
		{
			var d = new int[u - l + 1]; // count array ku i shtojme numrimet
			var S = new int[input.Length];

			for (int j = 0; j <= (u - l); j++)
			{
				d[j] = 0;
			}

			//gjetja e frekuences
			for (int i = 0; i <= input.Length - 1; i++)
			{
				d[input[i] - l] = d[input[i] - l] + 1;
			}

			//mbledhja e elementeve paraprake (cumulative frequency distribution)
			for (int j = 1; j <= (u - l); j++)
			{
				d[j] = d[j - 1] + d[j];
			}

			//vendosja sipas frekuences ne array-in perfundimtar s[]
			for (int i = input.Length - 1; i >= 0; i--)
			{
				int j = input[i] - l;
				S[d[j] - 1] = input[i];
				d[j] = d[j] - 1;
			}

			return S;
		}

	
	
	
	public static void Main()
		{
			int[] thearray; // the array of unsorted elements
			long start = Stopwatch.GetTimestamp();
			Thread.Sleep(5000);
			int size = 1000000;
			thearray = new int[size];
			Random ran = new Random();
			for (int i = 0; i < size; i++)
			{
				thearray[i] = ran.Next(0,9);
			}
			int u = thearray.Max();
			int l = thearray.Min();
			//Comparisoncountsort(thearray);
		    var sortedArray = DistributionCountSort(thearray, l, u);

			//Console.Write("Sorted character array is ");
			//for (int i = 0; i < thearray.Length; ++i)
			//    Console.Write(thearray[i]);
			
			for (int i = 0; i < sortedArray.Length; ++i)
			    Console.Write(sortedArray[i]);

			long end = Stopwatch.GetTimestamp();
			Console.WriteLine("Elapsed Time is {0} ticks", (end - start));
		
		}
	}

	




}
