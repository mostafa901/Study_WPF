using System;
using System.Windows;

namespace Study_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel mv;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = mv = new ViewModel();            
            Setup_Events();

        }

        private void Setup_Events()
        {
            KeyDown += MainWindow_KeyDown;
        }

        private void MainWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
           if(e.Key == System.Windows.Input.Key.Escape)
           {
                Close();
           }
        }
    }
}