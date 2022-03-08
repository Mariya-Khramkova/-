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
    public partial class Form1 : Form
    {
        //класс банкомата
        ATMmachineClass aTMmachineClass;
        //сумма вывода для чека
        double sum;
        public Form1()
        {
            InitializeComponent();
        }
        //конструктор по умолчанию
        public Form1(cardHolder _cardHolder)
        {
            InitializeComponent();
            aTMmachineClass = new ATMmachineClass();
            aTMmachineClass.cardHolder = _cardHolder;
            C_H.Text = aTMmachineClass.cardHolder.getName();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                      
        }
        //вывод баланса на экран
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Баланс: " + aTMmachineClass.cardHolder.getBalance());
        }
        //выход из программы
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        //вывод средст из введенной суммы
        private void button10_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "") getMoney(int.Parse(textBox1.Text));
        }
        //функция вывода выбранной суммы
        private void getMoney(double value)
        {
            if (aTMmachineClass.cardHolder.getBalance() >= value)
            {
                if (aTMmachineClass.moneyStorage.tryGetMoney(value)){
                    button1.Enabled = true;
                    aTMmachineClass.moneyStorage.GetMoney(value);
                    aTMmachineClass.cardHolder.setBalance(aTMmachineClass.cardHolder.getBalance()-value);
                    sum = value;

                    button1.BackColor = Color.Green;
                    button1.Enabled = true;
                    button2.BackColor = Color.Red;
                    button2.Enabled = false;
                    groupBox3.Enabled = false;
                    MessageBox.Show("Заберите деньги!");
                }
                else
                {
                    MessageBox.Show("В банкомате недостаточно средств!");
                }
            }
            else
            {
                MessageBox.Show("Недостаточно средств!");
            }
           
        }
        //кнопка забрать деньги из лотка
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Деньги получены!");
         if (checkBox1.Checked)
            {
                MessageBox.Show("Со счета: " + aTMmachineClass.cardHolder.getCardNumber() + " снято " + sum + " условных едениц.", "Чек");
            }
            button2.BackColor = Color.Green;
            button1.BackColor = Color.Red;
            MessageBox.Show("Заберите карту");
            button1.Enabled = false;
            button2.Enabled = true;
            groupBox3.Enabled = true;
        }
        //кнопка забрать карту
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //кнопки отвечающие за вывод суммы из кнопок
        private void button9_Click(object sender, EventArgs e)
        {
            getMoney(50);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            getMoney(500);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            getMoney(2000);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            getMoney(100);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            getMoney(1000);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            getMoney(5000);
        }
        //кнопка оплаты услуг
        private void button11_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex >-1 && textBox2.Text != "" && textBox3.Text != "")
            {
                double value = double.Parse(textBox2.Text);

                if (aTMmachineClass.cardHolder.getBalance() >= value)
                {
                        button1.Enabled = true;
                        aTMmachineClass.moneyStorage.GetMoney(value);
                        aTMmachineClass.cardHolder.setBalance(aTMmachineClass.cardHolder.getBalance() - value);
                    MessageBox.Show("Оплата прошла");
                }
                else
                {
                    MessageBox.Show("Недостаточно средств!");
                }

   
            }
        }
    }
}
