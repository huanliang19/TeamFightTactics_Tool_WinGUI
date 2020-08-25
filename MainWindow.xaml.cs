using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TeamfightTacticsUI_CS_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        private ItemChart itemChart = new ItemChart();
        public static Button[] buttonArr = new Button[45];

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
            for (int i = 0; i < 45; i++)
            {
                Button completeButton = new Button();
                buttonArr[i] = completeButton;
                completeButton.Name = "completeItem_" + i.ToString();
                ImageBrush brush = new ImageBrush(
                            new BitmapImage(
                            new Uri(@"C:\Users\huanl\source\repos\TeamFightTactics_Tool_WinGUI\Images\" + completeButton.Name + ".png", UriKind.Relative)));
                completeButton.Background = brush;
                completeButton.Width = 50;
                completeButton.Height = 50;
                completeButton.Margin = new Thickness(3);
                completeButton.BorderThickness = new Thickness(2);
                completeButton.Visibility = Visibility.Collapsed;
                completeButton.Click += new RoutedEventHandler(completeItemClick);
                Grid.SetColumn(completeButton, 0);
                Grid.SetColumn(completeButton, 0);
                CompletedItems.Children.Add(completeButton);
            }
        }

        void completeItemClick(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string[] tokens = btn.Name.Split('_');
            int buttonNumber_int = int.Parse(tokens[1]);
            itemChart.RemoveFullItem(buttonNumber_int);
            updateFullItems(buttonArr, itemChart.GetItems());
        }

        void componentItemClick(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Name)
            {
                case "Reset":
                    itemChart.Reset();
                    break;
                case "Exit":
                    Application.Current.Shutdown();
                    break;
                case "B_F_Sword_btn":
                    itemChart.AddItem(0);
                    break;
                case "Chain_Vest_btn":
                    itemChart.AddItem(1);
                    break;
                case "Giants_Belt_btn":
                    itemChart.AddItem(2);
                    break;
                case "Needlessly_Large_Rod_btn":
                    itemChart.AddItem(3);
                    break;
                case "Negatron_Cloak_btn":
                    itemChart.AddItem(4);
                    break;
                case "Recurve_Bow_btn":
                    itemChart.AddItem(5);
                    break;
                case "Golden_Spatula_btn":
                    itemChart.AddItem(6);
                    break;
                case "Tear_of_the_Goddess_btn":
                    itemChart.AddItem(7);
                    break;
                case "Brawlers_Gloves_btn":
                    itemChart.AddItem(8);
                    break;
            }
            updateFullItems(buttonArr, itemChart.GetItems());
        }

        void updateFullItems(Button[] buttonArr, int[] componentItemArr)
        {
            int x = 1;
            int y = 1;
            for (int i = 0; i < 45; i++)
            {
                buttonArr[i].Visibility = Visibility.Collapsed;
                if (componentItemArr[i] > 0)
                {
                    Grid.SetColumn(buttonArr[i], x);
                    Grid.SetRow(buttonArr[i], y);
                    x++;
                    if (x > 9)
                    {
                        x = 1;
                        y++;
                    }
                    buttonArr[i].Visibility = Visibility.Visible;
                }
            }

        }

        private string _boundState;

        public string BoundState
        {
            get { return "_boundState"; }
            set
            {
                if (_boundState != value)
                {
                    _boundState = value;
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