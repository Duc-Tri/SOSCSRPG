using Engine.Factories;
using Engine.Models;

namespace Engine.ViewModels
{
    public class GameSession : BaseNotification
    {
        public World CurrentWorld { get; set; }
        public Player CurrentPlayer { get; set; }

        private Location _currentLocation;
        public Location CurrentLocation
        {
            get
            {
                return _currentLocation;
            }
            set
            {
                _currentLocation = value;

                OnPropertyChanged(nameof(CurrentLocation)); // instead of "CurrentLocation"
                OnPropertyChanged(nameof(HasLocationToNorth)); // instead of "HasLocationToNorth"
                OnPropertyChanged(nameof(HasLocationToEast));  // instead of "HasLocationToEast"
                OnPropertyChanged(nameof(HasLocationToWest));  // instead of "HasLocationToWest"
                OnPropertyChanged(nameof(HasLocationToSouth));  // instead of "HasLocationToSouth"
            }
        }

        private Location LocationAtNorth => CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1);
        private Location LocationAtSouth => CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1);
        private Location LocationAtEast => CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate);
        private Location LocationAtWest => CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);

        public bool HasLocationToNorth { get { return LocationAtNorth != null; } }
        public bool HasLocationToSouth { get { return LocationAtSouth != null; } }
        public bool HasLocationToEast { get { return LocationAtEast != null; } }
        public bool HasLocationToWest { get { return LocationAtWest != null; } }

        public GameSession()
        {
            CurrentPlayer = new Player();
            CurrentPlayer.Name = "Scott";
            CurrentPlayer.Gold = 1_000_000;
            CurrentPlayer.CharacterClass = "Fighter";
            CurrentPlayer.HitPoints = 10;
            CurrentPlayer.ExperiencePoints = 0;
            CurrentPlayer.Level = 1;

            WorldFactory factory = new WorldFactory();
            CurrentWorld = factory.CreateWorld();

            CurrentLocation = CurrentWorld.LocationAt(0, 0);
        }

        public void MoveNorth()
        {
            CurrentLocation = LocationAtNorth;
        }
        public void MoveSouth()
        {
            CurrentLocation = LocationAtSouth;
        }

        public void MoveEast()
        {
            CurrentLocation = LocationAtEast;
        }

        public void MoveWest()
        {
            CurrentLocation = LocationAtWest;
        }

    }

}
