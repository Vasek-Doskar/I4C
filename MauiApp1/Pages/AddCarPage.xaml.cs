using MauiApp1.Data;
using MauiApp1.Models;
using Microsoft.Maui.Controls.Platform.Compatibility;

namespace MauiApp1.Pages;

public partial class AddCarPage : ContentPage
{
    private readonly Context _context;
    public AddCarPage( Context context)
	{
        _context = context;
		InitializeComponent();
        ForUser.ItemsSource = _context.Persons.ToList();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await SaveAsync();
        //await Shell.Current.GoToAsync("mainpage");
    }

    private async Task SaveAsync()
    {
        Person p = ForUser.SelectedItem as Person;
        if (p != null)
        {
            Car c = new Car()
            {
                Brand = ForBrand.Text,
                Model = ForModel.Text,
                UserId = p.Id,
            };
            await _context.Cars.AddAsync(c);
            await _context.SaveChangesAsync();

            ForBrand.Text = ForModel.Text = "";
            ForUser.SelectedIndex = -1;
        }
    }
}
