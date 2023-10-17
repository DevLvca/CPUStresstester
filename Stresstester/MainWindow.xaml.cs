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
using System.Threading;

namespace Stresstester
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        static bool running;
        
        private void CPUStresstestButton(object sender, RoutedEventArgs e)
        {
            uint numberOfThreads;

            try
            {
                numberOfThreads = Convert.ToUInt32(NumberOfThreads.Text);
            }
            catch
            {
                MessageBox.Show("Invalid input, positive numbers only", "Invalid input");
                return;
            }

            MessageBox.Show("Stresstest started");
            running = true;

            for (int i = 0; i < Convert.ToInt32(numberOfThreads); i++)
            {
                Thread thread = new Thread(burn);
                thread.Start();
            }

            running = false;
        }

        private void burn()
        {
            while (running)
            {
                long primeCount = 0;
                long candidate = 2;

                while (primeCount < double.MaxValue)
                {
                    bool isPrime = true;
                    for (long divisor = 2; divisor <= Math.Sqrt(candidate); divisor++)
                    {
                        if (candidate % divisor == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }

                    if (isPrime)
                        primeCount++;

                    candidate++;
                }
            }
        }
    }
}
