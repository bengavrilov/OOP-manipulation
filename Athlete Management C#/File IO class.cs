using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Wrestling_Manager
{
    class FileIO
    {
        StreamWriter fileOut;
        StreamReader fileIn;

        public FileIO()
        {

        }

        public void UpdateFile(List<string> output, string nameOfFile)
        {
            File.WriteAllText(nameOfFile, String.Empty);

            fileOut = File.AppendText(nameOfFile);

            for (int counter = 0; counter < output.Count; counter++)
            {
                fileOut.WriteLine(output[counter]);
            }

            fileOut.Close();
        }

        public List<string> ReadFile(string nameOfFile)
        {
            List<string> fileInfo = new List<string>();
            string txt = "";

            fileIn = File.OpenText(nameOfFile);

            while (fileIn.EndOfStream == false)
            {
                txt = fileIn.ReadLine();
                fileInfo.Add(txt);
            }

            fileIn.Close();

            return fileInfo;
        }

        public void CreateFile(string nameOfFile)
        {
            var fileNew = File.Create(nameOfFile);
            fileNew.Close();
        }
    }
}
