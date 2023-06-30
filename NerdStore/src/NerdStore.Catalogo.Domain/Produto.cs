using NerdStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Domain
{
    public class Produto : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string Imagem { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public Guid CategoriaId { get; private set; }
        public Categoria Categoria { get; private set; }

        public Produto(
            string nome,
            string descricao,
            bool ativo,
            Guid categoriaId,
            decimal valor,
            DateTime dataCadastro,
            string imagem)
        {
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
            DataCadastro = dataCadastro;
            Imagem = imagem;
            CategoriaId = categoriaId;

            Validar();
        }

        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;

        public void AlterarCategoria(Categoria categoria)
        {
            Categoria = categoria;
            CategoriaId = categoria.Id;
        }

        public void AlterarDescricao(string descricao)
        {
            Validacoes.ValidarSeVazio(descricao, "O campo Descricao do produto nao pode estar vazio");
            Descricao = descricao;
        }

        public void DebitarEstoque(int quantidade)
        {
            if (!PossuiEstoque(Math.Abs(quantidade)))
                throw new DomainException("Estoque insuficiente");

            QuantidadeEstoque -= Math.Abs(quantidade);
        }

        public void ReporEstoque(int quantidade)
        {
            QuantidadeEstoque += Math.Abs(quantidade);
        }

        public bool PossuiEstoque(int quantidade)
            => QuantidadeEstoque >= quantidade;

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome do produto nao pode estar vazio");
            Validacoes.ValidarSeVazio(Descricao, "O campo Descricao do produto nao pode estar vazio");
            Validacoes.ValidarSeDiferente(CategoriaId, Guid.Empty, "O campo CategoriaId do produto nao pode estar vazio");
            Validacoes.ValidarSeMenorIgualMinimo(Valor, 0, "O campo Valor do produto nao pode zer menor ou igual a zero");
            Validacoes.ValidarSeVazio(Imagem, "O campo Imagem do produto nao pode estar vazio");
        }
    }
}
