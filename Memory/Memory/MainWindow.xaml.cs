using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;

namespace Pairs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameOptions gameOptions = new GameOptions();
        private GameController gameController;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            gameController = new SinglePlayerGameController(this.gameGrid, gameOptions.SelectedIconSet);
        }


        private void rectangleLeftMouseButtonUp(object sender, MouseButtonEventArgs e)
        {
            Rectangle cardRectangle = e.Source as Rectangle;
            if (cardRectangle == null) return;

            gameController.PickCard(cardRectangle);
        }

        private void NewGameSinglePlayerCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            borderPlayer1.DataContext = null;
            gameController = new SinglePlayerGameController(gameGrid, gameOptions.SelectedIconSet);
            gameController.StartGame();
        }
    }
}
