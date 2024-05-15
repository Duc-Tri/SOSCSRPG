using Engine.Models;

namespace Engine.Factories
{
    internal class WorldFactory
    {
        internal World CreateWorld()
        {
            World newWorld = new World();

            newWorld.AddLocation(0, -1, "Home", "This is your home", "/Engine;component/Images/Locations/Home.png");

            newWorld.AddLocation(-2, -1, "Farmer's Field", "There are rows of corn growing here, with giant rats hiding between them.", "/Engine;component/Images/Locations/FarmFields.png");

            newWorld.AddLocation(-1, -1, "Farmer's House", "This is the house of your neighbor, Farmer Ted.", "/Engine;component/Images/Locations/FarmHouse.png");

            return newWorld;
        }
    }
}
