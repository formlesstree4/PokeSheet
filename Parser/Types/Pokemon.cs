using System;
using System.Collections.Generic;

namespace Parser.Types
{

    public enum Types
    {
        Normal,
        Fire,
        Water,
        Electric,
        Grass,
        Ice,
        Fighting,
        Poison,
        Ground,
        Flying,
        Psychic,
        Bug,
        Rock,
        Ghost,
        Dragon,
        Dark,
        Steel
    }


    public struct UsHeight
    {
        public int Feet { get; set; }
        public int Inches { get; set; }

        public override string ToString()
        {
            return string.Format("{0}' {1}\"", Feet, Inches);
        }

    }

    public struct SiHeight
    {
        public int Centimeters { get; set; }
        public int Meters { get; set; }

        public SiHeight(double height)
            : this()
        {

            // Meters will be the lowest possible integer.
            Meters = (int)Math.Floor(height);

            // And...it's time to continue on.
            Centimeters = (int)((height - Meters) * 100);

        }

        public override string ToString()
        {
            return string.Format("{0}m", Meters + (float)Centimeters/100);
        }

    }

    public struct UsWeight
    {
        public int Pounds { get; set; }
        public double Ounces { get; set; }

        public UsWeight(double weight)
            : this()
        {

            // default values
            Pounds = 0;
            Ounces = 0;

            // the passed weight is the combined mass in lbs and oz.
            // Floor it to get the appropriate weight in lbs.
            Pounds = (int)Math.Floor(weight);

            // okay, now, subtract and divide to get the ounces of the remainder.
            Ounces = Math.Round((weight - Pounds) / 0.0625, 2);

        }

        public override string ToString()
        {
            return string.Format("{0}lbs {1}oz", Pounds, Ounces);
        }

    }

    public struct SiWeight
    {
        public int Kilograms { get; set; }
        public int Grams { get; set; }
        public SiWeight(double weight) : this()
        {
            Kilograms = (int)Math.Floor(weight);
            Grams = (int) ((weight - Kilograms) * 1000);
        }

        public override string ToString()
        {
            return string.Format("{0}kg", Kilograms + (float)Grams/1000);
        }
    }


    public struct Gender
    {
        public decimal Male { get; set; }
        public decimal Female { get; set; }
    }

    public struct Stage
    {
        public string Name { get; set; }
        public string Requirement { get; set; }
    }

    public struct Capabilities
    {
        public int Overland { get; set; }
        public int Surface { get; set; }
        public int Underwater { get; set; }
        public int Sky { get; set; }
        public int Burrow { get; set; }
        public int Jump { get; set; }
        public int Power { get; set; }
        public int Intelligence { get; set; }
        public List<string> CustomCapabilities { get; set; }
    }

    public struct Stats
    {
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpecialAttack { get; set; }
        public int SpecialDefense { get; set; }
        public int Speed { get; set; }
    }

