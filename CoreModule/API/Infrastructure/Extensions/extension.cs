using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    public static class extension
    {
        // Generic method to convert one object to another
        public static TTarget ToClassObject<TSource, TTarget>(this TSource source)
            where TSource : class
            where TTarget : class, new()
        {
            if (source == null)
            {
                return null;
            }

            var target = new TTarget();

            // For simplicity, using reflection to copy properties with the same name and type
            foreach (var sourceProp in typeof(TSource).GetProperties())
            {
                var targetProp = typeof(TTarget).GetProperty(sourceProp.Name);
                if (targetProp != null && targetProp.CanWrite && targetProp.PropertyType == sourceProp.PropertyType)
                {
                    targetProp.SetValue(target, sourceProp.GetValue(source));
                }
            }

            return target;
        }
    }

}
