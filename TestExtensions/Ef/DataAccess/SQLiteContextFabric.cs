namespace TestExtensions.Ef.DataAccess
{
    public static class SQLiteContextFabric
    {
        internal static SQLiteContext _instance;
        public static SQLiteContext Instance
        {
            get 
            { 
                return _instance ??= new SQLiteContext(); 
            }
        }
    }
}