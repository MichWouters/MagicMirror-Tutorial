using MagicMirror.DataAccess.Entities;

namespace MagicMirror.DataAccess.Entities.Traffic
{
    public class GoogleMapsTrafficEntity: TrafficEntity
    {
        public string[] Destination_addresses { get; set; }

        public string[] Origin_addresses { get; set; }

        public Row[] Rows { get; set; }

        public string Status { get; set; }
    }
}