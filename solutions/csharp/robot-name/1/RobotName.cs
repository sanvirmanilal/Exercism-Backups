public class Robot
{
    private string _name;
    private static HashSet<string> _robotNames = new();
    public Robot()
    {
        GenerateRobotName();
    }

    private void GenerateRobotName()
    {
        do
        {
            char firstLetter = (char)('A' + Random.Shared.Next(26));
            char secondLetter = (char)('A' + Random.Shared.Next(26));
            int number = Random.Shared.Next(1000);

            _name = $"{firstLetter}{secondLetter}{number:000}";
        }
        while (!_robotNames.Add(_name));
    }

    public string Name
    {
        get
        {
            return _name;
        }
    }

    public void Reset()
    {
        _robotNames.Remove(Name);
        GenerateRobotName();
    }
}