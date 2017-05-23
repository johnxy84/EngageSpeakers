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
        private Faci speaker;
        public DetailsPage(Faci item)
        {
            InitializeComponent();
            speaker = item;
            BindingContext = speaker;
        }
    }
}
