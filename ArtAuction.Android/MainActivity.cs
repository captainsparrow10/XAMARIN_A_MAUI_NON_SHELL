﻿  using System;
  using Microsoft.Maui;
  using Android.App;
  using Android.Content.PM;
  using Android.Runtime;
  using Android.OS;
  namespace ArtAuction.Droid
  {
      [Activity(Label = "ArtAuction", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
      public class MainActivity : MauiAppCompatActivity
    {
      protected override void OnCreate(Bundle savedInstanceState)
      {
        base.OnCreate(savedInstanceState);
      }
    }
  }