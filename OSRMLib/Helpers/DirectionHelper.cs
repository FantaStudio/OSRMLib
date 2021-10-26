using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OSRMLib.Helpers
{
    public enum Direction
    {
        None,
        Uturn,
        SharpRight,
        Right,
        SlightRight,
        Straight,
        SlightLeft,
        Left,
        SharpLeft
    }
    
    public static class DirectionHelper
    {
        public static Direction ParseStringToDirection(string directionString)
        {
            if (string.IsNullOrEmpty(directionString))
            {
                return Direction.None;
            }

            directionString = directionString.Remove(' ');
            var directions = Enum.GetNames(typeof(Direction)).ToList().Select(x=>x.ToLower());
            if (directions.Contains(directionString))
                return (Direction)Enum.Parse(typeof(Direction), directions.Where(x => x == directionString).First());
            else
                return Direction.None;
        }

        public static IEnumerable<Direction> ParseStringArrayToDirection(IEnumerable<string> directionStrings)
        {
            return directionStrings.Select(x => ParseStringToDirection(x));
        }
    }
}
