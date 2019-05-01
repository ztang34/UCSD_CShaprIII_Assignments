using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lab03
{
	class Program
	{
		#region Fields
		static Dictionary<int, List<ulong>> m_Primes = new Dictionary<int, List<ulong>>();
		static ConcurrentQueue<ulong> m_Numbers = new ConcurrentQueue<ulong>();
		static ManualResetEvent m_ProducersComplete = new ManualResetEvent(false);
		static object m_ConsoleLock = new object();
		static Timer m_Timer = null;
		#endregion Fields

		/// <summary>
		/// Main program
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			Console.BufferHeight = 9999;
			ulong highest = IOFunctions.GetULongFromUser("Enter largest number to test for prime: ", 2, 100000000UL);
			int producerThreadCount = IOFunctions.GetIntFromUser("Enter number of producer threads (1 - 64): ", 1, 64);
			int consumerThreadCount = IOFunctions.GetIntFromUser("Enter number of consumer threads (1 - 64): ", 1, 64);
			OutputHeader();
			ulong approxNumPrimes = MathStuff.ApproximateNumberOfPrimes(highest);
			List<Thread> producerThreads = new List<Thread>();
			List<Thread> consumerThreads = new List<Thread>();

			DateTime startTime = DateTime.Now;

			// Create the producer threads
			// TODO:

			// Create the consumer threads
			// TODO: 

			// Create the timer that will output the number of numbers left to process
			m_Timer = new Timer(CountTimerCallback, null, 500, 500);

			// Wait for producer threads...
			// TODO:

			// Wait for consumer threads...
			// TODO:
			
			
			m_Timer.Dispose();

			DateTime endTime = DateTime.Now;

			CountTimerCallback(null);
			Console.SetCursorPosition(0, 8);
			Console.WriteLine("Processing took: {0} ms", endTime.Subtract(startTime).TotalMilliseconds);

			ShowStats();

			ShowPrimes(highest);

			Console.WriteLine();
			Console.Write("Press <ENTER> to quit...");
			Console.ReadLine();
		}

		/// <summary>
		/// Shows the statistics for the calculations
		/// </summary>
		private static void ShowStats()
		{
			Console.WriteLine();
			if (IOFunctions.GetBoolFromUser("Would you like to see the statistics? "))
			{
				// Output results
				Console.WriteLine();
				int primesFound = 0;
				foreach (int key in m_Primes.Keys)
				{
					Console.WriteLine("Thread {0} found {1:N0} primes.", key, m_Primes[key].Count);
					primesFound += m_Primes[key].Count;
				}
				Console.WriteLine("Total: {0:N0} primes.", primesFound);
			}
		}

		/// <summary>
		/// Method that displays the found primes
		/// </summary>
		/// <param name="highest">Largest number that primes were calculated for</param>
		private static void ShowPrimes(ulong highest)
		{
			Console.WriteLine();
			if (IOFunctions.GetBoolFromUser("Would you like to see the primes? "))
			{
				int highestNumberLen = highest.ToString().Length;
				int resultsPerRow = (Console.WindowWidth - 1) / (highestNumberLen + 1);
				string format = "{0," + highestNumberLen.ToString() + "} ";

				// Use a sorted set to combine all of the lists of primes
				SortedSet<ulong> sortedPrimes = new SortedSet<ulong>();
				foreach (int key in m_Primes.Keys)
				{
					sortedPrimes.UnionWith(m_Primes[key]);
					m_Primes[key].Clear();
				}

				// Print the primes into columns
				int col = 0;
				foreach (ulong prime in sortedPrimes)
				{
					Console.Write(format, prime);
					col++;
					if (col >= resultsPerRow)
					{
						Console.WriteLine();
						col = 0;
					}
				}
			}
		}

		/// <summary>
		/// Timer to update number of items left to process
		/// </summary>
		/// <param name="state"></param>
		private static void CountTimerCallback(object state)
		{
			lock (m_ConsoleLock)
			{
				Console.SetCursorPosition(9 , 6);
				Console.Write("{0,10:0}        ", m_Numbers.Count);
			}
		}

		/// <summary>
		/// Outputs the thread status header
		/// </summary>
		private static void OutputHeader()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.SetCursorPosition(0, 0);
			Console.WriteLine("        |0         1         2         3         4         5         6   ");
			Console.WriteLine("        |0123456789012345678901234567890123456789012345678901234567890123");
			Console.WriteLine("-------------------------------------------------------------------------");
			Console.WriteLine("Producer|");
			Console.WriteLine("Consumer|");
			Console.WriteLine("        |");
			Console.WriteLine("#s Left | ");
			Console.WriteLine();
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.White;
		}

		/// <summary>
		/// Updates the status of the current thread
		/// </summary>
		/// <param name="threadNum">Thread number</param>
		/// <param name="isProducer">true if producer thread, false if consumer thread</param>
		/// <param name="status">Character to display in the status window</param>
		private static void UpdateThreadStatus(int threadNum, bool isProducer, char status)
		{
			lock (m_ConsoleLock)
			{
				Console.SetCursorPosition(9 + threadNum, 3 + (isProducer ? 0 : 1));
				Console.Write(status);
			}
		}
				
		/// <summary>
		/// Method to populate the numbers queue
		/// </summary>
		/// <param name="state">Contains the start, increment and upper bound for the numbers to add</param>
		static void ProducerThread(object state)
		{
			// TODO:
		}

		/// <summary>
		/// Consumer thread that pulls values from the numbers queue and determines if they are prime
		/// </summary>
		/// <param name="state">Contains the id of the thread</param>
		static void ConsumerThread(object state)
		{
			// TODO:
		}

	}
}
