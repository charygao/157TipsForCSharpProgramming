using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading.Tasks;
using System.Threading;

namespace Tip87WPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            Task t = new Task(() =>
            {
                while (true)
                {
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        textBlock1.Text = DateTime.Now.ToString();
                    }));
                    Thread.Sleep(1000);
                }
            });
            //为了捕获异常，启动了一个新任务
            t.ContinueWith((task) =>
            {
                try
                {
                    task.Wait();
                }
                catch (AggregateException ex)
                {
                    foreach (Exception inner in ex.InnerExceptions)
                    {
                        MessageBox.Show(string.Format("异常类型：{0}{1}来自于：{2}{3}异常内容：{4}", inner.GetType(), Environment.NewLine, inner.Source, Environment.NewLine, inner.Message));
                    }
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            t.Start();
        }

    }
}
