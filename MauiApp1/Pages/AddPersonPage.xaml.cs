using MauiApp1.Data;
namespace MauiApp1.Pages;

public partial class AddPersonPage : ContentPage
{
	private readonly IDataManager _dataManager;
	public AddPersonPage(IDataManager dataManager)
	{
        _dataManager = dataManager;
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		string name = ForName.Text;
		_dataManager.Add(new Models.Person { Name = name });
		ForName.Text = "";     
    }
}