using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccordionControl.Helper;
using Xamarin.Forms;
using System.Reflection;

namespace AccordionControl.Helper
{
    /// <summary>
    /// This class is used for getting runtime data for viewcell  templates of listview, using refelction.
    /// </summary>
    public class ViewCellUserControl : ViewCell
    {
        /// <summary>
        /// need to be changed
        /// </summary>
        /// <param name="action"></param>
        public ViewCellUserControl(Action<object, EventArgs> action)
        {
        }


        /// <summary>
        ///
        /// </summary>
        private Dictionary<string, object> cache = new Dictionary<string, object>();


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
