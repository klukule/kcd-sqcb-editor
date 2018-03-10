using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQCBEditor
{
    public partial class Form1 : Form
    {
        private SQCBFile File;
        public Form1()
        {
            InitializeComponent();
            File = null;
            LB_Files.SelectedIndexChanged += SelectedSoundChanged;
            TS_Save.Enabled = false;
            TS_CEdit.Enabled = false;
            TS_Export.Enabled = false;
        }

        private void SelectedSoundChanged(object sender, EventArgs e)
        {
            playbackPanel1.CleanUp();
            if(LB_Files.SelectedIndex >= 0)
                playbackPanel1.BeginPlayback(new MemoryStream(File.Entries[LB_Files.SelectedIndex].Data));

            TS_Export.Enabled = LB_Files.SelectedIndex > 0;
            TS_RemoveSelected.Enabled = LB_Files.SelectedIndex > 0;
        }

        private void LoadFile(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog
            {
                Filter = "Sequencer bank file|*.sqcb"
            };
            if(fd.ShowDialog() == DialogResult.OK)
            {
                using (Stream stream = fd.OpenFile())
                {
                    File = SQCBFile.LoadFile(stream);
                }
            }

            LB_Files.Items.Clear();
            foreach (var entry in File.Entries)
            {
                LB_Files.Items.Add(entry.Name);
            }

            TS_Save.Enabled = true;
            TS_CEdit.Enabled = true;
        }

        private void SaveFile(object sender, EventArgs e)
        {
            //Shouldn't really happen, but whatever
            if(File != null)
            {
                SaveFileDialog sfd = new SaveFileDialog()
                {
                    Filter = "Sequencer bank file|*.sqcb",
                };

                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    using (Stream fs = sfd.OpenFile())
                    {
                        SQCBFile.SaveFile(fs, File);
                    }
                }
            }
        }

        private void TS_Export_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "OGG Sound file|*.ogg",
                FileName = File.Entries[LB_Files.SelectedIndex].Name
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (Stream fs = sfd.OpenFile())
                {
                    fs.Write(File.Entries[LB_Files.SelectedIndex].Data, 0, File.Entries[LB_Files.SelectedIndex].Length);
                }
            }
        }

        private void TS_Import_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog
            {
                Filter = "OGG Sound file|*.ogg"
            };
            if (fd.ShowDialog() == DialogResult.OK)
            {
                using (Stream stream = fd.OpenFile())
                using (MemoryStream ms = new MemoryStream((int)stream.Length))
                {
                    stream.CopyTo(ms);
                    SQCBFile.FileEntry entry = new SQCBFile.FileEntry
                    {
                        Name = Path.GetFileName(fd.FileName),
                        Data = ms.ToArray(),
                        Offset = 0, //Will be calculated during export
                        Length = (int)ms.Length
                    };
                    File.Entries.Add(entry);
                }
                LB_Files.Items.Clear();
                foreach (var entry in File.Entries)
                {
                    LB_Files.Items.Add(entry.Name);
                }

                TS_Save.Enabled = true;
                TS_CEdit.Enabled = true;
            }
        }

        private void TS_ExportAll_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog()
            {
                Description = "Please select folder to export .ogg files to"
            };

            if (fbd.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                foreach (var item in File.Entries)
                {
                    using (FileStream fs = new FileStream(Path.Combine(fbd.SelectedPath, item.Name), FileMode.Create, FileAccess.Write))
                    {
                        fs.Write(item.Data, 0, item.Data.Length);
                    }
                }
            }
        }

        private void TS_New_Click(object sender, EventArgs e)
        {
            File = new SQCBFile();

            LB_Files.Items.Clear();
            foreach (var entry in File.Entries)
            {
                LB_Files.Items.Add(entry.Name);
            }

            TS_Save.Enabled = true;
            TS_CEdit.Enabled = true;
        }

        private void TS_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TS_RemoveSelected_Click(object sender, EventArgs e)
        {
            if(LB_Files.SelectedIndex > -1)
                File.Entries.RemoveAt(LB_Files.SelectedIndex);

            LB_Files.Items.Clear();
            foreach (var entry in File.Entries)
            {
                LB_Files.Items.Add(entry.Name);
            }

            TS_RemoveSelected.Enabled = LB_Files.SelectedIndex > 0;
        }
    }
}
