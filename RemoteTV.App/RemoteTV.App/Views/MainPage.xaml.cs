using RemoteTV.APIClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RemoteTV.App.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Web_Navigating(object sender, WebNavigatingEventArgs e)
        {
            txtUrl.Text = e.Url;
            await DataClient.Instance.Update(e.Url);
        }
        
        private void Button_Clicked(object sender, EventArgs e)
        {
            web.Source = txtUrl.Text;
        }
    }
}
