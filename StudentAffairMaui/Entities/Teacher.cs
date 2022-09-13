namespace StudentAffairMaui;

public class Teacher: BaseSetting
{
    public string Phone { get; set; }
    public DateTime Birthdate { get; set; }
    public int Age { get { return (DateTime.Now.Year - Birthdate.Year); } }
}

