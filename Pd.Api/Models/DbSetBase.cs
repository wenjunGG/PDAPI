using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models
{
    public interface IDbSetBase
    {
        Guid Id { get; set; }
        Guid? UserId { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime UpdatedDate { get; set; }
        bool Deleted { get; set; }
    }

    public abstract class DbSetBase : IDbSetBase
    {
        protected DbSetBase()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
            Deleted = false;
        }

        [MaxLength(200)]
        [DataType(DataType.MultilineText)]
        [Column("REMARK")]
        public string Remark { get; set; }

        [Key]
        [ScaffoldColumn(false)]
        [Column("ID")]
        public Guid Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        [Column("CREATEDDATE")]
        public DateTime CreatedDate { get; set; }

        [ScaffoldColumn(false)]
        [Column("UPDATEDDATE")]
        public DateTime UpdatedDate { get; set; }
        
        [ScaffoldColumn(false)]
        [Column("USERID")]
        public Guid? UserId { get; set; }

        [ScaffoldColumn(false)]
        [Column("DELETED")]
        public bool Deleted { get; set; }
    }



    public interface IDbSetBaseForInt
    {
        int Id { get; set; }
        Guid EnterpriseId { get; set; }
        Guid? UserId { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime UpdatedDate { get; set; }
        bool Deleted { get; set; }
    }

    public abstract class DbSetBaseForInt : IDbSetBaseForInt
    {
        protected DbSetBaseForInt()
        {
            Id = 0;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
            Deleted = false;
        }

        [Key]
        [ScaffoldColumn(false)]
        [Column("ID")]
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        [Column("CREATEDDATE")]
        public DateTime CreatedDate { get; set; }

        [ScaffoldColumn(false)]
        [Column("UPDATEDDATE")]
        public DateTime UpdatedDate { get; set; }

        [ScaffoldColumn(false)]
        [Column("ENTERPRISEID")]
        public Guid EnterpriseId { get; set; }

        [ScaffoldColumn(false)]
        [Column("USERID")]
        public Guid? UserId { get; set; }

        [ScaffoldColumn(false)]
        [Column("DELETED")]
        public bool Deleted { get; set; }
    }
}
