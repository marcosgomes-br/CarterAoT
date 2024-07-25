using Core.DTOs;
using Infrastructure.Services;
using Moq.AutoMock;

namespace TestAPIMinimal
{
    public class TestServiceTest
    {
        private readonly AutoMocker _mocker = new();
        private readonly TestService _testService;

        public TestServiceTest() {
            _testService = _mocker.CreateInstance<TestService>();
        }

        [Fact]
        public async void InputPost_IsValid()
        {
            //Arrange
            InputPostDTO inputPostDTO = new() {
                UserId = 15,
                Title = "TestTitle",
                Body = "TestBody",
                Idade = 19,
            };

            //Action
            var result = await _testService.InputPost(inputPostDTO);

            //Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);

            Assert.Equal(inputPostDTO.Title, result.Value.Title);
            Assert.Equal(inputPostDTO.Body, result.Value.Body);
            Assert.Equal(inputPostDTO.UserId, result.Value.UserId);
            Assert.Equal(inputPostDTO.Idade , result.Value.Idade);


            Assert.Equal(123445, result.Value.Id);
            Assert.True(result.Value.Id > 0);

            Assert.NotNull(result.Value.Title);
            Assert.NotEmpty(result.Value.Title);

            Assert.NotNull(result.Value.Body);
            Assert.NotEmpty(result.Value.Body);
        }

        [Fact]
        public async void InputPost_isBodyAndTitleareNullorEmpty() {
            //Arrange
            InputPostDTO inputPostDTO = new()
            {
                UserId = 15,
                Title = "",
                Idade = 19,
            };


            //Action
            var result = await _testService.InputPost(inputPostDTO);

            //Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);

            Assert.True(string.IsNullOrEmpty(inputPostDTO.Title));
            Assert.True(string.IsNullOrEmpty(inputPostDTO.Body));
        }

        [Fact]
        public void IsNotMinor() {
            //Arrange
            int idade = 19;

            //Action
            bool isNotMinor = _testService.ValidarIdade(idade);

            //Assert
            Assert.True(isNotMinor);

        }


        [Theory]
        [InlineData(17)]
        [InlineData(13)]
        [InlineData(9)]
        public void IsMinor(int value)
        {
            //Arrange
            int idade = value;

            //Action
            bool isNotMinor = _testService.ValidarIdade(idade);

            //Assert
            Assert.False(isNotMinor);

        }
    }
}