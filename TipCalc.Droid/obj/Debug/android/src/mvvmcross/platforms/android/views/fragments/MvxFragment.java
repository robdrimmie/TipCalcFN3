package mvvmcross.platforms.android.views.fragments;


public class MvxFragment
	extends mvvmcross.platforms.android.views.fragments.eventsource.MvxEventSourceFragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onDestroy:()V:GetOnDestroyHandler\n" +
			"n_onStart:()V:GetOnStartHandler\n" +
			"n_onResume:()V:GetOnResumeHandler\n" +
			"n_onPause:()V:GetOnPauseHandler\n" +
			"n_onStop:()V:GetOnStopHandler\n" +
			"";
		mono.android.Runtime.register ("MvvmCross.Platforms.Android.Views.Fragments.MvxFragment, MvvmCross", MvxFragment.class, __md_methods);
	}


	public MvxFragment ()
	{
		super ();
		if (getClass () == MvxFragment.class)
			mono.android.TypeManager.Activate ("MvvmCross.Platforms.Android.Views.Fragments.MvxFragment, MvvmCross", "", this, new java.lang.Object[] {  });
	}


	public MvxFragment (int p0)
	{
		super (p0);
		if (getClass () == MvxFragment.class)
			mono.android.TypeManager.Activate ("MvvmCross.Platforms.Android.Views.Fragments.MvxFragment, MvvmCross", "System.Int32, mscorlib", this, new java.lang.Object[] { p0 });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onDestroy ()
	{
		n_onDestroy ();
	}

	private native void n_onDestroy ();


	public void onStart ()
	{
		n_onStart ();
	}

	private native void n_onStart ();


	public void onResume ()
	{
		n_onResume ();
	}

	private native void n_onResume ();


	public void onPause ()
	{
		n_onPause ();
	}

	private native void n_onPause ();


	public void onStop ()
	{
		n_onStop ();
	}

	private native void n_onStop ();

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
