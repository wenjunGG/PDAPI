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
    /// 接口
    /// </summary>
    [Table("T_MON_Ports")]
    public class Ports : DbSetBase
    {
        /// <summary>
        /// 模块ID
        /// </summary>
        [ForeignKey("Modular")]
        public Guid ModularID { get; set; }
        [ScaffoldColumn(false)]
        public virtual Modular Modular { get; set; }

        /// <summary>
        /// 接口名
        /// </summary>
        [MaxLength(50)]
        public string PortsName { get; set; }

        /// <summary>
        /// 接口请求Ip
        /// </summary>
        [MaxLength(50)]
        public string PortsIp { get; set; }

        /// <summary>
        /// 接口请求地址
        /// </summary>
        [MaxLength(50)]
        public string PortsAddress { get; set; }

        /// <summary>
        /// 接口请求的方式
        /// </summary>
        [MaxLength(50)]
        public string PortsType { get; set; }

        /// <summary>
        /// 是否分页
        /// </summary>
        public bool IsPag { get; set; }

       
    }
}
