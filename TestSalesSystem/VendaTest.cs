using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using SalesSystem.WebApi.Controllers;
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
        List<VendaModel> vendas = new List<VendaModel>();
        VendaModel venda = new VendaModel();
        ProdutoModel produto = new ProdutoModel();

        [SetUp]
        [Category("SetUp")]
        public void SetUp()
        {
            _repository = new Mock<IVendaRepository>();
            _produtoRepository = new Mock<IProdutoRepository>();
            _controller = new VendaController(_repository.Object, _produtoRepository.Object);
            vendas = PopulaAllVendas();
            venda = PopulaVenda();
            produto = ProdutoTest.PopulaProduto();

            //Arrange
            _repository.Setup(x => x.GetAllVendas()).ReturnsAsync(vendas);
            _repository.Setup(x => x.GetVendaPorId(venda.Id)).ReturnsAsync(venda);
            _repository.Setup(x => x.SaveChanges()).ReturnsAsync(true);
            _produtoRepository.Setup(x => x.GetProdutoPorId(venda.IdProduto)).ReturnsAsync(produto);
            _produtoRepository.Setup(x => x.SaveChanges()).ReturnsAsync(true);
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

            var vendasNotNull = result.Value as List<VendaModel>;
            Assert.That(vendasNotNull.Count, Is.EqualTo(vendas.Count));
        }

        [Test]
        [Category("Get")]
        public async Task GetVenda()
        {
            //Arrange já declarado no SetUp
            //Act
            var result = await _controller.Get(venda.Id) as OkObjectResult;
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(200));

            var vendaNotNull = result.Value as VendaModel;
            Assert.That(vendaNotNull, Is.EqualTo(venda));
        }

        [Test]
        [Category("Post")]
        public async Task Post()
        {
            //Arrange já declarado no SetUp
            //Act
            var result = await _controller.Post(venda) as OkObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(200));

            var vendaNotNull = result.Value as VendaModel;
            Assert.That(vendaNotNull, Is.EqualTo(venda));
        }

        [Test]
        [Category("Delete")]
        public async Task Delete()
        {
            //Arrange já declarado no SetUp
            //Act
            var result = await _controller.Delete(venda.Id) as OkResult;

            //Assert
            Assert.That(result.StatusCode, Is.EqualTo(200));
        }

        private List<VendaModel> PopulaAllVendas()
        {
            for (int i = 1; i < 3; i++)
            {
                venda = new VendaModel()
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
                vendas.Add(venda);
            }
            return vendas;
        }

        private VendaModel PopulaVenda()
        {
            return venda = new VendaModel()
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
    }
}
