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
        /// 接口ID
        /// </summary>
        [ForeignKey("Ports")]
        public Guid PortsID { get; set; }
        [ScaffoldColumn(false)]
        public virtual Ports Ports { get; set; }

        /// <summary>
        /// 返回Code
        /// </summary>
        public string BackCode { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        public string BackMess { get; set; }


    }
}
