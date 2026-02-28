<#
.SYNOPSIS
    Extracts text from a searchable PDF for a given page range.

.DESCRIPTION
    Uses a .NET console app (iText7) under the hood to extract text from
    specified pages of a PDF and writes the result to a .txt file.

.PARAMETER PdfPath
    Path to the input PDF file.

.PARAMETER PageRange
    Comma-separated page ranges, e.g. "1-5,8,10-12".

.PARAMETER OutputPath
    Optional. Path for the output .txt file.
    Defaults to <pdf-name>.txt next to the input PDF.

.EXAMPLE
    .\Extract-PdfText.ps1 -PdfPath "C:\docs\rules.pdf" -PageRange "1-5,8,10-12"

.EXAMPLE
    .\Extract-PdfText.ps1 -PdfPath ".\book.pdf" -PageRange "10-48" -OutputPath ".\output.txt"
#>

[CmdletBinding()]
param(
    [Parameter(Mandatory = $true, Position = 0)]
    [string]$PdfPath,

    [Parameter(Mandatory = $true, Position = 1)]
    [string]$PageRange,

    [Parameter(Position = 2)]
    [string]$OutputPath
)

$ErrorActionPreference = "Stop"

# Resolve the PDF path
$resolvedPdf = Resolve-Path $PdfPath -ErrorAction SilentlyContinue
if (-not $resolvedPdf) {
    Write-Error "PDF file not found: $PdfPath"
    exit 1
}

# Build args for dotnet run
$projectPath = Join-Path $PSScriptRoot "PdfTextExtractor"

$dotnetArgs = @("run", "--project", $projectPath, "--", $resolvedPdf.Path, $PageRange)

if ($OutputPath) {
    # Resolve relative output path against current directory
    $resolvedOutput = $ExecutionContext.SessionState.Path.GetUnresolvedProviderPathFromPSPath($OutputPath)
    $dotnetArgs += $resolvedOutput
}

Write-Host "Extracting pages [$PageRange] from: $($resolvedPdf.Path)" -ForegroundColor Cyan

& dotnet @dotnetArgs

if ($LASTEXITCODE -ne 0) {
    Write-Error "Extraction failed with exit code $LASTEXITCODE"
    exit $LASTEXITCODE
}
