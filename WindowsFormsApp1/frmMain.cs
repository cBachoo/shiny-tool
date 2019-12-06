using System;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        //important variables
        string path = "./counter.txt";
        int currentCount = 0;

        private void writeFile()
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(currentCount);
                sw.Close();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            if (File.Exists(path))
            {
                //open the file and grab the counter and then close the scanner stream
                StreamReader sr = new StreamReader(path);
                string raw = sr.ReadLine();
                currentCount = int.Parse(raw);
                lblCounter.Text = raw;
                sr.Close();
            } else
            {
                writeFile();
            }
        }

        //set, add, subtract, reset buttons while writing to file each time 
        private void btnSetInput_Click(object sender, EventArgs e)
        {
            int value = int.Parse(txtInput.Text);
            lblCounter.Text = value.ToString();
            currentCount = value;
            writeFile();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            currentCount += 1;
            lblCounter.Text = currentCount.ToString();
            writeFile();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            currentCount -= 1;
            lblCounter.Text = currentCount.ToString();
            writeFile();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            currentCount = 0;
            lblCounter.Text = "0";
            writeFile();
        }
        
        //grab all keypresses on the file while the program is in focus
        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Z )
            {
                currentCount += 1;
                lblCounter.Text = currentCount.ToString();
                writeFile();
            } else if(e.KeyCode == Keys.X)
            {
                currentCount -= 1;
                lblCounter.Text = currentCount.ToString();
                writeFile();
            }
        }
    }
}
