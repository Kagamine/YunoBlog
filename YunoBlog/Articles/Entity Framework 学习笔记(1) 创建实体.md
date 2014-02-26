  最近在做Cena+这个项目，是我和Ibe Kaoet合作的，本以为寒假可以完成，但是由于各种原因，项目没有按预期的日程走，稍微拖延了一个多星期。原来的分工是Ibe Kaoet负责数据库、通讯等逻辑，我负责评测机和UI，显然现在需要我揽起全局了。


  Cena+是使用WPF+WCF+Entity Framework+MySQL来构建的。


  Entity Framework简言之就是类似于NHibernate的一种框架，是推行NoSQL运动的一个产物，其查询语言为Linq to Entities。


  据网上传言EF5之前的版本都很残，效率成大问题，而在EF5起才解决了这一问题。我是现在才开始用EF的，因此只知道现在的版本很好用。而且与NHibernate相比，Entity Framework更为本土化，NH则是从java衍生过来的。


  闲话不多说，我们开始进入正题。


  首先，我们需要创建与数据库对应的实体类，比如我们有如下的建表语句

	CREATE TABLE `users` (
		id int not null auto_increment,
		`name` varchar(20) not null,
		`password` binary(20) not null,
		nick_name varchar(50) not null,
		real_name varchar(50) default null,
		identification_number varchar(50) default null,
		email varchar(100) not null,
		gravatar varchar(100) default null,
		`role` tinyint not null,
		primary key (id),
		unique index (`name`)
	)  default charset=utf8;

  我们则需要根据C#/VB.Net类型与MySQL类型对应关系，来定义每个成员。
    namespace CenaPlus.Cloud.Entity
    {
        [Table("users")]
        public class User
        {
            [Column("id")]
            public int ID { get; set; }

            [Column("name")]
            public string Name { get; set; }

            [Column("email")]
            public string Email { get; set; }

            [Column("gravatar")]
            public string Gravatar { get; set; }

            [Column("real_name")]
            public string RealName { get; set; }

            [Column("identification_number")]
            public string IdentificationNumber { get; set; }

            [Column("nick_name")]
            public string NickName { get; set; }

            /// <summary>
            /// Stored in SHA-1
            /// </summary>
            [Column("password")]
            public byte[] Password { get; set; }

            [Column("role")]
            public int RoleAsInt { get; set; }

            [NotMapped]
            public UserRole Role
            {
                get { return (UserRole)RoleAsInt; }
                set { RoleAsInt = (int)value; }
            }

            public virtual ICollection<Rating> Ratings { get; set; }

            public override bool Equals(object obj)
            {
                User other = obj as User;
                if (other == null) return false;
                return other.ID == this.ID;
            }

            public string GetGravatar()
            {
                var email_hash = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Gravatar, "MD5").ToLower();
                return String.Format("http://www.gravatar.com/avatar/{0}?d=http://www.cenaplus.org/images/Default.png", Gravatar);
            }

            public override int GetHashCode()
            {
                return ID;
            }
        }

        public enum UserRole
        {
            Banned, User, Customer, Manager, Root
        }
    }

  首先属性[Table("users")]表示这个实体是对应users这个表的，紧接着下面每个实体上方几乎都有一个[Column("xxx")]属性，xxx表示对应数据库中的字段，如果数据库中没有这个字段，我们则需要为它贴上“[NotMapped]”标签，比如上面的Role字段，因为EF5不支持存储enum（EF6支持），因此在这里我选择了使用int存储Role(用户角色)，当然也可以使用varchar存储（我的一个同学就是这么做的）。

  我们需要注意的是，方括号的“标签”只需要给属性贴，而方法是不需要的，比如后面我重写了Equal和GetHashCode，这个操作是为了后面的操作用的，当然不这样做也有其他的解决方法。

  了解了基本的实体创建方法后，我们要开始做外键映射了，我们以用户的积分变化表与用户表关系为例：

	CREATE TABLE `ratings` (
		id int not null auto_increment,
		`time` datetime not null,
		contest_id int not null,
		`user_id` int not null,
		`rating_change` int not null,
		primary key (id),
		foreign key (contest_id)
			references contests (id)
			on delete cascade,
		foreign key (user_id)
			references users (id)
			on delete cascade
	)  default charset=utf8;

  在这张表定义实体的时候，不仅需要给ContestID、UserID字段添加[Column]属性，还要添加ForeignKey标签。

        [Column("user_id")]
        [ForeignKey("User")]
        public int UserID { get; set; }

        public virtual User User { get; set; }

  ForeignKey中的参数则表示对象名，我们在后面定义了一个虚成员User，EF在获得到ForeignKey属性后会与这个虚成员建立关系，在调用时会加载User这个成员，也就是说，我们可以通过ratings.user来访问user中的成员，而我们没用访问user成员时，则EF不会实例化user对象。