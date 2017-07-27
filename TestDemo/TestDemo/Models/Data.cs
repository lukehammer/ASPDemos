using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestDemo.Models
{
   
    public partial class Product
        {
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
            public Product()
            {
                this.Areas = new HashSet<Area>();
                this.ProductTasks = new HashSet<ProductTask>();
                this.UserProductRoles = new HashSet<UserProductRole>();
            }
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Area> Areas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductTask> ProductTasks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserProductRole> UserProductRoles { get; set; }
    }
    public partial class Activity
    {
        public int ActivityID { get; set; }
        public Nullable<System.DateTime> CommitDate { get; set; }
        public Nullable<System.DateTime> NeedDate { get; set; }
        public int AreaID { get; set; }
        public int TaskID { get; set; }
        public bool isActualized { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedUserID { get; set; }
        public Nullable<bool> isMax { get; set; }

        public virtual Area Area { get; set; }
        public virtual Task Task { get; set; }

    }
    public partial class Area
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Area()
        {
            this.Activities = new HashSet<Activity>();
        }

        public int AreaID { get; set; }
        public int PointOfContactUserID { get; set; }
        public int SectionID { get; set; }
        public int ProductID { get; set; }
        public string AreaName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual Product Product { get; set; }
        public virtual string Section { get; set; }
        public virtual string PointOfContactUser { get; set; }
    }
    public partial class Section
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Section()
        {
            this.Areas = new HashSet<Area>();
        }

        public int SectionID { get; set; }
        public string SectionName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Area> Areas { get; set; }
    }
    public partial class UserProductRole
    {
        public int UserProductRolesID { get; set; }
        public int UserAccountID { get; set; }
        public int ProductID { get; set; }
        public int RoleID { get; set; }

        public virtual Product Product { get; set; }
        public virtual Role Role { get; set; }
        public virtual UserAccount UserAccount { get; set; }
    }
    public partial class UserAccount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserAccount()
        {
            this.UserProductRoles = new HashSet<UserProductRole>();
            this.Areas = new HashSet<Area>();
        }

        public int UserAccountID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public bool Locked { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserProductRole> UserProductRoles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Area> Areas { get; set; }
    }
    public partial class Role
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Role()
        {
            this.UserProductRoles = new HashSet<UserProductRole>();
        }

        public int RoleID { get; set; }
        public string RoleName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserProductRole> UserProductRoles { get; set; }
    }
    public partial class Task
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Task()
        {
            this.Activities = new HashSet<Activity>();
            this.ProductTasks = new HashSet<ProductTask>();
        }

        public int TaskID { get; set; }
        public string TaskDescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activity> Activities { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductTask> ProductTasks { get; set; }
    }
    public partial class ProductTask
    {
        public int ProductTaskID { get; set; }
        public Nullable<int> TaskID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> SortOrder { get; set; }

        public virtual Product Product { get; set; }
        public virtual Task Task { get; set; }
    }
}