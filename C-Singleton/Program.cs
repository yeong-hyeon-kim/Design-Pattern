namespace Creational_Singleton
{
    /* 생성(Creational) - 싱글턴(Singleton) */
    public class Singleton
    {
        private static Singleton staticSingleton;

        public static Singleton Instance()
        {
            // 객체가 null 인 경우에만 인스턴스를 생성합니다. 
            if (staticSingleton == null)
            {
                staticSingleton = new Singleton();
            }

            // 객체가 null이 아니라면 생성하지 않고 반환만 합니다.
            return staticSingleton;
        }
    }

    class Program
    {
        static void Main()
        {
            // 객체 생성은 해당 클래스가 담당합니다.

            /* 일반적인 객체 생성 - New */
            // new 를 이용하여 만들 때마다 서로 다른 객체(주소 값)을 가지게 됩니다.
            // var objectA =  new Singleton();

            /* Singleton - Return */
            // 객체가 null인 경우를 제외하고
            // 프로그램 실행 시 정적으로 선언된 Singleton 클래스(Class) 객체이므로 동일한 객체를 반환합니다.
            // 매번 생성하지 않고 생성된 객체가 있으면 반환만 합니다.

            // A, B 모두 같은 객체(주소 값)
            var objectA = Singleton.Instance();
            var objectB = Singleton.Instance();

            var objectC = new Singleton();

            unsafe
            {
                TypedReference trA = __makeref(objectA);
                TypedReference trB = __makeref(objectB);
                TypedReference trC = __makeref(objectC);

                IntPtr ptrA = **(IntPtr**)(&trA);
                IntPtr ptrB = **(IntPtr**)(&trB);
                IntPtr ptrC = **(IntPtr**)(&trC);

                // 싱글톤을 사용한 A, B는 주소 값이 동일하지만 New를 이용한 C는 주소 값이 다릅니다.
                Console.WriteLine("objectA(Singleton) : {0},\nobjectB(Singleton) : {1},\nobjectC(New) : {2}", ptrA, ptrB, ptrC);
            }
        }
    }
}