using MauiApp1.Data;
using MauiApp1.Models;

namespace MauiApp1.Pages;

public partial class AddCarPage : ContentPage
{

    private readonly IDataManager _dataManager;
    private readonly ICarManager _carManager;
    public AddCarPage(IDataManager dataManager, ICarManager carManager)
	{
        _carManager = carManager;
        _dataManager = dataManager;
		InitializeComponent();
        ForUser.ItemsSource = _dataManager.GetAll() as List<Person>;
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

            _carManager.Add(c);
            ForBrand.Text = ForModel.Text = "";
            ForUser.SelectedIndex = -1;
        }
    }
}
