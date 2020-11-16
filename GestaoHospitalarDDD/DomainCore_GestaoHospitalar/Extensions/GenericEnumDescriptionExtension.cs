using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace DomainCore_GestaoHospitalar.Extensions
{
    public static class GenericEnumDescriptionExtension
    {
        public static string ObterDescricao(this Enum _enum)
        {
            Type EnumType = _enum.GetType();
            MemberInfo[] memberInfos = EnumType.GetMember(_enum.ToString());
            if ((memberInfos.Length <= 0))
            {
                return _enum.ToString();
            }

            var attribs = memberInfos[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attribs.Any() ? ((DescriptionAttribute)attribs.ElementAt(0)).Description : _enum.ToString();
        }
    }
}
