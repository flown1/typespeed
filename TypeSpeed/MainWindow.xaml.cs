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
            canvasController = new CanvasController(gameCanvas, playerInfo);
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
            updateLogBox("The Game Has Started!");
            lives.Text = playerInfo.getLives().ToString();
            score.Text = playerInfo.getScore().ToString();
            
            loopController.startLoop(Config.LOOP_INTERVAL, loop_cancellation_token);
            loopController.scoreAndLivesUpdater(Config.LOOP_INTERVAL ,this, playerInfo);
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
    }
}
