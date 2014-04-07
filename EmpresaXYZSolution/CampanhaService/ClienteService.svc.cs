using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Diagnostics;

namespace CampanhaService
{
    public class ClienteService : IClienteService
    {

        Cliente IClienteService.GetClienteById(long id)
        {
            
            using (var dbContext = new DBLibrary.EmpresaXYZDBEntities())
            {

                var resultado = dbContext.CLIENTE.FirstOrDefault(c => c.ID_CLIENTE == id);

                var clienteService = new Cliente()
                {
                    idCliente = resultado.ID_CLIENTE,
                    nome = resultado.NOME,
                    endereco = resultado.ENDERECO,
                    telResidencial = resultado.TEL_RESIDENCIAL,
                    telCelular = resultado.TEL_CELULAR,
                    dataNascimento = resultado.DATA_NASCIMENTO
                };

                return clienteService;
            }
        }


        List<Cliente> IClienteService.GetClienteByNome(string nome)
        {
            using (var dbContext = new DBLibrary.EmpresaXYZDBEntities())
            {
                var resultado = dbContext.CLIENTE.Where(c => c.NOME.Contains(nome)).ToList();

                var clienteServiceList = new List<Cliente>();

                foreach (var clienteDB in resultado)
                {
                    var clienteService = new Cliente()
                    {
                        idCliente = clienteDB.ID_CLIENTE,
                        nome = clienteDB.NOME,
                        endereco = clienteDB.ENDERECO,
                        telResidencial = clienteDB.TEL_RESIDENCIAL,
                        telCelular = clienteDB.TEL_CELULAR,
                        dataNascimento = clienteDB.DATA_NASCIMENTO
                    };

                    clienteServiceList.Add(clienteService);
                }

                return clienteServiceList;
            }
        }

        void IClienteService.UpdateCliente(Cliente cliente)
        {
            try
            {
                using (var dbContext = new DBLibrary.EmpresaXYZDBEntities())
                {
                    var clienteDB = dbContext.CLIENTE.FirstOrDefault(c => c.ID_CLIENTE == cliente.idCliente);

                    clienteDB.DATA_NASCIMENTO = cliente.dataNascimento;
                    clienteDB.TEL_CELULAR = cliente.telCelular;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new FaultException("Falha na atualização dos dados! Contate o administrador.");
            }
        }


        public List<Cliente> GetClienteCampanha()
        {
            using (var dbContext = new DBLibrary.EmpresaXYZDBEntities())
            {
                var query = from c in dbContext.CLIENTE
                            where c.DATA_NASCIMENTO.Value == null || c.TEL_CELULAR == null
                            select new { c.ID_CLIENTE, c.NOME, c.ENDERECO, c.TEL_RESIDENCIAL };

                var resultado = query.ToList();

                var clienteServiceList = new List<Cliente>();

                foreach (var clienteDB in resultado)
                {
                    var clienteService = new Cliente()
                    {
                        idCliente = clienteDB.ID_CLIENTE,
                        nome = clienteDB.NOME,
                        endereco = clienteDB.ENDERECO,
                        telResidencial = clienteDB.TEL_RESIDENCIAL
                    };

                    clienteServiceList.Add(clienteService);
                }

                return clienteServiceList;
            }
        }
    }
}
