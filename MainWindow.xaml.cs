using System.Windows.Input;
using System.ComponentModel;
using System.Windows;
using System.Runtime.CompilerServices;

namespace TeamfightTacticsUI_CS_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            MouseDown += Window_MouseDown;
            void Window_MouseDown(object sender, MouseButtonEventArgs e)
            {
                if (e.ChangedButton == MouseButton.Left)
                    DragMove();
            }


            //Sets up Buttons for Complete items
            /*            for (int i = 0; i < 45; i++)
                        {
                            Button compButton = new Button();

                            var brush = new ImageBrush(
                                        new BitmapImage(
                                        new Uri(@"C:\Users\huanl\source\repos\TeamFightTactics_Tool_WinGUI\Images\Tear_of_the_Goddess.png", UriKind.Relative)));

                            compButton.Name = "Tear_of_the_Goddess_btn" + i.ToString();
                            compButton.Background = brush;
                            compButton.Width = 50;
                            compButton.Height = 50;
                            compButton.Margin = new Thickness(3);
                            compButton.BorderThickness = new Thickness(2);
                            Grid.SetColumn(compButton, (i%9)+2);
                            Grid.SetRow(compButton, (i/9)+1);
                            CompletedItems.Children.Add(compButton);
                        }*/

            ItemChart itemChart = new ItemChart();

        }

        private int _boundNumber;
        public int BoundNumber
        {
            get { return _boundNumber; }
            set
            {
                if (_boundNumber != value)
                {
                    _boundNumber = value;
                    OnPropertyChanged();
                }

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}