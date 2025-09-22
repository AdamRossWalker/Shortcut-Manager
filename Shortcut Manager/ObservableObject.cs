using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ShortcutManager;

public abstract class ObservableObject : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected bool SetField<T>(
        ref T field,
        T newValue, 
        [CallerMemberName] string propertyName = null!)
    {
        if (EqualityComparer<T>.Default.Equals(field, newValue))
            return false;

        field = newValue;
        RaisePropertyChanged(propertyName);
        return true;
    }

    protected static bool SetFieldWithoutNotification<T>(
        ref T field,
        T newValue)
    {
        if (EqualityComparer<T>.Default.Equals(field, newValue))
            return false;

        field = newValue;
        return true;
    }

    protected void RaisePropertyChanged([CallerMemberName] string propertyName = null!) =>
        PropertyChanged?.Invoke(this, new(propertyName));
}
