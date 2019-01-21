using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    /// <summary>
    /// 系统中的角色
    /// </summary>
    public class ProjectRole:BaseEntity
    {
        public ProjectRole()
        {
            Actions = new List<RoleAction>();
        }
        /// <summary>
        /// 角色名称
        /// </summary>
        [Required,StringLength(32)]
        public string RoleName { get; set; }
        /// <summary>
        /// 角色状态
        /// </summary>
        public CodeMap RoleState { get; set; }
        /// <summary>
        /// 角色对应的权限列表
        /// </summary>
        public virtual IEnumerable<RoleAction> Actions { get; set; }
    }
}