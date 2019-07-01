namespace ToDo.WebApp.Helpers
{
    public static class IdGenerator
    {
        private static int _lastGeneratedId = 0;
        public static int NextId { get => ++_lastGeneratedId; }
    }
}
