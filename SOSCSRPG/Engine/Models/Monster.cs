﻿using System.Collections.ObjectModel;

namespace Engine.Models
{
    public class Monster : BaseNotification
    {
        #region Properties
        private int _hitPoints;
        public string Name { get; private set; }
        public string ImageName { get; set; }
        public int MaximumHitPoints { get; private set; }
        public int HitPoints
        {
            get { return _hitPoints; }
            set
            {
                _hitPoints = value;
                OnPropertyChanged(nameof(HitPoints));
            }
        }

        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }

        public int RewardExperiencePoints { get; private set; }
        public int RewardGold { get; private set; }
        public ObservableCollection<ItemQuantity> Inventory { get; set; }

        #endregion

        public Monster(string name, string imageName, int maximumHitpoints, int hitPoints,
            int maximumDamge, int minimumDamge,
            int rewardExperiencePoints, int rewardGold)
        {
            Name = name;
            ImageName = string.Format($"/Engine;component/Images/Monsters/{imageName}");
            MaximumHitPoints = maximumHitpoints;
            HitPoints = hitPoints;
            MinimumDamage = minimumDamge;
            MaximumDamage = maximumDamge;
            RewardExperiencePoints = rewardExperiencePoints;
            RewardGold = rewardGold;

            Inventory = new ObservableCollection<ItemQuantity>();
        }

    }

}
