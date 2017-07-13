using System.Configuration;

namespace PeriodRequestWebsite.WindowsService
{
    public class TargetWebsiteSettingConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("intervalSecond", IsRequired = false, DefaultValue = 60 * 5)]
        public int IntervalSecond
        {
            get { return (int)base["intervalSecond"]; }
            set { base["intervalSecond"] = value; }
        }

        [ConfigurationProperty("websites", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(Website), CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap, RemoveItemName = "remove")]
        public Websites Websites
        {
            get { return (Websites)base["websites"]; }
            set { base["websites"] = value; }
        }
    }

    public class Websites : ConfigurationElementCollection
    {
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((Website)element).Name;
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new Website();
        }

        public Website this[int i]
        {
            get
            {
                return (Website)BaseGet(i);
            }
        }

        public new Website this[string key]
        {
            get
            {
                return (Website)BaseGet(key);
            }
        }

    }

    public class Website : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get { return (string)base["name"]; }
            set { base["name"] = value; }
        }

        [ConfigurationProperty("url", IsRequired = false, DefaultValue = "")]
        public string Url
        {
            get { return (string)base["url"]; }
            set { base["url"] = value; }
        }
    }
}
