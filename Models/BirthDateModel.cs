using Zadontseva03.Annotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Zadontseva03.Models
{
    class BirthDateModel : INotifyPropertyChanged
    {


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
