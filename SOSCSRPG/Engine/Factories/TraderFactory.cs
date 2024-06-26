﻿using Engine.Models;

namespace Engine.Factories
{
    public static class TraderFactory
    {
        public static readonly List<Trader> _traders = new List<Trader>();

        static TraderFactory()
        {
            Trader susan = new Trader("Susan");
            susan.AddItemToInventory(ItemFactory.CreateGameItem(1001));
            AddTraderToList(susan);

            Trader farmerTed = new Trader("Farmer Ted");
            farmerTed.AddItemToInventory(ItemFactory.CreateGameItem(1001));
            AddTraderToList(farmerTed);

            Trader peteTheHerbalist = new Trader("Pete the Herbalist");
            peteTheHerbalist.AddItemToInventory(ItemFactory.CreateGameItem(1001));
            AddTraderToList(peteTheHerbalist);
        }

        public static Trader GetTraderByName(string name)
        {
            Trader trader = _traders.FirstOrDefault(t => t.Name == name);

            if (trader == null)
                return new Trader("GOLLUM");

            return trader;
        }

        private static void AddTraderToList(Trader trader)
        {
            if (_traders.Any(t => t.Name == trader.Name))
                throw new ArgumentException($"There is already a trader named '{trader.Name}'");

            _traders.Add(trader);
        }

    }

}
