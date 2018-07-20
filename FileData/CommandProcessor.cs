using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdPartyTools;

namespace FileData
{
    public static class CommandProcessor
    {
        //Array of accepted commands for File Version
        private static string[] versionCommands = { "-v", "--v", "/v", "--version" };
        //Array of accepted commands for File Size
        private static string[] sizeCommands = { "-s", "--s", "/s", "--size" };

        //Returns the requested file details
        public static string getFileDetails(FileDetails fc, string[] args)
        {
            //Checks if the args array has the required number of elements
            //First element should be the command, the second element should be the file path
            if (args.Length != 2)
            {
                throw new System.ArgumentException("Number of arguments out of range", "args");
            }

            if (versionCommands.Contains(args[0]))
            {
                return fc.Version(args[1]);
            }
            else if (sizeCommands.Contains(args[0]))
            {
                return fc.Size(args[1]).ToString();
            }
            else
            {
                //The command is not a member of the accepted commands
                throw new System.ArgumentException("Command not found", args[0]);
            }
        }
    }
}
