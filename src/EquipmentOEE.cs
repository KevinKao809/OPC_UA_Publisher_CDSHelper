using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpcPublisher_CDS
{
    // This Class be Added by Kevin Kao for OPC UA GW Demo
    class EquipmentOEE
    {        
        static Random _random = new Random();
        public static string getEquipmentOEEMessage(int cId, string eId)
        {
            int expectedUnits = 100;
            int producedUnits = _random.Next(85, 92);
            int rejectedUnits = _random.Next(1, (producedUnits / 10));
            int goodUnits = producedUnits - rejectedUnits;
            var OEEMessage = new
            {
                companyId = cId,
                msgTimestamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                equipmentId = eId,
                equipmentRunStatus = 1,
                OEE_RunTime = _random.Next(90, 96),
                OEE_PlannedProductionTime = 100,                
                OEE_ProducedUnits = producedUnits,
                OEE_ExpectedUnits = expectedUnits,
                OEE_RejectedUnits = rejectedUnits,
                OEE_GoodUnits = goodUnits
            };
            return JsonConvert.SerializeObject(OEEMessage);
        }
    }
}
