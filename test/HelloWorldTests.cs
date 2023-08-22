using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Shouldly;
using Xunit;
using System;

namespace AElf.Contracts.HelloWorld
{
    // This class is unit test class, and it inherit TestBase. Write your unit test code inside it.
    public class HelloWorldTests : TestBase
    {
        [Fact]
        public async Task Update_ShouldUpdateMessageAndFireEvent()
        {
            // Arrange
            var inputValue = "Hello, World!";
            var input = new StringValue { Value = inputValue };

            // Act
            await HelloWorldStub.Update.SendAsync(input);

            // Assert
            var updatedMessage = await HelloWorldStub.Read.CallAsync(new Empty());
            updatedMessage.Value.ShouldBe(inputValue);
        }
        
        [Fact]
        public async Task Random_Test()
        {
            // Arrange
            await HelloWorldStub.CreateRandomCharacter.SendAsync(new Empty());

            var result = await HelloWorldStub.GetRandomCharacter.CallAsync(new Empty());
            result.Value.ShouldNotBeNull();
        }
    }
    
}