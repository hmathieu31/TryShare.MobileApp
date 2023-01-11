using Microsoft.Maui.Maps;

namespace INSAT._4I4U.TryShare.MobileApp
{
    /// <summary>
    /// A custom Binding of the Map class defining a circle with Bindings
    /// </summary>
    public class CircleZone
    {
        public Color FillColor { get; set; }

        public Color StrokeColor { get; set; }

        public float StrokeWidth { get; set; }

        public Location Center { get; set; }

        public Distance Radius { get; set; }

        public required bool IsVisible { get; set; }
    }
}