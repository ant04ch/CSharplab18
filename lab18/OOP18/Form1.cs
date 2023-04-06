using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OOP18
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //task1
            label1.Text = "Кількість додатніх елементів масиву: ";
            label2.Text = "Суму елементів масиву, після нуля: ";
            label3.Text = "Усі елементи, ціла частина яких не перевищує 1 : ";
            label4.Text = "arr= ";
            button1.Text = "OK";
            //task2
            button2.Text = "Сгенерувати масив";
            label5.Text = "Масив";
            label6.Text = "усі елементи п’ятого рядка масиву";
            label7.Text = "усі елементи s-го стовбця масиву.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Розрахунок кількості додатніх елементів масиву
            double[] array = textBox1.Text.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray(); // ігнорування подвійних пробілів, і при цьому використовувала пробіли як роздільник між елементами масиву.
            int dodatne = 0;
            foreach (double element in array)
            {
                if (element > 0)
                {
                    dodatne++;
                }
            }
            label1.Text = "Кількість додатніх елементів масиву: " + dodatne.ToString();

            double sumzero = 0;
            bool zeroFound = false;
            for (int i = 0; i < array.Length; i++)
            {
                if (zeroFound)
                {
                    sumzero += array[i];
                }
                else if (array[i] == 0)
                {
                    zeroFound = true;
                }
            }
            label2.Text = "Суму елементів масиву, після нуля: " + sumzero.ToString();

            Array.Sort(array, (a, b) => (Math.Floor(a) <= 1).CompareTo(Math.Floor(b) <= 1));
            label3.Text = "Усі елементи, ціла частина яких не перевищує 1 : " + string.Join(", ", array);

        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                // цифра
                return;
            }
            if ((e.KeyChar == '.') || (e.KeyChar == ','))
            {
                // крапку замінемо проб
                e.KeyChar = ',';
                return;
            }
            if ((e.KeyChar == ' '))
            {
                // крапку замінемо проб
                e.KeyChar = ' ';
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                // <Enter>, <Backspace>, <Esc>
                if (e.KeyChar == (char)Keys.Enter)
                    // натиснута клавіша <Enter>
                    // встановити курсор на кнопку OK
                    textBox1.Focus();
                return;
            }
            // інші символи заборонені
            e.Handled = true;
        }// Захист для поля

        //TASK2
        private void button2_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
            int m = 5; // кількість рядків
            int l = 5; // кількість стовбців
            int[,] arr = new int[m, l];

            Random random = new Random();

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    arr[i, j] = random.Next(50); // генеруємо випадкове число
                }
            }

            // виводимо масив
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    label5.Text += arr[i, j] + " ";
                }
                label5.Text += Environment.NewLine;
            }

            // виводимо елементи п'ятого рядка масиву
            label6.Text = "усі елементи п’ятого рядка масиву: ";
            for (int j = 0; j < l; j++)
            {
                label6.Text += arr[4, j] + " ";
            }

            // виводимо елементи s-го стовбця масиву
            int s = random.Next(5);
            label7.Text = $"s {s} рядка: " + Environment.NewLine;
            for (int i = 0; i < m; i++)
            {
                label7.Text += arr[i, s] + Environment.NewLine;
            }
        }
    }
}

