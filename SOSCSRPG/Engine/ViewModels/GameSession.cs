using Engine.EventArgs;
using Engine.Factories;
using Engine.Models;

namespace Engine.ViewModels
{
    public class GameSession : BaseNotification
    {
        public event EventHandler<GameMessageEventArgs> OnMessageRaised;

        #region Properties
        public World CurrentWorld { get; set; }
        public Player CurrentPlayer { get; set; }

        private Location _currentLocation;
        private Monster _currentMonster;

        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;

                OnPropertyChanged(nameof(CurrentLocation)); // instead of "CurrentLocation"
                OnPropertyChanged(nameof(HasLocationToNorth)); // instead of "HasLocationToNorth"
                OnPropertyChanged(nameof(HasLocationToEast));  // instead of "HasLocationToEast"
                OnPropertyChanged(nameof(HasLocationToWest));  // instead of "HasLocationToWest"
                OnPropertyChanged(nameof(HasLocationToSouth));  // instead of "HasLocationToSouth"

                GivePlayerQuestAtLocation();
                GetMonsterAtLocation();
            }
        }
        #endregion

        private Location LocationAtNorth => CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1);
        private Location LocationAtSouth => CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1);
        private Location LocationAtEast => CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate);
        private Location LocationAtWest => CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);

        public Monster CurrentMonster
        {
            get { return _currentMonster; }
            set
            {
                _currentMonster = value;
                OnPropertyChanged(nameof(CurrentMonster));
                OnPropertyChanged(nameof(HasMonster));
            }
        }

        public bool HasLocationToNorth { get { return LocationAtNorth != null; } }
        public bool HasLocationToSouth { get { return LocationAtSouth != null; } }
        public bool HasLocationToEast { get { return LocationAtEast != null; } }
        public bool HasLocationToWest { get { return LocationAtWest != null; } }
        public bool HasMonster => CurrentMonster != null;

        public GameSession()
        {
            CurrentPlayer = new Player
            {
                Name = "Scott",
                CharacterClass = "Fighter",
                HitPoints = 10,
                Gold = 1_000_000,
                ExperiencePoints = 0,
                Level = 1
            };

            CurrentWorld = WorldFactory.CreateWorld();

            CurrentLocation = CurrentWorld.LocationAt(0, 0);

            // FOR TESTS
            //CurrentPlayer.Inventory.Add(ItemFactory.CreateGameItem(1001));
            //CurrentPlayer.Inventory.Add(ItemFactory.CreateGameItem(1002));
            //CurrentPlayer.Inventory.Add(ItemFactory.CreateGameItem(1002));
        }

        public void MoveNorth()
        {
            if (HasLocationToNorth)
                CurrentLocation = LocationAtNorth;
        }
        public void MoveSouth()
        {
            if (HasLocationToSouth)
                CurrentLocation = LocationAtSouth;
        }

        public void MoveEast()
        {
            if (HasLocationToEast)
                CurrentLocation = LocationAtEast;
        }

        public void MoveWest()
        {
            if (HasLocationToWest)
                CurrentLocation = LocationAtWest;
        }

        private void GivePlayerQuestAtLocation()
        {
            foreach (Quest quest in CurrentLocation.QuestsAvailableHere)
                if (!CurrentPlayer.Quests.Any(q => q.PlayerQuest.ID == quest.ID))
                    CurrentPlayer.Quests.Add(new QuestStatus(quest));
        }

        private void GetMonsterAtLocation()
        {
            CurrentMonster = CurrentLocation.GetMonster();
        }

        private void RaiseMessage(string message)
        {
            OnMessageRaised?.Invoke(this, new GameMessageEventArgs(message));
        }

    }

}
