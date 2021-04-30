namespace SOLID
{
    public interface StudentEligibility
    {
        bool IsEligibleToEnroll(string studentId, string classId);
    }
}