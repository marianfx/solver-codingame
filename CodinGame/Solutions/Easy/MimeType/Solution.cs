using System;
using System.Collections.Generic;
using System.Text;

namespace Solutions.Easy.MimeType
{
    public class Solution
    {
        static void Main(string[] args)
        {
            int tableCount = int.Parse(Console.ReadLine()); // Number of elements which make up the association table.
            int fileCount = int.Parse(Console.ReadLine()); // Number Q of file names to be analyzed.

            Dictionary<String, String> associations = new Dictionary<string, string>();//the dictionary containing the extension - description associations

            for (int i = 0; i < tableCount; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                string EXT = inputs[0].ToUpper(); // file extension, store it as UPPER
                string MT = inputs[1]; // MIME type.
                associations.Add(EXT, MT);
            }

            // Process File Names
            for (int i = 0; i < fileCount; i++)
            {
                string FNAME = Console.ReadLine(); // One file name per line.
                int pExt = FNAME.LastIndexOf('.');

                if (pExt < 0)// no extension => UNKNOWN
                {
                    Console.WriteLine("UNKNOWN");
                    continue;
                }

                string extension = FNAME.Substring(pExt + 1).ToUpper();// get extension as upper
                if (!associations.ContainsKey(extension))// extension not in dictionary => UNKNOWN
                {
                    Console.WriteLine("UNKNOWN");
                    continue;
                }

                Console.WriteLine(associations[extension]);//any other case = get it from the dictionary
            }
        }
    }
}
