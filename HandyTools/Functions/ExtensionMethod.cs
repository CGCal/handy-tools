using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventor;
using System.Reflection;

namespace HandyTools.Functions
{
    public static class ExtensionMethod
    {

        public static ObjectTypeEnum GetObjectTypeEnum(this object obj)
        {

            Type invokeType = obj.GetType();
            object tmp = invokeType.InvokeMember("Type",
                                        BindingFlags.GetProperty,
                                        null,
                                        obj,
                                        null);

            ObjectTypeEnum objType = (ObjectTypeEnum)tmp;

            return objType;
        }
    }
}
