using Models.Activity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Motion
{
    /// <summary>
    /// 接口字典类型
    /// </summary>
    [Table("T_MON_DicPorts")]
   public class DicPorts:DbSetBase
    {

        /// <summary>
        /// 模块ID
        /// </summary>
        [ForeignKey("Modular")]
        public Guid ModularID { get; set; }
        [ScaffoldColumn(false)]
        public virtual Modular Modular { get; set; }


        /// <summary>
        /// 接口ID
        /// </summary>
        [ForeignKey("Ports")]
        public Guid PortsID { get; set; }
        [ScaffoldColumn(false)]
        public virtual Ports Ports { get; set; }

        /// <summary>
        /// 字典项
        /// </summary>
        [MaxLength(50)]
        public string DicName { get; set; }

        /// <summary>
        /// 字典值
        /// </summary>
        [MaxLength(50)]
        public string DicValue { get; set; }
        

        /// <summary>
        /// 是否重要
        /// </summary>
        public bool IsImportant { get; set; }
    }
}
