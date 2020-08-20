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

namespace TeamfightTacticsUI_CS_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
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
    }
}