namespace Test
{
    class C : B
    {
        public string cstring;

        public C()
        {
            this.AddToTestString();
            this.AddThirdTime();
        }
        public override void AddThirdTime()
        {
            testString = BeString + " und hier c";
        }

        public void printall()
        {
            System.Console.WriteLine(testString);
        }
    }
}
