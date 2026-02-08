using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        bool kebabMode = false;
        StringBuilder stringBuilder = new();
        
        for (int c = 0; c < identifier.Length; c++)
        {
            if (char.IsWhiteSpace(identifier[c]))
            {
                stringBuilder.Append('_');
            }
            else if (char.IsControl(identifier[c]))
            {
                stringBuilder.Append("CTRL");
            }
            else if (identifier[c] == '-')
            {
                kebabMode = true;
            }
            else if (kebabMode)
            {
                stringBuilder.Append(char.ToUpper(identifier[c]));
                kebabMode = false;
            }           
            else if (char.IsLetter(identifier[c]) 
                     && !(identifier[c] >= 'α' && identifier[c] <= 'ω'))
            {
                stringBuilder.Append(identifier[c]);
            } 
        }

        return stringBuilder.ToString();
    }    
}
