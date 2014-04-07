using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CampanhaService
{
    [DataContract]
    public class Cliente
    {
        [DataMember]
        public long idCliente { get; set; }
        [DataMember]
        public string nome { get; set; }
        [DataMember]
        public string endereco { get; set; }
        [DataMember]
        public decimal telResidencial { get; set; }
        [DataMember]
        public decimal? telCelular { get; set; }
        [DataMember]
        public DateTime? dataNascimento { get; set; }

    }
    
    [ServiceContract]
    public interface IClienteService
    {
        [OperationContract]
        Cliente GetClienteById(long id);
        [OperationContract]
        List<Cliente> GetClienteByNome(string nome);
        [OperationContract]
        void UpdateCliente(Cliente cliente);
        [OperationContract]
        List<Cliente> GetClienteCampanha();


    }
}
