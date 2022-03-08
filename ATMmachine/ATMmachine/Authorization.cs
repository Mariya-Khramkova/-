using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMmachine
{
    public partial class Authorization : Form
    {
        //пользователь при входе в банкомат
        cardHolder cardHolder;
        int Trycount = 3;
        //конструктор по умолчанию
        public Authorization()
        {
            InitializeComponent();
        }

        //функции отвечающие за ввод цифр пин-кода
        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox2.TextLength < 4)
            {
                textBox2.Text += '1';
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox2.TextLength < 4)
            {
                textBox2.Text += '2';
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox2.TextLength < 4)
            {
                textBox2.Text += '3';
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox2.TextLength < 4)
            {
                textBox2.Text += '4';
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.TextLength < 4)
            {
                textBox2.Text += '5';
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.TextLength < 4)
            {
                textBox2.Text += '6';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.TextLength < 4)
            {
                textBox2.Text += '7';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.TextLength < 4)
            {
                textBox2.Text += '8';
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.TextLength < 4)
            {
                textBox2.Text += '9';
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox2.TextLength < 4)
            {
                textBox2.Text += '0';
            }
        }

        //проверка количество цифр пинкода и вход
        private void button12_Click(object sender, EventArgs e)
        {
            if (Trycount != 0)
            {
                if (textBox2.Text.Length == 4 && textBox1.Text.Length == 16)
                {
                    if (cardHolder.tryPin(int.Parse(textBox2.Text)))
                    {
                        Form1 form1 = new Form1(cardHolder);
                        this.Visible = false;
                        form1.Show();

                    }
                    else
                    {
                        Trycount--;
                        MessageBox.Show("Неверный PIN код. Количество оставшихся попыток: " + Trycount.ToString());
                        if (Trycount == 0)
                        {
                            MessageBox.Show("Попытки закончились. Карта изъята");
                            Application.Exit();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Введите полные данные");
                }

            }
            else
            {
                MessageBox.Show("Попытки закончились. Карта изъята");
                Application.Exit();
            }
        }
        //проверка номера карты
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 16)
            {
                cardHolder = new cardHolder(textBox1.Text);
                Trycount = 3;
            }
        }
        //кнопка отмены
        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = "";
        }
        //кнопка удаления символа
        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0) textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.Length-1);
        }
    }
}
