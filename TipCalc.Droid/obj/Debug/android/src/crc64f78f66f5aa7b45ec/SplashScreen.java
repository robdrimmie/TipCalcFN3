package crc64f78f66f5aa7b45ec;


public class SplashScreen
	extends mvvmcross.platforms.android.views.MvxSplashScreenActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("TipCalc.UI.Droid.SplashScreen, TipCalc.UI.Droid", SplashScreen.class, __md_methods);
	}


	public SplashScreen ()
	{
		super ();
		if (getClass () == SplashScreen.class)
			mono.android.TypeManager.Activate ("TipCalc.UI.Droid.SplashScreen, TipCalc.UI.Droid", "", this, new java.lang.Object[] {  });
	}


	public SplashScreen (int p0)
	{
		super (p0);
		if (getClass () == SplashScreen.class)
			mono.android.TypeManager.Activate ("TipCalc.UI.Droid.SplashScreen, TipCalc.UI.Droid", "System.Int32, mscorlib", this, new java.lang.Object[] { p0 });
	}

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
