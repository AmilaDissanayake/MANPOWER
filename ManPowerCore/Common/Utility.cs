using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Common
{
    public class Utility
    {
        public static Object cloneObject(Object fromObject, Object toObject)
        {
            if (fromObject != null)
            {
                foreach (PropertyInfo propertyfrom in fromObject.GetType().GetProperties())
                {
                    if (!propertyfrom.PropertyType.IsGenericType)
                    {
                        foreach (PropertyInfo propertyto in toObject.GetType().GetProperties())
                        {
                            if (propertyto.Name.Equals(propertyfrom.Name))
                            {
                                propertyto.SetValue(toObject, propertyfrom.GetValue(fromObject, null), null);
                                break;
                            }
                        }
                    }
                }
            }
            return toObject;
        }
    }
}
