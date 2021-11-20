using System;
using System.Drawing;
using System.Windows.Forms;

namespace paintdotnetHistoryManager
{
    public partial class MainForm : Form
    {
        string[,] list = RegistryWork.GetList();
        static Bitmap placeholder = BitmapWork.Base64StringToBitmap("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");
        
        void InitPics(string[,] list)
        {
            Bitmap[] pics = new Bitmap[10]; 
            for (int i = 0; i < 10; i++) {
                pics[i] = (list[i,1] != "") ? BitmapWork.Base64StringToBitmap(list[i, 1]) : placeholder;
            }
            Pic1 .Image = pics[0];
            Pic2 .Image = pics[1];
            Pic3 .Image = pics[2];
            Pic4 .Image = pics[3];
            Pic5 .Image = pics[4];
            Pic6 .Image = pics[5];
            Pic7 .Image = pics[6];
            Pic8 .Image = pics[7];
            Pic9 .Image = pics[8];
            Pic10.Image = pics[9];

            Name1 .Text = list[0,0];
            Name2 .Text = list[1,0];
            Name3 .Text = list[2,0];
            Name4 .Text = list[3,0];
            Name5 .Text = list[4,0];
            Name6 .Text = list[5,0];
            Name7 .Text = list[6,0];
            Name8 .Text = list[7,0];
            Name9 .Text = list[8,0];
            Name10.Text = list[9,0];
        }
        bool[] delstate = new bool[10];
        
        public MainForm()
        {
            InitializeComponent();
        }
        
        private void Apply_Click(object sender, EventArgs e)
        {
            delstate[0] = toRemove1 .Checked;
            delstate[1] = toRemove2 .Checked;
            delstate[2] = toRemove3 .Checked;
            delstate[3] = toRemove4 .Checked;
            delstate[4] = toRemove5 .Checked;
            delstate[5] = toRemove6 .Checked;
            delstate[6] = toRemove7 .Checked;
            delstate[7] = toRemove8 .Checked;
            delstate[8] = toRemove9 .Checked;
            delstate[9] = toRemove10.Checked;
            string[,] list1 = RegistryWork.Sort(list, delstate);
            RegistryWork.Write(list1);

            if (!NoInfo.Checked) {
                MessageBox.Show("Выполнено.", 
                                "Очистка истории", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);
            }

            toRemove1 .Checked = false;
            toRemove2 .Checked = false;
            toRemove3 .Checked = false;
            toRemove4 .Checked = false;
            toRemove5 .Checked = false;
            toRemove6 .Checked = false;
            toRemove7 .Checked = false;
            toRemove8 .Checked = false;
            toRemove9 .Checked = false;
            toRemove10.Checked = false;
            Updater_Click(null, null);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            InitPics(list);
        }

        private void PicClick(object sender, EventArgs e)
        {
            int cases = 0;
            if (sender.GetType().ToString()[22] == 'i')
            {
                PictureBox btn = (PictureBox)sender;
                cases = Convert.ToInt32(btn.Name.Replace("Pic", ""));
            }
            else {
                Label btn = (Label)sender;
                cases = Convert.ToInt32(btn.Name.Replace("Name", ""));
            }

            switch (cases)
            {
                case 1 :toRemove1 .Checked = toRemove1 .Checked ? false : true; break;
                case 2 :toRemove2 .Checked = toRemove2 .Checked ? false : true; break;
                case 3 :toRemove3 .Checked = toRemove3 .Checked ? false : true; break;
                case 4 :toRemove4 .Checked = toRemove4 .Checked ? false : true; break;
                case 5 :toRemove5 .Checked = toRemove5 .Checked ? false : true; break;
                case 6 :toRemove6 .Checked = toRemove6 .Checked ? false : true; break;
                case 7 :toRemove7 .Checked = toRemove7 .Checked ? false : true; break;
                case 8 :toRemove8 .Checked = toRemove8 .Checked ? false : true; break;
                case 9 :toRemove9 .Checked = toRemove9 .Checked ? false : true; break;
                case 10:toRemove10.Checked = toRemove10.Checked ? false : true; break;
            }
        }

        private void Updater_Click(object sender, EventArgs e)
        {
            list = RegistryWork.GetList();
            InitPics(list);
        }

        private void SelectManager(object sender, EventArgs e) // общий обработчик для выделения 
        {
            Button btn = (Button)sender;
            bool func = (btn.Name == "SelectAll") ? true : false;

            toRemove1 .Checked = func;
            toRemove2 .Checked = func;
            toRemove3 .Checked = func;
            toRemove4 .Checked = func;
            toRemove5 .Checked = func;
            toRemove6 .Checked = func;
            toRemove7 .Checked = func;
            toRemove8 .Checked = func;
            toRemove9 .Checked = func;
            toRemove10.Checked = func;
        }
    }
}
