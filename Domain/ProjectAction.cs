using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    /// <summary>
    /// 系统中的行为信息
    /// </summary>
    public class ProjectAction:BaseEntity
    {
        public ProjectAction()
        {
            Roles = new List<RoleAction>();
        }
        /// <summary>
        /// 行为名称
        /// </summary>
        [Required,StringLength(32)]
        public string ActionName { get; set; }
        /// <summary>
        /// 行为状态
        /// </summary>
        public CodeMap ActionState { get; set; }
        /// <summary>
        /// 行为所属的分组
        /// </summary>
        public  virtual  ActionGroup Group { get; set; }
        /// <summary>
        /// 行为对应的角色列表
        /// </summary>
        public  virtual ICollection<RoleAction> Roles { get; set; }
    }
}