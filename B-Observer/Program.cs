namespace Behavioral_Observer
{
    public interface IObserver
    {
        void Update(Object obj);
    }

    public interface ISubject
    {
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObserver();
    }

    public class Youtuber : ISubject
    {
        // Youtuber를 구독한 클래스 타입이 저장됩니다.
        private List<IObserver> _observers = new List<IObserver>();
        public string Content { get; set; }

        public Youtuber()
        {
            CreateContent();
        }

        /// <summary>
        /// 컨텐츠를 올리면 구독 중인 클래스에게 알려줍니다.
        /// </summary>
        public void CreateContent()
        {
            Content = $"New Content!! : {DateTime.Now.ToString("yyyy-MM-dd , HH:mm:ss:fffffff")}";
            NotifyObserver();
        }

        /// <summary>
        /// 구독 시 구독자 리스트에 등록합니다.
        /// </summary>
        /// <param name="subscriber">구독 클래스 타입</param>
        public void AddObserver(IObserver subscriber)
        {
            _observers.Add(subscriber);
        }

        /// <summary>
        /// 구독 해제 시 리스트에서 제거합니다.
        /// </summary>
        /// <param name="subscriber">구독 해제 클래스 타입</param>
        public void RemoveObserver(IObserver subscriber)
        {
            if (_observers.Contains(subscriber))
            {
                _observers.Remove(subscriber);
            }
        }

        /// <summary>
        /// 옵저버를 호출하는 메서드
        /// </summary>
        public void NotifyObserver()
        {
            foreach (IObserver observer in _observers)
            {
                observer.Update(this);
            }
        }
    }

    public class DisplayContents : IObserver
    {
        /// <summary>
        /// 초기화 시 구독
        /// </summary>
        /// <param name="youtuber"></param>
        public DisplayContents(Youtuber youtuber)
        {
            // 구독한 클래스의 타입을 매계 변수로 전달합니다.
            youtuber.AddObserver(this);
        }

        public void Update(object obj)
        {
            // is 키워드 : 형 변환이 가능한 여부를 불린형으로 결과값을 반환
            if (obj is Youtuber)
            {
                // as 키워드 : 형 변환이 가능하면 형변환을 수행하고, 그렇지 않으면 null 값을 대입
                var Youtuber = obj as Youtuber;
                Console.WriteLine($"Display : {Youtuber.Content}");
            }
        }
    }

    public class EmailContents : IObserver
    {
        public EmailContents(Youtuber youtuber)
        {
            youtuber.AddObserver(this);
        }

        public void Update(object obj)
        {
            if (obj is Youtuber)
            {
                var Youtuber = obj as Youtuber;
                Console.WriteLine($"Email : {Youtuber.Content}");
            }
        }
    }

    public class Program
    {
        static void Main()
        {
            // 구독하는 객체가 없으므로 알림이 안감.
            Youtuber youtuber = new Youtuber();

            // 초기화 동시에 구독.
            DisplayContents display = new DisplayContents(youtuber);
            EmailContents email = new EmailContents(youtuber);
            
            // 구독 이후 변화.
            youtuber.CreateContent();

            Thread.Sleep(500);

            youtuber.CreateContent();

            Thread.Sleep(500);

            youtuber.CreateContent();

        }
    }
}