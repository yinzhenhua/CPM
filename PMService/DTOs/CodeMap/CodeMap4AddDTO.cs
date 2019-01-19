using System;
namespace PMService.DTOs.CodeMap
{
    public class CodeMap4AddDTO
    {
        /// <summary>
        /// Code对应的分类，如项目的状态，用户的状态
        /// </summary>
        /// <value>The category.</value>
        public string Category { get; set; }

        /// <summary>
        /// Code对应的名称
        /// </summary>
        /// <value>The name of the code.</value>
        public string CodeName { get; set; }

        /// <summary>
        /// 中文名称
        /// </summary>
        /// <value>The name of the chinese.</value>
        public string ChineseName { get; set; }

        /// <summary>
        /// Code描述
        /// </summary>
        /// <value>The name of the english.</value>
        public string Description { get; set; }

        /// <summary>
        /// Code状态
        /// </summary>
        /// <value>The status.</value>
        public int Status { get; set; }
    }
}
