using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwapiMaui.ViewModel;


namespace SwapiMaui.View;

public partial class DetailPage : ContentPage
{
    public DetailPage(DetailViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}