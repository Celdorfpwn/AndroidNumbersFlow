using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;

namespace AndroidNumbersFlow
{
    [Activity(Label = "AndroidNumbersFlow", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        private NumbersFactory _numbersFactory { get; set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            _numbersFactory = new NumbersFactory();
            CreateGameButtons();
        }

        private void CreateGameButtons()
        {
            var layout = FindViewById<RelativeLayout>(Resource.Id.mainLayout);

            var metrics = new DisplayMetrics();

            WindowManager.DefaultDisplay.GetMetrics(metrics);

            var size = metrics.WidthPixels / 5;

            var whiteSpace = size / 5;

            var leftMargin = whiteSpace;
            var topMargin = (metrics.HeightPixels - (size * 4 + whiteSpace * 3)) / 2;

            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    var button = new GameButton(this, leftMargin, topMargin, size);

                    layout.AddView(button);
                    button.Text = _numbersFactory.NextNumber.ToString();

                    leftMargin += (size + whiteSpace);
                }

                leftMargin = whiteSpace;
                topMargin += (size + whiteSpace);
            }

        
        }
    }
}

