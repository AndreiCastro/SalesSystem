using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using SalesSystem.WebApi.Controllers;
using SalesSystem.WebApi.Dtos;
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
        private Mock<IMapper> _mapper;

        List<ClienteModel> clientesModel = new List<ClienteModel>();
        ClienteModel clienteModel = new ClienteModel();
        List<ClienteDto> clientesDto = new List<ClienteDto>();
        ClienteDto clienteDto = new ClienteDto();

        [SetUp]
        [Category("SetUp")]
        public void Setup()
        {
            _repository = new Mock<IClienteRepository>();
            _mapper = new Mock<IMapper>();
            _controller = new ClienteController(_repository.Object, _mapper.Object);
            clientesModel = PopulaAllClientesModel();
            clienteModel = PopulaClienteModel();
            clientesDto = PopulaAllClientesDto();
            clienteDto = PopulaClienteDto();

            //Arrange
            _repository.Setup(x => x.GetAllClientes()).ReturnsAsync(clientesModel);
            _repository.Setup(x => x.GetClientePorId(clienteModel.Id)).ReturnsAsync(clienteModel);
            _repository.Setup(x => x.SaveChanges()).ReturnsAsync(true);
            _mapper.Setup(x => x.Map<ClienteModel>(clienteDto)).Returns(clienteModel);
            _mapper.Setup(x => x.Map<ClienteDto>(clienteModel)).Returns(clienteDto);
            _mapper.Setup(x => x.Map<List<ClienteDto>>(clientesModel)).Returns(clientesDto);
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

            var clientesNotNull = result.Value as List<ClienteDto>;
            Assert.That(clientesNotNull.Count, Is.EqualTo(clientesDto.Count));
        }

        [Test]
        [Category("Get")]
        public async Task GetCliente()
        {
            //Arrange já declarado SetUp 
            //Act
            var result = await _controller.Get(clienteDto.Id) as OkObjectResult;            

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(200));

            var clienteNotNull = result.Value as ClienteDto;
            Assert.That(clienteNotNull, Is.EqualTo(clienteDto));
         }

        [Test]
        [Category("Post")]
        public async Task Post()
        {
            //Arrange já declarado SetUp 
            //Act
            var result = await _controller.Post(clienteDto) as OkObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(200));

            var clienteNotNull = result.Value as ClienteDto;
            Assert.That(clienteNotNull, Is.EqualTo(clienteDto));
        }

        [Test]
        [Category("Put")]
        public async Task Put()
        {
            //Arrange já declarado SetUp 
            //Act
            var result = await _controller.Put(clienteDto.Id, clienteDto) as OkObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(200));

            var clienteNotNull = result.Value as ClienteDto;
            Assert.That(clienteNotNull, Is.EqualTo(clienteDto));
        }

        [Test]
        [Category("Delete")]
        public async Task Delete()
        {
            //Arrange já declarado SetUp 
            //Act
            var result = await _controller.Delete(clienteDto.Id) as OkResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(200));
        }

        #region Popula Classes
        private List<ClienteModel> PopulaAllClientesModel()
        {
            for (int i = 1; i < 3; i++)
            {
                clientesModel.Add(new ClienteModel()
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
            return clientesModel;
        }

        private ClienteModel PopulaClienteModel()
        {
            for (int i = 0; i < 1; i++)
            {
                clienteModel = new ClienteModel()
                {
                    Id = clientesModel[i].Id,
                    Nome = clientesModel[i].Nome,
                    Email = clientesModel[i].Email,
                    CpfCnpj = clientesModel[i].CpfCnpj,
                    Logradouro = clientesModel[i].Logradouro,
                    Bairro = clientesModel[i].Bairro,
                    Uf = clientesModel[i].Uf,
                    Cep = clientesModel[i].Cep,
                    Cidade = clientesModel[i].Cidade,
                    Telefone = clientesModel[i].Telefone
                };
            }
            return clienteModel;
        }

        private List<ClienteDto> PopulaAllClientesDto()
        {
            for (int i = 1; i < 3; i++)
            {
                clientesDto.Add(new ClienteDto()
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
                    Telefone = $"12345678{i}",
                    ComparaEmail = "email@teste.com"
                });
            }
            return clientesDto;
        }

        private ClienteDto PopulaClienteDto()
        {
            for (int i = 0; i < 1; i++)
            {
                clienteDto = new ClienteDto()
                {
                    Id = clientesDto[i].Id,
                    Nome = clientesDto[i].Nome,
                    Email = clientesDto[i].Email,
                    CpfCnpj = clientesDto[i].CpfCnpj,
                    Logradouro = clientesDto[i].Logradouro,
                    Bairro = clientesDto[i].Bairro,
                    Uf = clientesDto[i].Uf,
                    Cep = clientesDto[i].Cep,
                    Cidade = clientesDto[i].Cidade,
                    Telefone = clientesDto[i].Telefone,
                    ComparaEmail = clienteDto.ComparaEmail,
                };
            }
            return clienteDto;
        }
        #endregion Popula Classes
    }
}