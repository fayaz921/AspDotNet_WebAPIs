namespace AspDotNetCore_WebAPIs.Shared
{
    public interface IPasswordEncryptor
    {
        void CreatePasswordHashandSalt(string password, out byte[] hash, out byte[] salt);
        bool VerifyPasswordhashandsalt(string password, byte[] Storedhash, byte[] Storedsalt);
    }
}
