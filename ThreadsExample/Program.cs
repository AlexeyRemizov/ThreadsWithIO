using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace ThreadsWithIO
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            FindTheWord ftw = new FindTheWord();

            if (ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc), ftw))
            {
                Console.WriteLine("Main Thread does some work");
                Thread.Sleep(1000);

                Console.WriteLine("Exit from main thread");
            }
            else
                Console.WriteLine("Unable to queue ThreadPool request.");
            Console.ReadKey();
        }

        static void ThreadProc(object stateInfo)
        {
            FindTheWord ftw = (FindTheWord)stateInfo;
            foreach (var wordsNumber in ftw.FindTheWordInTheText(ftw.curFile, ftw.curWord).OrderByDescending(ws => ws.Value))
            {
                Console.WriteLine("Substring {0} is in line #{1} and occurs <<< {2} >>> ", ftw.curWord, wordsNumber.Key, wordsNumber.Value);
            }


        }
    }
}
