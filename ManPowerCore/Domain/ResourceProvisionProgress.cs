using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManPowerCore.Domain
{
    public class ResourceProvisionProgress
    {

        [DBField("ID")]
        public int ResourceProvisionProgressId { get; set; }

        [DBField("DATE")]
        public DateTime Date { get; set; }

        [DBField("NAME_OF_THE_PROGRAM")]
        public string NameOfTheProgram { get; set; }

        [DBField("INSTITUTE")]
        public string Institute { get; set; }

        [DBField("ADDRESS")]
        public string Address { get; set; }

        [DBField("SUBJECT_AREA_OR_TOPIC")]
        public string SubjectAreaOrTopic { get; set; }

        [DBField("NAME_OF_THE_ORGANIZATION")]
        public string NameOfTheOrganization { get; set; }

        [DBField("ORGANIZATION_TYPE")]
        public string OrganizationType { get; set; }

        [DBField("DS")]
        public string Ds { get; set; }

        [DBField("ORGANIZATION_ADDRESS")]
        public string OrganizationAddress { get; set; }

        [DBField("NAME")]
        public string Name { get; set; }

        [DBField("POSITION")]
        public string Position { get; set; }

        [DBField("CONTACT_NUMBER")]
        public string ContactNumber { get; set; }

        [DBField("WHATSAPP_NUMBER")]
        public string WhatsappNumber { get; set; }

        [DBField("EMAIL")]
        public string Email { get; set; }

        [DBField("DETAILS_OF_THE_PROVIDED_SERVICE")]
        public string DetailsOfTheProvidedService { get; set; }
    }
}
