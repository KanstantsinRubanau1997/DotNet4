namespace DotNet4
{
    public static class BoxingTypeConversionExample
    {
        public static void BoxingWithGeneric()
        {
            // No boxing
            var someStruct = new SomeStruct();
            var genericObj = new GenericClass<SomeStruct>(someStruct);

            SomeStruct someStructReleased = genericObj.SomeStruct;
        }

        public static void BoxingWithInterface()
        {
            var someStruct = new SomeStruct();

            Action<IStruct> funcWithBoxing = (someInterface) => { };

            funcWithBoxing(someStruct);
        }

        public static void BoxingWithDynamic()
        {
            var someStruct = new SomeStruct();
            dynamic someDynamic = someStruct;
        }
    }

    public class GenericClass<T> where T : IStruct
    {
        public T SomeStruct { get; set; }

        public GenericClass(T someStruct)
        {
            this.SomeStruct = someStruct;
        }
    }

    public struct SomeStruct : IStruct { }

    public interface IStruct { }
}
