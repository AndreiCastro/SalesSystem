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
using System.Threading.Tasks;

namespace TestSalesSystem
{
    [TestFixture]
    public class ProdutoTest
    {
        private ProdutoController _controller;
        private Mock<IProdutoRepository> _repository;
        private Mock<IMapper> _mapper;
        List<ProdutoModel> produtosModel = new List<ProdutoModel>();
        ProdutoModel produtoModel = new ProdutoModel();
        List<ProdutoDto> produtosDto = new List<ProdutoDto>();
        ProdutoDto produtoDto = new ProdutoDto();

        [SetUp]
        [Category("SetUp")]
        public void SetUp()
        {
            _repository = new Mock<IProdutoRepository>();
            _mapper = new Mock<IMapper>();
            _controller = new ProdutoController(_repository.Object, _mapper.Object);
            produtoModel = PopulaProdutoModel();
            produtosModel = PopulaAllProdutosModel();
            produtoDto = PopulaProdutoDto();
            produtosDto = PopulaAllProdutosDto();

            //Arrange
            _repository.Setup(x => x.GetAllProdutos()).ReturnsAsync(produtosModel);
            _repository.Setup(x => x.GetProdutoPorId(produtoModel.Id)).ReturnsAsync(produtoModel);
            _repository.Setup(x => x.SaveChanges()).ReturnsAsync(true);
            _mapper.Setup(x => x.Map<ProdutoModel>(produtoDto)).Returns(produtoModel);
            _mapper.Setup(x => x.Map<ProdutoDto>(produtoModel)).Returns(produtoDto);
            _mapper.Setup(x => x.Map<List<ProdutoDto>>(produtosModel)).Returns(produtosDto);
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

            var produtosNotNull = result.Value as List<ProdutoDto>;
            Assert.That(produtosNotNull.Count, Is.EqualTo(produtosDto.Count));        
        }

        [Test]
        [Category("Get")]
        public async Task GetProduto()
        {
            //Arrange já foi declarado no SetUp
            //Act
            var result = await _controller.Get(produtoDto.Id) as OkObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(200));

            var produtoNotNull = result.Value as ProdutoDto;
            Assert.That(produtoNotNull, Is.EqualTo(produtoDto));
        }

        [Test]
        [Category("Post")]
        public async Task Post()
        {
            //Arrange já foi declarado no SetUp
            //Act
            var result = await _controller.Post(produtoDto) as OkObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(200));

            var produtoNotNull = result.Value as ProdutoDto;
            Assert.That(produtoNotNull, Is.EqualTo(produtoDto));
        }

        [Test]
        [Category("Put")]
        public async Task Put()
        {
            //Arrange já foi declarado no SetUp
            //Act
            var result = await _controller.Put(produtoDto.Id, produtoDto) as OkObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(200));

            var produtoNotNull = result.Value as ProdutoDto;
            Assert.That(produtoNotNull, Is.EqualTo(produtoDto));
        }

        [Test]
        [Category("Delete")]
        public async Task Delete()
        {
            //Arrange já foi declarado no SetUp
            //Act
            var result = await _controller.Delete(produtoDto.Id) as OkResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(200));
        }

        #region Popula Classes
        private List<ProdutoModel> PopulaAllProdutosModel()
        {
            for (int i = 1; i < 3; i++)
            {
                produtoModel = new ProdutoModel()
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
                produtosModel.Add(produtoModel);
            }
            return produtosModel;
        }

        internal static ProdutoModel PopulaProdutoModel()
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

        private List<ProdutoDto> PopulaAllProdutosDto()
        {
            for (int i = 1; i < 3; i++)
            {
                produtoDto = new ProdutoDto()
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
                produtosDto.Add(produtoDto);
            }
            return produtosDto;
        }

        internal static ProdutoDto PopulaProdutoDto()
        {
            return new ProdutoDto()
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
        #endregion Popula Classes
    }
}
