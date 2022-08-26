namespace Behavioral_Strategy
{
    /* 행위(Behavioral) - 전략(Strategy) */
    // 행동을 정의하고 캡슐화해서 각각의 행동이 추가될 때 유연하고 독립적으로 변경하여 사용할 수 있게 도와주는 패턴 입니다.
    // 코드에서 달라지는 부분을 캡슐화하는 패턴 입니다.

    // 같은 (추상)클래스를 상속하는 클래스 중 일부 클래스에만 필요한 기능이 추가될 때 사용하는 패턴 입니다.

    /// <summary>
    /// 행동 인터페이스
    /// </summary>
    public interface IMonitor
    {
        public void Internet();
    }

    /// <summary>
    /// 행동 클래스 : 클래스마다 달라지는 행동은 각각의 행동 클래스로 만들어 정의합니다. 
    /// </summary>
    public class WebSurfingUnable : IMonitor
    {
        public void Internet()
        {
            Console.WriteLine("인터넷 불가능.");
        }
    }

    /// <summary>
    /// 행동 클래스 : 클래스마다 달라지는 행동은 각각의 행동 클래스로 만들어 정의합니다. 
    /// </summary>
    public class WebSurfingAvailable : IMonitor
    {
        public void Internet()
        {
            Console.WriteLine("인터넷 가능.");
        }
    }

    public abstract class Monitor
    {
        IMonitor monitorFunction;

        public abstract void Display();

        public void ExecuteInternet()
        {
            monitorFunction.Internet();
        }

        public void SetMonitorMonitorFunction(IMonitor monitorFunction)
        {
            this.monitorFunction = monitorFunction;
        }
    }

    // Monitor를 상속받는 StandardMonitor, SmartMonitor는 인터페이스를 구현하지 않습니다.
    // 행동을 인터페이스로부터 강제받지 않아 한쪽에서는 필요하지만 다른 쪽에서는 불필한 메서드를 정의할 필요가 없습니다.

    public class StandardMonitor : Monitor
    {
        public override void Display()
        {
            Console.WriteLine("일반 모니터");
        }
    }

    public class SmartMonitor : Monitor
    {
        public override void Display()
        {
            Console.WriteLine("스마트 모니터");
        }
    }

    public class Program
    {
        static void Main()
        {
            // 클래스(전략)에 따라 행동을 변경할 수 있습니다.

            Monitor Standard = new StandardMonitor();
            // Standard에서 필요한 행동 클래스를 선택합니다.
            Standard.SetMonitorMonitorFunction(new WebSurfingUnable());
            Standard.Display();
            Standard.ExecuteInternet();

            Monitor Smart = new SmartMonitor();
            // Smart에서 필요한 행동 클래스를 선택합니다.
            Smart.SetMonitorMonitorFunction(new WebSurfingAvailable());
            Smart.Display();
            Smart.ExecuteInternet();
        }
    }
}