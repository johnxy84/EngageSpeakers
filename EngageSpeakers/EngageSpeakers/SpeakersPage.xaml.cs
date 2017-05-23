using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EngageSpeakers
{
    public partial class SpeakersPage : ContentPage
    {
        public SpeakersPage()
        {
            InitializeComponent();
        }

        private async void SyncbuttonCLicked(object sender, EventArgs e)
        {
            ObservableCollection<Faci> speakers = await GetSpeakers();
            SpeakersList.ItemsSource = speakers;
        }

        async Task<ObservableCollection<Faci>> GetSpeakers()
        {
            ObservableCollection<Faci> speakers = new ObservableCollection<Faci>();
            try
            {
                Loader.IsVisible = true;
                Loader.IsRunning = true;

                var service = new AzureService();
                var items = await service.GetFacis();

                speakers.Clear();
                foreach (var item in items)
                    speakers.Add(item);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex);
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                Loader.IsVisible = false;
                Loader.IsRunning = false;
            }

            return speakers;
        }

        private async void SpeakersList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var faci = e.SelectedItem as Faci;
            if (faci == null)
                return;

            await Navigation.PushAsync(new DetailsPage(faci));
            SpeakersList.SelectedItem = null;
        }

        private async void MenuItem_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddFaciPage(new Faci()));
        }
    }
}