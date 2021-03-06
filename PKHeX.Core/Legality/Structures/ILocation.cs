﻿namespace PKHeX.Core
{
    public interface ILocation
    {
        int Location { get; set; }
        int EggLocation { get; set; }
    }

    public static partial class Extensions
    {
        public static int GetLocation(this ILocation encounter)
        {
            if (encounter == null)
                return -1;
            return encounter.Location != 0 
                ? encounter.Location 
                : encounter.EggLocation;
        }
        internal static string GetEncounterLocation(this ILocation Encounter, int gen)
        {
            int loc = Encounter.GetLocation();
            if (loc < 0)
                return null;
            return GameInfo.GetLocationName(loc != Encounter.Location, loc, gen, gen);
        }
    }
}
