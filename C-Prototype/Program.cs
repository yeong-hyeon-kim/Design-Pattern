namespace Creational_Prototype
{
    /* 생성(Creational) - 프로토타입(ProtoType) */
    // Clone을 이용하여 객체를 생성하는 방법입니다.

    public abstract class ProtoType
    {
        public abstract ProtoType Clone();
    }

    public class ConcreteProtyTypeA : ProtoType
    {
        public override ProtoType Clone()
        {
            // MemberwiseClone :  객체를 복사한 새로운 객체를 object 타입으로 반환해주는 함수입니다.
            return (ConcreteProtyTypeA)this.MemberwiseClone();
        }
    }

    public class ConcreteProtyTypeB : ProtoType
    {
        public override ProtoType Clone()
        {
            // MemberwiseClone :  객체를 복사한 새로운 객체를 object 타입으로 반환해주는 함수입니다.
            return (ConcreteProtyTypeB)this.MemberwiseClone();
        }
    }

    /// <summary>
    /// 타입을 직접 입력받아 해당 객체에 맞는 객체를 생성하는 Factory
    /// </summary>
    public class ProtoTypeFactory
    {
        private static List<ProtoType> protoTypes = new List<ProtoType>();

        /// <summary>
        /// Factory 생성 시 프로토타입에 해당하는 인스턴스를 미리 만들어서 등록합니다.
        /// </summary>
        public ProtoTypeFactory()
        {
            protoTypes.Add(new ConcreteProtyTypeA());
            protoTypes.Add(new ConcreteProtyTypeB());
        }

        /// <summary>
        /// Type을 직접 입력 받아서 해당 타입에 맞는 객체를 생성합니다.
        /// </summary>
        /// <typeparam name="T">ProtoType 타입의 객체</typeparam>
        /// <returns></returns>
        public ProtoType Create<T>() where T : ProtoType
        {
            return protoTypes.Find(pt => pt is T).Clone();
        }
    }

    public class Program
    {
        static void Main()
        {
            ProtoTypeFactory protoTypeFactory = new ProtoTypeFactory();

            var concreteProtoTypeA = protoTypeFactory.Create<ConcreteProtyTypeA>();
            var concreteProtoTypeB = protoTypeFactory.Create<ConcreteProtyTypeB>();
        }
    }
}