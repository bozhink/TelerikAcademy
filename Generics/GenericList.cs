namespace Generics
{
    using System;

    public class GenericList<T> where T : IComparable<T>
    {
        private const int InitialCapacity = 5;
        private int capacity;

        private T[] elements;

        public GenericList()
        {
            this.Initialize(InitialCapacity);
        }

        public GenericList(int capacity)
        {
            this.Initialize(capacity);
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentException(nameof(this.Capacity));
                }

                this.capacity = value;
            }
        }

        public int Count { get; private set; }

        private int CountWithValidation
        {
            get
            {
                if (this.Count < 1)
                {
                    throw new ApplicationException("There are no elements in this list");
                }

                return this.Count;
            }
        }

        public void AddAtIndex(int index, T element)
        {
            if (0 > index || index > this.Count)
            {
                throw new IndexOutOfRangeException($"Invalid index: {index}.");
            }

            if (index >= this.Capacity)
            {
                this.DoubleSize();
            }

            for (int i = this.Count - 1; i >= index; --i)
            {
                this.elements[i] = this.elements[i - 1];
            }

            this.elements[index] = element;
            this.Count++;
        }

        public void AddElement(T element)
        {
            if (this.Count == this.Capacity)
            {
                this.DoubleSize();
            }

            this.elements[this.Count] = element;
            this.Count++;
        }

        public void Clear()
        {
            this.elements = new T[this.Capacity];
            this.Count = 0;
        }

        public T Max()
        {
            int count = this.CountWithValidation;

            T maximalElement = this.elements[0];

            for (int i = 1; i < count; ++i)
            {
                if (maximalElement.CompareTo(this.elements[i]) < 0)
                {
                    maximalElement = this.elements[i];
                }
            }

            return maximalElement;
        }

        public T Min()
        {
            int count = this.CountWithValidation;

            T minimalElement = this.elements[0];

            for (int i = 1; i < count; ++i)
            {
                if (minimalElement.CompareTo(this.elements[i]) > 0)
                {
                    minimalElement = this.elements[i];
                }
            }

            return minimalElement;
        }

        public void RemoveAtIndex(int index)
        {
            if (0 > index || index >= this.CountWithValidation)
            {
                throw new IndexOutOfRangeException($"Invalid index: {index}.");
            }

            for (int i = index; i < this.Count - 1; ++i)
            {
                this.elements[i] = this.elements[i + 1];
            }

            this.Count--;
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", this.elements, 0, this.Count)}]";
        }

        private void DoubleSize()
        {
            this.Capacity *= 2;
            var newElements = new T[this.Capacity];
            for (int i = 0; i < this.Count; ++i)
            {
                newElements[i] = this.elements[i];
            }

            this.elements = newElements;
        }

        private void Initialize(int capacity)
        {
            this.Count = 0;
            this.Capacity = capacity;
            this.elements = new T[this.Capacity];
        }
    }
}
