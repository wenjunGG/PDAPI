using Models.Activity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SysModels
{
    /// <summary>
    /// 用户模块表
    /// </summary>
    [Table("T_SYS_SysUserModular")]
    public  class SysUserModular:DbSetBase
    {

        /// <summary>
        /// 用户ID
        /// </summary>
        [ForeignKey("SysUser")]
        public Guid? SysUserID { get; set; }
        [ScaffoldColumn(false)]
        public virtual SysUser SysUser { get; set; }

        /// <summary>
        /// 模块ID
        /// </summary>
        [ForeignKey("Modular")]
        public Guid ModularID { get; set; }
        [ScaffoldColumn(false)]
        public virtual Modular Modular { get; set; }
        
    }
}
