using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Views;
using TipCalc.Core.ViewModels;

namespace TipCalc.UI.Droid.Views
{
    [Activity(Label = "Tip Calculator", Theme = "@style/AppTheme")]
    public class TipView : MvxActivity<FirstViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);
        }
    }
}