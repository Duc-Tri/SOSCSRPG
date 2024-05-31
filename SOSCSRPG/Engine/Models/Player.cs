using System.Collections.ObjectModel;

namespace Engine.Models
{
    public class Player : BaseNotification
    {
        #region Properties
        private string _name;
        private string _characterClass;
        private int _hitPoints;
        private int _experiencePoints;
        private int _level;
        private int _gold;

        // automatically handles notifications
        public ObservableCollection<GameItem> Inventory { get; set; }

        public List<GameItem> Weapons => Inventory.Where(i => i is Weapon).ToList();

        public ObservableCollection<QuestStatus> Quests { get; set; }

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

        #endregion

        public Player()
        {
            Inventory = new ObservableCollection<GameItem>();
            Quests = new ObservableCollection<QuestStatus>();
        }

        public void AddItemToInventory(GameItem item)
        {
            Inventory.Add(item);

            OnPropertyChanged(nameof(Weapons));
        }

        public void RemoveItemFromInventory(GameItem item)
        {
            Inventory.Remove(item);
            OnPropertyChanged(nameof(Weapons));
        }

        public bool HasAllTheseItems(List<ItemQuantity> items)
        {
            foreach (ItemQuantity item in items)
                if (Inventory.Count(i => i.ItemTypeID == item.ItemID) < item.Quantity)
                    return false;

            return true;
        }

    }

}