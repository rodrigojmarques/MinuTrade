using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ClienteWebApp.Models
{

    public static class HelperConversor
    {
        public static decimal? ConvertToNumber(string valor)
        {
            if (string.IsNullOrEmpty(valor))
            {
                return null;
            }
            else
            {
                string valorNumerico = "";

                foreach (var item in valor)
                {
                    decimal valorDecimal;
                    if (Decimal.TryParse(item.ToString(), out valorDecimal))
                    {
                        valorNumerico += item;
                    }
                }

                if (string.IsNullOrEmpty(valorNumerico))
                {
                    return null;
                }
                else
                {
                    return Decimal.Parse(valorNumerico);
                }
            }
        }
    }

    public class Cliente
    {
        [Key]
        [Display(Name = "ID", Description = "ID", ResourceType = typeof(Resources.Lables))]
        [Editable(false)]
        public long idCliente { get; set; }
        
        [StringLength(100)]
        [Display(Name = "NOME", Description = "NOME", ResourceType = typeof(Resources.Lables))]
        [Editable(false)]
        public string nome { get; set; }

        [StringLength(250)]
        [Display(Name = "ENDERECO", Description = "ENDERECO", ResourceType = typeof(Resources.Lables))]
        [Editable(false)]
        public string endereco { get; set; }

        [Display(Name = "TEL_RESIDENCIAL", Description = "TEL_RESIDENCIAL", ResourceType = typeof(Resources.Lables))]
        [Editable(false)]
        [DataType(DataType.Text)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string telResidencial { get; set; }

        [Required(ErrorMessageResourceName = "CAMPO_OBRIGATORIO", ErrorMessageResourceType = typeof(Resources.Mensagens))]
        [Display(Name = "TEL_CELULAR", Description = "TEL_CELULAR", ResourceType = typeof(Resources.Lables))]
        [DataType(DataType.Text)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string telCelular { get; set; }

        [Required(ErrorMessageResourceName = "CAMPO_OBRIGATORIO", ErrorMessageResourceType = typeof(Resources.Mensagens))]
        [Display(Name = "DATA_NASCIMENTO", Description = "DATA_NASCIMENTO", ResourceType = typeof(Resources.Lables))]
        [DisplayFormat(ApplyFormatInEditMode=true, ConvertEmptyStringToNull=true, DataFormatString = "{0:dd/mm/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? dataNascimento { get; set; }


        private static string mascaraTelefone = @"{0:\(00\)0000\-0000}";

        public List<Cliente> GetClienteCampanha()
        {
            var listaCliente = new List<Cliente>();

            using (var clienteServiceClient = new ClienteServiceReference.ClienteServiceClient())
            {
                var listaClienteService = clienteServiceClient.GetClienteCampanha().ToList();

                foreach (var clienteServiceItem in listaClienteService)
                {
                    var cliente = new Cliente()
                    {
                        idCliente = clienteServiceItem.idCliente,
                        nome = clienteServiceItem.nome,
                        endereco = clienteServiceItem.endereco,
                        telResidencial = String.Format(mascaraTelefone, clienteServiceItem.telResidencial),
                        dataNascimento = clienteServiceItem.dataNascimento,
                        telCelular = String.Format(mascaraTelefone, clienteServiceItem.telCelular),
                    };

                    listaCliente.Add(cliente);
                }

            }

            return listaCliente;
        }

        public Cliente GetClienteById(long id)
        {
            var cliente = new Cliente();

            using (var clienteServiceClient = new ClienteServiceReference.ClienteServiceClient())
            {
                var clienteServiceItem = clienteServiceClient.GetClienteById(id);

                cliente.idCliente = clienteServiceItem.idCliente;
                cliente.nome = clienteServiceItem.nome;
                cliente.endereco = clienteServiceItem.endereco;
                cliente.telCelular = String.Format(mascaraTelefone, clienteServiceItem.telCelular);
                cliente.telResidencial = String.Format(mascaraTelefone, clienteServiceItem.telResidencial);
                cliente.dataNascimento = clienteServiceItem.dataNascimento;
            }

            return cliente;
        }

        public List<Cliente> GetClienteByNome(string nome)
        {
            var listaCliente = new List<Cliente>();

            using (var clienteServiceClient = new ClienteServiceReference.ClienteServiceClient())
            {
                var listaClienteService = clienteServiceClient.GetClienteByNome(nome).ToList();

                foreach (var clienteServiceItem in listaClienteService)
                {
                    var cliente = new Cliente()
                    {
                        idCliente = clienteServiceItem.idCliente,
                        nome = clienteServiceItem.nome,
                        endereco = clienteServiceItem.endereco,
                        telResidencial = String.Format(mascaraTelefone, clienteServiceItem.telResidencial),
                        dataNascimento = clienteServiceItem.dataNascimento,
                        telCelular = clienteServiceItem.telCelular.ToString()
                    };

                    listaCliente.Add(cliente);
                }

            }

            return listaCliente;
        }

        public void UpdateCliente(Cliente cliente)
        {
            using (var clienteServiceClient = new ClienteServiceReference.ClienteServiceClient())
            {
                var clienteService = new ClienteServiceReference.Cliente()
                {
                    idCliente = cliente.idCliente,
                    nome = cliente.nome,
                    endereco = cliente.endereco,
                    telCelular = HelperConversor.ConvertToNumber(cliente.telCelular),
                    telResidencial = HelperConversor.ConvertToNumber(cliente.telResidencial).Value,
                    dataNascimento = cliente.dataNascimento
                };

                clienteServiceClient.UpdateCliente(clienteService);
            }
        }

    }
}