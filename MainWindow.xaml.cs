using System;
using System.Collections.ObjectModel;
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
            updateComponentItems();
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
            updateComponentItems();
        }
        /*        public class ButtonBindings : INotifyPropertyChanged
                {
                    public event PropertyChangedEventHandler PropertyChanged;

                    private int _Value;
                    public int Value
                    {
                        get { return _Value; }
                        set { Value = value; OnPropertyChanged("Value"); }
                    }

                    void OnPropertyChanged(string propertyName)
                    {
                        var handler = PropertyChanged;
                        if (handler != null)
                        {
                            handler(this, new PropertyChangedEventArgs(propertyName));
                        }
                    }
            }
                ObservableCollection<ButtonBindings> Arr {
                    get; 
                    set; 
                }*/
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

        //try array of binding variables using Observable Collections updated by itemChart.getComponentItems()
        private int _boundState0;
        private int _boundState1;
        private int _boundState2;
        private int _boundState3;
        private int _boundState4;
        private int _boundState5;
        private int _boundState6;
        private int _boundState7;
        private int _boundState8;
        public int BoundState0
        {
            get { return _boundState0; }
            set
            {
                if (_boundState0 != value)
                {
                    _boundState0 = value;
                    OnPropertyChanged();
                }

            }
        }
        public int BoundState1
        {
            get { return _boundState1; }
            set
            {
                if (_boundState1 != value)
                {
                    _boundState1 = value;
                    OnPropertyChanged();
                }

            }
        }
        public int BoundState2
        {
            get { return _boundState2; }
            set
            {
                if (_boundState2 != value)
                {
                    _boundState2 = value;
                    OnPropertyChanged();
                }

            }
        }
        public int BoundState3
        {
            get { return _boundState3; }
            set
            {
                if (_boundState3 != value)
                {
                    _boundState3 = value;
                    OnPropertyChanged();
                }

            }
        }
        public int BoundState4
        {
            get { return _boundState4; }
            set
            {
                if (_boundState4 != value)
                {
                    _boundState4 = value;
                    OnPropertyChanged();
                }

            }
        }
        public int BoundState5
        {
            get { return _boundState5; }
            set
            {
                if (_boundState5 != value)
                {
                    _boundState5 = value;
                    OnPropertyChanged();
                }

            }
        }
        public int BoundState6
        {
            get { return _boundState6; }
            set
            {
                if (_boundState6 != value)
                {
                    _boundState6 = value;
                    OnPropertyChanged();
                }

            }
        }
        public int BoundState7
        {
            get { return _boundState7; }
            set
            {
                if (_boundState7 != value)
                {
                    _boundState7 = value;
                    OnPropertyChanged();
                }

            }
        }
        public int BoundState8
        {
            get { return _boundState8; }
            set
            {
                if (_boundState8 != value)
                {
                    _boundState8 = value;
                    OnPropertyChanged();
                }

            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        void updateComponentItems()
        {
            int[] compArr = itemChart.GetComponentItems();
            BoundState0 = compArr[0];
            BoundState1 = compArr[1];
            BoundState2 = compArr[2];
            BoundState3 = compArr[3];
            BoundState4 = compArr[4];
            BoundState5 = compArr[5];
            BoundState6 = compArr[6];
            BoundState7 = compArr[7];
            BoundState8 = compArr[8];
        }
    }
}