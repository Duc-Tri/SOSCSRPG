﻿using Engine.Factories;
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

    }

}
