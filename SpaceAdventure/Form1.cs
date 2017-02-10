using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceAdventure
{
    public partial class Form1 : Form
    {
        GameEngine game;

        public Form1()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint ,true);
            this.DoubleBuffered = true;
            InitializeComponent();                    
        }

        private void InitializeCustomeComponents()
        { 
            Screen myScreen = Screen.FromControl(this);
            Rectangle area = myScreen.WorkingArea;
            int width = area.Width;
            this.Left = width / 2;

            game = new GameEngine();
            game.ScreenWidth = this.Size.Width;
            lbInventory.DataSource = game.GetInventory();            
        }

        private void  MoveActor(Action<object> action, object parameter)
        {
            var operation = new ParameterizedThreadStart(o => action((object)o));
            Thread thread = new Thread(operation);            
            thread.Start(parameter);
        }
        private void btnUp_Click(object sender, EventArgs e)
        {
            game.PlayerAction = "UpArrow";
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            game.PlayerAction = "DownArrow";
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            game.PlayerAction = "LeftArrow";
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            game.PlayerAction = "RightArrow";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            { 
                case Keys.Left:
                    btnLeft_Click(this, null);
                    break;
                case Keys.Right:
                    btnRight_Click(this, null);
                    break;
                case Keys.Down:
                    btnDown_Click(this, null);
                    break;
                case Keys.Up:
                    btnUp_Click(this, null);
                    break;
                case Keys.O:
                    game.PlayerAction = "O";
                    break;
                case Keys.C:
                    game.PlayerAction = "C";
                    break;
                case Keys.P:
                    game.PlayerAction = "P";
                    break;
                case Keys.F:
                    game.PlayerAction = "F";
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (game != null)
            {
                game.GameLoop(ref g);
                lblMessage.Text = game.StatusMessage;
                lblMessage.Refresh();
                lbInventory.DataSource = game.GetInventory();
                lbInventory.Refresh();
                this.Invalidate();
                lblMessage.Focus();
            }
            else
            {
                InitializeCustomeComponents();
                this.Invalidate();
                this.Refresh();
            }
        }
       
    }
}
