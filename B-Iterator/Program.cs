using System.Collections;

namespace Behavioral_Iterator
{
    /* 행위(Behavioral) - 반복(Iterator) */
    // 컬렉션이나 집합 객체의 내부적인 구현 방법을 숨기면서 그 안에 있는 모든 원소에 순차적으로 접근할 수 있는 수단을 제공합니다.
    // 모든 항목에 일일이 접근하는 작업을 컬렉션 객체가 아닌 이터레이터 객체에서 맡게 됩니다.
    // 이터레이터가 반복 작업을 처리하므로 원래 자신이 할 일에만 집중할 수 있습니다.

    /// <summary>
    /// Iterator : 원소를 접근하고 순회하는 데 필요한 인터페이스(IEnumerator)를 제공합니다.
    /// </summary>
    public abstract class Iterator : IEnumerator
    {
        // IEnumerator 구현.
        object IEnumerator.Current => Current();
        public abstract int Key();

        public abstract object Current();

        public abstract bool MoveNext();

        public abstract void Reset();
    }

    /// <summary>
    /// IterableCollection : Iterator 객체를 생성하는 인터페이스를 정의합니다.
    /// </summary>
    public abstract class IteratorAggregate : IEnumerable
    {
        public abstract IEnumerator GetEnumerator();
    }

    /// <summary>
    /// ConcreteCollection : 해당하는 ConcreteIterator의 인스턴스를 반환하는 Iterator 생성 인터페이스를 구현합니다.
    /// </summary>
    public class WordCollection : IteratorAggregate
    {
        List<string> Collection = new List<string>();
        bool Direction = false;

        public void ReverseDirection()
        {
            Direction = !Direction;
        }

        public List<string> GetItems()
        {
            return Collection;
        }

        public void AddItem(string Item)
        {
            Collection.Add(Item);
        }


        public override IEnumerator GetEnumerator()
        {
            return new AlphabeticalOrderIterator(this, Direction);
        }
    }

    /// <summary>
    /// ConcreteIterator : Iterator에 정의된 인터페이스를 구현하는 클래스 입니다.
    /// </summary>
    public class AlphabeticalOrderIterator : Iterator
    {
        private WordCollection wordCollection;
        private int position = -1;
        private bool reverse = false;

        public AlphabeticalOrderIterator(WordCollection collection, bool reverse = false)
        {
            wordCollection = collection;
            this.reverse = reverse;

            if (reverse)
            {
                this.position = collection.GetItems().Count;
            }
        }

        public override object Current()
        {
            return wordCollection.GetItems()[position];
        }
        public override int Key()
        {
            return position;
        }

        public override bool MoveNext()
        {
            int updatedPosition = position + (reverse ? -1 : 1);

            if (updatedPosition >= 0 && updatedPosition < wordCollection.GetItems().Count)
            {
                position = updatedPosition;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Reset()
        {
            position = reverse ? wordCollection.GetItems().Count - 1 : 0;
        }
    }


    /// <summary>
    /// Client
    /// </summary>
    public class Program
    {
        static void Main()
        {
            var collection = new WordCollection();

            collection.AddItem("1");
            collection.AddItem("2");
            collection.AddItem("3");

            Console.WriteLine("정방향");

            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("역방향");

            collection.ReverseDirection();

            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}