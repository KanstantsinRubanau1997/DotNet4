namespace DotNet4
{
    public static class BoxingTypeConversionExample
    {
        public static void BoxingWithGeneric()
        {
            // ???
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

    public class GenericClass<T> where T : IStruct { };

    public struct SomeStruct : IStruct { }

    public interface IStruct { }
}
