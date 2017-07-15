﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Motion
{
    /// <summary>
    /// 参数表
    /// </summary>
    [Table("T_MON_Coefficient")]
   public class Coefficient:DbSetBase
    {
        /// <summary>
        /// 接口ID
        /// </summary>
        [ForeignKey("Ports")]
        public Guid PortsID { get; set; }
        [ScaffoldColumn(false)]
        public virtual Ports Ports { get; set; }

        /// <summary>
        /// 参数Code
        /// </summary>
        public string CoeffiCode { get; set; }

        /// <summary>
        /// 参数名
        /// </summary>
        public string CoffiName { get; set; }
        
    }
}
