using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.Widget;
using System.ComponentModel;
using System.Threading;

namespace SwipeRefresh
{
	[Activity (Label = "SwipeRefresh", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		SwipeRefreshLayout mSwipeRefreshLayout;


		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			//inflates this
			SetContentView (Resource.Layout.Main);
			//calls this constructor, then substantiates this object
			mSwipeRefreshLayout = FindViewById<SwipeRefreshLayout> (Resource.Id.swipeLayout);
			mSwipeRefreshLayout.SetColorScheme (Android.Resource.Color.HoloPurple, Android.Resource.Color.HoloBlueBright, Android.Resource.Color.HoloRedDark, Android.Resource.Color.HoloRedLight);
			mSwipeRefreshLayout.Refresh += mSwipeRefreshLayout_Refresh;

		}

		void mSwipeRefreshLayout_Refresh(object sender, EventArgs e)
		{
			BackgroundWorker worker = new BackgroundWorker ();
			worker.DoWork += worker_DoWork;
			worker.RunWorkerCompleted += Worker_RunWorkerCompleted;	
			worker.RunWorkerAsync ();
		}

		void Worker_RunWorkerCompleted (object sender, RunWorkerCompletedEventArgs e)
		{
			RunOnUiThread(() => {mSwipeRefreshLayout.Refreshing = false; });
		}


		void worker_DoWork (object sender, DoWorkEventArgs e)
		{
			//will run on separate thread
			Thread.Sleep(3000);
		}

	}
}


