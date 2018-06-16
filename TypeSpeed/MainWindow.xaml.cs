using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
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
        private LoopController loopController;
        private CancellationToken loop_cancellation_token;
        private Config config;

        public MainWindow()
        {
            InitializeComponent();

            config = new Config();
            config.setCanvasConfig(gameCanvas);
            canvasController = new CanvasController(gameCanvas);
            loopController = new LoopController(canvasController);
            loop_cancellation_token = new CancellationToken();
        }
        
        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            buttonStart.IsEnabled = false; 
            updateLogBox("The Game Has Started!");
            canvasController.drawNewWord();
            loopController.startLoop(Config.LOOP_INTERVAL, loop_cancellation_token);
            loopController.addNewWordWithInitInterval(Config.INIT_WORD_ADDING_INTERVAL);
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
        public void updateLogBox(string message) {
            logBox.Text = message;
        }

        private void typeInput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void typeInput_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            Console.WriteLine("costam pressed");

            if (e.Key == Key.Enter)
            {
                Console.WriteLine("Enter pressed");
                typeInput_enterHandler(typeInput.Text);
            }
        }

        private void typeInput_enterHandler(string text)
        {
            canvasController.checkIfHit(text);
        }
    }
}
