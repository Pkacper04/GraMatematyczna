using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraMatematyczna
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        

        int operation = -1;
        int number1 = -1;
        int number2 = -1;
        public Form1()
        {
            InitializeComponent();
            doProcess();
        }

        public async void doProcess()
        {
            int i = 0;
            while (true)
            {
                label2.Text = "";
                string question = ChooseQuestion();
                label1.Text = question;
                await Task.Delay(5000);
                if (textBox1.Text != Result())
                    label2.Text = "Zla odpowiedz";
                else
                    label2.Text = "Dobra odpowiedz";
                await Task.Delay(2000);
            }
        }

        private string Result()
        {
            switch (operation)
            {
                case 0:
                    return (number1 + number2).ToString();
                case 1:
                    return (number1 - number2).ToString();
            }
            return null;

        }

        private string ChooseQuestion()
        {
            number1 = rand.Next(0, 11);
            number2 = rand.Next(0, 11);

            operation = rand.Next(0, 2);

            switch (operation)
            {
                case 0:
                    return number1.ToString() + " + " + number2.ToString();
                case 1:
                    return number1.ToString() + " - " + number2.ToString();
            }

            return null;

        }



    }
}
