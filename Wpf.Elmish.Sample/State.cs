using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Wpf.Elmish
{
    public class State
    {
        public static readonly State Empty =
            new State(0, new Coordinate(0, 0), new Area[0], Area.Empty);

        public State(double mapZoomLevel, Coordinate center, IEnumerable<Area> areas, Area newArea)
        {
            MapZoomLevel = mapZoomLevel;
            Center = center;
            Areas = areas?.ToImmutableList() ?? throw new ArgumentNullException(nameof(areas));
            NewArea = newArea ?? throw new ArgumentNullException(nameof(newArea));
        }

        public double MapZoomLevel { get; }
        public Coordinate Center { get; }
        public ImmutableList<Area> Areas { get; }
        public Area NewArea { get; }
    }

    public class Area
    {
        public static readonly Area Empty = new Area(new Coordinate[0], "");

        public Area(IEnumerable<Coordinate> coordinates, string note)
        {
            Coordinates = coordinates?.ToImmutableList() ?? throw new ArgumentNullException(nameof(coordinates));
            Note = note ?? throw new ArgumentNullException(nameof(note));
        }

        public ImmutableList<Coordinate> Coordinates { get; }
        public string Note { get; }
    }

    public class Coordinate
    {
        public Coordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; }
        public double Longitude { get; }
    }
}