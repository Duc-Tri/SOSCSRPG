using Engine.ViewModels;
using System.Windows;

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameSession _gameSession;

        public MainWindow()
        {
            InitializeComponent();

            _gameSession = new GameSession();

            DataContext = _gameSession; // visible in XAML
        }

        private void ButtonXP_OnClick(object sender, RoutedEventArgs e)
        {
            _gameSession.CurrentPlayer.ExperiencePoints += 10;
        }
        private void ButtonGold_OnClick(object sender, RoutedEventArgs e)
        {
            _gameSession.CurrentPlayer.Gold += 3;
        }

    }
}