using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace EncodingConverter
{
    public partial class Form1 : Form
    {
        int _foundedCode;
        string filePath;
        string _charSetName;
        private static string _safeFileName;
        readonly string _desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public Form1()
        {
            InitializeComponent();
            Converter.Enabled = false;
        }
        public void FilePath()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FilterIndex = 0;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                _safeFileName = openFileDialog1.SafeFileName;
                Console.WriteLine($"filename: {filePath}\nsafefilename: {_safeFileName}");
                Converter.Enabled = true;
            }
        }

        public string[] multiselect()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "srt files (*.srt)|*.srt";
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in ofd.FileNames)
                {
                    Console.WriteLine(file);
                }
                return ofd.FileNames;
            }

            return null;
        }
        //public void EncodingCheck()
        //{
        //    Console.WriteLine();
            
        //    bool detecbyteordermark =true;
        //    using (var reader = new StreamReader(filename, detecbyteordermark))
        //    {
        //        reader.Peek(); // you need this!
        //        var encoding = reader.CurrentEncoding;
        //        Console.WriteLine(encoding);
        //    }


        //}
        public void EncoderConverter(string path)
        {
            using (FileStream fs = File.OpenRead(path))
            {
                Ude.CharsetDetector charDet = new Ude.CharsetDetector();
                charDet.Feed(fs);
                charDet.DataEnd();
                _charSetName = charDet.Charset;
                
                charDet.Reset();
            }
            if (_charSetName != null)
            {
                foreach (EncodingInfo ei in Encoding.GetEncodings())
                {
                    if (_charSetName.ToLower() == ei.Name)
                    {
                        _foundedCode = ei.CodePage;
                        Console.WriteLine("founded code is : " + ei.CodePage);
                        Console.WriteLine($"unicode is: {ei.Name}");

                        if (_foundedCode == 0)
                        {
                            Console.WriteLine("didn't find code page");
                        }
                        else
                        {
                            OutputBox.RightToLeft = RightToLeft.No;
                            string msg = "This file already has been modified";
                            OutputBox.Text = msg;
                            break;
                        }
                    }
                }
            }
            else
            {
                string ans=converter(path);
                File.WriteAllText(path, ans, Encoding.UTF8);
                OutputBox.Text = ans;
                OutputBox.RightToLeft = RightToLeft.Yes;   
            }
        }
        private string converter(string fPath)
        {
            byte[] readers = File.ReadAllBytes(fPath);

            char[] characters = Encoding.GetEncoding(0).GetChars(readers);

            byte[] bytes = Encoding.GetEncoding(0).GetBytes(characters);

            string result = Encoding.GetEncoding(1256).GetString(bytes);

            return result;
        }
        private void LoadBtn_Click(object sender, EventArgs e)
        {
            FilePath();
        }
        private void ConvertBtn_Click(object sender, EventArgs e)
        {
            EncoderConverter(filePath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] paths = multiselect();
            foreach (var fp in paths)
            {
                EncoderConverter(fp);
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
