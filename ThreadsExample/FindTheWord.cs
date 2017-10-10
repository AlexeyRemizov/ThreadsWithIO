using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace ThreadsWithIO
{
    public class FindTheWord
    {
        public string curFile = "D:\\InformClientLog.txt";
        public string curWord = "English";

        public Dictionary<int, string> FindTheWordInTheText(string curFile, string curWord)
        {
            var wordsStat = new Dictionary<int, string>();
            int amountInTheLine;
            try
            {
                using (var streamReader = new StreamReader(curFile))
                {

                    int numberOfString = 0;
                    string inputLine;

                    while (!streamReader.EndOfStream)
                    {
                        inputLine = streamReader.ReadLine();
                        numberOfString++;
                        amountInTheLine = new Regex(curWord).Matches(inputLine).Count;
                        if (amountInTheLine > 0)
                        {
                            wordsStat[numberOfString] = inputLine;
                        }

                    }


                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("The programm failed with an error.");
                Console.WriteLine(ex.ToString());
            }
            return wordsStat;
        }
    }
}
