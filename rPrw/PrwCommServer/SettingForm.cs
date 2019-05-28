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

namespace PrwCommServer
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            if (MainForm.DataBasePathName != null)
            {
                textBox_DbFilePath.Text = MainForm.DataBasePathName;
                textBox_Port.Text = MainForm.Port.ToString();
            }
        }

        private void button_OpenFile_Click(object sender, EventArgs e)
        {
            FileDialog dlg = new OpenFileDialog();
            DialogResult dr = dlg.ShowDialog();
            if (dr == DialogResult.OK)
            {
                textBox_DbFilePath.Text = dlg.FileName;
            }
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox_DbFilePath.Text))
            {
                Registor.SetRegistryKey("DataBasePathName", textBox_DbFilePath.Text);
                Registor.SetRegistryKey("Port", int.Parse(textBox_Port.Text));
                Close();
            }
            else
            {
                MessageBox.Show("指定的文件不存在");
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
