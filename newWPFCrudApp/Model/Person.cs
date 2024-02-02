using System.ComponentModel;

namespace newWPFCrudApp.Model
{
    public class Person : INotifyPropertyChanged
    {
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged(nameof(FirstName));

                }
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged(nameof(LastName));

                }
            }
        }

        private string userId;
        public string UserId
        {
            get
            {
                return userId;
            }
            set
            {
                userId = value;
                OnPropertyChanged(nameof(UserId));

            }
        }
        private DateTime birthDate;

        public DateTime BirthDate
        {
            get
            {
                return birthDate;
            }
            set {
                if (value != birthDate)
                {
                    birthDate = value;
                    OnPropertyChanged(nameof(BirthDate));
                }
                else birthDate = DateTime.Now;
            }
        }


        private string gender;
        public string Gender
        {
            get { return gender; }
            set { gender = value;
            OnPropertyChanged(nameof (Gender));
            }
        }

        private string title;
        
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged(nameof (Title));
            }
        }
        private string interest;
        public string Interest
        {
            get
            {
                return interest;
            }
            set
            {
                interest = value;
                OnPropertyChanged(nameof (Interest));
            }
        }

      
        public event PropertyChangedEventHandler PropertyChanged;

        private  void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
   
}
