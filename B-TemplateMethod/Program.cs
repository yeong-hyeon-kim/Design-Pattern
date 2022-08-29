namespace Behavioral_TemplateMethod
{
    /* 행위(Behavioral) - 템플릿 메서드(Template Method) */

    // 상위 클래스에서 특정 동작의 템플릿(Template)만 정의해두고, 구체적인 단계의 동작 방법은 하위 클래스에서 재정의합니다.
    // 상위 클래스에서 하위 클래스의 흐름을 제어하는 특징을 가지고 있습니다.
    // 상위 클래스는 공통 기능을 구현한 템플릿 메서드와 하위 클래스에서 개별적(추상 메서드)으로 기능 구현할 수 있도록 규약을 지정하는 추상 메서드로 구성 됩니다.

    // 템플릿 메서드 : 훅 메서드를 포함하는 상위 클래스 메서드.
    // 훅(Hook) 메서드 : 하위 클래스에서 재정의 할 수 있게 선언된(추상 메서드) 메서드.

    public abstract class Alcohol
    {
        /// <summary>
        /// <para>주류마다 들어가는 재료가 다르니 추상 메서드를 통해 하위 클래스에서 구체화 합니다.</para>
        /// <para>protected를 사용하여 상속받는 하위 클래스에서만 사용하게 제한합니다.</para>
        /// <para>추상 메서드로 선언되어 하위 클래스에서 알맞게 확장할 수 있도록 선언된 메서드를 훅(Hook) 메서드라고 합니다.</para>
        /// </summary>
        protected abstract void AddIngredient();

        /// <summary>
        /// <para>주류마다 들어가는 재료가 다르니 추상 메서드를 통해 하위 클래스에서 구체화 합니다.</para>
        /// <para>protected를 사용하여 상속받는 하위 클래스에서만 사용하게 제한합니다.</para>
        /// <para>추상 메서드로 선언되어 하위 클래스에서 알맞게 확장할 수 있도록 선언된 메서드를 훅(Hook) 메서드라고 합니다.</para>
        /// </summary>
        protected abstract void StartMakeAlcoholBeverage();

        /// <summary>
        /// <para>주류마다 들어가는 재료가 다르니 추상 메서드를 통해 하위 클래스에서 구체화 합니다.</para>
        /// <para>protected를 사용하여 상속받는 하위 클래스에서만 사용하게 제한합니다.</para>
        /// <para>추상 메서드로 선언되어 하위 클래스에서 알맞게 확장할 수 있도록 선언된 메서드를 훅(Hook) 메서드라고 합니다.</para>
        /// </summary>
        protected abstract void EndMakeAlcoholBeverage();

        /// <summary>
        /// 주류 제조 시 공통 기능은 실제 구현합니다.
        /// </summary>
        public void Fermentation()
        {
            Console.WriteLine("발효 시키기.");
        }

        /// <summary>
        /// 주류 제조 시 공통 기능은 실제 구현합니다.
        /// </summary>
        public void BoilWater()
        {
            Console.WriteLine("물 끓이기");
        }

        /// <summary>
        /// 주류 제조 시 공통 기능은 실제 구현합니다.
        /// </summary>
        public void PourInCup()
        {
            Console.WriteLine("컵에 따르기");
        }

        /// <summary>
        /// 템플릿 메서드(Template Method)
        /// </summary>
        public void Recipe()
        {
            StartMakeAlcoholBeverage();
            AddIngredient();
            Fermentation();
            BoilWater();
            PourInCup();
            EndMakeAlcoholBeverage();
        }
    }

    public class Wine : Alcohol
    {
        protected override void AddIngredient()
        {
            Console.WriteLine("포도");
        }

        protected override void StartMakeAlcoholBeverage()
        {
            Console.WriteLine("포도주 만들기...");
        }

        protected override void EndMakeAlcoholBeverage()
        {
            Console.WriteLine("포도주 완성!");
        }
    }

    public class Beer : Alcohol
    {
        protected override void AddIngredient()
        {
            Console.WriteLine("보리");
        }

        protected override void StartMakeAlcoholBeverage()
        {
            Console.WriteLine("맥주 만들기...");
        }

        protected override void EndMakeAlcoholBeverage()
        {
            Console.WriteLine("맥주 완성!");
        }
    }

    public class Program
    {
        static void Main()
        {
            Alcohol AlcoholWine = new Wine();
            AlcoholWine.Recipe();

            Alcohol AlcoholBeer = new Beer();
            AlcoholBeer.Recipe();
        }
    }
}