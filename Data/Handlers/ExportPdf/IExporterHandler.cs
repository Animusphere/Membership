using ApplicationMember.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;

namespace ApplicationMember.Data.Handlers.ExportPdf
{
    public interface IExporterHandler
    {
        FileStreamResult GeneratePdf(List<DataModel> data);
    }
}
