// Copyright (c) 2025 Otto
// Лицензия: MIT (см. LICENSE)

using System;
using System.Windows.Forms;

namespace Буквы_Цифры
{
    internal partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Раскомментировать для проверки точного расположения внедрённых ресурсов
            //var resources = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            //string message = string.Join(Environment.NewLine, resources);
            //MessageBox.Show(message, "Список внедренных ресурсов");
        }

        // Обработчик кнопки "Буквы" — открывает форму с алфавитом
        private void BtnLetters_Click(object sender, EventArgs e)
        {
            var lettersForm = new LettersForm();
            lettersForm.Closed += (s, args) => this.Show(); // Показываем главное окно при закрытии
            this.Hide(); // Скрываем главное окно
            lettersForm.Show();
        }

        // Обработчик кнопки "Цифры 0-10" — открывает форму с цифрами 0-10
        private void BtnNumbers0_10_Click(object sender, EventArgs e)
        {
            var numbersForm = new NumbersForm(0, 10);
            numbersForm.Closed += (s, args) => this.Show();
            this.Hide();
            numbersForm.Show();
        }

        // Обработчик кнопки "Цифры 10-20" — открывает форму с цифрами 10-20
        private void BtnNumbers10_20_Click(object sender, EventArgs e)
        {
            var numbersForm = new NumbersForm(10, 20);
            numbersForm.Closed += (s, args) => this.Show();
            this.Hide();
            numbersForm.Show();
        }

        // Выход из программы горячей клавишей Esc
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close(); // Закрываем главное окно
                return true;  // Указываем, что событие обработано
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        // Ссылка на автора
        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://gitflic.ru/project/otto/bukvy-cifry");
        }
    }
}
