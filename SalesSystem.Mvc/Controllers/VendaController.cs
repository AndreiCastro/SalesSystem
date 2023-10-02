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
    public class VendaController : Controller
    {
        #region Atributos
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _httpClient;
        #endregion Atributos

        #region Construtor
        public VendaController(IHttpClientFactory httpClientFactory)
        {
            _clientFactory = httpClientFactory;
            _httpClient = _clientFactory.CreateClient("HttpClient");
        }
        #endregion Construtor

        /// <summary>
        /// Método que retorna lista de vendas cadastradas
        /// </summary>
        public async Task<IActionResult> Index()
        {
            try
            {
                var vendas = new List<VendaModel>();
                HttpResponseMessage response = await _httpClient.GetAsync("/api/venda");

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    vendas = JsonConvert.DeserializeObject<List<VendaModel>>(data);
                    return View(vendas);
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
        public async Task<IActionResult> Create()
        {
            try
            {
                var clientes = new List<ClienteModel>();
                var produtos = new List<ProdutoModel>();
                                
                HttpResponseMessage response = await _httpClient.GetAsync("/api/cliente/Get");

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    ViewBag.ListaClientes = JsonConvert.DeserializeObject<List<ClienteModel>>(data);
                    
                    response = await _httpClient.GetAsync("/api/produto");

                    if (response.IsSuccessStatusCode) 
                    {
                        data = response.Content.ReadAsStringAsync().Result;
                        ViewBag.ListaProdutos = JsonConvert.DeserializeObject<List<ProdutoModel>>(data);
                    }
                    else
                    {
                        ViewBag.Erro = await response.Content.ReadAsStringAsync();
                        return View("Error");
                    }
                }
                else
                {
                    ViewBag.Erro = await response.Content.ReadAsStringAsync();
                    return View("Error");
                }

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
                return View("Error");
            }
        }

        /// <summary>
        /// Método para cadastrar um venda
        /// </summary>
        /// <param name="venda"></param>
        [HttpPost]
        public async Task<IActionResult> Create(VendaModel venda)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var jsonVenda = JsonConvert.SerializeObject(venda);
                    StringContent content = new StringContent(jsonVenda, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await _httpClient.PostAsync("/api/venda/", content);

                    if (response.IsSuccessStatusCode)
                    {
                        TempData["MensagemSucesso"] = "Venda cadastrada com sucesso!";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Erro = await response.Content.ReadAsStringAsync();
                        return View("Error");
                    }
                }
                return View("Create", venda);
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
                return View("Error");
            }
        }
        #endregion Create

        #region Delete
        /// <summary>
        /// Método que retorna com a view de confirmação de exclusão
        /// </summary>      
        /// <param name="id"></param>
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var venda = new VendaModel();
                HttpResponseMessage response = await _httpClient.GetAsync("/api/venda/" + id);

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    venda = JsonConvert.DeserializeObject<VendaModel>(data);
                    return View(venda);
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
        /// Método para excluir uma venda
        /// </summary>       
        /// <param name="idVenda"></param>
        public async Task<IActionResult> DeleteConfirm(int idVenda)
        {
            try
            {
                var venda = new VendaModel();
                HttpResponseMessage response = await _httpClient.GetAsync("/api/venda/" + idVenda);
                if(response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    venda = JsonConvert.DeserializeObject<VendaModel>(data);
                }

                response = await _httpClient.DeleteAsync("/api/venda/" + idVenda);
                
                if (response.IsSuccessStatusCode)
                {                
                    response = await _httpClient.GetAsync("/api/produto/" + venda.IdProduto);
                    string data = response.Content.ReadAsStringAsync().Result;
                    var produto = JsonConvert.DeserializeObject<ProdutoModel>(data);
                    
                    produto.Quantidade += venda.QuantidadeProduto;
                    var jsonProduto = JsonConvert.SerializeObject(produto);
                    StringContent content = new StringContent(jsonProduto, Encoding.UTF8, "application/json");
                    response = await _httpClient.PutAsync("/api/produto/" + produto.Id, content);

                    TempData["MensagemSucesso"] = "Venda excluída com sucesso!";
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
