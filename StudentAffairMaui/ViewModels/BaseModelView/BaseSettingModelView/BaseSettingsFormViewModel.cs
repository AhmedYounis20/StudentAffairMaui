using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace StudentAffairMaui.ViewModels;

public partial class BaseSettingsFormViewModel<TEntity> : BaseFormsViewModel<TEntity> where TEntity : BaseSetting
{
    private readonly IBaseSettingService<TEntity> _baseSettingService;

 
    public BaseSettingsFormViewModel(IBaseSettingService<TEntity> baseSettingService) :base(baseSettingService) => _baseSettingService = baseSettingService;

    
}
