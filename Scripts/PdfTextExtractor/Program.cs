using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;

if (args.Length < 2)
{
    Console.Error.WriteLine("Usage: PdfTextExtractor <pdf-path> <page-ranges> [output-path]");
    Console.Error.WriteLine("  page-ranges: comma-separated ranges, e.g. \"1-5,8,10-12\"");
    Console.Error.WriteLine("  output-path: optional, defaults to <pdf-name>.txt next to the PDF");
    return 1;
}

var pdfPath = Path.GetFullPath(args[0]);
var pageRangesArg = args[1];
var outputPath = args.Length >= 3
    ? Path.GetFullPath(args[2])
    : Path.Combine(
        Path.GetDirectoryName(pdfPath)!,
        Path.GetFileNameWithoutExtension(pdfPath) + ".txt");

if (!File.Exists(pdfPath))
{
    Console.Error.WriteLine($"Error: PDF file not found: {pdfPath}");
    return 1;
}

// Parse page ranges like "1-5,8,10-12"
List<int> pages;
try
{
    pages = ParsePageRanges(pageRangesArg);
}
catch (FormatException ex)
{
    Console.Error.WriteLine($"Error parsing page ranges: {ex.Message}");
    return 1;
}

if (pages.Count == 0)
{
    Console.Error.WriteLine("Error: No pages specified.");
    return 1;
}

try
{
    using var reader = new PdfReader(pdfPath);
    using var pdfDoc = new PdfDocument(reader);
    var totalPages = pdfDoc.GetNumberOfPages();

    // Validate page numbers
    var outOfRange = pages.Where(p => p < 1 || p > totalPages).ToList();
    if (outOfRange.Count > 0)
    {
        Console.Error.WriteLine(
            $"Error: Pages out of range (PDF has {totalPages} pages): {string.Join(", ", outOfRange)}");
        return 1;
    }

    using var writer = new StreamWriter(outputPath, false, System.Text.Encoding.UTF8);
    writer.WriteLine($"Source: {Path.GetFileName(pdfPath)}");
    writer.WriteLine($"Pages:  {pageRangesArg}");
    writer.WriteLine($"Extracted: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
    writer.WriteLine(new string('=', 60));
    writer.WriteLine();

    foreach (var pageNum in pages)
    {
        var page = pdfDoc.GetPage(pageNum);
        var strategy = new LocationTextExtractionStrategy();
        var text = PdfTextExtractor.GetTextFromPage(page, strategy);

        // Clean up the extracted text
        text = CleanText(text);

        writer.WriteLine($"--- Page {pageNum} ---");
        writer.WriteLine();
        writer.WriteLine(text);
        writer.WriteLine();
    }

    Console.WriteLine($"Extracted {pages.Count} page(s) to: {outputPath}");
    return 0;
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Error reading PDF: {ex.Message}");
    return 1;
}

// --- Helper methods ---

static List<int> ParsePageRanges(string input)
{
    var pages = new SortedSet<int>();
    var parts = input.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

    foreach (var part in parts)
    {
        if (part.Contains('-'))
        {
            var bounds = part.Split('-', 2);
            if (!int.TryParse(bounds[0].Trim(), out var start) ||
                !int.TryParse(bounds[1].Trim(), out var end))
            {
                throw new FormatException($"Invalid range: \"{part}\"");
            }

            if (start > end)
                throw new FormatException($"Invalid range (start > end): \"{part}\"");

            for (var i = start; i <= end; i++)
                pages.Add(i);
        }
        else
        {
            if (!int.TryParse(part.Trim(), out var page))
                throw new FormatException($"Invalid page number: \"{part}\"");

            pages.Add(page);
        }
    }

    return pages.ToList();
}

static string CleanText(string text)
{
    // Normalize line endings
    text = text.Replace("\r\n", "\n").Replace("\r", "\n");

    // Remove excessive blank lines (more than 2 consecutive)
    while (text.Contains("\n\n\n"))
        text = text.Replace("\n\n\n", "\n\n");

    return text.Trim();
}
