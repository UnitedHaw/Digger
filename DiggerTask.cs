using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digger
{
    //Напишите здесь классы Player, Terrain и другие.

    public class Player : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            CreatureCommand creatureCommand = new CreatureCommand();

            if (x < Game.MapWidth && y < Game.MapHeight)
            {
                creatureCommand.DeltaX = x;
                creatureCommand.DeltaY = y;
                creatureCommand.TransformTo = null;

                return creatureCommand;
            }
            else
            {
                return new CreatureCommand { };
            }
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            string conflictedObjectName = conflictedObject.GetImageFileName();
            return !conflictedObjectName.Equals("Monster.png");
        }

        public int GetDrawingPriority()
        {
            throw new NotImplementedException();
        }

        public string GetImageFileName()
        {
            return "Digger.png";
        }
    }

    public class Terrain : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand { DeltaX = x - Game.MapWidth, DeltaY = y - Game.MapHeight, TransformTo = null };
            
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return false;
        }

        public int GetDrawingPriority()
        {
            throw new NotImplementedException();
        }

        public string GetImageFileName()
        {
            return "Terrain.png";
        }
    }
}
