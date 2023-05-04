using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PatientDomain.Entities
{
    public abstract class Auditable
    {
        public int Id { get; set; }

        [JsonIgnore]
        public DateTime Created { get; set; } = DateTime.Now;

        [JsonIgnore]
        public DateTime LastModified { get; set;} = DateTime.Now;

    }
}