    public struct PokemonMove
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }

    public class Pokemon
    {

        public Pokemon()
        {
            Types = new List<Types>();
            Diet = new List<string>();
            Habitat = new List<string>();
            EggGroups = new List<string>();
            Stages = new List<Stage>();
            BasicAbilities = new List<string>();
            HighAbilities = new List<string>();
            Moves = new List<PokemonMove>();
            TM = new List<string>();
            EggMoves = new List<string>();
            TutorMoves = new List<string>();
        }

        public override string ToString()
        {
            return Name;
        }

        public string Name { get; set; }
        public string JapaneseName { get; set; }
        public int PtaNumber { get; set; }
        public int NationalNumber { get; set; }

        public List<Types> Types { get; set; }

        public UsHeight HeightUs { get; set; }
        public SiHeight HeightSi { get; set; }
        
        public string HeightClass { get; set; }

        public UsWeight WeightUs { get; set; }
        public SiWeight WeightSi { get; set; }
        public int WeightClass { get; set; }
        public string Classification { get; set; }

        public string Description { get; set; }
        public List<string> Diet { get; set; }
        public List<string> Habitat { get; set; }
        public Gender Gender { get; set; }
        public List<string> EggGroups { get; set; }

        public string HatchRate { get; set; }
        public List<Stage> Stages { get; set; }
        public Stats BaseStats { get; set; }
        public Capabilities Capabilities { get; set; }

        public List<string> BasicAbilities { get; set; }
        public List<string> HighAbilities { get; set; }

        public List<PokemonMove> Moves { get; set; }

        public List<string> TM { get; set; }
        public List<string> EggMoves { get; set; }
        public List<string> TutorMoves { get; set; } 

    }

    public static class ExtraInformation
    {

        /// <summary>
        /// Returns various levels of intelligence that a Pokemon can have.
        /// </summary>
        /// <param name="value">The level of intelligence to check.</param>
        /// <returns>A string that represents an estimated level.</returns>
        public static string Intelligence(int value)
        {
            switch(value)
            {
                case 1:
                    return "Feeble-minded: Slow reaction time; cannot do simple tasks";
                case 2:
                    return "Deficiency: Self-aware";
                case 3:
                    return "Dullness: Can't figure out tasks by self, but can follow instructions";
                case 4:
                    return "Normal: Can build and use tools";
                case 5:
                    return "Superior: Average human intellect";
                case 6:
                    return "Vastly Superior:  Able to function as a leader, act by self";
                case 7:
                    return "Genius: Super Computer thought, can understand human language";
                default:
                    return "Something went wrong with the value...try again";
            }
        }

        /// <summary>
        /// Returns various levels of Power that a Pokemon can have.
        /// </summary>
        /// <param name="value">The level of Power to check.</param>
        /// <returns>A string that represents an estimated level.</returns>
        public static string Power (int value)
        {
            switch (value)
            {
                case 1:
                    return "This Pokemon can lift up to 10lbs or 5kg";
                case 2:
                    return "This Pokemon can lift up to 50lbs or 23kg";
                case 3:
                    return "This Pokemon can lift up to 100lbs or 45kg";
                case 4:
                    return "This Pokemon can lift up to 200lbs or 90kg";
                case 5:
                    return "This Pokemon can lift up to 350lbs or 158kg";
                case 6:
                    return "This Pokemon can lift up to 500lbs or 227kg";
                case 7:
                    return "This Pokemon can lift up to 750lbs or 340kg";
                case 8:
                    return "This Pokemon can lift up to 1000lbs or 455kg";
                case 9:
                    return "This Pokemon can lift up to 2500lbs or 1135kg";
                case 10:
                    return "This Pokemon can lift up to 4000lbs or 1815kg";
                default:
                    return "Something went wrong with the value...try again";
            }
        }

        /// <summary>
        /// Returns various levels of Jump that a Pokemon can have.
        /// </summary>
        /// <param name="value">The level of Jump to check.</param>
        /// <returns>A string that represents an estimated level.</returns>
        public static string Jump(int value)
        {
            switch (value)
            {
                case 1:
                    return "This Pokemon can jump up to 3ft or 1 meter";
                case 2:
                    return "This Pokemon can jump up to 6ft or 1.8 meters";
                case 3:
                    return "This Pokemon can jump up to 10ft or 3 meters";
                case 4:
                    return "This Pokemon can jump up to 15ft or 4.5 meters";
                case 5:
                    return "This Pokemon can jump up to 20ft or 6 meters";
                case 6:
                    return "This Pokemon can jump up to 25ft or 7.6 meters";
                case 7:
                    return "This Pokemon can jump up to 35ft or 10.6 meters";
                case 8:
                    return "This Pokemon can jump up to 50ft or 15.2 meters";
                case 9:
                    return "This Pokemon can jump up to 70ft or 21 meters";
                case 10:
                    return "This Pokemon can jump up to 100ft or 30.5 meters";
                default:
                    return "Something went wrong with the value...try again";
            }
        }

        /// <summary>
        /// Returns how far a Pokemon can burrow in one turn.
        /// </summary>
        /// <param name="value">The level of the Pokemon's burrow capability.</param>
        /// <returns></returns>
        public static string Burrow(int value)
        {
            return string.Format("This Pokemon can burrow underground {0} meters in one round.", value);
        }

        /// <summary>
        /// Returns how far a Pokemon can move in one turn.
        /// </summary>
        /// <param name="value">The level of the Pokemon's Overland capability.</param>
        /// <returns></returns>
        public static string Overland(int value)
        {
            return string.Format("This Pokemon can move {0} meters on land in one round.", value);
        }
        
        /// <summary>
        /// Returns how far a Pokemon can swim in one turn.
        /// </summary>
        /// <param name="value">The level of the Pokemon's surface capability.</param>
        /// <returns></returns>
        public static string Surface(int value)
        {
            return string.Format("This Pokemon can swim {0} meters on the surface of the water in one round.", value);
        }

        /// <summary>
        /// Returns how far a Pokemon can swim underwater in one turn.
        /// </summary>
        /// <param name="value">The level of the Pokemon's Underwater capability.</param>
        /// <returns></returns>
        public static string Underwater(int value)
        {
            return string.Format("This Pokemon can swim {0} meters underwater in one round.", value);
        }

        /// <summary>
        /// Returns how far a Pokemon can fly in one turn.
        /// </summary>
        /// <param name="value">The level of the Pokemon's Sky capability.</param>
        /// <returns></returns>
        public static string Sky(int value)
        {
            return string.Format("This Pokemon can fly {0} meters in one round.", value);
        }

    }



}
