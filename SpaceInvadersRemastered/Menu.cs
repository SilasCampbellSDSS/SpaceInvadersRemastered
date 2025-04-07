using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvadersRemastered
{
    public partial class Menu: UserControl
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    Form1.ChangeScreen(this, new GameScreen());
                    break;
                case Keys.Escape:
                    Application.Exit();
                    break;   
            }
        }
    }
}
