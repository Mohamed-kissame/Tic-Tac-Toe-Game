using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tik_Tak_Tok_Game.Properties;

namespace Tik_Tak_Tok_Game
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        stGameStatus GameStatus;
        enPlayer PlayerTurn = enPlayer.Player1;
        enum enPlayer
        {
            Player1,
            Player2
        }

        enum enWinner
        {
            Player1,
            Player2,
            Draw,
            GameInProgress
        }

        struct stGameStatus
        {
            public enWinner Winner;
            public bool GameOver;
            public short PlayCount;

        }

        private void Form_Paint(object sender, PaintEventArgs e)
        {

            //Color Black = Color.FromArgb(255, 0, 0, 0);
            //Pen Pen = new Pen(Black);

            //Pen.Width = 15;

            //Pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            //Pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            //e.Graphics.DrawLine(Pen, 400, 300, 1050, 300);
            //e.Graphics.DrawLine(Pen, 405, 460, 1050, 460);

            //e.Graphics.DrawLine(Pen, 610, 140, 610, 620);
            //e.Graphics.DrawLine(Pen, 840, 140, 840, 620);



        }

        void EndGame()
        {

            lblTurn.Text = "Game Over";
            switch (GameStatus.Winner)
            {

                case enWinner.Player1:

                    lblWinner.Text = "Player1";
                    break;

                case enWinner.Player2:

                    lblWinner.Text = "Player2";
                    break;

                default:

                    lblWinner.Text = "Draw";
                    break;

            }

            MessageBox.Show("GameOver", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public bool CheckValues(Button btn1 , Button btn2 , Button btn3)
        {

            if(btn1.Tag.ToString() != "?" && btn1.Tag.ToString() == btn2.Tag.ToString() && btn1.Tag.ToString() == btn3.Tag.ToString())
            {
                btn1.BackColor = Color.GreenYellow;
                btn2.BackColor = Color.GreenYellow;
                btn3.BackColor = Color.GreenYellow;

                if (btn1.Tag.ToString() == "X")
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
                else
                {
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }

            }

            GameStatus.GameOver = false;
            return false;
        }


        public void CheckWinner()
        {

            if (CheckValues(button1, button2, button3))
                return;

            if (CheckValues(button4, button5, button6))
                return;

            if (CheckValues(button7, button8, button9))
                return;

            if (CheckValues(button1, button4, button7))
                return;

            if (CheckValues(button2, button5, button8))
                return;

            if (CheckValues(button3, button6, button9))
                return;

            if (CheckValues(button1, button5, button9))
                return;

            if (CheckValues(button3, button5, button7))
                return;
        }

       public void changeImage(Button btn)
        {
            if(btn.Tag.ToString() == "?")
            {
                switch (PlayerTurn)
                {
                    case enPlayer.Player1:
                        btn.Image = Resources.X_1_;
                        PlayerTurn = enPlayer.Player2;
                        lblTurn.Text = "Player 2";
                        GameStatus.PlayCount++;
                        btn.Tag = "X";
                        CheckWinner();
                        break;
                    case enPlayer.Player2:
                        btn.Image = Resources.O;
                        PlayerTurn = enPlayer.Player1;
                        lblTurn.Text = "Player 1";
                        GameStatus.PlayCount++;
                        btn.Tag = "O";
                        CheckWinner();
                        break;
                }
            }

            else

            {
                MessageBox.Show("Wrong Choice", "Worng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (GameStatus.PlayCount == 9)
            {
                GameStatus.GameOver = true;
                GameStatus.Winner = enWinner.Draw;
                EndGame();
            }

        }
        

        private void button_Click(object sender, EventArgs e)
        {

            changeImage((Button)sender);
        }

      

        private void RestButton(Button btn)
        {
            btn.Image = Resources.question_mark_96;
            btn.Tag = "?";
            btn.BackColor = Color.Transparent;
            lblTurn.Text = "Player 1";
            GameStatus.PlayCount = 0;
            GameStatus.GameOver = false;
            GameStatus.Winner = enWinner.GameInProgress;
            lblWinner.Text = "In Progress";
        }
        private void RestartGame()
        {

            for (int i = 1; i <= 9; i++)
            {
                RestButton((Button)this.Controls["button" + i]);
            }

        }
      
        private void button10_Click(object sender, EventArgs e)
        {
            RestartGame();
        }
    }
}
