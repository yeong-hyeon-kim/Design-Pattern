namespace Creational_FactoryMethod
{
    /* 생성(Creational) - 팩토리 메서드(Factory Method) */

    // 객체를 생성하는 방법을 해당 클래스를 상속 받는 클래스에서 명시하도록 합니다.
    // 객체를 생성(인스턴스) 할때 인스턴스를 어떤 타입(Class)으로 할지를 서브 클래스가 결정하도록 위임합니다.

    /* 팩토리 메서드(Factory Method) */
    // Product - 가장 기본이 되는 타입, 일반화 시킬 수 있는 가장 큰 분류
    // Ex. 자동차, 동물, 식물

    // ConcreteProduct - Product를 상속 받는 클래스
    // Ex. 자동차 > 아반떼, 쏘나타
    //     동물   > 사자, 호랑이, 고양이
    //     식물   > 양배추, 양상추

    // Creator - Product를 생성하는 메서드가 있는 클래스

    // ConcreteCreator - Creator를 상속 받아 ConcreteProduct를 구현하는 메서드가 있는 클래스


    /// <summary>
    /// Product
    /// </summary>
    public abstract class Shpae
    {
        public abstract double GetArea();
    }

    /// <summary>
    /// ConcreteProduct : Product Shpae 클래스를 상속.
    /// </summary>
    public class Circle : Shpae
    {
        public double Radius;

        public override double GetArea()
        {
            return 2 * Math.PI * Radius;
        }
    }

    /// <summary>
    /// ConcreteProduct : Product Shpae 클래스를 상속.
    /// </summary>
    public class Ractangle : Shpae
    {
        public double Width, Height;
        public override double GetArea()
        {
            return Width * Height;
        }
    }

    /// <summary>
    /// Creator : Product Shpae를 생성하는 메서드가 있는 클래스
    /// </summary>
    public abstract class ShapeCreator
    {
        // 객체를 생성(인스턴스) 할때 인스턴스를 어떤 타입(Class)으로 할지를 서브 클래스가 결정하도록 위임합니다.
        // 인터페이스 없이 인터페이스를 구현.
        // 추상 메서드를 인터페이스 처럼 이용.
        public abstract Shpae Create();
    }

    /// <summary>
    /// ConcreteCreator : Creator Shpae를 상속받아 ConcreteProduct Circle을 구현하는 메서드가 있는 클래스
    /// </summary>
    public class CircleCreator : ShapeCreator
    {
        public override Shpae Create()
        {
            // 객체 생성을 ConcreteProduct 한 곳에서 관리하며 동일한 생성(같은 주소 값)을 보장합니다.
            // ConcreteProduct에서만 생성 코드를 넣습니다.
            return new Circle();
        }
    }

    public class AnyCreator : ShapeCreator
    {
        public override Shpae Create()
        {
            Console.WriteLine(new Circle());
            Console.WriteLine(new Ractangle());

            return new Ractangle();
        }
    } 

    /// <summary>
    /// ConcreteCreator : Creator Shpae를 상속받아 ConcreteProduct Ractangle을 구현하는 메서드가 있는 클래스
    /// </summary>
    public class RactangleCreator : ShapeCreator
    {
        public override Shpae Create()
        {
            return new Ractangle();
        }
    }

    class Program
    {
        static void Main()
        {
            RactangleCreator rc = new RactangleCreator();
            RactangleCreator cc = new RactangleCreator();

            Console.WriteLine(rc.Create());
            Console.WriteLine(cc.Create());
        }
    }
}