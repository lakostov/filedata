using System;
using System.Collections.Generic;
using System.Linq;
using ThirdPartyTools;

namespace FileData
{
    public static class Program
    {
        private static string output;
        public static void Main(string[] args)
        {
            try
            {
                output = CommandProcessor.getFileDetails(new FileDetails(), args);

                Console.Out.WriteLine(output);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message); 
            } 
        }
    }
}
