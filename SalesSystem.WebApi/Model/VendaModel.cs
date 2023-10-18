using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using SalesSystem.WebApi.Repository;
using System.Threading.Tasks;

namespace SalesSystem.WebApi.Model
{
    public class VendaModel
    {
        private readonly IVendaRepository _repository;
        private readonly IProdutoRepository _produtoRepository;
        public VendaModel()
        {
                
        }

        public VendaModel(IVendaRepository repository, IProdutoRepository produtoRepository)
        {
            _repository = repository;
            _produtoRepository = produtoRepository;                
        }

        [Key()]
        public int Id { get; set; }

        [Required]
        public DateTime DataVenda { get; set; }
        
        [Required]
        public int QuantidadeProduto { get; set; }

        [Required]
        public decimal ValorTotal { get; set; }
                
        [StringLength(100)]
        public string Descricao { get; set; }

        public decimal? Desconto { get; set; }


        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }
        public virtual ClienteModel Cliente { get; set; }

        [ForeignKey("Produto")]
        public int IdProduto { get; set; }
        public virtual ProdutoModel Produto { get; set; }

        public async Task<(bool, string)> ValidaExclusaoVenda(int idVenda)
        {
            string textoErro = "";
            try
            {
                var venda = await _repository.GetVendaPorId(idVenda);
                if(venda == null)
                    return (false, "Venda não encontrada.");

                var produto = await _produtoRepository.GetProdutoPorId(venda.IdProduto);  
                _repository.Delete(venda);
                if (await _repository.SaveChanges())
                {
                    //Chamei esse metodo para resolver o erro ChangeTracking.Internal.IdentityMap
                    _repository.ChangeTrackerClear(); 

                    produto.Quantidade += venda.QuantidadeProduto;
                    _produtoRepository.Update(produto);

                    if (await _produtoRepository.SaveChanges())
                        return (true, "");                    
                    else
                        return (false, "Erro ao alterar quantidade do produto.");
                }
                else
                {
                    return (false, "Erro ao excluir venda.");
                }
            }
            catch (Exception ex)
            {
                textoErro = ex.ToString();
            }
            return (false, textoErro);
        }

        public async Task<(bool, string)> ValidaInclusaoVenda(VendaModel venda)
        {
            string textoErro = "";
            try
            {                
                var produto = await _produtoRepository.GetProdutoPorId(venda.IdProduto);
                if (produto.DataValidade < DateTime.Now)                
                    return (false, "Produto fora da data de validade.");                

                if ((produto.Quantidade - venda.QuantidadeProduto) < 0)
                    return (false,"Estoque do produto insuficiente.");                

                venda.DataVenda = DateTime.Now;
                venda.ValorTotal = venda.Desconto == null ? produto.Preco * venda.QuantidadeProduto
                    : (produto.Preco * venda.QuantidadeProduto) - Convert.ToDecimal(venda.Desconto);

                _repository.Add(venda);
                if (await _repository.SaveChanges())
                {
                    produto.Quantidade -= venda.QuantidadeProduto;
                    _produtoRepository.Update(produto);

                    if (await _repository.SaveChanges())
                        return (true, "");
                    else
                        return (false, "Erro ao alterar quantidade do produto vendido."); 
                }
                else
                {
                    return (false, "Erro ao registrar venda.");
                }
            }
            catch (Exception ex)
            {
                textoErro = ex.ToString();
            }
            return (false, textoErro);
        }
    }
}
