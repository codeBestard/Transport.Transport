namespace Heaven
{
    using NServiceBus;

	public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, UsingTransport<RabbitMQTransport>
	{
	    public void Customize(BusConfiguration configuration)
	    {
	        configuration.Conventions()
                .DefiningEventsAs(t => t.Namespace != null && t.Namespace.StartsWith("Messages.Events"))
                .DefiningCommandsAs(t => t.Namespace != null && t.Namespace.StartsWith("Messages.Commands"))
                .DefiningMessagesAs(t => t.Namespace != null && t.Namespace.StartsWith("Messages.Messages"));

            configuration.EnableInstallers();

	        configuration.UsePersistence<InMemoryPersistence>();
	    }
	}
}
