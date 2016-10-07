namespace SchoolSystem
{
    public class Mark
    {
        public Mark(Subject subject, float value) {
            this.Subject = subject;
            this.Value = value;
        }

        internal float Value { get; set; }

        internal Subject Subject { get; set; }
    }
}
