using MensageryLib.Services;
using System;

namespace MensageryLibTests
{
    public class MensageryTest
    {

        string host = "localhost";
        string userName = "guest";
        string password = "guest";
        int port = 5682;





        [Fact]
        public void Mensagery_CreateExchange_ReturnsTrue()
        {
            bool result = false;
            // Arrange
            MensageryImp mensagery = new Mensagery(host, userName, password, port);

            // Act
            if (mensagery != null) 
                result = mensagery.CreateExchange("ExgTeste2");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Mensagery_CreateExchange_ReturnsFalse()
        {
            bool result = false;
            // Arrange
            MensageryImp mensagery = new Mensagery(host, userName, password, port);

            // Act
            if (mensagery != null)
                result = mensagery.CreateQueue("ExgTeste2");

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Mensagery_CreateQueue_ReturnsTrue()
        {
            bool result = false;
            // Arrange
            MensageryImp mensagery = new Mensagery(host, userName, password, port);

            // Act
            if(mensagery != null)
                result = mensagery.CreateQueue("QueueTeste2");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Mensagery_CreateQueue_ReturnsFalse()
        {
            bool result = false;
            // Arrange
            MensageryImp mensagery = new Mensagery(host, userName, password, port);

            // Act
            if (mensagery != null) 
                result = mensagery.CreateQueue("QueueTeste2");

            // Assert
            Assert.False(result);
        }


        [Fact]
        public void Mensagery_BindQueue_ReturnsTrue()
        {
            bool result = false;
            // Arrange
            MensageryImp mensagery = new Mensagery(host, userName, password, port);

            // Act
            if (mensagery != null) 
                result = mensagery.BindQueue("ExgTeste2","QueueTeste2", "testBind");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Mensagery_BindQueue_ReturnsFalse()
        {
            bool result = false;
            // Arrange
            MensageryImp mensagery = new Mensagery(host, userName, password, port);

            // Act
            if (mensagery != null) 
                mensagery.BindQueue( "ExgTeste2","QueueTeste2654654", "testBind");

            // Assert
            Assert.False(result);
        }
        
        [Fact]
        public async void Mensagery_Publish_ReturnsTrue()
        {
            bool result = false;
            // Arrange
            MensageryImp mensagery = new Mensagery(host, userName, password, port);

            // Act
            if (mensagery != null) 
                result = await mensagery.SendMessage<string>("simpleTest", "ExgTeste2", "testBind");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async void Mensagery_Publish_ReturnsFalse()
        {
            bool result = false;
            // Arrange
            MensageryImp mensagery = new Mensagery(host, userName, password, port);

            // Act
            if (mensagery != null)
                result = await mensagery.SendMessage<string>("simpleTest", "ExgTeste2124124", "testNotBinder");

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async void Mensagery_Consume_ReturnsTrue()
        {
            bool result = false;
            // Arrange
            MensageryImp mensagery = new Mensagery(host, userName, password, port);

            // Act
            if (mensagery != null) 
                result = mensagery.ConsumeQueu<string>("simpleTest");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Mensagery_Consume_ReturnsFalse()
        {
            bool result = false;
            // Arrange
            MensageryImp mensagery = new Mensagery(host, userName, password, port);

            // Act
            if (mensagery != null) 
                result = mensagery.ConsumeQueu<string>("NotAValidQueue");

            // Assert
            Assert.False(result);
        }



    }
}