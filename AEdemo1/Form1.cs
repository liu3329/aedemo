using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AEdemo1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bt_openfiledialog_Click(object sender, EventArgs e)
        {
            OpenFileDialog pOpenFileDialog = new OpenFileDialog();
            pOpenFileDialog.CheckFileExists = true;
            pOpenFileDialog.Title = "�򿪵�ͼ�ĵ�";
            pOpenFileDialog.Filter = "arcmap�ĵ���*.mxd��|*.mxd";
            pOpenFileDialog.Multiselect = false;
            pOpenFileDialog.RestoreDirectory = true;
            if (pOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string pFileName = pOpenFileDialog.FileName;
                if (pFileName == "")
                {
                    return;
                }
                if (mainMapControl.CheckMxFile(pFileName)) //����ͼ�ĵ�����Ч��
                {
                    mainMapControl.LoadMxFile(pFileName);//��ͼ�ռ����mxd�ĵ�

                }
                else
                {
                    MessageBox.Show(pFileName + "����Ч�ĵ�", "��Ϣ��ʾ");
                    return;
                }
            }
        }
    }
}