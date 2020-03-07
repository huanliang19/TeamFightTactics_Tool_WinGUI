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

            //Sets up Buttons for Component items
            for (int i = 1; i < 10; i++)
            {
                Button compButton = new Button();
          
                var brush = new ImageBrush(
                            new BitmapImage(
                            new Uri(@"C:\Users\huanl\source\repos\TeamfightTacticsUI_CS_WPF\TeamfightTacticsUI_CS_WPF\Images\Tear_of_the_Goddess.png", UriKind.Relative)));

                compButton.Name = "Tear_of_the_Goddess_btn";
                compButton.Background = brush;
                compButton.Width = 50;
                compButton.Height = 50;
                compButton.Margin = new Thickness(5);
                compButton.BorderThickness = new Thickness(2);
                Grid.SetColumn(compButton, i);
                Grid.SetRow(compButton, 1);
                ComponentItems.Children.Add(compButton);
            }
        }
    }
}