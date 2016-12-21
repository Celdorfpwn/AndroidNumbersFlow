using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AndroidNumbersFlow
{
    public class GameButton : Button
    {
        public GameButton(Context context,int marginLeft,int marginTop,int size) : base(context)
        {
            RelativeLayout.LayoutParams @params = new RelativeLayout.LayoutParams(size, size);

            @params.LeftMargin = marginLeft;
            @params.TopMargin = marginTop;

            TextSize = (float)(size / 4);

            LayoutParameters = @params;
        }
    }
}