using newWPFCrudApp.Commands;
using newWPFCrudApp.DataBasee;
using newWPFCrudApp.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.IO.Packaging;
using System.Runtime.ExceptionServices;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Input;

namespace newWPFCrudApp.ViewModel
{
    /// <summary>
    /// ViewModel for the MainWindow.
    /// </summary>
    internal class PersonViewModel : INotifyPropertyChanged
    {
        private Person _person;

        private Person selectedPerson;
        private DataTable dataTable;
        private Mydatabase db;
        private string userId;

        public string UserId
        {
            get { return userId; }
            set
            {
                userId = value;
                OnPropertyChanged("UserId");
            }
        }
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; OnPropertyChanged("FirstName"); }
        }
        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; OnPropertyChanged("LastName"); }
        }
        private DateTime? birthDate;

        public DateTime? BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; OnPropertyChanged("BirthDate"); }
        }
        private string gender;

        public string Gender
        {
            get { return gender; }
            set { gender = value; OnPropertyChanged("Gender"); }
        }
        private string interest;

        public string Interest
        {
            get { return interest; }
            set { interest = value; OnPropertyChanged("Interest"); }
        }



        private DataRowView selectedObject;
        public DataRowView SelectedObject
        {
            get { return selectedObject; }
            set
            {
                selectedObject = value;
                selectedPerson = new Person()
                {
                    UserId = selectedObject.Row[0].ToString(),
                    FirstName = selectedObject.Row[1].ToString(),
                    LastName = selectedObject.Row[2].ToString(),
                    Gender = selectedObject.Row[3].ToString(),
                    BirthDate = (DateTime)selectedObject.Row[4],
                    Title = selectedObject.Row[5].ToString(),
                    Interest = selectedObject.Row[6].ToString()
                };
                OnPropertyChanged("SelectedPerson");
                SetTextBoxes();
            }
        }
        public DataTable DataTable
        {
            get
            { return dataTable; }
            set
            { dataTable = value; }
        }
        public Person Person
        {
            get { return _person; }
            set
            { _person = value; }
        }
        public Person SelectedPerson
        {
            get { return selectedPerson; }
            set
            {
                selectedPerson = value;
            }
        }

        /// <summary>
        /// This array's each index is bound to each successive checkbox's IsChecked Property and will get set to true after user checks it.
        /// </summary>
        private bool[] interestcheckbox = new bool[] { false, false, false };
        public bool[] InterestCheckBox
        {
            get
            { return interestcheckbox; }
        }

        /// <summary>
        /// This will make false to all the checkBox's IsChecked property, and all checkbox will get Unchecked.  
        /// </summary>
        private void UncheckAllInterest()
        {
            try
            {
                interestcheckbox = [false, false, false];
                OnPropertyChanged("InterestCheckBox");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// This method will Help to get The selected Interest,by checking which index of our interestcheckbox is set to true.
        /// </summary>
        /// <returns>
        /// A list of String that will contain selected Interests by user.
        /// </returns>
        private List<string> getSelectedInterests()
        {
            List<string> result = new List<string>();
            try
            {
                if (interestcheckbox[0])
                {
                    result.Add("Reading");
                }
                if (interestcheckbox[1])
                {
                    result.Add("Writing");
                }
                if (interestcheckbox[2])
                {
                    result.Add("Swimming");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            return result;
        }

        /// <summary>
        /// This Method will be called from  SetTextBoxes method set the checkboxes to check or uncheck by checking if users interest 
        /// string contains certain interest or not, and if does then it makes certain index true according to the Interest string.
        /// </summary>
        private void SetInterest()
        {
            try
            {
                if (SelectedPerson != null)
                {
                    if (SelectedPerson.Interest.Contains("Reading"))
                    {
                        interestcheckbox[0] = true;
                    }
                    if (selectedPerson.Interest.Contains("Writing"))
                    {
                        interestcheckbox[1] = true;
                    }
                    if (selectedPerson.Interest.Contains("Swimming"))
                    {
                        interestcheckbox[2] = true;
                    }
                }
                OnPropertyChanged("InterestCheckBox");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// This array's each index is bound to each successive Radio button's IsChecked Property and will get set to true after user checks it.
        /// </summary>
        private bool[] titleRadiobox = new bool[] { false, false, false };
        public bool[] TitleRadioBox
        {
            get { return titleRadiobox; }

        }

        /// <summary>
        /// This method will Help to get The selected Titles,by checking which index of our titleRadiobox is set to true.
        /// </summary>
        /// <returns>
        /// A String that will contain selected Title by user.
        /// </returns>
        private String SelectTitile()
        {
            try
            {
                int ind = Array.IndexOf(titleRadiobox, true);
                if (ind == -1)
                {
                    return String.Empty;
                }
                else if (ind == 0)
                {
                    return "Mr.";
                }
                else if (ind == 1)
                {
                    return "Mrs.";
                }
                else
                {
                    return "Miss.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }

        /// <summary>
        /// This Method will be called from the SetTextBoxes method, to set the Radio buttons to check or uncheck by checking users title string.
        /// </summary>
        private void SetTitle()
        {
            try
            {
                if (SelectedPerson != null)
                {
                    if (selectedPerson.Title.Contains("Mr."))
                    {
                        titleRadiobox[0] = true;
                    }
                    else if (selectedPerson.Title.Contains("Mrs."))
                    {
                        titleRadiobox[1] = true;
                    }
                    else
                    {
                        titleRadiobox[2] = true;
                    }
                }
                OnPropertyChanged("TitleRadioBox");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// This will make false to all the RadioButton's IsChecked property, and all Radio buttons will get Unchecked
        /// </summary>
        private void UncheckAllTitles()
        {
            try
            {
                titleRadiobox = new bool[] { false, false, false };
                OnPropertyChanged("TitleRadioBox");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// This Method will clear all the text boxes after user clicks the submit button or delete buttons
        /// </summary>
        private void ClearTextBoxes()
        {
            try
            {
                FirstName = string.Empty;
                LastName = string.Empty;
                Gender = string.Empty;
                BirthDate = DateTime.Now;
                UserId = string.Empty;
                UncheckAllTitles();
                UncheckAllInterest();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// This method will be called when user clicks any entry from the datagrid and the check boxes will set according to the values of that entry 
        /// </summary>
        public void SetTextBoxes()
        {
            try
            {
                FirstName = SelectedPerson.FirstName;
                LastName = SelectedPerson.LastName;
                Gender = SelectedPerson.Gender;
                BirthDate = SelectedPerson.BirthDate;
                UserId = SelectedPerson.UserId;
                SetInterest();
                SetTitle();
                OnPropertyChanged("Firstname");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// ViewModel Class
        /// </summary>
        public PersonViewModel()
        {
            Person = new Person();
            DataTable = new DataTable();
            db = new Mydatabase();
            DataTable = db.GetData();
            DataTable2 = db.GetData();
            selectedPersongridtwo = new Person();
            Genders = new ObservableCollection<string> { "Male", "Female" };
            Titles = new ObservableCollection<string> { "Mr.", "Mrs.", "Miss." };
            OnPropertyChanged("DataTable");
            OnPropertyChanged("DataTable2");
        }

        /// <summary>
        /// this command is to submit or update the users entry to database 
        /// </summary>
        private ICommand _submitCommand;
        public ICommand SubmitCommamd
        {
            get
            {
                if (_submitCommand == null)
                {
                    _submitCommand = new RelayCommand(submitExecute, CanSubmitExecute, false);
                };
                return _submitCommand;
            }
        }

        /// <summary>
        /// this method will check if user has selected any entry from the datagrid or user is trying to create a new item. after user is done with any operation
        /// it will refresh the datatable and then clear all the text boxes.
        /// </summary>
        private void submitExecute(object parameter)
        {
            try
            {
                if (SelectedPerson == null)
                {
                    db.insertQuery(FirstName, LastName,BirthDate.Value.ToString("yyyy-MM-dd"), Gender, SelectTitile(), String.Join(",", getSelectedInterests()), UserId);
                }
                else
                {
                    db.updateQuery(FirstName, LastName,BirthDate.Value.ToString("yyyy-MM-dd"),Gender, SelectTitile(), String.Join(",", getSelectedInterests()), UserId, selectedPerson.UserId);
                    selectedPerson = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DataTable = null;
                DataTable2 = null;
                DataTable2 = db.GetData();
                DataTable = db.GetData();
                OnPropertyChanged("DataTable");
                OnPropertyChanged("DataTable2");
                ClearTextBoxes();
            }
        }

        /// <summary>
        /// returns boolean value after checking if user has entered the value in firstname,lastname and userid textboxes,
        /// and enable or disable submit button according to it.
        /// </summary>
        private bool CanSubmitExecute(object arg)
        {
            if (String.IsNullOrEmpty(FirstName) || String.IsNullOrEmpty(LastName) || String.IsNullOrEmpty(UserId))
            {
                return false;
            }
            else return true;
        }

        /// <summary>
        /// this command is to delete the entry from the database.
        /// </summary>
        private ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand(deleteExecute, canDelete, false);
                }
                return _deleteCommand;
            }

        }

        /// <summary>
        /// this method returns boolean values after checking is user has selected any entry from the data table and disables or enables according to that.
        /// </summary>
        private bool canDelete(object parameter)
        {
            if (selectedPerson == null)
            {
                return false;
            }
            else return true;
        }

        /// <summary>
        /// this method will perform the delete operation , refresh the datagrid and clear textboxes.
        /// </summary>
        private void deleteExecute(object obj)
        {
            try
            {
                MessageBoxResult mBoxresult = MessageBox.Show("Are You Sure You Want to Delete this Item", "Delete Alert", MessageBoxButton.YesNo);
                if (mBoxresult == MessageBoxResult.Yes)
                {
                    db.deleteQuery(SelectedPerson.UserId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                selectedPerson = null;
                DataTable = null;
                DataTable = db.GetData();
                DataTable2 = null;
                DataTable2 = db.GetData();
                ClearTextBoxes();
                OnPropertyChanged("DataTable2");
                OnPropertyChanged("DataTable");
            }

        }



        public event PropertyChangedEventHandler? PropertyChanged;
        public virtual void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private DataRowView selecteditem;
        private DataTable datatable2;
        public DataTable DataTable2
        {
            get { return datatable2; }
            set { datatable2 = value; }
        }
        public DataRowView SelectedItem
        {
            get
            {
                return selecteditem;
            }
            set
            {
                if (value == null) return;
                selecteditem = value;
                if (selecteditem.Row[4]!=DBNull.Value)
                {
                    selectedPersongridtwo = new Person()
                    {
                        UserId = selecteditem.Row[0].ToString(),
                        FirstName = selecteditem.Row[1].ToString(),
                        LastName = selecteditem.Row[2].ToString(),
                        Gender = selecteditem.Row[3].ToString(),
                        BirthDate = (DateTime)selecteditem.Row[4],
                        Title = selecteditem.Row[5].ToString(),
                        Interest = selecteditem.Row[6].ToString()
                    };
                }
                else
                {
                    selectedPersongridtwo = new Person() { };
                }
                
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
        private Person selectedPersongridtwo;
        public Person SelectedPersontwo
        {
            get
            {
                return selectedPersongridtwo;
            }
            set
            {
                if (selectedPersongridtwo == value) return;
                selectedPersongridtwo = value;
            }
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
            if (newuserid == null && selectedPersongridtwo!=null)
            {
                newuserid = selectedPersongridtwo.UserId;
            }
            if (!db.doesExixst(newuserid))
            {
                db.insertQuery(newfname, newlname, newdate.ToString("yyyy-MM-dd"), newgender, newtitle, newinterests, newuserid);
            }
            else
            {
                if (selectedPersongridtwo != null)
                {
                    if (newfname == null) newfname = selectedPersongridtwo.FirstName;
                    if (newlname == null) newlname = selectedPersongridtwo.LastName;
                    if (newdate == new DateTime()) newdate = selectedPersongridtwo.BirthDate;
                    if (newgender == null) newgender = selectedPersongridtwo.Gender;
                    if (newtitle == null) newtitle = selectedPersongridtwo.Title;
                    if (newinterests == null) newinterests = selectedPersongridtwo.Interest;
                    if (newuserid == null) newuserid = selectedPersongridtwo.UserId;
                }
                db.updateQuery(newfname, newlname, newdate.ToString("yyyy-MM-dd"), newgender, newtitle, newinterests, newuserid, selectedPersongridtwo.UserId);
            }
            newgender = null;
            newfname = null;
            newlname = null;
            newdate = new System.DateTime();
            newinterests = null;
            newtitle = null;
            newuserid = null;
            DataTable = null;
            DataTable = db.GetData();
            DataTable2 = null;
            DataTable2 = db.GetData();
            OnPropertyChanged("DataTable2");
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
                case "UserID":
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
                    deletePerson = new RelayCommand(deleteExecutegridtwo, canDeletegridtwo, false);
                }
                return deletePerson;
            }
        }

        private void deleteExecutegridtwo(object obj)
        {
            if (selectedPersongridtwo != null)
            {
                db.deleteQuery(selectedPersongridtwo.UserId);

            }
            selectedPersongridtwo = null;
            DataTable = null;
            DataTable = db.GetData();
            DataTable2 = null;
            DataTable2 = db.GetData();
            OnPropertyChanged("DataTable");
            OnPropertyChanged("DataTable2");
        }

        private bool canDeletegridtwo(object arg)
        {
            return true;
        }

    }
}


