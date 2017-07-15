using Models.SysModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Activity
{
    /// <summary>
    /// 模块
    /// </summary>
    [Table("T_ACT_Modular")]
  public  class Modular:DbSetBase
    {
        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModularName { get; set; }

        public virtual ICollection<SysUserModular> SysUserModular { get; set; }
    }
}
