using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneNumberSorter
{
    public partial class Form1 : Form
    {
        // Create variables
        string FILE_CONTENTS_DELETE = string.Empty;
        string FILE_CONTENTS_COMPARE = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Allows user to choose a .txt file to delete numbers from
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.InitialDirectory = "c:\\"; // Automatically directs user to c:\\ path when pop-up opens
                openFile.Filter = "txt files|*.txt"; // Restricts user to uploading only .txt files
                openFile.RestoreDirectory = true; // Resets director to original path

                if(openFile.ShowDialog() == DialogResult.OK)
                {
                    // First display file path in tbDelete for user to see
                    tbDelete.Text = openFile.SafeFileName;

                    // Retrieve contents of file
                    var fileStream = openFile.OpenFile();

                    // Store file contents into FILE_CONTENTS_DELETE variable
                    using(StreamReader fileReader = new StreamReader(fileStream))
                    {
                        FILE_CONTENTS_DELETE = fileReader.ReadToEnd(); // Makes one big string
                    }
                }
            }
        }

        /// <summary>
        /// Allows user to choose a .txt file to compare the first list to
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCompare_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileAgain = new OpenFileDialog())
            {
                openFileAgain.InitialDirectory = "c:\\"; 
                openFileAgain.Filter = "txt files|*.txt"; 
                openFileAgain.RestoreDirectory = true; 

                if (openFileAgain.ShowDialog() == DialogResult.OK)
                {
                    tbCompare.Text = openFileAgain.SafeFileName;

                    var fileStream2 = openFileAgain.OpenFile();

                    using (StreamReader fileReader2 = new StreamReader(fileStream2))
                    {
                        FILE_CONTENTS_COMPARE = fileReader2.ReadToEnd(); 
                    }
                }
            }
        }

        /// <summary>
        /// Compares the first list to the second and deletes any differing numbers
        /// from list 1. Produces a new list in a .txt file for the user to save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnParse_Click(object sender, EventArgs e)
        {
            // Create array lists
            List<Int64> deletableList = new List<Int64>();
            List<Int64> comparableList = new List<Int64>();

            // Separate list data
            string[] deletableLines = FILE_CONTENTS_DELETE.Split('\n');
            string[] comparableLines = FILE_CONTENTS_COMPARE.Split('\n');

            // Store line data (numbers) into arrays
            for (int i = 0; i < deletableLines.Length; i++)
            {
                string simplifyLine = Regex.Replace(deletableLines[i], @"\t|\n|\r", "").Trim();

                deletableList.Add(Convert.ToInt64(simplifyLine));
            }

            for (int i = 0; i < comparableLines.Length; i++)
            {
                string simplifyLine = Regex.Replace(comparableLines[i], @"\t|\n|\r", "").Trim();

                comparableList.Add(Convert.ToInt64(simplifyLine));
            }

            // Compare lists and delete differing numbers from first list
            for(int i = deletableList.Count - 1; i >= 0; i--)
            {
                //If deletable list has a number different than comparable                
                if (!(comparableList.Contains(Convert.ToInt64(deletableList[i]))))
                {
                    // and DOES NOT start with 619, delete it
                    if (Convert.ToInt64(deletableList[i]) / 10000000 != 619)
                    {
                        deletableList.Remove(deletableList[i]);
                    }
                }
            }

            // Provide user with a file to save
            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.FileName = "newListOfNumbers.txt";
            saveFile.Filter = "txt files|*.txt";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(saveFile.OpenFile());

                for(int i = 0; i < deletableList.Count; i++)
                {
                    streamWriter.WriteLine(deletableList[i]);
                }

                streamWriter.Dispose();
                streamWriter.Close();
            }
        }
    }
}
