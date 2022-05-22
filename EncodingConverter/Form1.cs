using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncodingConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            FilePath();
            encodeConverter();
            //Reader();
        }
        string filename;

        public void FilePath()
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FilterIndex = 0;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                filename = openFileDialog1.FileName;
            }

        }
        //USEFULL när du vill hitta Encoding med Bytes
        //public static Encoding GetEncoding(string filename)
        //{
        //    // Read the BOM
        //    var bom = new byte[4];
        //    using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read))
        //    {

        //        file.Read(bom, 0, 4);

        //    }

        //    // Analyze the BOM
        //    if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76) return Encoding.UTF7;
        //    if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) return Encoding.UTF8;
        //    if (bom[0] == 0xff && bom[1] == 0xfe) return Encoding.Unicode; //UTF-16LE
        //    if (bom[0] == 0xfe && bom[1] == 0xff) return Encoding.BigEndianUnicode; //UTF-16BE
        //    if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return Encoding.UTF32;
        //    return Encoding.ASCII;
        //}
        int lineCounter;
        public void encodeConverter() {

            //Encoding latin = Encoding.GetEncoding(1252);
            //Encoding arabicChar = Encoding.GetEncoding(1256);
            //StreamWriter Writer = new StreamWriter(filename + " Fixed.srt");
            string[] Reader = File.ReadAllLines(filename);
            lineCounter = Reader.Count();
            string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ////foreach(string line in Reader)
            //// {
            //for (int i = 1; i <= lineCounter; i++)
            //{               
            //    //lineChanger(result, filename, i);
            //    //Console.WriteLine("Line Number {0}: {1}", i,lin);
            //}
            //string nnn = Reader[2];
            //byte[] bytes = latin.GetBytes(nnn);
            ////string lin = File.ReadLines(filename).Skip(i).Take(1).First();
            //result = arabicChar.GetString(bytes);
            //Console.WriteLine(result);
            //File.WriteAllText(DesktopPath + "\\Info.txt", result);
            //Stops for Loop

            //}
            // }
            //Console.WriteLine("\n\n\n{0}",moststop);
            //Console.WriteLine(lin);
            //Console.WriteLine("Done\n {0} ",lin);
            //for(int i= 0; i <= File.ReadAllLines(filename).Count(); i++)
            //{
            using (StreamReader se = new StreamReader(filename))
            {
                string sgj = se.ReadToEnd();
                Console.WriteLine("Passed");

              //  string q = sgj; // UTF16.
              //  UTF7Encoding utf = new UTF7Encoding(); // Used to convert UTF16 to/from UTF7

              //  // Convert UTF16 to ANSI codepage 1256. winByte[] will be ANSI codepage 1256.
              //  byte[] winByte = Encoding.GetEncoding(1256).GetBytes(q);
              //  foreach(byte Byte in winByte)
              //  {
              //      Console.WriteLine(@"This is Byte: [0]", Byte);
              //  }
              ////  Console.WriteLine("winByte: "+winByte[]);
              //  // Convert UTF7 to UTF16.
              //  // But this is WRONG because winByte is ANSI codepage 1256, NOT UTF7!
              //  string result = utf.GetString(winByte);
              ////  Console.WriteLine("Result: "+result);
              //  // Debug.Assert(result != q); // So result doesn't equal q
                
              //  // The CORRECT way to convert the ANSI string back:
              //  // Convert ANSI codepage 1256 string to UTF16
              //  result = Encoding.GetEncoding(1256).GetString(winByte);
                // Console.WriteLine("New Result: "+result);
                //  Debug.Assert(result == q); // Now result DOES equal q
                File.WriteAllText(DesktopPath + "\\ NEw.SRT", sgj);

            }

            //  string[] PerText = File.ReadAllLines(filename);
            // Console.WriteLine("Using System.IO.File: {0}", PerText[i]);

            //}

        }


        static void lineChanger(string newText, string fileName , int line_to_edit)
        {

            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }
        public void Reader()
        {

            using (StreamReader reader = new StreamReader(filename))
            {
                string newfilename = filename.Replace(".srt", "Fixed.srt");

                using (StreamWriter Writer =new StreamWriter(newfilename))
                {
                    int currentLine = 0; 
                    for (int i = 0; i < lineCounter; i++)
                    {

                    }
                }


            }
        }

    }
}
