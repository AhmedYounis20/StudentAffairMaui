using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace StudentAffairMaui.ViewModels;

public partial class BaseSettingsRootViewModel<TEntity,TEntityForm> : BaseRootsViewModel<TEntity, TEntityForm> where TEntity:BaseSetting
{
    private readonly IBaseSettingService<TEntity> _baseSettingService;
    public BaseSettingsRootViewModel(IBaseSettingService<TEntity> baseSettingService) : base(baseSettingService) => _baseSettingService= baseSettingService;

    public async Task DisplayOptions(TEntity entity)
    {
        var response = await AppShell.Current.DisplayActionSheet("Select Action", "Cancel", null, "Details", "Update", "Delete");
        if (response == "Update")
        {
            var navParam = new Dictionary<string, Object>();
            navParam.Add("EntityDetails", entity);
            navParam.Add("Operation", "Update");
            await AppShell.Current.GoToAsync(typeof(TEntityForm).Name,navParam);
        }
        else if (response == "Delete")
        {
            if (await Shell.Current.DisplayAlert("Delete", $"Are you Sure You want to delete {entity.Name}", "Sure", "Canecel"))
            {
                try
                {
                await _baseSettingService.Delete(entity);
                Entities.Remove(entity);
                }
                catch(Exception ex)
                {
                    await Shell.Current.DisplayAlert("error", ex.Message, "ok");
                }
            }
        }
        else if (response == "Details")
        {
            var navParam = new Dictionary<string, Object>();
            navParam.Add("EntityDetails", entity);
            navParam.Add("Operation", "Details");
            await AppShell.Current.GoToAsync(typeof(TEntityForm).Name, navParam);

        }
    }

}
