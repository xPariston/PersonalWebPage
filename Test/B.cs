namespace Test
{
    abstract class B : A
    {
        public string BeString;
        public override void AddToTestString()
        {
            BeString = testString + " hier spricht B";
        }

        public abstract void AddThirdTime();
    }
}
