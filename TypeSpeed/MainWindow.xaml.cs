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
        private PlayerInfo playerInfo;
        
        public MainWindow()
        {
            InitializeComponent();

            config = new Config();
            config.setCanvasConfig(gameCanvas);
            playerInfo = new PlayerInfo(Config.INIT_LIVES);
            canvasController = new CanvasController(gameCanvas, playerInfo, config);
            loopController = new LoopController(canvasController);
            loop_cancellation_token = new CancellationToken();
        }
        
        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            buttonStart.IsEnabled = false;
            typeInput.Focus();

            startTheGame();
        }

        private void startTheGame()
        {
            score.Text = playerInfo.getScore().ToString();
            
            loopController.startLoop(config, loop_cancellation_token);
            loopController.scoreUpdater(config ,this, playerInfo);
            loopController.addNewWordWithInitInterval(config);
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void typeInput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void typeInput_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                typeInput_enterHandler(typeInput.Text);
                typeInput.Text = "";
            }
        }

        private void typeInput_enterHandler(string text)
        {
            canvasController.checkIfHit(text);
        }

        private void buttonRestart_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
