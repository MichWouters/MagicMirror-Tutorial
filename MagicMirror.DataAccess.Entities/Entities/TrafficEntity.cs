using MagicMirror.DataAccess.Entities.Entities;

namespace MagicMirror.DataAccess.Entities.Traffic
{
    public class TrafficEntity : Entity
    {
        public string[] Destination_addresses { get; set; }
        public string[] Origin_addresses { get; set; }
        public Row[] Rows { get; set; }
        public string Status { get; set; }
    }
}