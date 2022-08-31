namespace TestExtensions.Ef.DataAccess
{
    public static class SQLiteContextFabric
    {
        static SQLiteContext _instancia;
        public static SQLiteContext Instancia
        {
            get { return _instancia ?? (_instancia = new SQLiteContext()); }
        }
    }
}
