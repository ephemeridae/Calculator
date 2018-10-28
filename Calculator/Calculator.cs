using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public enum Operator { Add, Sub, Multi, Div }

    public partial class Calculator : Form
    {
        bool isNewNum = true; //true면 숫자가 한번도 안눌러진 상태
        int result = 0;
        Operator Opt = Operator.Add;

        public Calculator()
        {
            InitializeComponent();

            
        }

        private void SetNum(string num)
        {
            if (isNewNum)
            {
                NumScreen.Text = num;
                isNewNum = false;

            }
            else if (NumScreen.Text == "0")
            {
                NumScreen.Text = num;
            }
            else
            {
                NumScreen.Text = NumScreen.Text + num;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button numButton = (Button)sender;
            SetNum(numButton.Text);
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            Button optButton = (Button)sender;
            if(isNewNum == false)
            {
                //숫자 입력
                //연산자 버튼 - 숫자완성, 변수와 숫자를 저장된 연산자로 연산, 결과를 변수에 저장, 현재 연산자를 저장.
                string optButtonStr = optButton.Text;
                int num = int.Parse(NumScreen.Text);
                LogListBox.Items.Add(result + " " + optButtonStr + " " + num + " / 입력시간( " + DateTime.Now.ToString("yyyyMMdd hh:mm:ss") + ")");
                if (Opt == Operator.Add)
                {
                    result = result + num;
                }
                else if (Opt == Operator.Sub)
                {
                    result = result - num;
                }
                

                NumScreen.Text = result.ToString();
                
                isNewNum = true;
            }

           
            if (optButton.Text == "+")
            {
                Opt = Operator.Add;
            }
            else if (optButton.Text == "-")
            {
                Opt = Operator.Sub;
            }
            else if(optButton.Text == "=")
            {
                LogListBox.Items.Add(result + " " + optButtonStr + " " + num + " / 입력시간( " + DateTime.Now.ToString("yyyyMMdd hh:mm:ss") + ")");
            }


            
        }

        private void NumClear_Click(object sender, EventArgs e)
        {
            result = 0;
            isNewNum = true;
            Opt = Operator.Add;

            NumScreen.Text = "0";
        }
    }

    
}
