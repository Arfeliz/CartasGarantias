using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;

namespace GeneradorGarantia
{
    public class GarantiaModel 
    {
        // Usamos ? para permitir valores nulos y quitar las 8 advertencias
        public string? Material { get; set; }
        public string? Descripcion { get; set; }
        public string? Modelo { get; set; }
        public string? Marca { get; set; }
        public string? Serie { get; set; }
        public string? Observacion { get; set; }
        public string? Taller { get; set; }
        public string? FirmaNombre { get; set; }
    }

    public static class DocumentoGarantia
    {
        public static void Generar(GarantiaModel data, string ruta)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(1.5f, Unit.Centimetre);
                    page.DefaultTextStyle(x => x.FontSize(11).FontFamily(Fonts.Verdana));

                    // --- ENCABEZADO ---
                    page.Header().Row(row =>
                    {
                        row.RelativeItem().Column(col => 
                        {
                            try {
                                col.Item().Width(150).Image("logo_jumbo.png"); 
                            } catch {
                                col.Item().Text("JUMBO").FontSize(28).ExtraBold().FontColor(Colors.Red.Medium);
                            }
                            col.Item().Text("Lo Máximo").FontSize(10).Italic();
                        });

                        row.RelativeItem().Column(col => 
                        {
                            col.Item().AlignRight().Text("Santo Domingo, Rep. Dom.");
                            col.Item().AlignRight().Text(DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy"));
                        });
                    });

                    // --- CUERPO ---
                    page.Content().PaddingVertical(20).Column(col =>
                    {
                        col.Spacing(8);
                        
                        col.Item().Text("Sres.");
                        col.Item().Text(data.Taller ?? "").SemiBold().FontSize(12); 
                        
                        col.Item().PaddingLeft(20).Text("Asunto: CARTA DE GARANTIA");
                        col.Item().PaddingLeft(20).Text("Sus manos:");

                        col.Item().PaddingVertical(10).Text(text => {
                            text.Span("Nos dirigimos a ustedes para dar constancia de que el articulo descrito a continuación pertenecen a la tienda ");
                            text.Span("JUMBO LUPERON.").SemiBold();
                        });

                        // BLOQUE DE DATOS
                        col.Item().PaddingLeft(10).Table(table => {
                            table.ColumnsDefinition(columns => {
                                columns.ConstantColumn(100);
                                columns.ConstantColumn(10);
                                columns.RelativeColumn();
                            });

                            AddRow(table, "MATERIAL", data.Material ?? "");
                            AddRow(table, "DESCRIPCION", data.Descripcion ?? "");
                            AddRow(table, "MODELO", data.Modelo ?? "");
                            AddRow(table, "MARCA", data.Marca ?? "");

                            string valorSerie = string.IsNullOrWhiteSpace(data.Serie) ? "" : data.Serie;
                            AddRow(table, "SERIE", valorSerie);
                        });

                        col.Item().PaddingVertical(10).Text(text => {
                            text.Span("Se emite como constancia para Servicio de Garantía, en el centro de servicios de ");
                            text.Span(data.Taller ?? "").SemiBold();
                            text.Span(".");
                        });
                        
                        if(!string.IsNullOrEmpty(data.Observacion))
                            col.Item().PaddingTop(5).Text($"Observación: {data.Observacion}").Italic();
                        
                        col.Item().PaddingTop(15).Text("Gracias,");
                    });

                    // --- FIRMA (Corrección del Error de Color) ---
                    page.Footer().PaddingBottom(20).Column(col => 
                    {
                        // En versiones nuevas de QuestPDF, se usa LineColor dentro de la decoración
                        col.Item().Width(200).PaddingBottom(2).BorderBottom(1).BorderColor(Colors.Black).Height(1);
                        
                        col.Item().PaddingTop(2).Text(data.FirmaNombre ?? "");
                        col.Item().Text("Departamento de Electrodomésticos").FontSize(9);
                        col.Item().Text("Jumbo Luperón (806)").FontSize(9);
                        col.Item().Text("Tel. 809-333-1111 EXT.3520").FontSize(9);
                    });
                });
            })
            .GeneratePdf(ruta);
        }

        private static void AddRow(TableDescriptor table, string label, string value) {
            table.Cell().PaddingVertical(2).Text(label).SemiBold();
            table.Cell().PaddingVertical(2).Text(":");
            table.Cell().PaddingVertical(2).Text(value);
        }
    }
}