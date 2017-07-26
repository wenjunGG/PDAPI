using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Activity
{
   public class Header:DbSetBase
    {
        /// <summary>
        /// 模块ID
        /// </summary>
        [ForeignKey("Modular")]
        public Guid ModularID { get; set; }
        [ScaffoldColumn(false)]
        public virtual Modular Modular { get; set; }

        /// <summary>
        /// 头Code
        /// </summary>
        [MaxLength(50)]
        public string HeaderCode { get; set; }

        /// <summary>
        /// 头名称
        /// </summary>
        [MaxLength(50)]
        public string HeaderName { get; set; }


    }
}
