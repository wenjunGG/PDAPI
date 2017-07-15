using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Activity
{
    /// <summary>
    /// 模块字典类型
    /// </summary>
   [Table("T_MON_DicModular")]
   public class DicModular:DbSetBase
    {
        /// <summary>
        /// 模块ID
        /// </summary>
        [ForeignKey("Modular")]
        public Guid ModularID { get; set; }
        [ScaffoldColumn(false)]
        public virtual Modular Modular { get; set; }

        /// <summary>
        /// 字典项
        /// </summary>
        public string DicName { get; set; }

        /// <summary>
        /// 字典值
        /// </summary>
        public string DicValue { get; set; }
        

        /// <summary>
        /// 是否重要
        /// </summary>
        public bool IsImportant { get; set; }
    }
}
