using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AccordionControl.Helper
{
    /// <summary>
    ///  This class is used for getting runtime data for header template using reflection.
    /// </summary>
    public class ViewUserControl : Grid
    {
        /// <summary>
        ///This object is used for implementing reflection.
        /// </summary>
        private Dictionary<string, object> cache = new Dictionary<string, object>();

        /// <summary>
        /// need to be changed
        /// </summary>
        public ViewUserControl()
        {

        }

        /// <summary>
        /// This method is used for implenting reflection and runtime modifications.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        protected T FindByViewPrivate<T>(string name)
        {
            if (this.cache.ContainsKey(name))
            {
                return (T)this.cache[name];
            }

            Type t = this.GetType();
            FieldInfo fi = t.GetRuntimeFields().FirstOrDefault(f => f.Name == name);
            if (fi == null) throw new NullReferenceException(string.Format("Field {0} not found.", name));
            T value = (T)fi.GetValue(this);
            this.cache.Add(name, value);
            return value;
        }
    }
}
