using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace EADN.Semester.QuizGame.Common
{
    public class CustomAssemblySection : ConfigurationSection
    {
        [ConfigurationProperty("", IsDefaultCollection = true)]
        public CustomAssemblyConfigElementCollection ConfigElementCollection
        {
            get
            {
                return (CustomAssemblyConfigElementCollection)base[""];
            }
        }
    }

    [ConfigurationCollection(typeof(CustomAssemblyConfigElement), AddItemName = "ConfigElement")]
    public class CustomAssemblyConfigElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new CustomAssemblyConfigElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            if (element == null)
                throw new ArgumentNullException("element");

            return ((CustomAssemblyConfigElement)element).Key;
        }
    }

    public class CustomAssemblyConfigElement : ConfigurationElement
    {
        [ConfigurationProperty("key", IsRequired = true, IsKey = true)]
        public string Key
        {
            get { return (string)base["key"]; }
        }

        [ConfigurationProperty("dir", IsRequired = false, IsKey = false)]
        public string Dir
        {
            get { return (string)base["dir"]; }
        }

        [ConfigurationProperty("dll", IsRequired = true, IsKey = false)]
        public string Dll
        {
            get { return (string)base["dll"]; }
        }
    }
}
