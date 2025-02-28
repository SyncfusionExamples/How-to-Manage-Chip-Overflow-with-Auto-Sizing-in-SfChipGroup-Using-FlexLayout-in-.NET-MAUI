using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ChipMaui
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }
    }

    // view
    public class Person
    {
        public string? Name
        {
            get;
            set;
        }
    }

    //View model class for chips
    public class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Person> employees;
        private ObservableCollection<Person> selectedFilterItems;

        public ICommand AddFilterItemsCommand { get; private set; }

        public ObservableCollection<Person> Employees
        {
            get { return employees; }
            set { Employees = value; OnPropertyChanged("Employees"); }
        }

        public ObservableCollection<Person> SelectedFilterItems
        {
            get { return selectedFilterItems; }
            set { selectedFilterItems = value; OnPropertyChanged("Employees"); }
        }

        public ViewModel()
        {
            employees = new ObservableCollection<Person>();
            employees.Add(new Person() { Name = "Johnathan Alexander" });
            employees.Add(new Person() { Name = "Jameson William" });
            employees.Add(new Person() { Name = "Linda-Marie Johnson" });
            employees.Add(new Person() { Name = "Rosemary Thompson" });
            employees.Add(new Person() { Name = "Jameson Michael" });
            employees.Add(new Person() { Name = "Jameson Lee" });
            employees.Add(new Person() { Name = "Jameson Carter" });
            employees.Add(new Person() { Name = "Jameson Thomas" });
            employees.Add(new Person() { Name = "Markus Theodore" });
            employees.Add(new Person() { Name = "Elizabeth Grace" });



            // Add SelectedItem
            selectedFilterItems = new ObservableCollection<Person>();
            selectedFilterItems.Add(employees[0]);
            selectedFilterItems.Add(employees[1]);

            // Icommand to Update SelectedItems using Button Click
            AddFilterItemsCommand = new Command(AddFilterItems);

        }

        private void AddFilterItems()
        {
            //Update SelectedItems
            SelectedFilterItems.Clear();
            SelectedFilterItems.Add(employees[3]);
            SelectedFilterItems.Add(employees[4]);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }



}
