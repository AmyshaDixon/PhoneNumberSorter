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

            //Adds directions to lblDirections at the top of the app when app opens
            lblDirections.Text = "This is a program that sorts through and compares two given .txt " +
                "files that each contain a list of phone numbers; the .txt file must use a one-phone-number-per-line " +
                "format. Below, click each 'Browse' button to upload a file to the corresponding box." +
                "The first box being the file that you want to delete from, and the second file being " +
                "for comparison purposes only. \n \nWhen 'Parse' is clicked, the program will search for " +
                "differences between the two given .txt files and delete those numbers from the first " +
                "given list as long as it does not begin with the 619 area code. This new list will then " +
                "be stored in a .txt file, which you will be asked to save on your desktop with a popup. " +
                "\n \nTo exit, either click the 'x' in the upper right corner or click on 'exit'.";
        }

        /// <summary>
        /// Allows user to choose a .txt file to delete numbers from
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            ImportUserFile(true);
        }

        /// <summary>
        /// Allows user to choose a .txt file to compare the first list to
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCompare_Click(object sender, EventArgs e)
        {
            ImportUserFile(false);
        }

        /// <summary>
        /// Opens a dialog for the user to select files from their
        /// computer
        /// </summary>
        /// <param name="fileToggle"> Represents which variable to store the file
        /// information into; true for FILE_CONTENTS_DELETE and false for
        /// FILE_CONTENTS_COMPARE</param>
        private void ImportUserFile(bool fileToggle)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.InitialDirectory = "c:\\"; // Automatically directs user to c:\\ path when pop-up opens
                openFile.Filter = "txt files|*.txt"; // Restricts user to uploading only .txt files
                openFile.RestoreDirectory = true; // Resets director to original path

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    // First display file path in tbDelete for user to see
                    if (fileToggle)
                    {
                        tbDelete.Text = openFile.SafeFileName;
                    }
                    else
                    {
                        tbCompare.Text = openFile.SafeFileName;
                    }

                    // Retrieve contents of file
                    var fileStream = openFile.OpenFile();

                    // Store file contents into FILE_CONTENTS_DELETE variable
                    using (StreamReader fileReader = new StreamReader(fileStream))
                    {
                        if (fileToggle)
                        {
                            FILE_CONTENTS_DELETE = fileReader.ReadToEnd(); // Makes one big string
                        }
                        else
                        {
                            FILE_CONTENTS_COMPARE = fileReader.ReadToEnd();
                        }
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
            // Create lists
            List<long> deletableList = new List<long>();
            List<long> comparableList = new List<long>();

            // Separate list data
            string[] deletableLines = FILE_CONTENTS_DELETE.Split('\n');
            string[] comparableLines = FILE_CONTENTS_COMPARE.Split('\n');

            // Store line data (numbers) into arrays
            LineDataToArray(deletableList, deletableLines);
            LineDataToArray(comparableList, comparableLines);

            // Compare lists and delete differing numbers from first list
            CompareLists(deletableList, comparableList);

            // Provide user with a file to save
            SaveNewFile(deletableList);
        }

        /// <summary>
        /// Sepparates a given list of lines into tokens and
        /// stores them in a given array
        /// </summary>
        /// <param name="mainList"></param>
        /// <param name="lineList"></param>
        private static void LineDataToArray(List<long> mainList, string[] lineList)
        {
            for (int i = 0; i < lineList.Length; i++)
            {
                string simplifyLine = Regex.Replace(lineList[i], @"\t|\n|\r", "").Trim();

                mainList.Add(Convert.ToInt64(simplifyLine));
            }
        }

        /// <summary>
        /// Compares the deletableList to the comparableList and removed
        /// differing numbers that DO NOT beging with the area code 619
        /// </summary>
        /// <param name="deletableList"></param>
        /// <param name="comparableList"></param>
        private static void CompareLists(List<long> deletableList, List<long> comparableList)
        {
            for (int i = deletableList.Count - 1; i >= 0; i--)
            {
                //If deletable list has a number different than comparable                
                if (!(comparableList.Contains(deletableList[i])))
                {
                    // and DOES NOT start with 619, delete it
                    if (deletableList[i] / 10000000 != 619)
                    {
                        deletableList.Remove(deletableList[i]);
                    }
                }
            }
        }

        /// <summary>
        /// Pops open a dialog for the user to save a newly written
        /// file of numbers to their computer
        /// </summary>
        /// <param name="deletableList"></param>
        private static void SaveNewFile(List<long> deletableList)
        {
            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.FileName = "newListOfNumbers.txt";
            saveFile.Filter = "txt files|*.txt";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(saveFile.OpenFile());

                for (int i = 0; i < deletableList.Count; i++)
                {
                    streamWriter.WriteLine(deletableList[i]);
                }

                streamWriter.Dispose();
                streamWriter.Close();
            }
        }

        /// <summary>
        /// Allows user to exit the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
