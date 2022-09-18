using Microsoft.Maui.Layouts;
using System.Net.Http.Json;

namespace StudentAffairMaui;

public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : Base
{

    HttpClient _httpClient { get; set; }
    public BaseService(HttpClient httpClient)
    {
        _httpClient = httpClient;            
    }

    public virtual async Task<TEntity> Create(TEntity entity)
    {
        try
        {
        await _httpClient.PostAsJsonAsync<TEntity>($"api/{typeof(TEntity).Name}", entity);
        }
        catch(Exception ex)
        {
            await Shell.Current.DisplayAlert("Error",ex.Message,"OK");
            entity = null;
        }
        return entity;
    }

    public virtual async Task<TEntity> Delete(TEntity entity)
    {
        try
        {
            await _httpClient.DeleteAsync($"api/{typeof(TEntity).Name}/{entity.Id}");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            entity = null;
        }
        return entity;
    }

    public virtual async Task<List<TEntity>> Get()
    {
        List<TEntity> entities = new List<TEntity>();
        try
        {
            entities = await _httpClient.GetFromJsonAsync<List<TEntity>>($"api/{typeof(TEntity).Name}");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
        }
            return entities;
    }

    public virtual async Task<TEntity> Get(int id)
    {
        TEntity entity = null;
        try
        {
            entity = await _httpClient.GetFromJsonAsync<TEntity>($"api/{typeof(TEntity).Name}/{id}");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            entity = null;
        }
        return entity;
    }

    public virtual async Task<TEntity> Update(TEntity entity)
    {
        try
        {
             await _httpClient.PutAsJsonAsync<TEntity>($"api/{typeof(TEntity).Name}/", entity);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            entity = null;
        }
        return entity;
    }
}
