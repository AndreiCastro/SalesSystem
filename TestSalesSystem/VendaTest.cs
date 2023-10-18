using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using SalesSystem.WebApi.Controllers;
using SalesSystem.WebApi.Dtos;
using SalesSystem.WebApi.Model;
using SalesSystem.WebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSalesSystem
{
    [TestFixture]
    public class VendaTest
    {
        private VendaController _controller;
        private Mock<IVendaRepository> _repository;
        private Mock<IProdutoRepository> _produtoRepository;
        private Mock<IMapper> _mapper;

        List<VendaModel> vendasModel = new List<VendaModel>();
        VendaModel vendaModel = new VendaModel();
        List<VendaDto> vendasDto = new List<VendaDto>();
        VendaDto vendaDto = new VendaDto();
        ProdutoModel produto = new ProdutoModel();

        [SetUp]
        [Category("SetUp")]
        public void SetUp()
        {
            _repository = new Mock<IVendaRepository>();
            _produtoRepository = new Mock<IProdutoRepository>();
            _mapper = new Mock<IMapper>();
            _controller = new VendaController(_repository.Object, _produtoRepository.Object, _mapper.Object);
            vendasModel = PopulaAllVendasModel();
            vendaModel = PopulaVendaModel();
            vendasDto = PopulaAllVendasDto();
            vendaDto = PopulaVendaDto();
            produto = ProdutoTest.PopulaProdutoModel();

            //Arrange
            _repository.Setup(x => x.GetAllVendas()).ReturnsAsync(vendasModel);
            _repository.Setup(x => x.GetVendaPorId(vendaModel.Id)).ReturnsAsync(vendaModel);
            _repository.Setup(x => x.SaveChanges()).ReturnsAsync(true);
            _produtoRepository.Setup(x => x.GetProdutoPorId(vendaModel.IdProduto)).ReturnsAsync(produto);
            _produtoRepository.Setup(x => x.SaveChanges()).ReturnsAsync(true);
            _mapper.Setup(x => x.Map<VendaModel>(vendaDto)).Returns(vendaModel);
            _mapper.Setup(x => x.Map<VendaDto>(vendaModel)).Returns(vendaDto);
            _mapper.Setup(x => x.Map<List<VendaDto>>(vendasModel)).Returns(vendasDto);
        }

        [Test]
        [Category("Get")]
        public async Task GetAllVendas()
        {
            //Arrange já declarado no SetUp
            //Act
            var result = await _controller.Get() as OkObjectResult;
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(200));

            var vendasNotNull = result.Value as List<VendaDto>;
            Assert.That(vendasNotNull.Count, Is.EqualTo(vendasDto.Count));
        }

        [Test]
        [Category("Get")]
        public async Task GetVenda()
        {
            //Arrange já declarado no SetUp
            //Act
            var result = await _controller.Get(vendaModel.Id) as OkObjectResult;
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(200));

            var vendaNotNull = result.Value as VendaDto;
            Assert.That(vendaNotNull, Is.EqualTo(vendaDto));
        }

        [Test]
        [Category("Post")]
        public async Task Post()
        {
            //Arrange já declarado no SetUp
            //Act
            var result = await _controller.Post(vendaDto) as OkObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(200));

            var vendaNotNull = result.Value as VendaDto;
            Assert.That(vendaNotNull, Is.EqualTo(vendaDto));
        }

        [Test]
        [Category("Delete")]
        public async Task Delete()
        {
            //Arrange já declarado no SetUp
            //Act
            var result = await _controller.Delete(vendaDto.Id) as OkResult;

            //Assert
            Assert.That(result.StatusCode, Is.EqualTo(200));
        }

        #region Popula Classes
        private List<VendaModel> PopulaAllVendasModel()
        {
            for (int i = 1; i < 3; i++)
            {
                vendaModel = new VendaModel()
                {
                    Id = i,
                    DataVenda = DateTime.Now,
                    QuantidadeProduto = 5,
                    ValorTotal = 100,
                    Descricao = $"Test mock venda{i}",
                    Desconto = i,
                    IdCliente = 1,
                    IdProduto = 1
                };
                vendasModel.Add(vendaModel);
            }
            return vendasModel;
        }

        private VendaModel PopulaVendaModel()
        {
            return vendaModel = new VendaModel()
            {
                Id = 1,
                DataVenda = DateTime.Now,
                QuantidadeProduto = 5,
                ValorTotal = 100,
                Descricao = "Test mock venda",
                Desconto = 1,
                IdCliente = 1,
                IdProduto = 1
            };
        }

        private List<VendaDto> PopulaAllVendasDto()
        {
            for (int i = 1; i < 3; i++)
            {
                vendaDto = new VendaDto()
                {
                    Id = i,
                    DataVenda = DateTime.Now,
                    QuantidadeProduto = 5,
                    ValorTotal = 100,
                    Descricao = $"Test mock venda{i}",
                    Desconto = i,
                    IdCliente = 1,
                    IdProduto = 1
                };
                vendasDto.Add(vendaDto);
            }
            return vendasDto;
        }

        private VendaDto PopulaVendaDto()
        {
            return vendaDto = new VendaDto()
            {
                Id = 1,
                DataVenda = DateTime.Now,
                QuantidadeProduto = 5,
                ValorTotal = 100,
                Descricao = "Test mock venda",
                Desconto = 1,
                IdCliente = 1,
                IdProduto = 1
            };
        }
        #endregion Popula Classes
    }
}
