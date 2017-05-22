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
            ObservableCollection<Speaker> speakers = await GetSpeakers();
            SpeakersList.ItemsSource = speakers;
        }

        async Task<ObservableCollection<Speaker>> GetSpeakers()
        {
             ObservableCollection<Speaker> speakers= new ObservableCollection<Speaker>();
            try
            {
                Loader.IsVisible = true;
                Loader.IsEnabled = true;
                Loader.IsRunning = true;

                var service = new AzureService();
                var items = await service.GetSpeakers();

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
                Loader.IsEnabled = false;
                Loader.IsRunning = false;
            }

            return speakers;
        }

        private async void SpeakersList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var speaker = e.SelectedItem as Speaker;
            if (speaker == null)
                return;

            await Navigation.PushAsync(new DetailsPage(speaker));
            SpeakersList.SelectedItem = null;
        }
    }
}
