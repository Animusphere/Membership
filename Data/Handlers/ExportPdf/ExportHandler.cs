using ApplicationMember.Data.Models;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace ApplicationMember.Data.Handlers.ExportPdf
{
    public class ExportHandler : IExporterHandler
    {
        public FileStreamResult GeneratePdf(List<DataModel> data)
        {
            try
            {
                MemoryStream ms = new MemoryStream();

                PdfWriter writer = new PdfWriter(ms);
                PdfDocument pdfDoc = new PdfDocument(writer);
                Document document = new Document(pdfDoc, PageSize.A4, false);
                writer.SetCloseStream(false);

                Paragraph header = new Paragraph("Membership "+DateTime.Now.Year)
                  .SetTextAlignment(TextAlignment.CENTER)
                  .SetFontSize(20);

                document.Add(header);

                Paragraph subheader = new Paragraph(DateTime.Now.ToShortDateString())
                  .SetTextAlignment(TextAlignment.CENTER)
                  .SetFontSize(15);
                document.Add(subheader);

                // empty line
                document.Add(new Paragraph(""));

                // Line separator
                LineSeparator ls = new LineSeparator(new SolidLine());
                document.Add(ls);
                // Add a table to the PDF document
                var table = new Table(4,false);
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

                document.Close();
                byte[] byteInfo = ms.ToArray();
                ms.Write(byteInfo, 0, byteInfo.Length);
                ms.Position = 0;

                FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/pdf");

                return fileStreamResult;
            }
            catch (Exception e)
            {
                return null;
            }
            
        }
    }
}
