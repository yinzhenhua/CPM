using System.ComponentModel.DataAnnotations;

namespace Domain
{
    /// <summary>
    /// 安全吗，用于Client认证
    /// </summary>
    public class SecurityKey:BaseEntity
    {
        /// <summary>
        /// 安全码
        /// </summary>
        [Required,StringLength(64)]
        public string SecurityCode { get; set; }
    }
}