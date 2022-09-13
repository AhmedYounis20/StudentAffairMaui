namespace StudentAffairMaui;

public class Student:BaseSetting
{
    public string Phone { get; set; }
    public DateTime Birthdate { get; set; }
    public int Age { get { return (DateTime.Now.Year - Birthdate.Year); } }
    public string? ImagePath { get; set;  }

}
