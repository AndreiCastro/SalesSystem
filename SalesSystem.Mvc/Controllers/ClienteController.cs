using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SalesSystem.Mvc.Helpers;
using SalesSystem.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.Mvc.Controllers
{
    public class ClienteController : Controller
    {
        #region Atributos
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _httpClient;
        #endregion Atributos

        #region Construtor
        public ClienteController(IHttpClientFactory httpClientFactory)
        {
            _clientFactory = httpClientFactory;
            _httpClient = _clientFactory.CreateClient("HttpClient");
        }

        #endregion Construtor

        /// <summary>
        /// Método que retorna lista de clientes cadastrados
        /// </summary>
        public async Task<IActionResult> Index()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("/api/cliente/Get"); 
                //Deixei o /Get pq na route da controller estou passando a action, para se ter como exemplo de request.

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    var clientes = JsonConvert.DeserializeObject<List<ClienteModel>>(data);
                    return View(clientes);
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
        /// Método para cadastrar um cliente
        /// </summary>
        /// <param name="cliente"></param>
        [HttpPost]
        public async Task<IActionResult> Create(ClienteModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    cliente.Uf = Helper.RetornaDescricaoEnum(Convert.ToInt32(cliente.Uf), "UF");                    
                    var jsonCliente = JsonConvert.SerializeObject(cliente);
                    StringContent content = new StringContent(jsonCliente, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await _httpClient.PostAsync("/api/cliente/Post/", content);

                    if (response.IsSuccessStatusCode)
                    {
                        TempData["MensagemSucesso"] = "Cliente cadastrado com sucesso!";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Erro = await response.Content.ReadAsStringAsync();
                        return View("Error");
                    }
                }
                return View("Create", cliente);
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
        /// Método que retorna com a view Update com o cliente
        /// </summary>
        /// <param name="idCliente"></param>        
        public async Task<IActionResult> Update(int idCliente)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("/api/cliente/Get/" + idCliente);

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    var cliente = JsonConvert.DeserializeObject<ClienteModel>(data);
                    ViewBag.UF = cliente.Uf;
                    return View(cliente);
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
        /// Método para alterar um cliente
        /// </summary>
        /// <param name="cliente"></param>
        [HttpPost]
        public async Task<IActionResult> Update(ClienteModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (int.TryParse(cliente.Uf, out _))
                        cliente.Uf = Helper.RetornaDescricaoEnum(Convert.ToInt32(cliente.Uf), "UF");

                    var jsonCliente = JsonConvert.SerializeObject(cliente);
                    StringContent content = new StringContent(jsonCliente, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await _httpClient.PutAsync("/api/cliente/Put/" + cliente.Id, content);

                    if (response.IsSuccessStatusCode)
                    {
                        TempData["MensagemSucesso"] = "Cliente alterado com sucesso!";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Erro = await response.Content.ReadAsStringAsync();
                        return View("Error");
                    }
                }
                return View("Update", cliente);
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
                HttpResponseMessage response = await _httpClient.GetAsync("/api/cliente/Get/" + id);

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    var cliente = JsonConvert.DeserializeObject<ClienteModel>(data);
                    return View(cliente);
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
        /// Método para excluir um cliente
        /// </summary>
        /// <param name="idCliente"></param>
        public async Task<IActionResult> DeleteConfirm(int idCliente)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync("/api/cliente/Delete/" + idCliente);

                if (response.IsSuccessStatusCode)
                {
                    TempData["MensagemSucesso"] = "Cliente excluído com sucesso!";
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
