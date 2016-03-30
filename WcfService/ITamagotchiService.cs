using System.Collections.Generic;
using System.ServiceModel;
using TamagotchiWcfService.Contract;

namespace TamagotchiWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ITamagotchiService
    {
        [OperationContract]
        TamagotchiContract GetTamagotchiByName(string Name);

        [OperationContract]
        List<TamagotchiContract> GetTamagotchies();

        [OperationContract]
        TamagotchiContract ExecuteAction(ActionContract contract);

    }
}
