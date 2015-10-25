using System;
using System.Linq;
using System.Windows;
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

        public IReactiveCommand SaveCommand => ReactiveCommand.Create(_ =>
        {
            var newModel = new Contact(_model.Id, _editName, _editEmail);

            MainViewModel mainViewModel =
                Application.Current.MainWindow.DataContext as MainViewModel;

            foreach (ContactViewModel itemViewModel in
                from item in mainViewModel.Contacts
                where item.Model.Id == _model.Id
                select item)
            {
                itemViewModel.Model = newModel;
            }
        });
    }
}
