using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace StudentAffairMaui.ViewModels;

public partial class BaseFormsViewModel<TEntity> : ObservableObject where TEntity : Base
{
    public BaseFormsViewModel(IBaseService<TEntity> baseService) { 
    
    }
    public virtual async Task AddEntity()
    {
        if(Internet.CheckInternet())
        {
            try
            {
                await Shell.Current.DisplayAlert("Seccessed", "Record Saved", "Ok");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
            }
        }
        else
            await Shell.Current.DisplayAlert("Netowk Falid", "Please Check Your Wifi or Mobile Data.", "Ok");
        await Shell.Current.DisplayAlert("Netowk Falid", Connectivity.Current.NetworkAccess.ToString(), "Ok");
        await Cancel();
    }
    public virtual async Task Cancel()
    {
        try
        {
            await AppShell.Current.GoToAsync("..");

        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
        }


    }
}
