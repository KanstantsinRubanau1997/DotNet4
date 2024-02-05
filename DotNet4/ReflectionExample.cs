namespace DotNet4
{
    public static class ReflectionExample
    {
        public static void FindTypesImplementingAnInterface()
        {
            var interfaceType = typeof(SomeInterface);
            var assembly = interfaceType.Assembly;

            var types = assembly.DefinedTypes.Where(t => interfaceType.IsAssignableFrom(t));
        }

        public static void InstantiateAnObject()
        {
            var class2Type = typeof(SomeClass2);
            var class2Object = Activator.CreateInstance(class2Type, new[] { "Name" });
        }

        public static void InvokeMethodMarkedWithAnAttribute()
        {
            var attributeType = typeof(SomeAttribute);
            var class2Type = typeof(SomeClass2);
            var methodWithAttribute = class2Type
                .GetMethods()
                .Where(m => m.GetCustomAttributes(attributeType, false).Length > 0);

            methodWithAttribute.ToList().ForEach(method =>
            {
                var res2 = method.Invoke(class2Type, new object[] { "something" });
            });
        }
    }

    interface SomeInterface { }

    class SomeClass : SomeInterface { }

    class SomeClass2 : SomeInterface
    {
        public SomeClass2(string name)
        {
            Name = name;
            PrivateName = name;
            ReadonlyName = name;
        }

        public string Name { get; set; }

        private string PrivateName { get; set; }

        public readonly string ReadonlyName;

        [Some]
        public string SomeMethod(string text)
        {
            return text;
        }
    }

    class SomeAttribute : Attribute { }
}
