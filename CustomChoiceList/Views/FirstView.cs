using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;
using Android.Widget;
using Android.Content;
using Android.Views;
using Cirrious.MvvmCross.Binding.Droid.Views;
using Android.Util;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using CustomChoiceList.ViewModels;

namespace CustomChoiceList.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class FirstView : MvxActivity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            var list = FindViewById(Resource.Id.list) as MvxListView;
            list.Adapter = new MyMvxAdapter(this, (IMvxAndroidBindingContext)BindingContext);
        }
    }

    class MyMvxListItemView : MvxListItemView, ICheckable
    {
        
        static readonly int[] CHECKED_STATE_SET = {Android.Resource.Attribute.StateChecked};
        private bool mChecked = false;

        public MyMvxListItemView(Context context,
                               IMvxLayoutInflater layoutInflater,
                               object dataContext,
                               int templateId)
            : base(context, layoutInflater, dataContext, templateId)
        {         
        }

        public bool Checked {
            get {
                return mChecked;
            } set {
                if (value != mChecked) {
                    mChecked = value;
                    RefreshDrawableState ();
                }
            }
        }

        public void Toggle ()
        {
            Checked = !mChecked;
        }

        protected override int[] OnCreateDrawableState (int extraSpace)
        {
            int[] drawableState = base.OnCreateDrawableState (extraSpace + 1);

            if (Checked)
                MergeDrawableStates (drawableState, CHECKED_STATE_SET);

            return drawableState;
        }
    }

    class MyMvxAdapter : MvxAdapter {
        private readonly Context _context;
        private readonly IMvxAndroidBindingContext _bindingContext;

        public MyMvxAdapter(Context c) :this(c, MvxAndroidBindingContextHelpers.Current())
        {
        }
        public MyMvxAdapter(Context context, IMvxAndroidBindingContext bindingContext) :base(context, bindingContext)
        {
            _context = context;
            _bindingContext = bindingContext;
        }
        protected override MvxListItemView CreateBindableView(object dataContext, int templateId)
        {
            return new MyMvxListItemView(_context, _bindingContext.LayoutInflater, dataContext, templateId);
        }
    }

}