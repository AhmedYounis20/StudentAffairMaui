using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace StudentAffairMaui.ViewModels;

public partial class BaseRootsViewModel<TEntity,TEntityForm>: ObservableObject where TEntity : Base
{
    public ObservableCollection<TEntity> Entities { get; set; } = new ObservableCollection<TEntity>();
    private IBaseService<TEntity> _baseService;
    public BaseRootsViewModel(IBaseService<TEntity> baseService)=> _baseService = baseService;

    public virtual  async void GetEntities()
    {
        List<TEntity> entities = await _baseService.Get();
        if (entities?.Count > 0)
        {
            Entities.Clear();
            foreach (TEntity entity in entities)
                Entities.Add(entity);
        }
    }
    public virtual async Task AddEntity()
    {
        try
        {
            await AppShell.Current.GoToAsync(typeof(TEntityForm).Name);
        }
        catch(Exception Ex)
        {
        await Shell.Current.DisplayAlert($"{typeof(TEntityForm).Name}", Ex.Message, "Ok"); 
        }
    }

     
}
