using System;
using MacOS.Print.Extensions;
using MacOS.Print.Models;
using MacOS.Print.Structures;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace MacOS.Print;

/// <summary>
/// <see cref="MeetUpNameTagModel"/> Document.
/// </summary>
public sealed class MeetUpNameTagDocument : IDocument
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="model">model.</param>
    /// <param name="paperType">paperType.</param>
    public MeetUpNameTagDocument(MeetUpNameTagModel model, PaperType paperType)
    {
        Model = model ?? throw new ArgumentNullException(nameof(model));
        PaperType = paperType;
    }

    /// <summary>
    /// Model.
    /// </summary>
    public MeetUpNameTagModel Model { get; }

    /// <summary>
    /// Paper type.
    /// </summary>
    public PaperType PaperType { get; }

    /// <inheritdoc `/>
    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Size(PaperType.GetWidth(), PaperType.GetHeight(), Unit.Millimetre);
            page.DefaultTextStyle(style => style.FontFamily("NanumGothic"));

            page.Content()
                .AlignCenter()
                .AlignMiddle()
                .Column(column =>{
                    column.Spacing(20);

                    column.Item().Text(Model.Name).FontSize(20).Bold();
                    column.Item().Text(Model.Company).FontSize(14).SemiBold();
                });
        });
    }
}
