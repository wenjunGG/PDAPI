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
    /// 请求参数值
    /// </summary>
    [Table("T_MON_RequestCoeff")]
  public  class RequestCoeff:DbSetBase
    {
        /// <summary>
        /// 接口ID
        /// </summary>
        [ForeignKey("Ports")]
        public Guid PortsID { get; set; }
        [ScaffoldColumn(false)]
        public virtual Ports Ports { get; set; }

        /// <summary>
        /// 请求参数Code
        /// </summary>
        public string CoeffCode { get; set; }

        /// <summary>
        /// 请求参数值
        /// </summary>
        public string CoffValue { get; set; }
        
    }
}
