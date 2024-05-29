﻿using Engine.Models;

namespace Engine.Factories
{
    public static class ItemFactory
    {
        private static readonly List<GameItem> _standardGameItems = new List<GameItem>();

        static ItemFactory()
        {
            _standardGameItems =
            [
                new Weapon(1001, "Pointy Stick", 1, 1, 2),
                new Weapon(1002, "Rusty Sword", 5, 1, 3),

                new GameItem(9001, "Snake Fang",  1),
                new GameItem(9002, "Snake Skin",  2),
                new GameItem(9003, "Rat Tail",  1),
                new GameItem(9004, "Rat Fur",  2),
                new GameItem(9005, "Spider Fang",  1),
                new GameItem(9006, "Spider Silk",  2),
            ];
        }

        public static GameItem CreateGameItem(int itemTypeID)
        {
            GameItem standardItem = _standardGameItems.FirstOrDefault(item => item.ItemTypeID == itemTypeID);

            if (standardItem != null)
            {
                if (standardItem is Weapon)
                    return (standardItem as Weapon).Clone();

                return standardItem.Clone();
            }

            return null;
        }

    }

}
