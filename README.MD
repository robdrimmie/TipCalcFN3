Hi all, I'm really struggling with navigation. I've started with the TipCalc source from the Mvvmcross-samples repo. At this time I am only working with a Core and Droid project, so I deleted all the other platforms then build and run it.

It builds runs fine, behaves exactly as expected. I then moved on to adding logic described in the Extra - Navigation section of the docs (https://www.mvvmcross.com/documentation/tutorials/tipcalc/the-tip-calc-navigation). The splashscreen is already implemented in the repo's code, so I didn't have to do any work in that section. 

I wanted to keep the logic in the TipCalc portion, so instead of doing the navigation example button in `FirstViewModel` and associated view and layout, I added it button to the TipView.axml layout file:

```
    <Button
    	android:layout_width="match_parent"
    	android:layout_height="wrap_content"
    	android:text="Go"
    	android:textSize="40dp"
    	local:MvxBind="Click NavigateCommand"/>
```

And added the `NavigateCommand` to the TipViewmodel such that the the start of the class itself looks like:

```csharp
		// ... the early part of the file only has new using statements for nav service and commands
        private readonly ICalculationService _calculationService;
        private readonly IMvxNavigationService _navigationService;

        public TipViewModel(
            ICalculationService calculationService,
            IMvxNavigationService mvxNavigationService)
        {
            _calculationService = calculationService;
            _navigationService = mvxNavigationService;

            //NavigateCommand = new MvxAsyncCommand(() => _navigationService.Navigate<SecondViewModel>());
        }

        public IMvxAsyncCommand NavigateCommand { get; private set; }

        public override async Task Initialize()
        {
        // ... rest of file unchanged from original
```

I added a `FirstViewModel` class to the Core project, very simplified from the samples (it's basically acting as `SecondViewModel`). At this point I'm just trying to get the view to render and not worrying about the tallying of navigation attempts and such from the other documentation. 

```
using MvvmCross.ViewModels;

namespace TipCalc.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
    }
}
```

To TipCalc.Droid I added a `FirstView.axml` layout, straight from the tutorial (I did remove the `local` namespace since it isn't used for this textview):

```
<?xml version="1.0" encoding="utf-8"?>
<LinearLayout
	xmlns:android="http://schemas.android.com/apk/res/android"
	android:layout_width="match_parent"
	android:layout_height="match_parent">
	<TextView
		android:layout_width="match_parent"
		android:layout_height="wrap_content"
		android:text="This is the Second View"
		android:textSize="40dp"/>
</LinearLayout>
```

And then I added `FirstView.cs` into the Views folder, which is a direct copy/paste of `TipView.cs`:

```
using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Views;
using TipCalc.Core.ViewModels;

namespace TipCalc.UI.Droid.Views
{
    [Activity(Label = "Tip Calculator", Theme = "@style/AppTheme")]
    public class TipView : MvxActivity<TipViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.TipView);
        }
    }
}
```

When I build and run the application now, I get an exception with this full trace. Somehow I've broken the existing relationship of TipView in the Droid project and TipViewModel in the Core project, and I am just unable to figure out how I broke it and how to unbreak it. 

```
System.Collections.Generic.KeyNotFoundException: Could not find view for TipCalc.Core.ViewModels.TipViewModel
  at MvvmCross.Views.MvxViewsContainer.GetViewType (System.Type viewModelType) [0x00076] in /_/MvvmCross/Views/MvxViewsContainer.cs:69
  at MvvmCross.Platforms.Android.Presenters.MvxAndroidViewPresenter.GetPresentationAttribute (MvvmCross.ViewModels.MvxViewModelRequest request) [0x00000] in /_/MvvmCross/Platforms/Android/Presenters/MvxAndroidViewPresenter.cs:124
  at MvvmCross.Presenters.MvxAttributeViewPresenter.GetPresentationAttributeAction (MvvmCross.ViewModels.MvxViewModelRequest request, MvvmCross.Presenters.Attributes.MvxBasePresentationAttribute& attribute) [0x00000] in /_/MvvmCross/Presenters/MvxAttributeViewPresenter.cs:134
  at MvvmCross.Presenters.MvxAttributeViewPresenter.Show (MvvmCross.ViewModels.MvxViewModelRequest request) [0x00000] in /_/MvvmCross/Presenters/MvxAttributeViewPresenter.cs:175
  at MvvmCross.Platforms.Android.Views.MvxAndroidViewDispatcher+<>c__DisplayClass2_0.<ShowViewModel>b__0 () [0x00000] in /_/MvvmCross/Platforms/Android/Views/MvxAndroidViewDispatcher.cs:25
  at MvvmCross.Base.MvxMainThreadAsyncDispatcher+<>c__DisplayClass1_0.<ExecuteOnMainThreadAsync>b__0 () [0x00011] in /_/MvvmCross/Base/MvxMainThreadAsyncDispatcher.cs:27
  at System.Runtime.CompilerServices.AsyncMethodBuilderCore+<>c.<ThrowAsync>b__7_0 (System.Object state) [0x00000] in /Users/builder/jenkins/workspace/archive-mono/2020-02/android/release/mcs/class/referencesource/mscorlib/system/runtime/compilerservices/AsyncMethodBuilder.cs:1021
  at Android.App.SyncContext+<>c__DisplayClass2_0.<Post>b__0 () [0x00000] in <a54fd02a94254b8f91efc9ea3cec736c>:0
  at Java.Lang.Thread+RunnableImplementor.Run () [0x00008] in <a54fd02a94254b8f91efc9ea3cec736c>:0
  at Java.Lang.IRunnableInvoker.n_Run (System.IntPtr jnienv, System.IntPtr native__this) [0x00008] in <a54fd02a94254b8f91efc9ea3cec736c>:0
  at at (wrapper dynamic-method) Android.Runtime.DynamicMethodNameCounter.24(intptr,intptr)
```

There's a repo with the Solution located at: https://github.com/robdrimmie/TipCalcFN3