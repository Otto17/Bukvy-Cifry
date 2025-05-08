// Copyright (c) 2025 Otto
// Лицензия: MIT (см. LICENSE)

using System;
using System.Linq;
using System.Media;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Буквы_Цифры
{
    internal partial class NumbersForm : Form
    {
        // Для воспроизведения звуков
        private readonly SoundPlayer soundPlayer = new();
        private readonly Timer soundTimer = new();

        // Цифры и цвета к ним
        private readonly int[] numbers;
        private readonly Color[] numberColors =
        {
            Color.Red, Color.Green, Color.Blue, Color.FromArgb(200, 120, 0), Color.Purple,
            Color.FromArgb(180, 120, 30), Color.FromArgb(0, 180, 180), Color.Magenta, Color.ForestGreen, Color.Teal,
            Color.Navy, Color.Maroon, Color.OliveDrab, Color.Indigo, Color.Violet,
            Color.SaddleBrown, Color.Pink, Color.Brown, Color.SandyBrown, Color.Turquoise,
            Color.Orchid
        };
        private int currentIndex = 0;   // Текущий индекс цифры

        // Конструктор формы NumbersForm — инициализирует элементы и таймер для звука
        internal NumbersForm(int start, int end)
        {
            numbers = [.. Enumerable.Range(start, end - start + 1)];
            InitializeComponent();

            this.Resize += NumbersForm_Resize;  // Подписываемся на событие Resize
            lblCharacter.AutoSize = true;       // Включаем автоматический размер Label

            // Настройка таймера для задержки перед воспроизведением звука
            soundTimer = new Timer { Interval = 100 };
            soundTimer.Tick += Timer_Tick;

            UpdateDisplay();    // Отображаем цветную букву
            soundTimer.Start(); // Запускаем таймер
        }

        // Обработчик события таймера — воспроизводит звук текущей цифры и останавливает таймер
        private void Timer_Tick(object sender, EventArgs e)
        {
            PlayCurrentSound();
            soundTimer.Stop();
        }

        // Настройка таймера для задержки звука
        private void PlayCurrentSound()
        {
            int number = numbers[currentIndex];

            // Формируем имя ресурса: Namespace.Properties.Путь.К.Файлу.wav
            string resourceSoundName = $"Буквы_Цифры.Properties.Audio.Цифры.{number}.wav";

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

        // Метод меняет размер шрифта при изменении размера формы
        private void NumbersForm_Resize(object sender, EventArgs e)
        {
            {
                // Определяем размер шрифта в зависимости от состояния окна
                float fontSize = (this.WindowState == FormWindowState.Maximized) ? 400f : 250f;

                // Сохраняем текущий шрифт и стиль
                Font currentFont = lblCharacter.Font;

                // Обновляем шрифт метки
                lblCharacter.Font = new Font(currentFont.FontFamily, fontSize, currentFont.Style);

                CenterLabel();
            }
        }

        // Центрирует метку с цифрой в центре формы
        private void CenterLabel()
        {
            int x = (ClientSize.Width - lblCharacter.Width) / 2;
            int y = (ClientSize.Height - lblCharacter.Height) / 2;
            lblCharacter.Location = new Point(x, y);
        }

        // Обработчик кнопки "<" (назад) — переключает на предыдущую цифру
        private void BtnBack_Click(object sender, EventArgs e)
        {
            currentIndex = (currentIndex - 1 + numbers.Length) % numbers.Length;
            UpdateDisplay();

            soundTimer.Stop(); // Останавливаем старый таймер
            soundTimer.Start(); // Перезапускаем
        }

        // Обработчик кнопки ">" (вперёд) — переключает на следующую цифру
        private void BtnForward_Click(object sender, EventArgs e)
        {
            currentIndex = (currentIndex + 1) % numbers.Length;
            UpdateDisplay();

            soundTimer.Stop(); // Останавливаем старый таймер
            soundTimer.Start(); // Перезапускаем
        }

        // Обработчик кнопки "Домой" — закрывает текущую форму
        private void BtnHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Обновляет отображаемую цифру и её цвет
        private void UpdateDisplay()
        {
            lblCharacter.Text = numbers[currentIndex].ToString();
            lblCharacter.ForeColor = numberColors[currentIndex % numberColors.Length];
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
