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
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.OnAppearing();
    }

    private void PinMarkerClicked(object sender, PinClickedEventArgs e)
    {
        e.HideInfoWindow = true;
        //appel méthodes viewmodel
        _viewModel.DisplayPopup(int.Parse(((Pin)sender).Label));

    }

    private void OnMapClicked(object sender, MapClickedEventArgs e)
    {
        _viewModel.HidePopup();
    }

}

