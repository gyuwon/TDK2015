using System;
using Flip;
using Flip.ViewModels;

namespace ContactList
{
    public class ContactEditorViewModel : ReactiveViewModel<Contact, int>
    {
        private string _editName;
        private string _editEmail;

        public ContactEditorViewModel(Contact user)
            : base(user)
        {
            EditName = Model.Name;
            EditEmail = Model.Email;
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

        public IReactiveCommand SaveCommand => ReactiveCommand.Create(_ =>
            Connection.Emit(new Contact(ModelId, EditName, EditEmail)));
    }
}
