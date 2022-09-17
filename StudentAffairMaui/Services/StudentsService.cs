using Microsoft.Maui.Layouts;
using System.Net.Http.Json;

namespace StudentAffairMaui;

public class StudentsService : IStudentsService
{

    HttpClient _httpClient;
    public StudentsService(HttpClient httpClient)=>_httpClient = httpClient;

    public async Task<Student> Create(Student student)
    {
        try
        {
        await _httpClient.PostAsJsonAsync<Student>("/api/student",student);
        }
        catch(Exception ex)
        {
            await Shell.Current.DisplayAlert("Error",ex.Message,"OK");
            student = null;
        }
        return student;
    }

    public async Task<Student> Delete(Student student)
    {
        try
        {
            await _httpClient.DeleteAsync($"/api/student/{student.Id}");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            student = null;
        }
        return student;
    }

    public async Task<List<Student>> Get()
    {
        List<Student> students = new List<Student>();
        try
        {
            students= await _httpClient.GetFromJsonAsync<List<Student>>($"/api/student/");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            students = new();
        }
        return students;
    }

    public async Task<Student> Get(int id)
    {
        Student student = null;
        try
        {
            student=await _httpClient.GetFromJsonAsync<Student>($"/api/student/{student.Id}");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            student = null;
        }
        return student;
    }

    public async Task<Student> Update(Student student)
    {
        try
        {
             await _httpClient.PostAsJsonAsync<Student>($"/api/student/",student);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            student = null;
        }
        return student;
    }
}
