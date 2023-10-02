using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SalesSystem.Mvc.Helpers;
using SalesSystem.WebApi.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;

namespace SalesSystem.Mvc.Controllers
{
    public class ProdutoController : Controller
    {
        #region Atributos
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _httpClient;
        #endregion Atributos

        #region Construtor
        public ProdutoController(IHttpClientFactory httpClientFactory)
        {
            _clientFactory = httpClientFactory;
            _httpClient = _clientFactory.CreateClient("HttpClient");
        }
        #endregion Construtor

        /// <summary>
        /// Método que retorna lista de produtos cadastrados
        /// </summary>
        public async Task<IActionResult> Index()
        {
            try
            {
                var produtos = new List<ProdutoModel>();
                HttpResponseMessage response = await _httpClient.GetAsync("/api/produto");

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    produtos = JsonConvert.DeserializeObject<List<ProdutoModel>>(data);
                    return View(produtos);
                }
                else
                {
                    ViewBag.Erro = await response.Content.ReadAsStringAsync();
                    return View("Error");
                }
            }
            catch
            {
                return View("Error");
            }
        }

        #region Create
        /// <summary>
        /// Método que retorna com a view Create
        /// </summary>
        public IActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
                return View("Error");
            }
        }

        /// <summary>
        /// Método para cadastrar um produto
        /// </summary>
        /// <param name="produto"></param>
        [HttpPost]
        public async Task<IActionResult> Create(ProdutoModel produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    produto.UnidadeMedida = Helper.RetornaDescricaoEnum(Convert.ToInt32(produto.UnidadeMedida), "UM");
                    var jsonProduto = JsonConvert.SerializeObject(produto);
                    StringContent content = new StringContent(jsonProduto, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await _httpClient.PostAsync("/api/produto/", content);

                    if (response.IsSuccessStatusCode)
                    {
                        TempData["MensagemSucesso"] = "Produto cadastrado com sucesso!";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Erro = await response.Content.ReadAsStringAsync();
                        return View("Error");
                    }
                }
                return View("Create", produto);
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
                return View("Error");
            }
        }
        #endregion Create

        #region Update
        /// <summary>
        /// Método que retorna com a view Update com o produto
        /// </summary>
        /// <param name="idProduto"></param>
        public async Task<IActionResult> Update(int idProduto)
        {
            try
            {
                var produto = new ProdutoModel();
                HttpResponseMessage response = await _httpClient.GetAsync("/api/produto/" + idProduto);

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    produto = JsonConvert.DeserializeObject<ProdutoModel>(data);
                    ViewBag.UnidadeMedida = produto.UnidadeMedida;
                    return View(produto);
                }
                else
                {
                    ViewBag.Erro = await response.Content.ReadAsStringAsync();
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
                return View("Error");
            }
        }

        /// <summary>
        /// Método para alterar um produto
        /// </summary>
        /// <param name="produto"></param>
        [HttpPost]
        public async Task<IActionResult> Update(ProdutoModel produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (int.TryParse(produto.UnidadeMedida, out _))
                        produto.UnidadeMedida = Helper.RetornaDescricaoEnum(Convert.ToInt32(produto.UnidadeMedida), "UM");

                    var jsonProduto = JsonConvert.SerializeObject(produto);
                    StringContent content = new StringContent(jsonProduto, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await _httpClient.PutAsync("/api/produto/" + produto.Id, content);

                    if (response.IsSuccessStatusCode)
                    {
                        TempData["MensagemSucesso"] = "Produto alterado com sucesso!";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Erro = await response.Content.ReadAsStringAsync();
                        return View("Error");
                    }
                }
                return View("Update", produto);
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
                return View("Error");
            }
        }
        #endregion Update

        #region Delete
        /// <summary>
        /// Método que retorna com a view de confirmação de exclusão
        /// </summary>      
        /// <param name="id"></param>
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var produto = new ProdutoModel();
                HttpResponseMessage response = await _httpClient.GetAsync("/api/produto/" + id);

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    produto = JsonConvert.DeserializeObject<ProdutoModel>(data);
                    return View(produto);
                }
                else
                {
                    ViewBag.Erro = await response.Content.ReadAsStringAsync();
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
                return View("Error");
            }
        }

        /// <summary>
        /// Método para excluir um produto
        /// </summary>       
        /// <param name="idProduto"></param>
        public async Task<IActionResult> DeleteConfirm(int idProduto)
        {
            try
            {
                var produto = new ProdutoModel();
                HttpResponseMessage response = await _httpClient.DeleteAsync("/api/produto/" + idProduto);

                if (response.IsSuccessStatusCode)
                {
                    TempData["MensagemSucesso"] = "Produto excluído com sucesso!";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Erro = await response.Content.ReadAsStringAsync();
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
                return View("Error");
            }
        }
        #endregion Delete      
    }
}
