using MAB.DotIgnore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GitIgnoreExecutor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetupProgramState();
            UpdateProgramState();
        }

        private void SetupProgramState()
        {
            toolTip1.SetToolTip(checkBox1, "Programın yanlış kullanılması durumunda seçilen dizinde silinmesi istenmeyen dosyalar silinebilir, bu durumda kullanıcının kendisi sorumludur." +
                "\nLütfen seçtiğiniz .gitignore kurallarının ve özellikle de dizinin doğru olduğundan emin olunuz." +
                "\nEğer .gitignore kurallarının nasıl çalıştığını bilmiyorsanız programı kullanmayınız.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            UpdateProgramState();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            UpdateProgramState();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateProgramState();
        }

        private void UpdateProgramState()
        {
            // Only enable the button if checkbox is checked
            button1.Enabled = checkBox1.Checked;

            // Update text box contents accordingly
            textBox1.Text = openFileDialog1.FileName;
            textBox2.Text = folderBrowserDialog1.SelectedPath;

            // Ensure selected file exists
            if (!File.Exists(textBox1.Text))
            {
                textBox1.Text = "Lütfen geçerli bir dosya seçiniz.";
                button1.Enabled = false;
            }

            // Ensure selected directory exists
            if (!Directory.Exists(textBox2.Text))
            {
                textBox2.Text = "Lütfen geçerli bir dizin seçiniz.";
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // As this method is called, it is assumed that the ruleset file path and target directory path are valid

            var promptResult = MessageBox.Show(
                "Program seçilen dizindeki tüm dosyaları tarayacak ve sağlanan .gitignore kuralları ile filtreleyecek. Bu işlem biraz vakit alabilir.",
                "Bilgi",
                 MessageBoxButtons.OKCancel,
                 MessageBoxIcon.Information
                 );

            // Abort if canceled etc
            if (promptResult != DialogResult.Yes)
            {
                return;
            }

            // Perform the search and filtering
            var searchResult = GetTargetFiles(textBox1.Text, textBox2.Text);

            // Final 'warning' for the user
            DialogResult dialogResult = MessageBox.Show(
                "Tarama tamamlandı. Seçilen dizin ve .gitignore kurallarıyla görmezden gelinmesi talep edilen toplamda " + searchResult.ignoredPaths.Count + " dosya/dizin bulundu. " +
                "\n\nTüm bu dosyaları silmek istediğinize emin misiniz? Bu işlem geri alınamaz ve biraz vakit alabilir.",
                "Dikkat",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2
                );

            // Abort if canceled etc
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }

            // Delete all file and folders that are ignored per the .gitignore rules
            //
            // Note: This part of the program could probably benefit from starting with directories and then handling files
            // because the loop is likely wasting time deleting files one by one when their parent directory might be flagged
            // for deletion, maknig the process slower than it should be
            foreach (var file in searchResult.ignoredPaths)
            {
                // 'file' may be a directory in which case Directory API must be used for deletion
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
                else
                {
                    Directory.Delete(file, true);
                }
            }

            // Success message (hopefully)
            MessageBox.Show(
                "İşlem tamamlandı. Toplamda " + searchResult.ignoredPaths.Count + " dosya/dizin silindi.",
                "Bilgi",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information
                 );
        }

        // A tuple should suffice for this use case
        //
        // Note: We can probably just remove otherPaths and return a single list but I prefer to keep it for debugging purposes
        private static (List<string> ignoredPaths, List<string> otherPaths) GetTargetFiles(string ignoreFilePath, string targetDirectoryPath)
        {
            List<string> ignored = new List<string>();
            List<string> other = new List<string>();

            var ignoreList = new IgnoreList(ignoreFilePath);

            // This could be made better but it is easier to read this way
            var filePaths = Directory.GetFiles(targetDirectoryPath, "*", SearchOption.AllDirectories);
            var directoryPaths = Directory.GetDirectories(targetDirectoryPath);
            var allPaths = filePaths.Concat(directoryPaths);

            // Populate the lists
            foreach (var path in allPaths)
            {
                bool isDirectory = Directory.Exists(path);
                if (ignoreList.IsIgnored(path, isDirectory))
                {
                    ignored.Add(path);
                }
                else
                {
                    other.Add(path);
                }
            }

            return (ignored, other);
        }
    }
}
