using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace AsyncAwait
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

        private async void btnDownload_Click(object sender, RoutedEventArgs e)
        {
            string fooStr = await GetStringAsync();
            Console.WriteLine(fooStr);
        }

        public async Task<string> GetStringAsync()
        {
            HttpClient client = new HttpClient();
            var result = await client.GetStringAsync("http://www.microsoft.com");
            return result;
        }

        private async void btnDownload2_Click(object sender, RoutedEventArgs e)
        {
            int x = 3, y = 1, z = 2, total = 0;
            total = x * y * z;
            string fooStr = await GetString2Async();
            Console.WriteLine(string.Format("{0} {1}", total,fooStr));
        }

        public async Task<string> GetString2Async()
        {
            string foo1 = "Hello", foo2 = "World", foo3 = "";
            HttpClient client = new HttpClient();
            var result = await client.GetStringAsync("http://www.microsoft.com");
            foo3 = string.Format("{0} {1}", foo1, foo2);
            return result;
        }


    }
}
