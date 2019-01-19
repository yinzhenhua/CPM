using System;
using System.ComponentModel.DataAnnotations;

namespace PMService.ViewModels.CodeMap
{
    public class CodeMapViewModel4Add
    {
        /// <summary>
        /// Code对应的分类，如项目的状态，用户的状态
        /// </summary>
        /// <value>The category.</value>
        [Required(ErrorMessage ="请选择{0}")]
        [Display(Name ="所属分类")]
        public string Category { get; set; }

        /// <summary>
        /// Code对应的名称
        /// </summary>
        /// <value>The name of the code.</value>
        [Required(ErrorMessage ="请输入{0}")]
        [StringLength(32, ErrorMessage ="{0}的长度不能超过{1}")]
        [Display(Name ="编码名称(英文)")]
        public string CodeName { get; set; }

        /// <summary>
        /// 中文名称
        /// </summary>
        /// <value>The name of the chinese.</value>
        [Display(Name ="中文名称"),Required(ErrorMessage ="请输入{0}")]
        public string ChineseName { get; set; }

        /// <summary>
        /// Code描述
        /// </summary>
        /// <value>The name of the english.</value>
        [Display(Name ="编码描述"),Required(ErrorMessage ="请输入{0}")]
        [StringLength(256, ErrorMessage ="{0}的长度不能超过{1}")]
        public string Description { get; set; }

        /// <summary>
        /// Code状态
        /// </summary>
        /// <value>The status.</value>
        [Display(Name ="初始状态")]
        public int Status { get; set; }
    }
}
