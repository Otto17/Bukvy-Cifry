// Copyright (c) 2025 Otto
// Лицензия: MIT (см. LICENSE)

using System;
using System.Media;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Буквы_Цифры
{
    internal partial class LettersForm : Form
    {
        // Для воспроизведения звуков
        private readonly SoundPlayer soundPlayer = new();
        private readonly Timer soundTimer = new();

        // Буквы и цвета к ним
        private readonly string[] letters = "А Б В Г Д Е Ё Ж З И Й К Л М Н О П Р С Т У Ф Х Ц Ч Ш Щ Ъ Ы Ь Э Ю Я".Split();
        private readonly Color[] letterColors =
         {
            Color.Red,                       // А
            Color.Green,                     // Б
            Color.Blue,                      // В
            Color.FromArgb(200, 120, 0),     // Г
            Color.Purple,                    // Д

            Color.FromArgb(180, 120, 30),    // Е
            Color.FromArgb(0, 180, 180),     // Ё
            Color.Magenta,                   // Ж
            Color.ForestGreen,               // З
            Color.Teal,                      // И

            Color.Navy,                      // Й
            Color.Maroon,                    // К
            Color.OliveDrab,                 // Л
            Color.Indigo,                    // М
            Color.DarkRed,                   // Н

            Color.SaddleBrown,               // О
            Color.FromArgb(139, 69, 19),     // П
            Color.DarkCyan,                  // Р
            Color.Orchid,                    // С
            Color.DarkViolet,                // Т

            Color.RoyalBlue,                 // У
            Color.Firebrick,                 // Ф
            Color.DarkBlue,                  // Х
            Color.DarkGreen,                 // Ц
            Color.DarkOrange,                // Ч

            Color.DarkViolet,                // Ш
            Color.DeepPink,                  // Щ
            Color.DodgerBlue,                // Ъ
            Color.MediumSeaGreen,            // Ы
            Color.MediumPurple,              // Ь

            Color.HotPink,                   // Э
            Color.MidnightBlue,              // Ю
            Color.SlateBlue                  // Я
        };
        private int currentIndex = 0;   // Текущий индекс буквы

        // Конструктор формы LettersForm — инициализирует элементы и таймер для звука
        internal LettersForm()
        {
            InitializeComponent();
            this.Resize += LettersForm_Resize;  // Подписываемся на событие Resize
            lblCharacter.AutoSize = true;       // Включаем автоматический размер Label

            // Настройка таймера для задержки перед воспроизведением звука
            soundTimer = new Timer { Interval = 100 };
            soundTimer.Tick += Timer_Tick;

            UpdateDisplay();    // Отображаем цветную букву
            soundTimer.Start(); // Запускаем таймер
        }

        // Обработчик события таймера — воспроизводит звук текущей буквы и останавливает таймер
        private void Timer_Tick(object sender, EventArgs e)
        {
            PlayCurrentSound();
            soundTimer.Stop();
        }

        // Метод для воспроизведения звука
        private void PlayCurrentSound()
        {
            string letter = letters[currentIndex];

            // Формируем имя ресурса: Namespace.Properties.Путь.К.Файлу.wav
            string resourceSoundName = $"Буквы_Цифры.Properties.Audio.Буквы.{letter}.wav";

            using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceSoundName);
            if (stream != null)
            {
                try
                {
                    soundPlayer.Stop();
                    soundPlayer.Stream = stream;
                    soundPlayer.Load(); // Загрузка из потока
                    soundPlayer.Play();
                }
                catch (Exception)
                {
                    // Ничего не делаем
                }
            }
        }

        // Меняет размер шрифта при изменении размера формы
        private void LettersForm_Resize(object sender, EventArgs e)
        {
            // Определяем размер шрифта в зависимости от состояния окна
            float fontSize = (this.WindowState == FormWindowState.Maximized) ? 400f : 250f;

            // Сохраняем текущий шрифт и стиль
            Font currentFont = lblCharacter.Font;

            // Обновляем шрифт метки
            lblCharacter.Font = new Font(currentFont.FontFamily, fontSize, currentFont.Style);

            // Центрируем метку
            CenterLabel();
        }

        // Центрирует метку с буквой в центре формы
        private void CenterLabel()
        {
            // Вычисляем позицию по центру
            int x = (ClientSize.Width - lblCharacter.Width) / 2;
            int y = (ClientSize.Height - lblCharacter.Height) / 2;
            lblCharacter.Location = new Point(x, y);
        }

        // Обработчик кнопки "<" (назад) — переключает на предыдущую букву
        private void BtnBack_Click(object sender, EventArgs e)
        {
            currentIndex = (currentIndex - 1 + letters.Length) % letters.Length;
            UpdateDisplay();

            soundTimer.Stop(); // Останавливаем старый таймер
            soundTimer.Start(); // Перезапускаем
        }

        // Обработчик кнопки ">" (вперёд) — переключает на следующую букву
        private void BtnForward_Click(object sender, EventArgs e)
        {
            currentIndex = (currentIndex + 1) % letters.Length;
            UpdateDisplay();

            soundTimer.Stop(); // Останавливаем старый таймер
            soundTimer.Start(); // Перезапускаем
        }

        // Обработчик кнопки "Домой" — закрывает текущую форму
        private void BtnHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Обновляет отображаемую букву и её цвет
        private void UpdateDisplay()
        {
            lblCharacter.Text = letters[currentIndex];
            lblCharacter.ForeColor = letterColors[currentIndex % letterColors.Length];
            CenterLabel(); // Центрируем после обновления текста
        }

        // Назначение горячих клавиш для кнопок "<", ">" и "Домой"
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left)
            {
                BtnBack_Click(this, EventArgs.Empty);
                return true;
            }
            else if (keyData == Keys.Right)
            {
                BtnForward_Click(this, EventArgs.Empty);
                return true;
            }
            else if (keyData == Keys.Home)
            {
                BtnHome_Click(this, EventArgs.Empty);
                return true;
            }

            // Отключаем фокус для кнопок "<", ">" и "Домой"
            if (keyData == Keys.Up || keyData == Keys.Down)
            {
                return true; // Игнорируем стрелки ↑ ↓
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        // Обработчик события закрытия формы — освобождает ресурсы перед выходом
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Освобождаем ресурсы таймера и плеера
            soundTimer.Stop();
            soundTimer.Tick -= Timer_Tick;
            soundPlayer.Stop();
            soundPlayer.Dispose();

            // Освобождаем системные ресурсы формы
            base.OnFormClosed(e);
        }
    }
}
