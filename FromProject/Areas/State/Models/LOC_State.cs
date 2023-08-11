using Microsoft.AspNetCore.Routing.Constraints;

namespace FromProject.Areas.State.Models
{
    public class LOC_State
    {
        public int StateID { get; set; }

        public string StateName { get; set; }

        public int CountryID { get; set; }

        public string StateCode { get; set; }

        public string Created { get; set; }

        public string Modified { get; set; }
    }
}
