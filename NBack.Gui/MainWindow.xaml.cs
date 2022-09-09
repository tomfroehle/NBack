using System;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace NBack.Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly TestAusführung _testAusführung;
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();

        public MainWindow()
        {
            InitializeComponent();
            _testAusführung = new TestAusführung(8);
            this.Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var ergebnis = await _testAusführung.FühreTestAus(1000, Display, _cts.Token);
            label.Content = ergebnis.ToString();
        }

        private void Display(char c)
        {
            label.Content = c;
        }

        private void MainWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                _cts.Cancel();
            } else if (e.Key == Key.Space)
            {
                _testAusführung.RegistriereReizWiederholung();
            }
        }
    }
}
