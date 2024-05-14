using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ClickMe
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int interval_int = 1000;
        DispatcherTimer timer = new DispatcherTimer();
        Random rd = new Random();

        Button ClickMe_Button = new Button()
        {
            Content = "Click Me!",
            Height = 25, Width = 50,
            Background = Brushes.Red,
        };
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClickMe_Window_Loaded(object sender, RoutedEventArgs e)
        {
            ClickMe_Button.Click += btnClick;
            timer.Interval = TimeSpan.FromMilliseconds(interval_int);
            timer.Tick += tick;
            timer.Start();
            tollesCanvas.Children.Add(ClickMe_Button);
            set_button_random_pos();
        }

        private void tollesCanvas_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(interval_int);
            if (Keyboard.IsKeyDown(Key.Enter) || Keyboard.IsKeyDown(Key.Space))
            {
                return;
            }
            if (interval_int < 51)
            {
                timer.Stop();
                MessageBox.Show("Congratulations, you have won!");
                Restart();
            }
            else 
            {
                interval_int -= 50;
                set_button_random_pos();
                timer.Interval = TimeSpan.FromMilliseconds(interval_int+500);
            }
        }
        private void tick(object sender, EventArgs e)
        {
            set_button_random_pos();
        }
        public void set_button_random_pos()
        {
            int x_int = rd.Next((int)(tollesCanvas.Width - ClickMe_Button.Width));
            int y_int = rd.Next((int)(tollesCanvas.Height - ClickMe_Button.Height));
            ClickMe_Button.Margin = new Thickness(x_int, y_int, 0, 0);
        }
        public void Restart()
        {
            System.Windows.Forms.DialogResult result = System.Windows.Forms.MessageBox.Show("Retry?", "Confirmation", System.Windows.Forms.MessageBoxButtons.YesNo);
            if(result == System.Windows.Forms.DialogResult.Yes)
            {
                Reset();
            }
            else
            {
                Environment.Exit(0);
            }
        }
        private void Reset()
        {
            interval_int = 1000;
            set_button_random_pos();
            timer.Interval = TimeSpan.FromMilliseconds(interval_int);
            timer.Start();
        }
    }
}
