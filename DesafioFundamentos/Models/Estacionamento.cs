using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string? placa = Console.ReadLine();

            placa = placa?.Trim().ToUpper();

            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Placa inválida. Tente novamente.");
                return;
            }

            if (veiculos.Contains(placa))
            {
                Console.WriteLine("Esse veículo já está estacionado.");
                return;
            }

            veiculos.Add(placa);
            Console.WriteLine($"Veículo com placa {placa} estacionado com sucesso.");
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string? placa = Console.ReadLine();
            placa = placa?.Trim().ToUpper();

            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Placa inválida. Tente novamente.");
                return;
            }

            // Verifica se o veículo existe (case-insensitive)
            if (veiculos.Any(x => x.ToUpper() == placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // Lê e valida as horas
                if (!int.TryParse(Console.ReadLine(), out int horas) || horas < 0)
                {
                    Console.WriteLine("Quantidade de horas inválida. Use um número inteiro maior ou igual a zero.");
                    return;
                }

                // Calcula: precoInicial + (precoPorHora * horas)
                decimal valorTotal = precoInicial + (precoPorHora * horas);

                // Remove a placa da lista
                veiculos.RemoveAll(v => v.ToUpper() == placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal:F2}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // Laço de repetição exibindo os veículos
                int i = 1;
                foreach (var placa in veiculos)
                {
                    Console.WriteLine($"{i}. {placa}");
                    i++;
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
