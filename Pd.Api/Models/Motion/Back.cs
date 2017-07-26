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
    /// 参数返回值
    /// </summary>
   [Table("T_MON_Back")]
  public  class Back:DbSetBase
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
        /// 返回Code
        /// </summary>
        [MaxLength(50)]
        public string BackCode { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        [MaxLength(50)]
        public string BackMess { get; set; }


    }
}
