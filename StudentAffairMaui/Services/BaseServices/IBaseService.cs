namespace StudentAffairMaui;

public  interface IBaseService<TEntity> where TEntity : Base
{
    Task<List<TEntity>> Get();
    Task<TEntity> Get(int id);
    Task<TEntity> Create(TEntity entity);
    Task<TEntity> Update(TEntity entity);
    Task<TEntity> Delete(TEntity entity);
}
