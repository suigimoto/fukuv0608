namespace fukuv0608
{
    public partial class Form1 : Form
    {
        int vx = -5;
        int vy = -5;
        public Form1()
        {
            InitializeComponent();
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

            // 変数mposを宣言して、マウスのフォーム座標を取り出す
            //// 1. MousePositionにマウス座標のスクリーン左上からのX、Yが入っている
            Text = $"{MousePosition.X},{MousePosition.Y}";
            //// 2. 変数fposを宣言して、PointToClient()でスクリーン座標をフォーム座標に変換
            var fpos = PointToClient(MousePosition);

            // ラベルに座標を表示
            //// 変換したフォーム座標は、fpos.X、fpos.Yで取り出せる
            label1.Text = $"{fpos.X},{fpos.Y}";

            //label2.Widthでラベルの幅
            //label2.Heigtでラベルの高さ
            //マウスカーソルの位置がLabel2の中央になるようにする
            label2.Left = fpos.X - label2.Width / 2;
            label2.Top = fpos.Y - label2.Height / 2;
            if ((fpos.X > label1.Left)&&(fpos.X < label1.Right)&&
                (fpos.Y>label1.Top)&&(fpos.Y<label1.Bottom))
            {

                timer1.Enabled = false;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            label1.Text = "杉本尚輝";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}