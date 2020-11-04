using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Custom
using Sem3Lab5_Levenshteyn;

namespace Sem3Lab4_WF_Files
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static List<string> words;

        List<string> GetWords(string path)
        {
            string fileData = File.ReadAllText(path, Encoding.UTF8);
            List<string> words = fileData.Split().ToList();
            words = words.Distinct().ToList();
            return words;
        }

        private void ReadFileBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                string path = @"c:\file.txt";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog.FileName;
                }
                if (!File.Exists(path))
                {
                    string textSeed = "Zdarova che kavo?";
                    File.WriteAllText(path, textSeed, Encoding.UTF8);
                }

                words = GetWords(path);

                OutputListBox.BeginUpdate();
                OutputListBox.Items.Clear();
                OutputListBox.EndUpdate();
            }
        }

        private void SearchWordButton_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string SearchingWord = SearchingWordInput.Text;
            OutputListBox.BeginUpdate();


            //Первый вариант выполнения
            
            foreach (var word in words)
            {
                if (word.Contains(SearchingWord))
                {
                    OutputListBox.Items.Add(word);
                }
            }
            

            //Второй выриант выполнеия starts
            /*
            var LevensteinDistances = words.Select(word => new { LevD = Levenshtein.LevenshteinDistance(word, SearchingWord), Word = word }).ToList();
            var minLevDist = LevensteinDistances.Min(i => i.LevD);
            var res = LevensteinDistances.Where(i => i.LevD == minLevDist);

            foreach (var item in res)
            {
                OutputListBox.Items.Add(item.Word);
            }
            */
            //Второй выриант выполнеия ends

            OutputListBox.EndUpdate();
            stopwatch.Stop();

            TimeSpan ts = stopwatch.Elapsed;
            string output = String.Format("{0}s {1}ms", ts.Seconds, ts.Milliseconds);
            OutputLabel.Text = output + "\t Всего слов " + words.Count() + " штук";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
