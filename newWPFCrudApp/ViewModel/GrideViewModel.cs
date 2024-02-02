using newWPFCrudApp.Commands;
using newWPFCrudApp.DataBasee;
using newWPFCrudApp.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace newWPFCrudApp.ViewModel
{
    internal class GrideViewModel : INotifyPropertyChanged
    {
        private Mydatabase db;
        private DataRowView selecteditem;
        public DataRowView SelectedItem
        {
            get
            {
                return selecteditem;
            }
            set
            {
                if (selecteditem == value) return;
                selecteditem = value;
                selectedPerson = new Person()
                {
                    UserId = selecteditem.Row[0].ToString(),
                    FirstName = selecteditem.Row[1].ToString(),
                    LastName = selecteditem.Row[2].ToString(),
                    Gender = selecteditem.Row[3].ToString(),
                    BirthDate = (DateTime)selecteditem.Row[4],
                    Title = selecteditem.Row[5].ToString()

                };
            }
        }
        private string newlname;
        private string newgender;
        private string newfname;
        private string newtitle;
        private string newuserid;
        private DateTime newdate;
        private string newinterests;
        public ObservableCollection<string> Genders { get; set; }
        public ObservableCollection<string> Titles { get; set; }

        public DataTable DataTable { get; set; }
        private Person selectedPerson;

        public event PropertyChangedEventHandler? PropertyChanged;
        public virtual void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public Person SelectedPerson
        {
            get
            {
                return selectedPerson;
            }
            set
            {
                if (selectedPerson == value) return;
                selectedPerson = value;
            }
        }

        public GrideViewModel()
        {
            DataTable = new DataTable();
            db = new Mydatabase();
            DataTable = db.GetData();
            selectedPerson = new Person();
            Genders = new ObservableCollection<string> { "Male", "Female" };
            Titles = new ObservableCollection<string> { "Mr.", "Mrs.", "Miss." };
            OnPropertyChanged("DataTable");
            
        }
        private ICommand _createPerson;
        public ICommand CreatePerson
        {
            get
            {
                if (_createPerson == null)
                {
                    _createPerson = new RelayCommand(createExecute, canCreateExecute, false);
                }
                return _createPerson;
            }
        }
        private bool canCreateExecute(object arg)
        {
            return true;
        }
        private void createExecute(object obj)
        {
            if (newuserid == null)
            {
                newuserid = selectedPerson.UserId;
            }
            if (!db.doesExixst(newuserid))
            {
                db.insertQuery(newfname, newlname, newdate.ToString("yyyy-MM-dd"), newgender, newtitle, newinterests, newuserid);
            }
            else
            {
                if (newfname == null) newfname = selectedPerson.FirstName;
                if (newlname == null) newlname = selectedPerson.LastName;
                if (newdate == new DateTime()) newdate = selectedPerson.BirthDate;
                if (newgender == null) newgender = selectedPerson.Gender;
                if (newtitle == null) newtitle = selectedPerson.Title;
                if (newinterests == null) newinterests = selectedPerson.Interest;
                newuserid = selectedPerson.UserId;
                db.updateQuery(newfname, newlname, newdate.ToString("yyyy-MM-dd"), newgender, newtitle, newinterests, newuserid, selectedPerson.UserId);
            }
            DataTable = null;
            DataTable = db.GetData();
            OnPropertyChanged("DataTable");
        }
        private ICommand celleditEndingCommand;
        public ICommand CellEditEndingCommand
        {
            get
            {
                if (celleditEndingCommand == null)
                {

                    celleditEndingCommand = new RelayCommand(celledingexecute, cancelledintexecute, false);
                }
                return celleditEndingCommand;
            }

        }
        private bool cancelledintexecute(object arg)
        {
            return true;
        }
        private void celledingexecute(object obj)
        {
            var e = (DataGridCellEditEndingEventArgs)obj;
            switch (e.Column.Header)
            {
                case "userID":
                    newuserid = ((TextBox)e.EditingElement).Text;
                    break;
                case "Firstname":
                    newfname = ((TextBox)e.EditingElement).Text;
                    break;
                case "Lastname":
                    newlname = ((TextBox)e.EditingElement).Text;
                    break;
                case "Gender":
                    newgender = ((Selector)e.EditingElement).SelectedItem.ToString();
                    break;
                case "Birthdate":
                    newdate = (DateTime)((DataRowView)((ContentPresenter)e.EditingElement).Content).Row.ItemArray[4];
                    break;
                case "Title":
                    newtitle = ((Selector)e.EditingElement).SelectedItem.ToString();
                    break;
                case "Interests":
                    newinterests = ((TextBox)e.EditingElement).Text;
                    break;
                default:
                    break;
            }

        }
        private ICommand deletePerson;
        public ICommand DeletePerson
        {
            get
            {
                if (deletePerson == null)
                {
                    deletePerson = new RelayCommand(deleteExecute, canDelete, false);
                }
                return deletePerson;
            }
        }

        private void deleteExecute(object obj)
        {
            if (selectedPerson != null)
            {
                db.deleteQuery(selectedPerson.UserId);
            }
            DataTable = null;
            DataTable = db.GetData();
            OnPropertyChanged("DataTable");
        }

        private bool canDelete(object arg)
        {
            return true;
        }

    }
}
