﻿using INSAT._4I4U.TryShare.MobileApp.ViewModel;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Graphics.Text;

namespace INSAT._4I4U.TryShare.MobileApp.View;

public partial class MainPage : ContentPage
{
    MainPageViewModel _viewModel;
	public MainPage(MainPageViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
        BindingContext = viewModel;
    }

    private void Pin_MarkerClicked(object sender, Microsoft.Maui.Controls.Maps.PinClickedEventArgs e)
    {
        e.HideInfoWindow = true;
        //appel méthodes viewmodel
        _viewModel.DisplayPopup(Int32.Parse(((Pin)sender).Label));

    }

}

