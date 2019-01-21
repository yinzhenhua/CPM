using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    /// <summary>
    /// 行为分组，比如用户操作会包含增加、删、改、查等具体的Action
    /// </summary>
    public class ActionGroup:BaseEntity
    {
        public ActionGroup()
        {
            Actions = new List<ProjectAction>();
        }
        /// <summary>
        /// 分组名称
        /// </summary>
        [Required, StringLength(64)]
        public string GroupName { get; set; }
        /// <summary>
        /// 分组状态
        /// </summary>
        public CodeMap GroupState { get; set; }
        /// <summary>
        /// 该分组下对应的行为列表
        /// </summary>
        public virtual ICollection<ProjectAction> Actions { get; set; }
    }
}