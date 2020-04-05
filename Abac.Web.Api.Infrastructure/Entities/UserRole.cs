namespace Abac.Web.Api.Infrastructure.Entities
{
    public partial class UserRole
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? RoleId { get; set; }
        public virtual RoleType Role { get; set; }
        public virtual User User { get; set; }
    }
}
