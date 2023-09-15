namespace CopyTextFile
{
    public partial class Form1 : Form
    {
        string FileOld = @"C:\Users\nik88\OneDrive\Desktop\1\1.xps";
        string FileNew = @"C:\Users\nik88\OneDrive\Desktop\1\2.txt";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamReader read = new StreamReader(FileOld, true))
            {
                using StreamWriter write = new StreamWriter(FileNew, false);
                write.WriteLine(read.ReadToEnd());
            }


        }
    }
}