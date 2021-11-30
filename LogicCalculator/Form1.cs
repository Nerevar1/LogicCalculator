using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicCalculator
{
    public partial class Form1 : Form
    {
        public static char[] arrChar;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnGetRes_Click(object sender, EventArgs e)
        {
            string res="";
            string s = TxBInput.Text;
            arrChar = new char[s.Length + 10];
            s = s.Replace(" ", "");
            s = s.Replace("!0", "1");
            s = s.Replace("!1", "0");

            int posArrChar = 1;

            int otkrSkobka = 0, zakrSkobka = 0;
            int amountSkobki = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '1' || s[i] == '0' || s[i] == '!' || s[i] == '(' || s[i] == ')' || s[i] == '+' || s[i] == '*')
                {
                    switch (s[i])
                    {
                        case '(':
                            otkrSkobka++;
                            break;
                        case ')':
                            zakrSkobka++;
                            break;
                    }
                    arrChar[posArrChar] = Convert.ToChar(s[i]);
                    posArrChar++;
                }
            }
            if (otkrSkobka > 0 && zakrSkobka > 0 && otkrSkobka == zakrSkobka)
            {

                amountSkobki = otkrSkobka;
                //MessageBox.Show($"В примере {amountSkobki} скобки");

            }
            else if (otkrSkobka != zakrSkobka)
            {
                MessageBox.Show($"В примере скобок не равное кол-во");
                return;
            }
            else
            {
                //MessageBox.Show($"В примере нет скобок");
            }

            int amountDig = GetAmountDigInArr(0, arrChar.Length - 1) - 1;
            int amountOper = GetAmountOperationInArr();
            if (amountDig != amountOper)
            {
                MessageBox.Show("Ошибка кол-ва опереций");
                return;
            }

            int amountDigitInArr = 1000000;
            int borderLeft = 0, borderRight = 0;
            while (amountDigitInArr > 1)
            {
                for (int i = 0; i < arrChar.Length; i++)
                {
                    if (arrChar[i] == ')')
                    {
                        for (int j = i; j > 0; j--)
                        {
                            if (arrChar[j] == '(')
                            {
                               // MessageBox.Show("Решаю скобки");
                                //вызов функции с диапазоном индексы скобок
                                borderLeft = j;
                                borderRight = i;
                                GetAnswer(borderLeft, borderRight);
                               // MessageBox.Show("Решил скобки");
                                amountDigitInArr = GetAmountDigInArr(0, arrChar.Length - 1);
                                if (amountDigitInArr <= 1)
                                {
                                    goto EndFunc;
                                }
                                break;
                            }
                        }
                    }
                    if (i == arrChar.Length - 1)//если пошёл до конца то передать диапазон всего примера
                    {
                       // MessageBox.Show("Решаю последний этап выражения");
                        GetAnswer(0, arrChar.Length - 1);
                        amountDigitInArr = GetAmountDigInArr(0, arrChar.Length - 1);
                        if (amountDigitInArr <= 1)
                        {
                            goto EndFunc;
                        }
                        break;
                    }
                }
            }

        EndFunc:
            //Console.Write("ОТВЕТ:");
            foreach (char el in arrChar)
            {//вывести результат
                if (el == '0' || el == '1' || el == '*' || el == '+')
                {
                    res += el;
                }
            }
            TxBViewRes.Text = res;
        }
        private static int GetAmountDigInArr(int borLeft, int borRight)
        {//кол-во чисел в массиве, в определённом диапазоне
            //MessageBox.Show("Считаю кол-во чисел в массиве");
            int cnt = 0;
            for (int i = borLeft; i <= borRight; i++)
            {
                if (arrChar[i] == '0' || arrChar[i] == '1') cnt++;
            }
            return cnt;
        }
        private static int GetAmountOperationInArr()
        {//кол-во чисел в массиве, в определённом диапазоне
            //MessageBox.Show("Считаю кол-во операций в массиве");
            int cnt = 0;
            for (int i = 0; i <= arrChar.Length - 1; i++)
            {
                if (arrChar[i] == '*' || arrChar[i] == '+') cnt++;
            }
            return cnt;
        }

        private static void GetAnswer(int borderLeft, int borderRight)
        {
            arrChar[borderLeft] = ' ';
            arrChar[borderRight] = ' ';
            int cnt = 1000000;
            char answer = ' ';
            char numLeft = ' ';
            char numRight = ' ';
            int indexAnswer = 0;
            while (cnt > 1)
            {
                for (int i = borderLeft; i < borderRight; i++)
                {
                    Start:
                    if (arrChar[i] == '*')
                    {
                        arrChar[i] = ' ';
                        indexAnswer = i;
                        for (int j = i; j < borderRight; j++)
                        {
                            if (arrChar[j] == '0' || arrChar[j] == '1')
                            {
                                numRight = arrChar[j];
                                arrChar[j] = ' ';
                                break;
                            }
                        }
                        for (int j = i; j > borderLeft; j--)
                        {
                            if (arrChar[j] == '0' || arrChar[j] == '1')
                            {
                                numLeft = arrChar[j];
                                arrChar[j] = ' ';
                                break;
                            }
                        }
                        answer = MakeBoolAct(numLeft, numRight, '*');
                        arrChar[indexAnswer] = answer;

                        goto Start;
                    }
                }

                for (int i = borderLeft; i < borderRight; i++)
                {
                    if (arrChar[i] == '+')
                    {
                        arrChar[i] = ' ';
                        indexAnswer = i;
                        for (int j = i; j < borderRight; j++)
                        {
                            if (arrChar[j] == '0' || arrChar[j] == '1')
                            {
                                numRight = arrChar[j];
                                arrChar[j] = ' ';
                                break;
                            }
                        }
                        for (int j = i; j > borderLeft; j--)
                        {
                            if (arrChar[j] == '0' || arrChar[j] == '1')
                            {
                                numLeft = arrChar[j];
                                arrChar[j] = ' ';
                                break;
                            }
                        }
                        answer = MakeBoolAct(numLeft, numRight, '+');
                        arrChar[indexAnswer] = answer;

                        break;
                    }
                }
                if (borderLeft > 0 && arrChar[borderLeft - 1] == '!')
                {
                    for (int i = borderLeft; i < borderRight; i++)
                    {
                        arrChar[borderLeft - 1] = ' ';
                        if (arrChar[i] == '1')
                        {
                            arrChar[i] = '0';
                            break;
                        }
                        else if (arrChar[i] == '0')
                        {
                            arrChar[i] = '1';
                            break;
                        }
                    }
                }

                cnt = GetAmountDigInArr(borderLeft, borderRight);
            }
        }

        private static char MakeBoolAct(char numLeft, char numRight, char act)
        {
            if (act == '*')
            {
                if (numLeft == '1' && numRight == '1')
                {
                    return '1';
                }
                else
                {
                    return '0';
                }
            }
            else
            {
                if (numLeft == '0' && numRight == '0')
                {
                    return '0';
                }
                else
                {
                    return '1';
                }
            }
        }
    }
}
