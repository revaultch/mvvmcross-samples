using Cirrious.MvvmCross.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace CustomChoiceList.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
    
        private List<string> _items = Cheeses.CHEESES.ToList();
        public List<string> Items
        { 
            get { return _items; }
        }
    }
}
