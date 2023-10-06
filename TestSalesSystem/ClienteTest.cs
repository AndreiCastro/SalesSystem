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
        List<ClienteModel> clientes = new List<ClienteModel>();
        ClienteModel cliente = new ClienteModel();

        [SetUp]
        [Category("SetUp")]
        public void Setup()
        {
            _repository = new Mock<IClienteRepository>();
            _controller = new ClienteController(_repository.Object);
            clientes = PopulaAllClientes();
            cliente = PopulaCliente();

            //Arrange
            _repository.Setup(x => x.GetAllClientes()).ReturnsAsync(clientes);
            _repository.Setup(x => x.GetClientePorId(cliente.Id)).ReturnsAsync(cliente);
            _repository.Setup(x => x.SaveChanges()).ReturnsAsync(true);
        }

        [Test]
        [Category("Get")]
        public async Task GetAllClientes()
        {
            //Arrange já declarado SetUp           
            //Act
            var result = await _controller.Get() as OkObjectResult;            

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(200));

            var clientesNotNull = result.Value as List<ClienteModel>;            
            Assert.That(clientesNotNull.Count, Is.EqualTo(clientes.Count));
        }

        [Test]
        [Category("Get")]
        public async Task GetCliente()
        {
            //Arrange já declarado SetUp 
            //Act
            var result = await _controller.Get(cliente.Id) as OkObjectResult;            

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(200));

            var clienteNotNull = result.Value as ClienteModel;
            Assert.That(clienteNotNull, Is.EqualTo(cliente));
         }

        [Test]
        [Category("Post")]
        public async Task Post()
        {
            //Arrange já declarado SetUp 
            //Act
            var result = await _controller.Post(cliente) as OkObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(200));

            var clienteNotNull = result.Value as ClienteModel;
            Assert.That(clienteNotNull, Is.EqualTo(cliente));
        }

        [Test]
        [Category("Put")]
        public async Task Put()
        {
            //Arrange já declarado SetUp 
            //Act
            var result = await _controller.Put(cliente.Id, cliente) as OkObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(200));

            var clienteNotNull = result.Value as ClienteModel;
            Assert.That(clienteNotNull, Is.EqualTo(cliente));
        }

        [Test]
        [Category("Delete")]
        public async Task Delete()
        {
            //Arrange já declarado SetUp 
            //Act
            var result = await _controller.Delete(cliente.Id) as OkResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(200));
        }

        private List<ClienteModel> PopulaAllClientes()
        {
            for (int i = 1; i < 3; i++)
            {
                clientes.Add(new ClienteModel()
                {
                    Id = i,
                    Nome = $"Cliente {i}",
                    Email = "email@teste.com",
                    CpfCnpj = $"12345678919{i}",
                    Logradouro = $"teste {i}",
                    Bairro = $"teste {i}",
                    Uf = "AC",
                    Cep = $"5247896{i}",
                    Cidade = "São Paulo",
                    Telefone = $"12345678{i}"
                });
            }
            return clientes;
        }

        private ClienteModel PopulaCliente()
        {
            for (int i = 0; i < 1; i++)
            {
                cliente = new ClienteModel()
                {
                    Id = clientes[i].Id,
                    Nome = clientes[i].Nome,
                    Email = clientes[i].Email,
                    CpfCnpj = clientes[i].CpfCnpj,
                    Logradouro = clientes[i].Logradouro,
                    Bairro = clientes[i].Bairro,
                    Uf = clientes[i].Uf,
                    Cep = clientes[i].Cep,
                    Cidade = clientes[i].Cidade,
                    Telefone = clientes[i].Telefone
                };
            }
            return cliente;
        }
    }
}