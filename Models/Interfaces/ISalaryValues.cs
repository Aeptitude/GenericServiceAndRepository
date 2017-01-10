namespace Models.Interfaces
{
    public interface ISalaryValues
    {
        int Age { get; set; }
        int YearsOfService { get; set; }
        bool AreValid();
    }
}
