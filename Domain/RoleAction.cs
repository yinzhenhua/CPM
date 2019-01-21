using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class RoleAction : BaseEntity
    {
        [Required, StringLength(32)] public string ActionKey { get; set; }

        [Required, StringLength(32)] public string RoleKey { get; set; }

        [ForeignKey("ActionKey")] public virtual ProjectAction Action { get; set; }

        [ForeignKey("RoleKey")] public virtual ProjectRole Role { get; set; }
    }
}