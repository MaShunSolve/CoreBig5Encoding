using System.IO;
using System.IO.Pipes;
using System.Text;

namespace EncodingTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\user\Desktop\TFA4";
            long fileLen = 0;
            fileLen = ReadUseStreamReader(filePath);
            Console.WriteLine(fileLen);
            fileLen = ReaUseFileStream(filePath);
            Console.WriteLine(fileLen);
            Console.ReadLine();
        }
        public static long ReadUseStreamReader(string filePath)
        {
            long result = 0;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var encoding = Encoding.GetEncoding(950);
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            Console.WriteLine(fs.Length);
            using (StreamReader stream = new StreamReader(fs, encoding))
            {
                result = stream.ReadLine().Length;
            }
            return result;
        }
        public static long ReaUseFileStream(string filePath)
        {
            long result = 0;
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            result = fs.Length;
            return result;
        }
    }
}