using CommunityToolkit.Maui.Converters;
using CommunityToolkit.Maui.Markup;
using INSAT._4I4U.TryShare.MobileApp.ViewModel;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Graphics.Text;

namespace INSAT._4I4U.TryShare.MobileApp.View;

public partial class MainPage : ContentPage
{
    readonly MainPageViewModel _viewModel;
    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = viewModel;

        SetReturnZoneCircleOnMap();
    }

    private void SetReturnZoneCircleOnMap()
    {
        var circle = new Circle()
        {
            StrokeColor = Color.FromArgb("#88FF2800"),
            StrokeWidth = 8,
            FillColor = Color.FromArgb("#88FFC0CB")
        }.Bind(Circle.CenterProperty, nameof(_viewModel.ReturnZone.Center))
         .Bind(Circle.RadiusProperty, nameof(_viewModel.ReturnZone.Radius));

        mainMap.MapElements.Add(circle);
    }

    private void PinMarkerClicked(object sender, Microsoft.Maui.Controls.Maps.PinClickedEventArgs e)
    {
        e.HideInfoWindow = true;
        //appel méthodes viewmodel
        _viewModel.DisplayPopup(Int32.Parse(((Pin)sender).Label));

    }

    private void OnMapClicked(object sender, Microsoft.Maui.Controls.Maps.MapClickedEventArgs e)
    {
        _viewModel.HidePopup();
    }

}

