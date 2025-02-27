namespace SabayNew.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; } = null;
        public int? RoleId { get; set; }
        public RoleModel roleModel { get; set; }
    }
}
