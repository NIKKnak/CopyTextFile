
using System.IO.Compression;
using System.Text.RegularExpressions;

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


            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string archivePath = openFileDialog.FileName;
                string fileNameToFind = "1.fpage"; // искомый файл

                using (ZipArchive archive = ZipFile.OpenRead(archivePath))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        if (entry.FullName.EndsWith(fileNameToFind, StringComparison.OrdinalIgnoreCase))
                        {
                            using (StreamReader reader = new StreamReader(entry.Open()))
                            {
                                string fileContent = reader.ReadToEnd();

                                // Поиск всех значений UnicodeString в файле
                                string pattern = @"UnicodeString\s*=\s*""([^""]*)""";
                                MatchCollection matches = Regex.Matches(fileContent, pattern);

                                if (matches.Count > 0)
                                {
                                    // Создание нового файла + запись
                                    string archiveFileName = Path.GetFileNameWithoutExtension(archivePath);
                                    string newFilePath = Path.Combine(Path.GetDirectoryName(archivePath), $"{archiveFileName}.txt");
                                    using (StreamWriter writer = new StreamWriter(newFilePath))
                                    {
                                        foreach (Match match in matches)
                                        {
                                            string unicodeString = match.Groups[1].Value;
                                            writer.WriteLine(unicodeString);
                                        }
                                    }

                                    MessageBox.Show("Файл успешно создан!");
                                }
                                else
                                {
                                    MessageBox.Show("UnicodeString не найден!");
                                }

                                break;
                            }
                        }
                    }
                }

            }
        }
    }
}
