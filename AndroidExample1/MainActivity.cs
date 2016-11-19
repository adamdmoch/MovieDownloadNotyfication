using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Net;
using Android.Net.Wifi;

namespace AndroidApp
{
    [Activity(Label = "MovieDownloadNotification", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        //public override bool OnPrepareOptionsMenu(IMenu menu)
        //{
        //    MenuInflater.Inflate(Resource.Menu.mymenu, menu);
        //    return base.OnPrepareOptionsMenu(menu);
        //}
        //public override bool OnOptionsItemSelected(IMenuItem item)
        //{
        //    switch (item.ItemId)
        //    {
        //        case Resource.Id.new_game:
        //            //do something
        //            return true;
        //        case Resource.Id.help:
        //            //do something
        //            return true;
        //    }
        //    return base.OnOptionsItemSelected(item);
        //}
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.btnCheckWifi);
            CheckBox checkBox = FindViewById<CheckBox>(Resource.Id.chbxCheckWifi);
            checkBox.Enabled = false;

            button.Click += ((object source, EventArgs e) => {
                var connectivityManager = (WifiManager)GetSystemService(WifiService);
                
                if (!ReferenceEquals(connectivityManager, null) && connectivityManager.IsWifiEnabled)
                {
                    checkBox.Checked = true;
                    checkBox.Text = connectivityManager.ConnectionInfo.SSID;
                    button.SetBackgroundColor(Android.Graphics.Color.Green);
                    button.SetTextColor(Android.Graphics.Color.Black);
                }
                else
                {
                    checkBox.Text = "You aren't home";
                    button.SetBackgroundColor(Android.Graphics.Color.Red);
                    button.SetTextColor(Android.Graphics.Color.LightGray);
                }
               
            });
                //delegate { button.Text = string.Format("{0} clicks!", count++); };
        }
    }
}

