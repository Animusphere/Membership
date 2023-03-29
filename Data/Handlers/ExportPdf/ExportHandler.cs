using ApplicationMember.Data.Models;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.IO;

namespace ApplicationMember.Data.Handlers.ExportPdf
{
    public class ExportHandler : IExporterHandler
    {
        public MemoryStream GeneratePdf(List<DataModel> data)
        {
            try
            {
                var pdfStream = new MemoryStream();
                var writer = new PdfWriter(pdfStream);
                var pdf = new PdfDocument(writer);
                var document = new Document(pdf);
                
                // Add a table to the PDF document
                var table = new Table(10);
                table.AddHeaderCell("NIK");
                table.AddHeaderCell("Nama");
                table.AddHeaderCell("Alamat");
                table.AddHeaderCell("Hp");
                foreach (var row in data)
                {
                    table.AddCell(row.NIK);
                    table.AddCell(row.Name);
                    table.AddCell(row.Address);
                    if (row.Phone != null)
                        table.AddCell(row.Phone);
                    else
                        table.AddCell(new Cell());
                }
                document.Add(table);
                pdfStream.Position = 0;
                return pdfStream;
            }
            catch (Exception e)
            {
                return null;
            }
            
        }
    }
}
