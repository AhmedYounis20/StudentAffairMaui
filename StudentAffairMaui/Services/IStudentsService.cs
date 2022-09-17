namespace StudentAffairMaui;

public  interface IStudentsService
{
    Task<List<Student>> Get();
    Task<Student> Get(int id);
    Task<Student> Create(Student student);
    Task<Student> Update(Student student);
    Task<Student> Delete(Student student);
}
