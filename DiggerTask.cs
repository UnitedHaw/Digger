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


            switch (Game.KeyPressed)
            {
                case System.Windows.Forms.Keys.Right:
                    if(creatureCommand.DeltaX + x < Game.MapWidth - 1)
                    creatureCommand.DeltaX++;
                    break;
                case System.Windows.Forms.Keys.Left:
                    if(creatureCommand.DeltaX + x > 0)
                    creatureCommand.DeltaX--;
                    break;
                case System.Windows.Forms.Keys.Up:
                    if(creatureCommand.DeltaY + y > 0)
                    creatureCommand.DeltaY--;
                    break;
                case System.Windows.Forms.Keys.Down:
                    if(creatureCommand.DeltaY + y < Game.MapHeight - 1)
                    creatureCommand.DeltaY++;
                    break;
            }
            return creatureCommand;
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            string conflictedObjectName = conflictedObject.GetImageFileName();
            if (conflictedObjectName.Equals("Monster.png"))
                return true;
            else return false;
        }

        public int GetDrawingPriority()
        {
            return 5;
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

            return new CreatureCommand();

        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return true;
        }

        public int GetDrawingPriority()
        {
            return 0;
        }

        public string GetImageFileName()
        {
            return "Terrain.png";
        }
    }
}
