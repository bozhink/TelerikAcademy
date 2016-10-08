namespace Methods
{
    using System;
    using System.Text.RegularExpressions;

    public class Student
    {
        private const int NumberOfCharsToTrimBirthDayDateString = 10;
        private const int MinimalLengthOfName = 2;
        private const int MaximalLengthOfName = 50;
        
        private string firstName;
        private string lastName;
        private string otherInfo;
        private DateTime birthDate;

        public Student(string firstName, string lastName, string birthDay)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.OtherInfo = birthDay;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (this.IsValidName(value))
                {
                    this.firstName = value;
                }
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (this.IsValidName(value))
                {
                    this.lastName = value;
                }
            }
        }

        public string OtherInfo
        {
            get
            {
                return this.otherInfo;
            }

            set
            {
                try
                {
                    this.birthDate = this.ConvertBirtDateString(value);
                }
                catch (FormatException)
                {
                    throw new Exception("Invalid date format for BirthDay.");
                }
                catch (Exception)
                {
                    throw new Exception("Something gone wrong with BirthDay.");
                }
                finally
                {
                    this.otherInfo = value;
                }
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return this.birthDate;
            }
        }

        public bool IsOlderThan(Student studentToCompare)
        {
            DateTime thisBirthDayDate = this.BirthDate;
            DateTime compareBirthDayDate = studentToCompare.BirthDate;
            bool isOlder = thisBirthDayDate > compareBirthDayDate;
            return isOlder;
        }

        private bool IsValidName(string name)
        {
            bool isValid = true;
            int length = name.Length;
            if (length < MinimalLengthOfName)
            {
                throw new Exception(string.Format(
                    "Name '{0}' should contain at least {1} characters.",
                    name,
                    MinimalLengthOfName));
            }

            if (length > MaximalLengthOfName)
            {
                throw new Exception(string.Format(
                    "Name '{0}' should contain no more than {1} characters.",
                    name,
                    MaximalLengthOfName));
            }

            // Check for invalid symbols
            if (Regex.Match(name, @"[,;:@#\$%&\*\^\\\/<>]").Success)
            {
                throw new Exception(string.Format(
                    "Name '{0}' should not contain special characters.",
                    name));
            }

            isValid = true;
            
            return isValid;
        }

        private DateTime ConvertBirtDateString(string date)
        {
            int birthDayLength = date.Length - NumberOfCharsToTrimBirthDayDateString;
            string birthDay = date.Substring(birthDayLength);
            DateTime birthDayDate = DateTime.Parse(birthDay);
            return birthDayDate;
        }
    }
}
