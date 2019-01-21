using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public abstract class BaseEntity
    {
        /// <summary>
        /// 键值
        /// </summary>
        /// <value>The key.</value>
        [Key,StringLength(32)]
        public string Key { get; set; }

        /// <summary>
        /// Code当前版本标识，用于进行并发的乐观锁管理
        /// </summary>
        /// <value>The version.</value>
        [Timestamp,ConcurrencyCheck]
        public byte[] Version { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        /// <value>The created on.</value>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        /// <value>The updated on.</value>
        public DateTime? UpdatedOn { get; set; }

        /// <summary>
        /// 移除时间
        /// </summary>
        /// <value>The removed on.</value>
        public DateTime? RemovedOn { get; set; }
        /// <summary>
        /// 排序字段
        /// </summary>
        public int SEQ { get; set; }
    }
}
