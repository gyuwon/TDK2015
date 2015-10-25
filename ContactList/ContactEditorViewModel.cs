using System;
using Flip;

namespace ContactList
{
    public class ContactEditorViewModel : ObservableObject
    {
        private Contact _model;
        private string _editName;
        private string _editEmail;

        public ContactEditorViewModel(Contact model)
        {
            _model = model;
            _editName = model.Name;
            _editEmail = model.Email;
        }

        public Contact Model
        {
            get { return _model; }
            set { SetValue(ref _model, value); }
        }

        public string EditName
        {
            get { return _editName; }
            set { SetValue(ref _editName, value); }
        }

        public string EditEmail
        {
            get { return _editEmail; }
            set { SetValue(ref _editEmail, value); }
        }

        public IReactiveCommand SaveCommand => null;
    }
}
