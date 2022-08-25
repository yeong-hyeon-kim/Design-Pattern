/* 구조(Structural) - 퍼사드(Facade) */
// 복잡한 내부 로직을 감추고 클라이언트가 쉽게 접근할 수 있는 인터페이스를 제공합니다.
// 자판기에서 상품을 구매하기 위해 버튼을 누를 뿐 상품이 나오는 과정을 알 필요는 없습니다.

public class CPU
{
    public void Process()
    {
        Console.WriteLine("Processing...");
    }
}

public class Memory
{
    public void Load()
    {
        Console.WriteLine("Loading...");
    }
}

public class Storage
{
    public void Read()
    {
        Console.WriteLine("Reading...");
    }
}

/// <summary>
/// 퍼사드(Facade)
/// </summary>
public class Computer
{
    private CPU _CPU;
    private Memory _Memory;
    private Storage _Storage;

    public Computer()
    {
        _CPU = new CPU();
        _Memory = new Memory();
        _Storage = new Storage();
    }

    /// <summary>
    /// <para>컴퓨터 부팅은 Process, Load, Read 메서드가 필요하지만</para>
    /// <para>퍼사드로 클라이언트는 Run 메서드로 부팅할 수 있습니다.</para>
    /// </summary>
    public void Run()
    {
        _CPU.Process();
        _Memory.Load();
        _Storage.Read();
    }
}

public class Program
{
    static void Main()
    {
        Computer _Computer = new Computer();
        _Computer.Run();
    }
}