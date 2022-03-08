using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMmachine
{
    //Класс хранилища денег
   public class moneyStorage
    {
        //переменные "banknote *" - количество купюр с наминалом, где * - число - номинал банкноты
        private int banknote5000;
        private int banknote2000;
        private int banknote1000;
        private int banknote500;
        private int banknote100;
        private int banknote50;
        private int banknote10;
        //конструктор по умолчанию, заполнем некоторым значеникем, чтобы банкомат не был пуст
        public moneyStorage()
        {
            banknote5000 = 100;
            banknote2000 = 200;
            banknote1000 = 200;
            banknote500 = 300;
            banknote100 = 500;
            banknote50 = 50;
            banknote10 = 0;
        }
        //метод для проверки наличия нужного количества денег перед снятием
        public bool tryGetMoney(double value)
        {
            if (value % 10 != 0) return false; //Если требуется вывести 1-9 рублей, то отклоняем запрос

            while(value >= 5000 && banknote5000 > 0)
            {
                value -= 5000;
            };
            while (value >= 2000 && banknote2000 > 0)
            {
                value -= 2000;
            };
            while (value >= 1000 && banknote1000 > 0)
            {
                value -= 1000;
            };
            while (value >= 500 && banknote500 > 0)
            {
                value -= 500;
            };
            while (value >= 100 && banknote100 > 0)
            {
                value -= 100;
            };
            while (value >= 50 && banknote50 > 0)
            {
                value -= 50;
            };
            while (value >= 10 && banknote10 > 0)
            {
                value -= 10;
            };

            if(value == 0)
            {
                return true; //если купюры набраны, то разрешаем вывод
            }

            return false; //иначе, запрещакем вывод средств
        }
        //метод для снятия нужного количества денег 
        public bool GetMoney(double value)
        {
            while (value >= 5000 && banknote5000 > 0)
            {
                value -= 5000;
                banknote5000--;
            };
            while (value >= 2000 && banknote2000 > 0)
            {
                value -= 2000;
                banknote2000--;
            };
            while (value >= 1000 && banknote1000 > 0)
            {
                value -= 1000;
                banknote1000--;
            };
            while (value >= 500 && banknote500 > 0)
            {
                value -= 500;
                banknote500--;
            };
            while (value >= 100 && banknote100 > 0)
            {
                value -= 100;
                banknote100--;
            };
            while (value >= 50 && banknote50 > 0)
            {
                value -= 50;
                banknote50--;
            };
            while (value >= 10 && banknote10 > 0)
            {
                value -= 10;
                banknote10--;
            };

            if (value == 0)
            {
                return true; //если купюры набраны, то разрешаем вывод
            }

            return false; //иначе, запрещакем вывод средств
        }
    }

    //класс - информация о карте и её держателе.
    public class cardHolder
    {
        //поля номер, пин, и владелец карты и баланс
        private string cardNumber;
        private int cardPin;
        private string[] holderName = new string[2];
        private double balance;
        //конструктор с параметрами
        public cardHolder(string _cardNumber)
        {
            cardNumber = _cardNumber;

            holderName[0] = "Card";
            holderName[1] = "Holder";
            string pin = cardNumber[0].ToString() + cardNumber[1].ToString() + cardNumber[2].ToString() + cardNumber[3].ToString();
            cardPin = int.Parse(pin);
            //баланс карты = последние 5 цифр
            balance = double.Parse(cardNumber.Substring(11));

        }
        //проверка pin
        public bool tryPin(int pin)
        {
            if (cardPin == pin) return true;
            else return false;
        }
        //получить баланс
        public double getBalance()
        {
            return balance;
        }
        //установить новый баланс
        public void setBalance(double value)
        {
            balance = value;
        }
        //получить имя держателя
        public string getName()
        {
            return (holderName[0] + ' ' + holderName[1]);
        }
        //получит номер карты
        public string getCardNumber()
        {
            return cardNumber;
        }

    }

    //главный класс - банкомат
    public class ATMmachineClass
    {
        //элементы банкомата - хранилище денег и держатель карты
        public moneyStorage moneyStorage;
        public cardHolder cardHolder;
        //конструктор по умолчанию
        public ATMmachineClass()
        {
            moneyStorage = new moneyStorage();
            
        }
    }
}
