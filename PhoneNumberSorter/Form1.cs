using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
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
                "files that each contain a list of phone numbers; text files must use a one-phone-number-per-line " +
                "format. Below, click each 'Browse' button to upload a file to the corresponding box." +
                "The first box being the file that you want to delete from, and the second file being " +
                "for comparison purposes only. \n \nAfter your files are selected, you can input an area code " +
                "for any phone numbers you would like to keep; these will not be deleted from the first list. " +
                "You may also leave the text box empty if this option is not needed. Keep in mind that any " +
                "area code entered must be three digits long. Letters and two-digit numbers will not be accepted. " +
                "\n \nWhen 'Parse' is clicked, the program will search for differences between the two given .txt " +
                "files and delete those numbers from the first given list as long as it does not begin with the area " +
                "code given. If an area code is not given, then all differening phone numbers will be removed from the " +
                "first list. This new list will then be stored in a .txt file, which you will be asked to save to your " +
                "desktop with a popup. \n \nTo exit, either click the 'x' in the upper right corner or click on 'exit'.";
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
        /// from list 1 while retaining any numbers beginning with the given area code. 
        /// Produces a new list in a .txt file for the user to save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnParse_Click(object sender, EventArgs e)
        {
            // Save contents of tbAreaCode
            string areaCode = tbAreaCode.Text;

            //Make sure there are files selected
            if (!String.IsNullOrEmpty(tbDelete.Text) && !String.IsNullOrEmpty(tbCompare.Text))
            {
                // Create lists
                List<long> deletableList = new List<long>();
                List<long> comparableList = new List<long>();

                //Separate list data
                string[] deletableLines = FILE_CONTENTS_DELETE.Split('\n');
                string[] comparableLines = FILE_CONTENTS_COMPARE.Split('\n');

                // Store line data (numbers) into arrays
                LineDataToArray(deletableList, deletableLines);
                LineDataToArray(comparableList, comparableLines);

                // Make sure area code is either three digits or empty, returns true
                //if area code is acceptable and false if not
                if(CheckAreaCode(areaCode))
                {
                    CompareListsWithAreaCode(deletableList, comparableList, Convert.ToInt16(areaCode));

                    //Provide user with a file to save
                    SaveNewFile(deletableList);

                    //Clear textboxes
                    ClearTextBoxes();
                }
                else
                {
                    if(String.IsNullOrWhiteSpace(areaCode))
                    {
                        CompareListsWithNoAreaCode(deletableList, comparableList);

                        //Provide user with a file to save
                        SaveNewFile(deletableList);

                        //Clear textboxes
                        ClearTextBoxes();
                    }
                }                
            }
            else
            {
                MessageBox.Show("Please make sure two files are selected",
                    "Oh, no!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
        /// Makes sure area code is only used when it is valid: three numeric characters
        /// or nothing at all
        /// </summary>
        /// <param name="areaCode"></param>
        /// <returns></returns>
        private static bool CheckAreaCode(string areaCode)
        {
            //Compare lists and delete differing numbers from first list, saving numbers
            //with given area code
            if (areaCode.Length == 3) // Making sure there is a 3-character numeric area code to work with
            {
                if (LookForNumbers(areaCode))
                {
                    return true;
                }
                else // If area code ISN'T all numbers, give a warning
                {
                    MessageBox.Show("Only numeric area codes are accepted",
                                            "Oh, no!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                //If the code entered IS NEITHER 3 characters nor 0, give a warning
                if (areaCode.Length == 2 || areaCode.Length == 1)
                {
                    MessageBox.Show("Any area code entered must be a total of three digits",
                        "Oh, no!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }

            return false;
        }

        /// <summary>
        /// Checks a string of three characters to make sure they are all
        /// numeric values
        /// </summary>
        /// <param name="areaCode"></param>
        /// <returns>True if every character is a number</returns>
        private static bool LookForNumbers(string areaCode)
        {
            //Variables
            bool index0isNumber = false;
            bool index1isNumber = false;
            bool index2isNumber = false;

            for(int i = 0; i < 3; i++)
            {
                if(areaCode[i] == '1' ||
                    areaCode[i] == '2' ||
                    areaCode[i] == '3' ||
                    areaCode[i] == '4' ||
                    areaCode[i] == '5' || 
                    areaCode[i] == '6' ||
                    areaCode[i] == '7' ||
                    areaCode[i] == '8' ||
                    areaCode[i] == '9' ||
                    areaCode[i] == '0')
                {
                    if(i == 0)
                    {
                        index0isNumber = true;
                    }
                    else if(i == 1)
                    {
                        index1isNumber = true;
                    }
                    else
                    {
                        index2isNumber = true;
                    }
                }
            }

            return index0isNumber && index1isNumber && index2isNumber;
        }

        /// <summary>
        /// Compares the deletableList to the comparableList and removes
        /// differing numbers that DO NOT beging with the given area code
        /// </summary>
        /// <param name="deletableList"></param>
        /// <param name="comparableList"></param>
        /// <param name="areaCode"></param>
        private static void CompareListsWithAreaCode(List<long> deletableList, List<long> comparableList, int areaCode)
        {
            for (int i = deletableList.Count - 1; i >= 0; i--)
            {
                //If deletable list has a number different than comparable                
                if (!(comparableList.Contains(deletableList[i])))
                {
                    // and DOES NOT start with the area code, delete it
                    if (deletableList[i] / 10000000 != Convert.ToInt16(areaCode))
                    {
                        deletableList.Remove(deletableList[i]);
                    }
                }
            }
        }

        /// <summary>
        /// Compares the deletableList to the comparableList and removes
        /// differing numbers (no area code involved)
        /// </summary>
        /// <param name="deletableList"></param>
        /// <param name="comparableList"></param>
        private static void CompareListsWithNoAreaCode(List<long> deletableList, List<long> comparableList)
        {
            for (int i = deletableList.Count - 1; i >= 0; i--)
            {              
                if (!(comparableList.Contains(deletableList[i])))
                {
                    deletableList.Remove(deletableList[i]);
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
        /// Removes all text from textboxes
        /// </summary>
        private void ClearTextBoxes()
        {
            tbDelete.Clear();
            tbCompare.Clear();
            tbAreaCode.Clear();
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
