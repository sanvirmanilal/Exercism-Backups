public record FacialFeatures(string EyeColor, decimal PhiltrumWidth)
{
}

public record Identity(string Email, FacialFeatures FacialFeatures)
{
}

public class Authenticator
{
    private Identity _admin = new("admin@exerc.ism", new FacialFeatures("green", 0.9m));
    private List<Identity> _identities = new();
    
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
    {
        return faceA == faceB;
    }

    public bool IsAdmin(Identity identity) => identity == _admin;

    public bool Register(Identity identity) 
    {
        if (!IsRegistered(identity))
        {
            _identities.Add(identity);
            return true;
        }

        return false;
            
    }

    public bool IsRegistered(Identity identity) => _identities.Any(i => i == identity);

    public static bool AreSameObject(Identity identityA, Identity identityB) => ReferenceEquals(identityA, identityB);
}
