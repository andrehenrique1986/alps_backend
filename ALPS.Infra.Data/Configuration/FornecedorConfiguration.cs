using ALPS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALPS.Infra.Data.Configuration
{
    public class FornecedorConfiguration : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("Fornecedor");

            builder.HasKey(f => f.FornecedorId)
                .HasName("pk_fornecedor_id");

            builder.Property(f => f.FornecedorId)
                .HasColumnName("fornecedor_id")
                .ValueGeneratedOnAdd();

            builder.Property(f => f.FornecedorNome)
                .HasColumnName("fornecedor_nome")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(f => f.FornecedorNomeFantasia)
                .HasColumnName("fornecedor_nome_fantasia")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(f => f.FornecedorNumeroFiscal)
                .HasConversion(
                    nf => nf.Numero,
                    valor => new NumeroFiscal(valor)
                )
                .HasColumnName("fornecedor_numero_fiscal")
                .HasMaxLength(14)
                .IsRequired();

            builder.Property(f => f.FornecedorEndereco)
                .HasColumnName("fornecedor_endereco")
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(f => f.FornecedorTelefone)
                .HasColumnName("fornecedor_telefone")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(f => f.FornecedorEmail)
                .HasColumnName("fornecedor_email")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(f => f.FornecedorAtivo)
                .HasColumnName("fornecedor_ativo")
                .IsRequired();

            builder.Property(f => f.FornecedorDataCriacao)
                .HasColumnName("fornecedor_data_criacao")
                .HasColumnType("timestamp with time zone")
                .IsRequired();
        }
    }
}