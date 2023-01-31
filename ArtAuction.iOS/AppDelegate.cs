    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Maui;
    using Foundation;
    using UIKit;
    using ArtAuction;
    namespace ArtAuction.iOS
    {
        [Register("AppDelegate")]
        public partial class AppDelegate : MauiUIApplicationDelegate
        {
            protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
        }
    }