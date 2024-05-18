﻿namespace Engine.Models
{
    public class Player : BaseNotification
    {
        private string _name;
        private string _characterClass;
        private int _hitPoints;
        private int _experiencePoints;
        private int _level;
        private int _gold;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name)); // instead of "Name"
            }
        }
        public string CharacterClass
        {
            get { return _characterClass; }
            set
            {
                _characterClass = value;
                OnPropertyChanged(nameof(CharacterClass)); // instead of "CharacterClass"
            }
        }
        public int HitPoints
        {
            get { return _hitPoints; }
            set
            {
                _hitPoints = value;
                OnPropertyChanged(nameof(HitPoints)); // instead of "HitPoints"
            }
        }

        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set
            {
                _experiencePoints = value;
                OnPropertyChanged(nameof(ExperiencePoints)); // instead of "ExperiencePoints"
            }
        }
        public int Level
        {
            get { return _level; }
            set
            {
                _level = value;
                OnPropertyChanged(nameof(Level)); // instead of "Level"
            }
        }
        public int Gold
        {
            get { return _gold; }
            set
            {
                _gold = value;
                OnPropertyChanged(nameof(Gold)); // instead of "Gold"
            }
        }

    }

}