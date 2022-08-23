namespace Structural_Decorator
{
    /* 구조(Structural) - 데코레이터(Decorator) */

    // 함수(컴포넌트 : Component) 내부를 수정하지 않고 기능 확장이 필요할 때 사용합니다.
    // 데코레이터는 코드 수정 없이 또다른 기능들을 첨가할 때 사용합니다.

    // 데코레이션(Decoration)
    // 피자에 토핑을 첨가(추가)하는 것을 의미합니다.
    // -> 함수(피자)에 기능(토핑)을 추가하는 것을 의미합니다.

    // 데코레이터(Decorator)는 데코레이션(Decoration) 할 수 있게 만들어 줍니다.
    // 데코레이션을 할려면 데코레이션 할 객체의 타입이어야합니다.
    // -> 객체를 데코레이션(Decoration) 할 수 있게 만들어 주는 데코레이터(Decorator) 클래스

    // 커피 원두에 우유를 첨가하고 모카를 첨가하니 모카라떼.
    // Ex. 커피 원두 + 우유 + 모카

    /// <summary>
    /// 일반화 시킬 수 있는 가장 큰 분류
    /// </summary>
    public abstract class Beverage
    {
        protected string description = string.Empty;
        public virtual string GetDescription()
        {
            return description;
        }

        public abstract double Cost();
    }

    /// <summary>
    /// 데코레이터(Decorator)가 음료(Beverage) 구조를 전달.
    /// </summary>
    public abstract class Decorator : Beverage
    {
        public abstract override string GetDescription();
    }

    /// <summary>
    /// 컴포넌트(Component) : 꾸며질 대상
    /// </summary>
    public class Espresso : Beverage
    {
        /// <summary>
        /// 에스프레소 : 원두
        /// </summary>
        public Espresso()
        {
            description = "Espresso";
        }

        public override double Cost()
        {
            return 1.2;
        }
    }

    /// <summary>
    /// Milk는 Beverage를 상속받고 있으므로 데코레이터가 필요 없습니다.
    /// </summary>
    public class Milk : Beverage
    {
        private Beverage beverage;

        /// <summary>
        /// Beverage 타입의 객체
        /// </summary>
        /// <param name="beverage"></param>
        public Milk(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override double Cost()
        {
            return beverage.Cost() + 0.5;
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + " + Milk";
        }
    }

    // 기본 객체에 기능(데이터)를 첨가하려면 데코레이터가 필요합니다.
    // 데코레이터가 음료(Beverage) 구조를 전달해주기 때문입니다.

    /// <summary>
    /// 모카(Mocha)는 음료(Beverage)를 상속하는 대신 음료(Beverage) 구조를 강제하는 데코레이터(Decorator)를 상속받고 있습니다.
    /// </summary>
    public class Mocha : Decorator
    {
        private Beverage beverage;

        public Mocha(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override double Cost()
        {
            // 기존 객체(자신을 감싼)에 기능(데이터)을 추가합니다.
            return beverage.Cost() + 0.20;
        }

        public override string GetDescription()
        {
            // 기존 객체(자신을 감싼)에 기능(데이터)을 추가합니다.
            return beverage.GetDescription() + " + 모카";
        }
    }

    public class Vanilla : Decorator
    {
        private Beverage beverage;

        public Vanilla(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override double Cost()
        {
            // 기존 객체(자신을 감싼)에 기능(데이터)을 추가합니다.
            return beverage.Cost() + 0.5;
        }

        public override string GetDescription()
        {
            // 기존 객체(자신을 감싼)에 기능(데이터)을 추가합니다.
            return beverage.GetDescription() + " + 바닐라";
        }
    }

    public class Program
    {
        static void Main()
        {
            /* 데코레이터(Decorator) 사용 */
            // 데코레이터만 Beverage를 상속 받고 모든 객체는 데코레이터를 상속받고 있습니다.
            // Vanilla    : Decorator
            // Espresso   : Decorator
            // Cappuccino : Decorator
            // FlatWhite  : Decorator

            /* 데코레이터(Decorator) 미사용 */
            // 모든 객체가 Beverage를 상속 받습니다.
            // Vanilla    : Beverage
            // Espresso   : Beverage
            // Cappuccino : Beverage
            // FlatWhite  : Beverage

            // 기본이 되는 객체.
            Beverage espresso = new Espresso();

            // 커피 원두 객체에 상황에 따른 재료를 추가해 다양한 음료를 만들 수 있습니다.
            // 에스프레소(Espresso)에 모카(Mocha) 넣고 우유(Milk) 넣은 모카 라떼는 음료(Beverage)라고 할 수 있습니다.
            Beverage CafeLatte = new Milk(new Mocha(espresso));

            Console.WriteLine("가격 : " + CafeLatte.Cost());
            Console.WriteLine("성분 : " + CafeLatte.GetDescription());

            // 에스프레소(Espresso)에 바닐라(Vanilla) 넣고 우유(Milk) 넣은 바닐라 라떼는 음료(Beverage)라고 할 수 있습니다.
            Beverage VanillaLatte = new Milk(new Vanilla(espresso));

            Console.WriteLine("가격 : " + VanillaLatte.Cost());
            Console.WriteLine("성분 : " + VanillaLatte.GetDescription());

            /* 데코레이터(Decorator) 미사용 */
            // 음료를 만들려면 각각 메뉴마다 객체를 만들어야 합니다.
            // Beverage Espresso = new Espresso();
            // Beverage VanillaLatte = new VanillaLatte();

            /* 데코레이터(Decorator) 사용 */
            // 재료(객체)만 바꿔주면 모카 라떼든 바닐라 라떼든 만들 수가 있습니다.
            // 하나의 객체가 여러가지 음료가 될 수 있습니다.
            // Beverage Latte = new Milk(new Mocha(espresso)); OR new Milk(new Vanilla(espresso));
        }
    }
}