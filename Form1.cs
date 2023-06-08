using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace fukuv0608
{
    public partial class Form1 : Form
    {
        int itime = 0;
        int vx = rand.Next(80, 99);
        int vy = rand.Next(-5,6);
        static Random rand = new Random();
        public Form1()
        {
            InitializeComponent();
            label1.Left = rand.Next(ClientSize.Width - label1.Width);
            label1.Top = rand.Next(ClientSize.Height - label1.Height);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Left += vx;
            label1.Top += vy;

            if (label1.Left < 0)
            {
                vx = Math.Abs(vx + (vx / 10));
            }
            if (label1.Top < 0)
            {
                vy = Math.Abs(vy + (vy / 10));
            }
            if (label1.Right > ClientSize.Width)
            {
                vx = -Math.Abs(vx + (vx / 10));
            }
            if (label1.Bottom > ClientSize.Height)
            {
                vy = -Math.Abs(vy + (vy / 10));
            }

            // �ϐ�mpos��錾���āA�}�E�X�̃t�H�[�����W�����o��
            //// 1. MousePosition�Ƀ}�E�X���W�̃X�N���[�����ォ���X�AY�������Ă���
            Text = $"{MousePosition.X},{MousePosition.Y}";
            //// 2. �ϐ�fpos��錾���āAPointToClient()�ŃX�N���[�����W���t�H�[�����W�ɕϊ�
            var fpos = PointToClient(MousePosition);

            // ���x���ɍ��W��\��
            //// �ϊ������t�H�[�����W�́Afpos.X�Afpos.Y�Ŏ��o����
            label1.Text = $"{fpos.X},{fpos.Y}";

            //label2.Width�Ń��x���̕�
            //label2.Heigt�Ń��x���̍���
            //�}�E�X�J�[�\���̈ʒu��Label2�̒����ɂȂ�悤�ɂ���
            label2.Left = fpos.X - label2.Width / 2;
            label2.Top = fpos.Y - label2.Height / 2;
            if ((fpos.X >= label1.Left) && (fpos.X <= label1.Right) &&
                (fpos.Y >= label1.Top) && (fpos.Y <= label1.Bottom))
            {

                timer1.Enabled = false;
            }
            itime++;
            label3.Text = $"time:{itime}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            label1.Text = "���{���P";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}