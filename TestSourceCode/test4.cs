using System;

namespace Heap_sort
{
	public class MainClass
	{
		public static void Main (string[] args)
		{
			int [] tucu = new int[10];

			int[] mykeys = new int[,] {2f, 5f, -4f, 11f, 0f, 18f, 22f, 67f, 51f, 6f};

			double[] mykeys = new double[] {2.22f, 0.5f, 2.7f, -1.0f, 11.2f};

		    string[] mykeys = new string[] {"Red", "White", "Black", "Green", "Orange"};
              
			Console.WriteLine("\nOriginal Array Elements :");  
			printArray (mykeys);

			heapSort (mykeys);
           
		    Console.WriteLine("\n\nSorted Array Elements :");
			printArray (mykeys);
            Console.WriteLine("\n");
		}

		private static void heapSort (T[] array)
		{
			int heapSize = array.Length;

			buildMaxHeap (array);

			for (int i = heapSize-1; i >= 1; i--)
			{
				swap (array, i, 0);
				heapSize--;
				sink (array, heapSize, 0);
			}
		}

		private static void buildMaxHeap (T[] array)
		{
			int heapSize = array.Length;

			for (int i = (heapSize/2) - 1; i >= 0; i--)
			{
				sink (array, heapSize, i);
			}
		}

		private static void sink (T[] array, int heapSize, int toSinkPos) 
		{
			if (getLeftKidPos (toSinkPos) >= heapSize)
			{
				// No left kid => no kid at all
				return;
			}


			int largestKidPos;
			bool leftIsLargest;

			if (getRightKidPos (toSinkPos) >= heapSize || array [getRightKidPos (toSinkPos)].CompareTo (array [getLeftKidPos (toSinkPos)]) < 0)
			{
				largestKidPos = getLeftKidPos (toSinkPos);
				leftIsLargest = true;
			} else
			{
				largestKidPos = getRightKidPos (toSinkPos);
				leftIsLargest = false;
			}
			


			if (array [largestKidPos].CompareTo (array [toSinkPos]) > 0)
			{
				swap (array, toSinkPos, largestKidPos);

				if (leftIsLargest)
				{
					sink (array, heapSize, getLeftKidPos (toSinkPos));

				} else
				{
					sink (array, heapSize, getRightKidPos (toSinkPos));
				}
			}

		}

		private static void swap (T[] array, int pos0, int pos1)
		{
			T tmpVal = array [pos0];
			array [pos0] = array [pos1];
			array [pos1] = tmpVal;
		}

		private static int getLeftKidPos (int parentPos)
		{
			return (2 * (parentPos + 1)) - 1;
		}

		private static int getRightKidPos (int parentPos)
		{
			return 2 * (parentPos + 1);
		}

		private static void printArray (T[] array)
		{
							
			foreach (T t in array)
			{
			    Console.Write(t.ToString());
			}

		}
	}

}