using Brewer.Domain.Entities;
using Xunit;
using Microsoft.Extensions.Configuration;
using Brewer.Infrastructure.Data;
using System.Threading.Tasks;
using FluentAssertions;
using System;

namespace Brewer.IntegrationTests.Infrastructure.Data
{
    public class AddressRepositoryFixture
    {
        private readonly IConfiguration _configuration;

        public AddressRepositoryFixture()
        {
            _configuration = new ConfigurationBuilder()
                                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                                .Build();

            Repository = new AddressRepository(_configuration);
        }

        public AddressRepository Repository { get; }

        public Address InsertedAddress { get; set; }
    }

    public class AddressRepositoryTests : IClassFixture<AddressRepositoryFixture>
    {
        private readonly AddressRepositoryFixture _fixture;

        public AddressRepositoryTests(AddressRepositoryFixture fixture)
        {
            _fixture = fixture ?? throw new ArgumentNullException(nameof(fixture));
        }

        [Fact, Order(0)]
        public async Task Insert_Should_Store_Entity_In_Database_And_Update_Key()
        {
            var entity = new Address
            {
                Street = "Rua X",
                Number = 999,
                Cep = "99999999",
                Complement = "Ap 99",
                StateId = 1
            };

            await _fixture.Repository.Insert(entity);

            entity.Id.Should().NotBe(0);

            _fixture.InsertedAddress = entity;
        }

        [Fact, Order(1)]
        public async Task GetByKey_Should_Retrieve_Stored_Entity_From_Database()
        {
            var entity = await _fixture.Repository.GetByKey(_fixture.InsertedAddress.Id);

            entity.Should().NotBeNull();
            entity.Street.Should().Be(_fixture.InsertedAddress.Street);
            entity.Number.Should().Be(_fixture.InsertedAddress.Number);
            entity.Cep.Should().Be(_fixture.InsertedAddress.Cep);
            entity.Complement.Should().Be(_fixture.InsertedAddress.Complement);
            entity.StateId.Should().Be(_fixture.InsertedAddress.StateId);
        }
    }
}