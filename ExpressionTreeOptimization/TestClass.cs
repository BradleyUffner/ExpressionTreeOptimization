namespace ExpressionTreeOptimization {
    public class TestClass
    {
        public string Name { get; set; }
        public int Key { get; set; }
        public bool IsAwesome { get; set; }

        public SubData SubData { get; set; } = new SubData();
    }

    public class SubData
    {
        public bool TrueProp { get; set; } = true;
        public bool FalseProp { get; set; } = false;
    }
}