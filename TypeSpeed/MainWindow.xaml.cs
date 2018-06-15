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

namespace TypeSpeed
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CanvasController canvasController;
        public MainWindow()
        {
            InitializeComponent();

            canvasController = new CanvasController(gameCanvas);
        }
        
        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            logBox.Text = "The Game has Started";
            canvasController.drawNewWord();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
