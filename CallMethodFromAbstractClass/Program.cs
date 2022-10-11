using System;
using System.Reflection;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.CompilerServices;
using System.Reflection.Emit;

namespace CallMethodFromAbstractClass
{

    class Program
    {
        static void Main(string[] args)
        {
            Type abstractType = typeof(AbstractClass);

            var constructors = abstractType.GetConstructors();

            var constructor = constructors[0];

            var field = constructor.GetType().GetField("m_invocationFlags", BindingFlags.NonPublic|  BindingFlags.Instance);
            field.SetValue(constructor, INVOCATION_FLAGS.INVOCATION_FLAGS_INITIALIZED| INVOCATION_FLAGS.INVOCATION_FLAGS_IS_CTOR);

            var abstractObject = (AbstractClass)constructor.Invoke(null);
            abstractObject.Message();

            Console.ReadLine();
        }


        [Flags]
        internal enum INVOCATION_FLAGS : uint
        {
            INVOCATION_FLAGS_UNKNOWN = 0,
            INVOCATION_FLAGS_INITIALIZED = 1,
            INVOCATION_FLAGS_NO_INVOKE = 2,
            INVOCATION_FLAGS_NEED_SECURITY = 4,
            INVOCATION_FLAGS_NO_CTOR_INVOKE = 8,
            INVOCATION_FLAGS_IS_CTOR = 16,
            INVOCATION_FLAGS_SPECIAL_FIELD = 16,
            INVOCATION_FLAGS_RISKY_METHOD = 32,
            INVOCATION_FLAGS_FIELD_SPECIAL_CAST = 32,
            INVOCATION_FLAGS_NON_W8P_FX_API = 64,
            INVOCATION_FLAGS_IS_DELEGATE_CTOR = 128,
            INVOCATION_FLAGS_CONTAINS_STACK_POINTERS = 256,
            INVOCATION_FLAGS_CONSTRUCTOR_INVOKE = 268435456
        }
    }


    public abstract class AbstractClass
    {


        public void Message()
        {
            Console.WriteLine("Я абстрактный!1!!");
        }

        public AbstractClass()
        {
            Console.WriteLine("Я создан");
        }
    }
}
