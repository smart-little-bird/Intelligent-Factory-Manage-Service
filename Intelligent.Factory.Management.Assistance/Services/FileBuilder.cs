using System.Globalization;
using PdfSharpCore.Drawing;
using PdfSharpCore.Fonts;
using PdfSharpCore.Pdf;
using PdfSharpCore.Utils;

namespace Intelligent.Factory.Management.Assistance.Services;

public class FileBuilder : IFileBuilder
{
    private readonly List<string> _firstTitles = new() { "name", "specifications" };

    private readonly List<string> _secondTitles = new() { "material", "count", "price", "totalPrice" };

    public bool Generate<T>() where T : class
    {
        GlobalFontSettings.FontResolver = new FontResolver();

        var tmpDoc = new PdfDocument();
        var page = tmpDoc.AddPage();
        var myPen = new XPen(XColors.Black);
        var gfx = XGraphics.FromPdfPage(page);

        gfx.TranslateTransform(10.0F, 10.0F);
        const int crossBigSeparationDistance = 100;
        const int crossSmallSeparationDistance = 85;
        const int lengthSeparationDistance = 50;
        const int startBoundary = 90;
        const int startCrossBoundary = 10;
        const int lengthBoundary = startBoundary + lengthSeparationDistance * 4;
        const int smallLineCount = 4;
        const int bigLineCount = 2;
        const int crossBoundary = startCrossBoundary + crossBigSeparationDistance * bigLineCount;
        const int crossNextBoundary = crossBoundary + crossSmallSeparationDistance * smallLineCount;
        for (var i = startBoundary; i <= lengthBoundary; i += lengthSeparationDistance)
        {
            gfx.DrawLine(myPen, new XPoint(startCrossBoundary, i), new XPoint(crossNextBoundary, i));
        }

        for (var i = startCrossBoundary; i <= crossBoundary; i += crossBigSeparationDistance)
        {
            gfx.DrawLine(myPen, new XPoint(i, startBoundary), new XPoint(i, lengthBoundary));
        }
        for (var i = crossBoundary; i <= crossNextBoundary; i += crossSmallSeparationDistance)
        {
            gfx.DrawLine(myPen, new XPoint(i, startBoundary), new XPoint(i, lengthBoundary));
        }
        var titleFont = new XFont("Arial", 20, XFontStyle.Bold);
        var textColor = XBrushes.Black;
        var layout = new XRect(10, 10, page.Width, page.Height);
        var format = XStringFormats.Center;
        gfx.DrawString("Contract Detail", titleFont, XBrushes.Black, new XRect(0, 0, page.Width, 40), XStringFormats.Center);

        var font = new XFont("Arial", 14, XFontStyle.Regular);
        gfx.DrawString("甲方 : ______________________________", font, XBrushes.DimGray, 20, 50);
        gfx.DrawString("乙方 : ______________________________", font, XBrushes.DimGray, 20, 75);
        gfx.DrawString(DateTime.Now.ToString(CultureInfo.InvariantCulture), font, XBrushes.DimGray, 60, 50);

        for (var i = 0; i < _firstTitles.Count; i++)
        {
            var xNumber = crossBigSeparationDistance * i + 20;
            gfx.DrawString(_firstTitles[i], font, XBrushes.DimGray, xNumber, 125);
        }

        for (var i = 0; i < _secondTitles.Count; i++)
        {
            var xNumber = crossBigSeparationDistance * 2 + 30 + crossSmallSeparationDistance * i;
            gfx.DrawString(_secondTitles[i], font, XBrushes.DimGray, xNumber, 125);
        }

        gfx.DrawString("Hello World!", font, textColor, layout, format);

        tmpDoc.Save("/Users/ericji/Projects/ServiceBusSender/demo.pdf");
        return true;
    }
}