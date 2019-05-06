using NHibernate.Mapping.ByCode.Conformist;

namespace FluentNhibernateCodeFirst
{
    public class Entity<TId>
    {
        public virtual TId Id { get; set; }
    }

    public class Customer : Entity<int>
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
    }

    public class CustomerMap : ClassMapping<Customer>
    {
        public CustomerMap()
        {
            Id(c => c.Id);
        }
    }
}