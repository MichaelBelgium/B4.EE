﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace B4.EE.MV.Droid
{

    [Activity(Label = "Weather", Icon = "@drawable/icon", Theme = "@style/MainTheme.Splash", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SplashActivity : Android.Support.V7.App.AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //simulate loading time
            //Task.Delay(8000).Wait();
            //launch the MainActivity screen when this activity ends
            StartActivity(new Intent(this, typeof(MainActivity)));
        }
    }
}