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
        private Config config;
        private PlayerInfo playerInfo;
        private CancellationTokenSource startLoopCancellationToken;
        private CancellationTokenSource scoreUpdaterCancellationToken;
        private CancellationTokenSource addNewWordCancellationToken;

        public MainWindow()
        {
            InitializeComponent();

            initializeGameObjects();
        }

        private void initializeGameObjects()
        {
            config = new Config();
            playerInfo = new PlayerInfo();
            canvasController = new CanvasController(this, gameCanvas, playerInfo, config);

            loopController = new LoopController(canvasController);
            startLoopCancellationToken = new CancellationTokenSource();
            scoreUpdaterCancellationToken = new CancellationTokenSource();
            addNewWordCancellationToken = new CancellationTokenSource();
            canvasController.bindCancellationTokens(startLoopCancellationToken, scoreUpdaterCancellationToken, addNewWordCancellationToken);

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
            try
            {
                loopController.startLoop(config, startLoopCancellationToken.Token);
                loopController.scoreUpdater(config, this, playerInfo, scoreUpdaterCancellationToken.Token);
                loopController.addNewWordLoop(config, addNewWordCancellationToken.Token);
            }
            catch (Exception e) {
                Console.WriteLine("There is something wrong with game loops work! Game stops");
            }
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
            clearGame();
            
            buttonRestart.IsEnabled = false;
            typeInput.Focus();
            typeInput.Text = "";

            startTheGame();
        }

        private void clearGame()
        {
            canvasController.clearEverything();
            
            initializeGameObjects();
        }
    }
}
