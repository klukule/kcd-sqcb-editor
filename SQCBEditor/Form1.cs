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
        }

        private void SelectedSoundChanged(object sender, EventArgs e)
        {
            playbackPanel1.CleanUp();
            playbackPanel1.BeginPlayback(new MemoryStream(File.Entries[LB_Files.SelectedIndex].Data));
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
    }
}
