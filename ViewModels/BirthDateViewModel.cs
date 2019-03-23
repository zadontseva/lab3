using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Zadontseva03.Annotations;
using Zadontseva03.Models;
using Zadontseva03.Tools;
using Test.Misc;

namespace Zadontseva03.ViewModels
{
    class BirthDateViewModel : INotifyPropertyChanged
    {
        private Person _person;

        private DateTime _date = System.DateTime.Today;
        private string _name;
        private string _surname;
        private string _email;

        public Person PersonInstance
        {
            get { return _person; }
            set { _person = value; OnPropertyChanged();}
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; OnPropertyChanged(); }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }
        public string Surname
        {
            get { return _surname; }
            set { _surname = value; OnPropertyChanged(); }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(); }
        }

        
        private ICommand _proceedCommand; 
        public ICommand ProceedCommand => _proceedCommand ?? (_proceedCommand = new RelayCommand<object>(o => CheckValues(), o => !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Surname) && !string.IsNullOrEmpty(Email)));



        private async void CheckValues()
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() => Thread.Sleep(500));

            try
            {
                PersonInstance = new Person(Name, Surname, Email, Date);
            }
            catch (PersonTooOldException) { return; }
            catch (PersonNotBornException) { return; }
            catch (PersonEmailException) { return; }

            if (PersonInstance.IsBirthday)
            {
                MessageBox.Show("Схоже, що сьогодні в вас День народження! Вітаємо!");
            }

            LoaderManager.Instance.HideLoader();
            MessageBox.Show("Ім'я: " + PersonInstance.Name + System.Environment.NewLine +
                            "Прізвище: " + PersonInstance.Surname + System.Environment.NewLine +
                            "Єлектронна пошта: " + PersonInstance.Email + System.Environment.NewLine +
                            "Дата народження: " + PersonInstance.BirthDate.ToLongDateString() + System.Environment.NewLine + System.Environment.NewLine +
                            (PersonInstance.IsAdult ? "Користувач є дорослим" : "Користувач не є дорослим") + System.Environment.NewLine +
                            "Сонячний знак користувача: " + PersonInstance.SunSign + System.Environment.NewLine +
                            "Знак зодіаку користувача за китайською системою: " + PersonInstance.ChineeseSign + System.Environment.NewLine +
                            (PersonInstance.IsBirthday ? "Сьогодні День народження користувача" : "Сьогодні не День народження користувача"));
        }



        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
