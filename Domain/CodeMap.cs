using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#region copyright (c) zhyin 2019
//=============copyright(c) zhyin 2019=============
//class Name: CodeMap
//Author/Created:zhyin/2019-1-15
//Description:权限管理系统中用于配置公共基础信息
//=================================================
#endregion
namespace Domain
{
    public class CodeMap:BaseEntity
    {
        public CodeMap()
        {
        }

        /// <summary>
        /// 对应的Code，数字表示具体的Code信息
        /// </summary>
        /// <value>The code.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Code { get; set; }

        /// <summary>
        /// Code对应的分类，如项目的状态，用户的状态
        /// </summary>
        /// <value>The category.</value>
        [StringLength(32), Required]
        public string Category { get; set; }

        /// <summary>
        /// Code对应的名称
        /// </summary>
        /// <value>The name of the code.</value>
        [StringLength(32), Required]
        public string CodeName { get; set; }

        /// <summary>
        /// 名称大写
        /// </summary>
        /// <value>The upper.</value>
        [StringLength(32)]
        public string Upper { get; set; }

        /// <summary>
        /// 名称小写
        /// </summary>
        /// <value>The lower.</value>
        [StringLength(32)]
        public string Lower { get; set; }

        /// <summary>
        /// 中文名称
        /// </summary>
        /// <value>The name of the chinese.</value>
        [StringLength(32), Required]
        public string ChineseName { get; set; }

        /// <summary>
        /// Code描述
        /// </summary>
        /// <value>The name of the english.</value>
        [StringLength(256)]
        public string Description { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
        /// <value>The seq.</value>
        public int Seq { get; set; }

        /// <summary>
        /// Code状态
        /// </summary>
        /// <value>The status.</value>
        public CodeStatus Status { get; set; }
    }
}
