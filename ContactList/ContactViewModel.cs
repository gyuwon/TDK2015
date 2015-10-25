using System;
using Flip;
using Flip.ViewModels;

namespace ContactList
{
    public class ContactViewModel : ObservableObject
    {
        private Contact _model;

        public ContactViewModel(Contact model)
        {
            _model = model;
        }

        public Contact Model
        {
            get { return _model; }
            set { SetValue(ref _model, value); }
        }
    }
}
