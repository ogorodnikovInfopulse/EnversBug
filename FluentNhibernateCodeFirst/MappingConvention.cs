using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Impl.CustomizersImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FluentNhibernateCodeFirst
{
    public static class MappingConvention
    {
        internal static readonly Dictionary<string, MemberInfo> _notMapped = new Dictionary<string, MemberInfo>();
        public static bool IsMemberNotMapped(MemberInfo member)
        {
            var key = member.ReflectedType.FullName + "." + member.Name;
            return _notMapped.ContainsKey(key);
        }

        public static void NotMapped<TEntity, TProperty>(this ClassCustomizer<TEntity> cm, Expression<Func<TEntity, TProperty>> property) where TEntity : class
        {
            var member = TypeExtensions.DecodeMemberAccessExpressionOf(property);
            var key = member.ReflectedType.FullName + "." + member.Name;
            if (!_notMapped.ContainsKey(key))
            {
                _notMapped.Add(key, member);
            }
        }
    }
}
