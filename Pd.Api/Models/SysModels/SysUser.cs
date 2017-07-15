using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SysModels
{
    [Table("T_SYS_USER")]
    public class SysUser:DbSetBase
    {

        /// <summary>
        /// 用户名
        /// </summary>
        [MaxLength(50)]
        [MinLength(3)]
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [MaxLength(50)]
        [MinLength(5)]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
    }
}
