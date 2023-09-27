using ModernStore.Domain.Primitives;
using System.Text;

namespace ModernStore.Domain.Entities
{
    public class User : BaseEntity
    {
        private User() { }
        public User(string username, string passwordHash, string confirmPassword)
        {
            Active = true;
            PasswordHash = EncryptPassword(passwordHash);
            ConfirmPassword = confirmPassword;
            Username = username;
        }

        public string Username { get; private set; }
        public string PasswordHash { get; private set; }
        public string ConfirmPassword { get; private set; }
        public bool Active { get; private set; }

        public void Deactivate()
             => Active = false;


        private string EncryptPassword(string pass)
        {
            if (string.IsNullOrEmpty(PasswordHash)) return "";

            var password = (pass += "bomba-navio-939casa-papel.chuva-capim");
            var data = System.Security.Cryptography.MD5.HashData(Encoding.Default.GetBytes(password));
            var sbString = new StringBuilder();

            foreach (var c in data)
                sbString.Append(c.ToString("x2"));

            return sbString.ToString();
        }


        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
