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

        int steps = 100;

        int operation = -1;
        int number1 = -1;
        int number2 = -1;
        public Form1()
        {
            InitializeComponent();
            label1.Visible = false;
            label2.Visible = false;
            textBox1.Visible = false;
            label3.Visible = false;
            progressBar1.Visible = false;
            label4.Visible = false;
            label1.Text = "";
            label2.Text = "";
        }

        public async void StartGame()
        {
            while (true)
            {
                if (progressBar1.Value == 100)
                {
                    RestartGame();
                    return;
                }
                label2.Text = "";
                textBox1.Clear();
                string question = ChooseQuestion();
                label1.Text = question;

                for (int i = 5; i > -1; i--)
                {
                    label4.Text = "Czas: " + i.ToString();
                    await Task.Delay(1000);
                }
                
                
                if (textBox1.Text != Result())
                {
                    label2.ForeColor = Color.Red;
                    label2.Text = "Zla odpowiedz";
                }
                else
                {
                    label2.ForeColor = Color.Green;
                    label2.Text = "Dobra odpowiedz";
                    if (progressBar1.Value + steps > 100)
                        progressBar1.Value = 100;
                    else
                        progressBar1.Value += steps;
                }
                await Task.Delay(2000);
            }
        }

        private void RestartGame()
        {
            label1.Visible = false;
            label2.Visible = false;
            textBox1.Visible = false;
            label3.Visible = false;
            progressBar1.Visible = false;
            label4.Visible = false;
            label1.Text = "";
            label2.Text = "";
            button1.Visible = true;
            progressBar1.Value = 0;
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.TextLength != 0)
                if (int.TryParse(textBox2.Text, out _))
                {
                    double a = 100.0 / double.Parse(textBox2.Text);
                    steps = (int)Math.Ceiling(a);
                }
            label1.Visible = true ;
            label2.Visible = true;
            textBox1.Visible = true;
            label3.Visible = true;
            button1.Visible = false;
            label4.Visible = true;
            progressBar1.Visible = true;
            StartGame();
        }
    }
}
