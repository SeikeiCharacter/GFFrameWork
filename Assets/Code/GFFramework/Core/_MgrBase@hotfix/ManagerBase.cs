using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GFFramework.Mgr
{
    public class ManagerAtrribute : Attribute
    {
        public string Tag { get; private set; }
        public ManagerAtrribute(string Id)
        {
            this.Tag = Id;
        }
    }
    
    /// <summary>
    /// Manager基类
    /// </summary>
    /// <typeparam name="T">Manager类型</typeparam>
    /// <typeparam name="V">被管理者所用的类标签</typeparam>
    public class ManagerBase<T,V>:IMgr  where T: IMgr, new() 
                                        where V: ManagerAtrribute
    {

        static private T i;

        static public T Inst
        {
            get
            {
                if (i == null)
                {
                    i = new T();
                }
                return i;
            }
        }
        
        protected ManagerBase ()
        {
            this.ClassDataMap = new Dictionary<string, ClassData>();
        }
        
        protected Dictionary<string, ClassData> ClassDataMap
        {
            get;
            set;
        }

        virtual  public void CheckType(Type type)
        {
            var attrs = type.GetCustomAttributes(typeof(V), false);
            if (attrs.Length > 0)
            {
                var attr = attrs[0];
                if (attr is V)
                {   
                    var _attr = (V)attr;
                    SaveAttribute(_attr.Tag, new ClassData() { Attribute = _attr, Type = type });
                }             
            }
        }


        virtual public void Init()
        {
            
        }

        virtual public void Start()
        {
            
        }

        virtual public void Update()
        {
            
        }
        
        
        public ClassData GetCalssData(string typeName)
        {
            ClassData classData = null;
            this.ClassDataMap.TryGetValue(typeName, out classData);
            return classData;
        }

        public void SaveAttribute(string name, ClassData data)
        {
            this.ClassDataMap[name] = data;
        }

        public T2 CreateInstance<T2>(string typeName , params object[] args) where T2 : class
        {
            var type = GetCalssData(typeName).Type;
            if (type != null)
            {
                if (args.Length == 0)
                {
                    return Activator.CreateInstance(type) as T2;
                }
                else
                {
                    return Activator.CreateInstance(type,args) as T2;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
