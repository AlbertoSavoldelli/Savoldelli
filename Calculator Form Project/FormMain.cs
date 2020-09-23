using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_Form_Project
{
    public partial class FormMain : Form
    {
        public struct ButtonStruct
        {
            public char Content;
            public bool isBold;
            public ButtonStruct(char Content, bool isBold)
            {
                this.Content = Content;
                this.isBold = isBold;
            }
            public override string ToString()
            {
                return base.ToString();
            }

        }
        //private char[,] buttons =new char[6,4];
        private ButtonStruct[,] buttons =
        {
            {new ButtonStruct(' ',false),new ButtonStruct(' ',false),new ButtonStruct(' ',false),new ButtonStruct(' ',false)},
            {new ButtonStruct(' ',false),new ButtonStruct(' ',false),new ButtonStruct(' ',false),new ButtonStruct('/',false)},
            {new ButtonStruct('7',true),new ButtonStruct('8',true),new ButtonStruct('9',true),new ButtonStruct('X',false)},
            {new ButtonStruct('4',true),new ButtonStruct('5',true),new ButtonStruct('6',true),new ButtonStruct('-',false)},
            {new ButtonStruct('1',true),new ButtonStruct('2',true),new ButtonStruct('3',true),new ButtonStruct('+',false)},
            {new ButtonStruct(' ',false),new ButtonStruct('0',true),new ButtonStruct(' ',false),new ButtonStruct('=',false)},

        };
        public FormMain()
        {
            InitializeComponent();
        }
        private RichTextBox txt;
        private void FormMain_Load(object sender, EventArgs e)
        {
            makebuttons(buttons);
            makeResultsBox(txt);
        }
        private void makeResultsBox(RichTextBox txt)
        {
            txt = new RichTextBox();
            txt.ReadOnly = true;
            txt.SelectionAlignment = HorizontalAlignment.Right;
            txt.Font = new Font("Segoe UI", 22);
            txt.Width = this.Width - 16;
            txt.Height = 50;
            txt.Top = 20;
            txt.Text = "0";
            this.Controls.Add(txt);
        }
        private void makebuttons(ButtonStruct[,] buttons)
        {
            int buttonWidth = 82;
            int buttonHeight = 60;
            int posX = 0;
            int posY = 101;
            for (int i = 0; i < buttons.GetLength(0); i++)
            {
                posX = 0;
                for (int j = 0; j < buttons.GetLength(1); j++)
                {
                    Button newButton = new Button();
                    newButton.Text = buttons[i, j].Content.ToString();
                    newButton.Font = new Font("segoe UI", 16);
                    ButtonStruct bs = buttons[i, j];
                    if (bs.isBold)
                    {
                        newButton.Font = new Font(newButton.Font, FontStyle.Bold);
                    }
                    //newButton.Text = buttons[i,j].ToString();
                    newButton.Width = buttonWidth;
                    newButton.Height = buttonHeight;
                    newButton.Left= posX;
                    newButton.Top = posY;
                    posX += buttonWidth;
                    this.Controls.Add(newButton);

                }
                posY += buttonHeight;
            }
        }
    }
}
