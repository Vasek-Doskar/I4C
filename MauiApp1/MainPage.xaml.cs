using MauiApp1.Data;
using MauiApp1.Models;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        public readonly IDataManager _dataManager;
        public MainPage(IDataManager dataManager)
        {
            _dataManager = dataManager;
            InitializeComponent();

            Shell.Current.Navigated += (s, e) =>
            {
                Refresh();               
            };       
        }


        void Refresh()
        {
            DbList.ItemsSource = null;
            DbList.ItemsSource = _dataManager.GetAll();
        }

        private async void DbList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            int id = (e.Item as Person)!.Id;
            Person? selected = _dataManager.GetById(id);

            if (selected is not null)
            {
                string output = "";
                foreach (Car c in selected.Cars!)
                {
                    output += $"{c}\n";
                }

                await DisplayAlert($"{selected}", output, "OK");
                Refresh();
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            int id = (DbList.SelectedItem as Person)!.Id;
            Person? selected = _dataManager.GetById(id);
            _dataManager.Delete(selected);
            Refresh();
        }
    }

}
