namespace CopyTextFile
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\Users\\nik88\\OneDrive\\Desktop\\1";


                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();


                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        // Получить название файла без расширения
                        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
                        // Создать новое имя файла с другим расширением
                        string newFilePath = Path.ChangeExtension(filePath, ".txt");

                        using StreamWriter write = new StreamWriter(newFilePath, false);
                        write.WriteLine(reader.ReadToEnd());


                    }
                }
            }

        }
    }
}