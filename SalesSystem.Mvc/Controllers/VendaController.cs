using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SalesSystem.WebApi.Dtos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
                HttpResponseMessage response = await _httpClient.GetAsync("/api/venda");
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    var vendas = JsonConvert.DeserializeObject<List<VendaDto>>(data);
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
                HttpResponseMessage response = await _httpClient.GetAsync("/api/cliente/Get");
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    ViewBag.ListaClientes = JsonConvert.DeserializeObject<List<ClienteDto>>(data);
                    response = await _httpClient.GetAsync("/api/produto");

                    if (response.IsSuccessStatusCode)
                    {
                        data = response.Content.ReadAsStringAsync().Result;
                        ViewBag.ListaProdutos = JsonConvert.DeserializeObject<List<ProdutoDto>>(data);
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
        public async Task<IActionResult> Create(VendaDto venda)
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
                HttpResponseMessage response = await _httpClient.GetAsync("/api/venda/" + id);
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    var venda = JsonConvert.DeserializeObject<VendaDto>(data);
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
                HttpResponseMessage response = await _httpClient.DeleteAsync("/api/venda/" + idVenda);                
                if (response.IsSuccessStatusCode)
                {
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
