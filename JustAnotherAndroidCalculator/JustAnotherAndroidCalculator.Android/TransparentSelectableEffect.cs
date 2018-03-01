using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using JustAnotherAndroidCalculator;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("MobileClient")]
[assembly: ExportEffect(typeof(JustAnotherAndroidCalculator.Droid.TransparentSelectableEffect), nameof(TransparentSelectableEffect))]
namespace JustAnotherAndroidCalculator.Droid
{
    public class TransparentSelectableEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                TypedValue value = new TypedValue();
                Android.App.Application.Context.Theme.ResolveAttribute(Android.Resource.Attribute.SelectableItemBackground, value, true);
                Control.SetBackgroundResource(value.ResourceId);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

        protected override void OnDetached()
        {

        }
    }
}