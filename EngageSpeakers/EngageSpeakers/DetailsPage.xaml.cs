using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EngageSpeakers
{
    public partial class DetailsPage : ContentPage
    {
        private Speaker speaker;
        public DetailsPage(Speaker item)
        {
            InitializeComponent();
            speaker = item;
            BindingContext = speaker;
        }
    }
}
