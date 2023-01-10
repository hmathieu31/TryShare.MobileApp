using INSAT._4I4U.TryShare.MobileApp.Behaviours.Base;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

using MauiMap = Microsoft.Maui.Controls.Maps.Map;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.MobileApp.Behaviours
{
    public class MapBehaviour : BindableBehaviour<MauiMap>
    {
        private MauiMap map;

        public static readonly BindableProperty IsReadyProperty =
            BindableProperty.CreateAttached(nameof(IsReady),
                typeof(bool),
                typeof(MapBehaviour),
                default(bool),
                BindingMode.Default,
                null,
                OnIsReadyChanged);


        public bool IsReady
        {
            get => (bool)GetValue(IsReadyProperty);
            set => SetValue(IsReadyProperty, value);
        }

        private static void OnIsReadyChanged(BindableObject view, object oldValue, object newValue)
        {
            var mapBehaviour = view as MapBehaviour;

            if (mapBehaviour is not null && newValue is bool)
                mapBehaviour.ChangePosition();
        }

        public static readonly BindableProperty ZonesProperty =
            BindableProperty.CreateAttached(nameof(Zones),
                typeof(IEnumerable<CircleZone>),
                typeof(MapBehaviour),
                default(IEnumerable<CircleZone>),
                BindingMode.Default,
                null,
                OnZonesChanged);

        public IEnumerable<CircleZone> Zones
        {
            get => (IEnumerable<CircleZone>)GetValue(ZonesProperty);
            set => SetValue(ZonesProperty, value);
        }

        private static void OnZonesChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var behaviour = bindable as MapBehaviour;

            behaviour?.DrawZones();

        }

        private void DrawZones()
        {
            // Whenever the returnZones bindable property is changed, all returnZones on the map are cleared and redrawn 
            map.MapElements.Clear();

            foreach (var zone in Zones)
            {
                var strokeColor = zone.IsVisible ? zone.StrokeColor : Color.FromArgb("00FFFFFF");
                var fillColor = zone.IsVisible ? zone.FillColor : Color.FromArgb("00FFFFFF");

                var circle = new Circle
                {
                    Center = zone.Center,
                    Radius = zone.Radius,
                    FillColor = fillColor,
                    StrokeColor = strokeColor,
                    StrokeWidth = zone.StrokeWidth
                };

                map.MapElements.Add(circle);
            }
        }

        private void ChangePosition()
        {
            // Not yet implemented

            //if (!IsReady)
            //    return;

        }

        protected override void OnAttachedTo(MauiMap bindable)
        {
            base.OnAttachedTo(bindable);
            map = bindable;
        }

        protected override void OnDetachingFrom(MauiMap bindable)
        {
            base.OnDetachingFrom(bindable);
            map = null;
        }
    }
}
