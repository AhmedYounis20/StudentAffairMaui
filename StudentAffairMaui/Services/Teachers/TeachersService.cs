namespace StudentAffairMaui;

public class TeachersService : BaseSettingService<Teacher>, ITeachersService
{
    HttpClient _httpClient { get; set; }

    public TeachersService(HttpClient httpClient) : base(httpClient)
    {
        _httpClient = httpClient;
    }
}
