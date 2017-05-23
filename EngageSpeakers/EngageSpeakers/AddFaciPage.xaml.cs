using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EngageSpeakers
{
    public partial class AddFaciPage : ContentPage
    {
        Faci Faci;
        public AddFaciPage(Faci faci)
        {
            InitializeComponent();
            Faci = faci;
            BindingContext = faci;
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await AddUser();
            await Navigation.PopAsync();
        }

        //Add a New User
        async Task AddUser()
        {
            try
            {
                Loader.IsVisible = true;
                Loader.IsRunning = true;
                var service = new AzureService();
                await service.AddFaci(Faci);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                Loader.IsVisible = false;
                Loader.IsRunning = false;
            }
        }
    }
}
