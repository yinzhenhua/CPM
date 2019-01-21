using System.ComponentModel.DataAnnotations;

namespace PMService.ViewModels.Project
{
    public class ProjectViewModel4Create
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        [Display(Name="项目名称")]
        [StringLength(64, ErrorMessage = "{0}的长度不能超过{1}")]
        [Required(ErrorMessage = "请输入{0}")]
        public string ProjectName { get; set; }
        
        /// <summary>
        /// 项目中状态
        /// </summary>
        [Display(Name = "项目状态")]
        public string ProjectState { get; set; }
    }
}