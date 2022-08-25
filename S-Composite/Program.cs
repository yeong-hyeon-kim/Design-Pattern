namespace Structural_Composite
{
    /* 구조(Structural) - 컴포지트(Composite) / 트리(Tree) */

    // 컴포지트(Composite)는 합성물을 의미합니다. 
    // 컴포넌트(Component)는 요소를 의미합니다.

    // 컴포넌트(Component)들을 합쳐놓은 것을 컴포지트(Composite)라 할 수 있습니다.
    // 각각의 클래스(컴포넌트)들 합쳐놓은 클래스(컴포지트)에서 모든 클래스를 관리할 수 있습니다.

    // > 컴포지트(Composite)는 클래스 계층(Hierarchy)화라고 할 수 있습니다. 
    // 유사한 클래스를 일반(분류)화해 관리하면 유지보수 측면에서 편리합니다.

    public interface IChannel
    {
        public void Show();
    }

    public class ChannelComposite : IChannel
    {
        private List<IChannel> _channels = new List<IChannel>();

        public void Show()
        {
            foreach (IChannel channel in _channels)
            {
                channel.Show();
            }
        }

        public void Add(IChannel channel)
        {
            _channels.Add(channel);
        }

        public void Remove(IChannel channel)
        {
            _channels.Add(channel);
        }

    }

    public class Channel : IChannel
    {
        private string Messages;

        public Channel(string messages)
        {
            Messages = messages;
        }

        public void Show()
        {
            Console.WriteLine(Messages);
        }
    }

    public class Program
    {
        static void Main()
        {
            // 채널 객체 생성
            Channel ch1 = new Channel("1");
            Channel ch2 = new Channel("2");
            Channel ch3 = new Channel("3");
            Channel ch4 = new Channel("4");
            Channel ch5 = new Channel("5");

            // 컴포지트(Composite) 객체 생성
            ChannelComposite channelComposite1 = new ChannelComposite();
            ChannelComposite channelComposite2 = new ChannelComposite();

            // 컴포지트(Composite)에 객체 할당
            channelComposite1.Add(ch1);
            channelComposite1.Add(ch2);
            // 트리(Tree) 구조
            channelComposite1.Add(channelComposite2);

            channelComposite2.Add(ch3);
            channelComposite2.Add(ch4);
            channelComposite2.Add(ch5);

            ch1.Show();

            channelComposite1.Show();
            channelComposite2.Show();
        }
    }
}