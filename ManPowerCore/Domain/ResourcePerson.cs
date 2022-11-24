using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class ResourcePerson
    {
        [DBField("ID")]
        public int ResoursePersonId { get; set; }

        [DBField("RESOURCE_PERSON_TYPE")]
        public string ResourcePersonType { get; set; }

        [DBField("NIC")]
        public string NIC { get; set; }

        [DBField("NAME")]
        public string Name { get; set; }

        [DBField("DESIGNATION")]
        public string Designation { get; set; }

        [DBField("WORK_PLACE")]
        public string WorkPlace { get; set; }

        [DBField("QUALIFICATIONS")]
        public string Qualifications { get; set; }

        [DBField("ADDRESS")]
        public string Address { get; set; }

        [DBField("CONTACT_NUMBER")]
        public string ContactNumber { get; set; }

        [DBField("WHATSAPP_NUMBER")]
        public string WhatsappNumber { get; set; }

        [DBField("EMAIL")]
        public string Email { get; set; }
    }
}
