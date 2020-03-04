using System;

namespace OcsicoTraining.Stasulevich.Lesson9.OrganizationManagment.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
