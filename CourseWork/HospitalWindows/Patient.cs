namespace CourseWork.HospitalWindows
{
    public class Patient
    {
        public int _startTime;
        public int _endTime;
        public string _fullName;

        public Patient(int startTime, int endTime, string fullName)
        {
            _startTime = startTime;
            _endTime = endTime;
            _fullName = fullName;
        }
    }
}