using Microsoft.Maui.Layouts;
using System.Net.Http.Json;

namespace StudentAffairMaui;

public class BaseSettingService<TEntity> : BaseService<TEntity>,IBaseSettingService<TEntity> where TEntity : BaseSetting
{
    public BaseSettingService(HttpClient httpClient) : base(httpClient)
    {
    }
}
