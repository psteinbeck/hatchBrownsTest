using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace hatchBrownsTest.Views
{
    public partial class GalleryView : ContentPage
    {
        public GalleryView()
        {
            InitializeComponent();
            BindingContext = Resolver.Resolve<GalleryViewModel>();
        }
    }

}
