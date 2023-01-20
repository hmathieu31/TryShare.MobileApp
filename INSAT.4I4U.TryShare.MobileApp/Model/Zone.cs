using Microsoft.Maui.Maps;

namespace INSAT._4I4U.TryShare.MobileApp
{
    /// <summary>
    /// A custom Binding of the Map class defining a circle with Bindings
    /// </summary>
    public class CircleZone
    {
        public required Color FillColor { get; set; }

        public required Color StrokeColor { get; set; }

        public float StrokeWidth { get; set; }

        public required Location Center { get; set; }

        public Distance Radius { get; set; }

        public required bool IsVisible { get; set; }
    }
}