namespace SchoolSystem.Core
{
    using System;
    using System.Collections.Generic;
    using Constants;

    public class Collection<T> : List<T>, ICollection<T>
    {
        void ICollection<T>.Add(T item)
        {
            int numberOfItems = this.Count;
            if (numberOfItems >= ValidationConstants.MaximalNumberOfStudentMarks)
            {
                // TODO: message
                throw new ArgumentOutOfRangeException(nameof(this.Add));
            }

            this.Add(item);
        }
    }
}
