using System;

namespace PtaSheet.Classes
{
    public class CombatStages
    {

        public enum Types
        {
            HP, Attack, Defense, SpAtk, SpDef, Speed
        }
        
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpAtk { get; set; }
        public int SpDef { get; set; }
        public int Speed { get; set; }

        public int Calculate(Types type, decimal value)
        {

            var stages = 0;
            switch (type)
            {
                case Types.HP: stages = HP; break;
                case Types.Attack: stages = Attack; break;
                case Types.Defense: stages = Defense; break;
                case Types.SpAtk: stages = SpAtk; break;
                case Types.SpDef: stages = SpDef; break;
                case Types.Speed: stages = Speed; break;
            }
            return stages > 0 ? (int)Math.Max(Math.Abs(stages * (decimal)25 / 100 * value) + value, 1) : 
                (int)Math.Round(Math.Max(Math.Abs((stages * (decimal)12.5 / 100 * value) - value), 1), 0);
            
        }

    }
}
