namespace Structural_Adapter
{
    /* 구조(Structural) - 어댑터(Adapter) / 클래스 어댑터, 객체 어댑터 */
    // 콘센트 어뎁터가 국가마다 다른 전원 소켓을 전자 제품에 알맞은 전원 소켓으로 맞춰주는 것을 생각하시면 됩니다.
    // 인터페이스 호환성 문제(Type이 다른)때문에 같이 쓸 수 없는 클래스들을 연결해서 사용할 수 있게 만드는 것이 목적입니다.

    // 클라이언트 코드 수정 없이 타입이 서로 다른 코드를 이용하게 하는 것이 어댑터 사용 목적입니다.

    #region 클래스에 의한 어댑터
    public interface Samsung
    {
        void call();
        void message();
        void samsung_pay();
    }

    public interface Apple
    {
        void call();
        void message();
        void apple_pay();
    }

    public class Galaxy : Samsung
    {
        public void call()
        {
            Console.WriteLine("Galaxy : 전화");
        }

        public void message()
        {
            Console.WriteLine("Galaxy : 메시지");
        }

        public void samsung_pay()
        {
            Console.WriteLine("Galaxy : 삼성 페이");
        }
    }

    public class IPhone : Apple
    {
        public void call()
        {
            Console.WriteLine("IPhone : 전화");
        }

        public void message()
        {
            Console.WriteLine("IPhone : 메시지");
        }
        public void apple_pay()
        {
            Console.WriteLine("IPhone : 애플 페이");
        }
    }

    public class IPhoneAdapter : Samsung
    {
        IPhone phone;

        public IPhoneAdapter(IPhone phone)
        {
            this.phone = phone;
        }

        public void call()
        {
            phone.call();
        }

        public void message()
        {
            phone.message();
        }

        public void samsung_pay()
        {
            phone.apple_pay();
        }
    }

    #endregion

    #region 인스턴스에 의한 어댑터

    public interface SamsungPay
    {
        string GetCardNumber();
        void SetCardNumber(string CardNumber);
    }

    public interface ApplePay
    {
        string GetUserCardNum();
        void SetUserCardNum(string UserCardNum);
    }

    public class SinglePay : SamsungPay
    {
        private string CardNumber;

        public string GetCardNumber()
        {
            Console.WriteLine("GET : SamsungPay");

            return CardNumber;
        }

        public void SetCardNumber(string CardNumber)
        {
            Console.WriteLine("SET : SamsungPay");
            this.CardNumber = CardNumber;
        }
    }

    /// <summary>
    /// 어댑터(Adapter)
    /// </summary>
    public class MultiPay : SamsungPay, ApplePay
    {
        private string CardNumber;

        // Samsung Pay
        public string GetCardNumber()
        {
            Console.WriteLine("Samsung Pay CardNumber");
            return CardNumber;
        }

        public void SetCardNumber(string CardNumber)
        {
            this.CardNumber = CardNumber;
        }

        // Apple Pay

        public string GetUserCardNum()
        {
            return GetCardNumber();
        }

        public void SetUserCardNum(string UserCardNum)
        {
            SetCardNumber(UserCardNum);
        }
    }

    #endregion

    public class Program
    {
        static void Main()
        {
            // 클래스에 의한 어댑터
            Galaxy galaxy = new Galaxy();
            IPhone iphone = new IPhone();

            Samsung iPhoneAdapter = new IPhoneAdapter(iphone);

            Console.WriteLine("갤럭시 사용");
            UseTest(galaxy);

            Console.WriteLine("아이폰 사용");
            UseTest(iPhoneAdapter);

            // 인스턴스에 의한 어댑터
            MultiPay pays = new MultiPay();

            // 일반적으로는 Samsung Pay, Apple Pay 메서드 명이 달라 각각 선언이 필요합니다.
            //pays.SetCardNumber("12345");
            //pays.GetCardNumber();

            // Apple Pay 메서드를 오버라이딩 할때 Samsung Pay 메서드를 호출하도록 함수 내용을 바꿔줍니다.

            // 어댑터에서 SetUserCardNum, GetUserCardNum를 호출할때 어떤 메서드를 사용할지만 바꿔주면
            // 클라이언트 코드 수정 없이 타입이 다른 메서드를 사용할 수 있습니다.
            pays.SetUserCardNum("12345");
            pays.GetUserCardNum();
        }

        static void UseTest(Samsung samsung)
        {
            // 삼성(Samsung) 타입(Type)으로 애플(Apple) 타입(Type)인 아이폰(IPhone)을 사용할 수 있습니다.
            samsung.call();
            samsung.message();
            samsung.samsung_pay();
        }
    }
}