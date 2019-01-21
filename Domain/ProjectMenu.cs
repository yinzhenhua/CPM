using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    /// <summary>
    /// 项目菜单配置，用以控制用户在操作过程中的行为
    /// </summary>
    public class ProjectMenu:BaseEntity
    {
        public ProjectMenu()
        {
            Children=new List<ProjectMenu>();
            Actions=new List<ProjectAction>();
        }
        /// <summary>
        /// 菜单名称
        /// </summary>
        [Required,StringLength(32)]
        public string MenuName { get; set; }
        /// <summary>
        /// 菜单显示名称
        /// </summary>
        [Required,StringLength(64)]
        public string Display { get; set; }
        /// <summary>
        /// URL,表示菜单名称或操作名称
        /// </summary>
        [Required,StringLength(255)]
        public string Uri { get; set; }
        /// <summary>
        /// 菜单状态
        /// </summary>
        public CodeMap MenuState { get; set; }
        /// <summary>
        /// 上级菜单
        /// </summary>
        public virtual ProjectMenu Parent { get; set; }
        /// <summary>
        /// 子菜单集合
        /// </summary>
        public virtual IEnumerable<ProjectMenu> Children { get; set; }
        /// <summary>
        /// 菜单对应的权限列表
        /// </summary>
        public virtual IEnumerable<ProjectAction> Actions { get; set; }
    }
}