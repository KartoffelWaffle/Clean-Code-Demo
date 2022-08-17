namespace OracleDatabaseGateway
{
    interface IRetriever<T>
    {
        public T Retrieve();
    }
}