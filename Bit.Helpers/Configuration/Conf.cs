using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Bit.Helpers.Configuration
{
    public class Conf
    {
        private Dictionary<string, string> Values { get; set; }

        private Conf(string nameSpace)
        {
            Values = CutOff(nameSpace, AllMatching(nameSpace, AppSettingValues()));
        }

        private Conf(string nameSpace, Dictionary<string, string> values)
        {
            Values = CutOff(nameSpace, AllMatching(nameSpace, values));
        }

        private Conf()
        {
            Values = AppSettingValues();
        }

        public Conf Sub(string nameSpace)
        {
            return new Conf(nameSpace, Values);
        }

        public static Conf Get(string nameSpace = null)
        {
            return string.IsNullOrEmpty(nameSpace) ? new Conf() : new Conf(nameSpace);
        }

        public T Key<T>(string key)
        {
            return (T) Convert.ChangeType(Values[key], typeof (T));
        }

        public T KeyOrDefault<T>(string key, T defaultValue = default(T))
        {
            try
            {
                var result = Key<T>(key);
                return result;
            }
            catch
            {
                return defaultValue;
            }
        }

        public static T GetKey<T>(string key)
        {
            return new Conf().Key<T>(key);
        }

        public static T GetKeyOrDefault<T>(string key, T defaultValue = default(T))
        {
            return new Conf().KeyOrDefault(key, defaultValue);
        }

        public IEnumerable<string> Keys()
        {
            return Values.Keys;
        }

        public void Populate(object destination)
        {
            var subSpaces = Values.Where(x => x.Key.Contains(".")).Select(x => x.Key.Split('.').First());

            foreach (var space in subSpaces)
            {
                var property = destination.GetType().GetProperty(space);

                if (property != null)
                {
                    var subConf = Sub(space);
                    var o = property.GetValue(destination);

                    if (o == null)
                    {
                        o = Activator.CreateInstance(property.PropertyType);
                        property.SetValue(destination, o);
                    }

                    subConf.Populate(o);
                }
            }

            var terminals = Values.Where(x => !x.Key.Contains(".")).Select(x => x.Key);

            foreach (var terminal in terminals)
            {
                var property = destination.GetType().GetProperty(terminal);

                if (property != null)
                {
                    var value = Convert.ChangeType(Values[terminal], property.PropertyType);
                    property.SetValue(destination, value);
                }
            }
        }

        private Dictionary<string, string> CutOff(string nameSpace, Dictionary<string, string> values)
        {
            return values.Select(x => new {Key = x.Key.Substring(nameSpace.Length + 1), Value = x.Value}).ToDictionary(x => x.Key, x => x.Value);
        }

        private Dictionary<string, string> AppSettingValues()
        {
            return ConfigurationManager.AppSettings
                .AllKeys
                .ToDictionary(x => x, x => ConfigurationManager.AppSettings[x]);
        }

        private Dictionary<string, string> AllMatching(string nameSpace, Dictionary<string, string> values)
        {
            return values.Where(x => NamespaceMatching(nameSpace, x.Key)).ToDictionary(x => x.Key, x => x.Value);
        }

        private bool NamespaceMatching(string nameSpace, string key)
        {
            var nsSplit = nameSpace.Split('.').ToList();
            var keySplit = key.Split('.').ToList();

            return
                nsSplit.Count < keySplit.Count
                && Enumerable.Range(0, nsSplit.Count).All(x => nsSplit[x] == keySplit[x]);
        }


    }
}
