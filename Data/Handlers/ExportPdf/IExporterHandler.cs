using ApplicationMember.Data.Models;
using System.Collections.Generic;
using System.IO;

namespace ApplicationMember.Data.Handlers.ExportPdf
{
    public interface IExporterHandler
    {
        MemoryStream GeneratePdf(List<DataModel> data);
    }
}
