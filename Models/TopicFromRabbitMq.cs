using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using quizartsocial_backend.Models;
using quizartsocial_backend;
using quizartsocial_backend.Services;

namespace SocialServer.Consumers
{
    public class TopicConsumer : ITopicFromRabbitMq
    {
    
        private IServiceProvider _serviceProvider;
        public TopicConsumer(IServiceProvider serviceProvider, GraphDb graph)
        {
            _serviceProvider = serviceProvider;
            GetTopicsFromRabbitMQ();
        }
        public void GetTopicsFromRabbitMQ()
        {
            var factory = new ConnectionFactory() { HostName = "rabbitmq", Port = 5672, UserName = "rabbitmq", Password = "rabbitmq" };
            // var factory =new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            
            channel.QueueDeclare(queue: "Topic", durable: false, exclusive: false, autoDelete: false, arguments: null);
            
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                try 
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(message);
                    Topic obj = new Topic();
                    obj.topicName = message;
                    Console.WriteLine(" [x] Received {0}", message);
                    using(var topicRepo = this._serviceProvider.GetRequiredService<ITopic>())
                    {
                        topicRepo.AddTopicToDBAsync(obj);
                    }
                }
                catch (System.Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                }
            };
            channel.BasicConsume(queue: "Topic", autoAck: true, consumer: consumer);
            Console.WriteLine(" Press [enter] to exit.");
        }
    
    }
}