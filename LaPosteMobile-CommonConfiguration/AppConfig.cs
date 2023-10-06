namespace LaPosteMobile_CommonConfiguration
{
    public static class AppConfig
    {
        public const string RabbitMQUri = "amqp://guest:guest@localhost:5672";
        public const string ClientProvidedName = "la poste mobile";
        public const string MailQueue= "mail-queue";
        public const string MailroutingKey = "mail-routing-key";
        public const string ContratQueue= "contrat-queue";
        public const string ContratRoutingKey = "contrat-routing-key";
        public const string SapQueue = "sap-queue";
        public const string ExchangeName = "LaposteExchange";
        public const string SapRoutingKey = "sap-routing-key";
        public const string SapConfirmationQueue = "confirmation-queue";
        public const string SapConfirmationRoutingKey = "contrat-confirm-routing-key";
        public const string SapConfirmationmessage = "processed";
    }
}