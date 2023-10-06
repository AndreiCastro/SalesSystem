using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using SalesSystem.WebApi.Controllers;
using SalesSystem.WebApi.Model;
using SalesSystem.WebApi.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestSalesSystem
{
    [TestFixture]
    public class ProdutoTest
    {
        private ProdutoController _controller;
        private Mock<IProdutoRepository> _repository;
        List<ProdutoModel> produtos = new List<ProdutoModel>();
        ProdutoModel produto = new ProdutoModel();

        [SetUp]
        [Category("SetUp")]
        public void SetUp()
        {
            _repository = new Mock<IProdutoRepository>();
            _controller = new ProdutoController(_repository.Object);
            produto = PopulaProduto();
            produtos = PopulaAllProdutos();

            //Arrange
            _repository.Setup(x => x.GetAllProdutos()).ReturnsAsync(produtos);
            _repository.Setup(x => x.GetProdutoPorId(produto.Id)).ReturnsAsync(produto);
            _repository.Setup(x => x.SaveChanges()).ReturnsAsync(true);
        }

        [Test]
        [Category("Get")]
        public async Task GetAllProdutos() 
        {
            //Arrange já foi declarado no SetUp
            //Act
            var result = await _controller.Get() as OkObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(200));

            var produtosNotNull = result.Value as List<ProdutoModel>;
            Assert.That(produtosNotNull.Count, Is.EqualTo(produtos.Count));        
        }

        [Test]
        [Category("Get")]
        public async Task GetProduto()
        {
            //Arrange já foi declarado no SetUp
            //Act
            var result = await _controller.Get(produto.Id) as OkObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(200));

            var produtoNotNull = result.Value as ProdutoModel;
            Assert.That(produtoNotNull, Is.EqualTo(produto));
        }

        [Test]
        [Category("Post")]
        public async Task Post()
        {
            //Arrange já foi declarado no SetUp
            //Act
            var result = await _controller.Post(produto) as OkObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(200));

            var produtoNotNull = result.Value as ProdutoModel;
            Assert.That(produtoNotNull, Is.EqualTo(produto));
        }

        [Test]
        [Category("Put")]
        public async Task Put()
        {
            //Arrange já foi declarado no SetUp
            //Act
            var result = await _controller.Put(produto.Id, produto) as OkObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(200));

            var produtoNotNull = result.Value as ProdutoModel;
            Assert.That(produtoNotNull, Is.EqualTo(produto));
        }

        [Test]
        [Category("Delete")]
        public async Task Delete()
        {
            //Arrange já foi declarado no SetUp
            //Act
            var result = await _controller.Delete(produto.Id) as OkResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(200));
        }
        private List<ProdutoModel> PopulaAllProdutos()
        {
            for (int i = 1; i < 3; i++)
            {
                produto = new ProdutoModel()
                {
                    Id = i,
                    Nome = $"Test mock produto{i}",
                    Descricao = $"Test mock descricao produto{i}",
                    Preco = 1000M,
                    UnidadeMedida = "UN",
                    Quantidade = 100,
                    Peso = 10,
                    DataValidade = new DateTime(2023, 12, 31)
                };
                produtos.Add(produto);
            }
            return produtos;
        }

        internal static ProdutoModel PopulaProduto()
        {
            return new ProdutoModel()
            {
                Id = 1,
                Nome = "Test mock produto",
                Descricao = "Test mock descricao produto",
                Preco = 1000M,
                UnidadeMedida = "UN",
                Quantidade = 100,
                Peso = 10,
                DataValidade = new DateTime(2023, 12, 31)
            };
        }
    }
}
