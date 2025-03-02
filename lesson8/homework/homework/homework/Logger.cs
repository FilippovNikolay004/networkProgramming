using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logger {
    internal class Logger {
        private FileStream fs;
        private string _nameFile;

        public Logger(string nameFile) { _nameFile = nameFile; }

        public void Log(string msg) {
            fs = new FileStream(_nameFile, FileMode.Append, FileAccess.Write);

            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine($"[{DateTime.Now}] - {msg}");

            sw.Close();
            fs.Close();
        }

        public void ReadLog() {
            fs = new FileStream(_nameFile, FileMode.Open, FileAccess.Read);

            StreamReader sr = new StreamReader(fs);
            string line = string.Empty;

            while (!sr.EndOfStream) {
                line = sr.ReadLine();
                Console.WriteLine(line);
            }
        }
    }
}