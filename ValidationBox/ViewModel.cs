namespace ValidationBox
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public class ViewModel : INotifyPropertyChanged
    {
        private int intValue;
        public event PropertyChangedEventHandler PropertyChanged;

        public int IntValue
        {
            get { return this.intValue; }
            set
            {
                if (value == this.intValue) return;
                this.intValue = value;
                this.OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
