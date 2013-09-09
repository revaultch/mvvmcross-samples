using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;

namespace DrawableStates
{
    [Activity (Label = "DrawableStates", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            LinearLayoutWithStates layout = FindViewById<LinearLayoutWithStates>(Resource.Id.layout);
            Button completedButton = FindViewById<Button>(Resource.Id.completedButton);
            Button validButton = FindViewById<Button>(Resource.Id.validButton);
            Button required = FindViewById<Button>(Resource.Id.requiredButton);
			
            completedButton.Click += (sender, e) => layout.Completed = !layout.Completed;
            validButton.Click += (sender, e) => layout.Valid = !layout.Valid;
            required.Click += (sender, e) => layout.Required = !layout.Required;
        }
    }

    public class LinearLayoutWithStates : LinearLayout
    {
        private bool _completed;
        public bool Completed
        {
            get {return _completed;}
            set { _completed = value; RefreshDrawableState();}
        }

        private bool _required;
        public bool Required
        {
            get {return _required;}
            set { _required = value; RefreshDrawableState();}
        }

        private bool _valid;
        public bool Valid
        {
            get {return _valid;}
            set { _valid = value; RefreshDrawableState();}
        }

        protected LinearLayoutWithStates(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
         
        }

        public LinearLayoutWithStates(Context context, IAttributeSet attrs) : base (context, attrs)
        {
         
        }

        /// <summary>
        /// Handles the create drawable state event by adding in additional states as needed.
        /// </summary>
        /// <param name="extraSpace">Extra space.</param>
        protected override int[] OnCreateDrawableState(int extraSpace)
        {
            int[] drawableState = base.OnCreateDrawableState(extraSpace + 3);

            if (Completed)
            {
                int[] completedState = new int[] { Resource.Attribute.completed };
                MergeDrawableStates(drawableState, completedState);
            }

            if (Required)
            {
                int[] requiredState = new int[] { Resource.Attribute.required };
                MergeDrawableStates(drawableState, requiredState);
            }

            if (Valid)
            {
                int[] validState = new int[] { Resource.Attribute.valid };
                MergeDrawableStates(drawableState, validState);
            }

            Android.Util.Log.Debug("ROW_VIEW", "OnCreateDrawableState Called");

            return drawableState;
        }
    }
}


