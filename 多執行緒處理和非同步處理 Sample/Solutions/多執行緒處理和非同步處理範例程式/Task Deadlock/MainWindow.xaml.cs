using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Task_Deadlock
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DoSomethingAsync().Wait();
            //never gets past this point
            btnDeadlock.Content = "Running";
        }
        private async void Button1_Click(object sender, RoutedEventArgs e)
        {
            await DoSomething2Async();
            btnDeadlock1.Content = "I'm no deadlock";
        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            DoSomething2Async().Wait();
            //never gets past this point
            btnDeadlock2.Content = "I'm no deadlock";
        }
        private async void Button3_Click(object sender, RoutedEventArgs e)
        {
            DateTime fooDT1 = DateTime.UtcNow;
            DateTime fooDT2 = DateTime.UtcNow;
            var doSomething = DoSomething3Async();
            Thread.Sleep(1000);
            await doSomething;
            fooDT2 = DateTime.UtcNow;

            btnDeadlock3.Content = "花費時間" + (fooDT2 - fooDT1);
        }
        private async void Button4_Click(object sender, RoutedEventArgs e)
        {
            DateTime fooDT1 = DateTime.UtcNow;
            DateTime fooDT2 = DateTime.UtcNow;
            var doSomething = DoSomething4Async();
            Thread.Sleep(1000);
            await doSomething;
            fooDT2 = DateTime.UtcNow;

            btnDeadlock4.Content = "花費時間" + (fooDT2 - fooDT1);
        }
        private async Task DoSomethingAsync()
        {
            await Task.Delay(1000);
        }
        private async Task DoSomething2Async()
        {
            await Task.Delay(1000).ConfigureAwait(false);
        }
        private async Task DoSomething3Async()
        {
            //When the following command runs, the calling method (Index)
            //will resume
            await Task.Delay(1);
            //This method now waits to continue on the 'captured' thread
            //(the thread it started it on)
            Thread.Sleep(1000);
        }
        private async Task DoSomething4Async()
        {
            //When the following command runs, the calling method (Index)
            //will resume
            await Task.Delay(1)
                      // *** difference ***
                      .ConfigureAwait(continueOnCapturedContext: false);
            //This method now happily resumes on any available thread
            //from the TPL's ThreadPool

            Thread.Sleep(1000);
        }
    }
}
