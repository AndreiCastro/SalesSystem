using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using SalesSystem.WebApi.Controllers;
using SalesSystem.WebApi.Model;
using SalesSystem.WebApi.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestSalesSystem
{
    [TestFixture]
    public class ClienteTest
    {
        private ClienteController _controller;
        private Mock<IClienteRepository> _repository;
        List<ClienteModel> clientes;

        [SetUp]
        public void Setup()
        {
            _repository = new Mock<IClienteRepository>();
            _controller = new ClienteController(_repository.Object);

            clientes = new List<ClienteModel>
            {
                new ClienteModel
                {
                    Id = 1
                    , Nome = "Cliente1"
                    , Email = "email@teste.com"
                    , CpfCnpj = "12345678910"
                    , Logradouro = "teste"
                    , Bairro = "teste"
                    , Uf = "AC"
                    , Cep = "52478963"
                    , Cidade = "São Paulo"
                    , Telefone = "12345678"
                }
            };
        }

        [Test]
        [Category("GetCliente")]
        public async Task GetAllClientes()
        {
            // Arrange            
            _repository.Setup(x => x.GetAllClientes()).ReturnsAsync(clientes);

            // Act
            var result = await _controller.Get() as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(200));

            var clientesNull = result.Value as List<ClienteModel>;
            Assert.IsNotNull(clientesNull);
            Assert.That(clientesNull.Count, Is.EqualTo(clientes.Count));

        }
    }
}