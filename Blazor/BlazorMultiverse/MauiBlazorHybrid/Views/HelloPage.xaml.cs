using MauiBlazorHybrid.ViewModels;

namespace MauiBlazorHybrid.Views;

public partial class HelloPage : ContentPage
{
    public HelloPage(HelloViewModel viewModel)
	{
        this.BindingContext = viewModel;
        InitializeComponent();
    }
}