using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace StudentAffairMaui.ViewModels;

public partial class BaseFormsViewModel<TEntity> : ObservableObject where TEntity : Base
{
    IBaseService<TEntity> _baseService;
    public BaseFormsViewModel(IBaseService<TEntity> baseService) =>_baseService=baseService;
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
    public virtual async Task UpdateEntity(TEntity entity)
    {
        if (Internet.CheckInternet())
        {
            try
            {
                await _baseService.Update(entity);
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
