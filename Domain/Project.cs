using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

#region copyright (c) zhyin 2019

//=============copyright(c) zhyin 2019=============
//class Name: Project
//Author/Created:zhyin/2019-1-15
//Description:权限管理系统中用于配置权限对应的项目信息
//=================================================

#endregion

namespace Domain
{
    /// <summary>
    /// 通过权限管理系统中的项目信息
    /// </summary>
    public class Project : BaseEntity
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        [Required,StringLength(64)]
        public string Name { get; set; }

        /// <summary>
        /// 项目状态，来自CodeMap中的记录
        /// </summary>
        public CodeMap ProjectState { get; set; }

        /// <summary>
        /// 安全码，后期用于进行Client验证
        /// </summary>
        [Required,StringLength(32)]
        private string SecurityCode { get; set; }

        [ForeignKey("SecurityCode")] public SecurityKey SecurityKey { get; set; }

        /// <summary>
        /// 系统的Action分组
        /// </summary>
        public virtual ICollection<ActionGroup> ActionGroups { get; set; }

        /// <summary>
        /// 系统的角色列表
        /// </summary>
        public virtual ICollection<ProjectRole> Roles { get; set; }

        /// <summary>
        /// 系统菜单列表
        /// </summary>
        public virtual ICollection<ProjectMenu> Menus { get; set; }
    }
}