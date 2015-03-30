using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using PdfSharp.Pdf;
using LC.Core.Engine;

namespace TopTal.Expenses.ServiceLayer.Exporters
{
	public class PdfWriter : BaseDocument
	{
		protected Document _document;
		protected PdfDocument _pdfDocument;
		protected string _title = "";
		protected string _subject = "";
		protected DateTime _createdOn = DateTime.UtcNow;

		public PdfWriter(string title, string subject, params string[] folderNames)
			: base(folderNames)
		{
			_extension = ".pdf";
		}

		/// <summary>
		/// Call this method to get started and focus on content only. Call SaveFile() at the end
		/// </summary>
		public virtual void CreateDocument(string fileName)
		{
			FileName = fileName;
			_document = new Document();
			_document.Info.Title = _title;
			_document.Info.Subject = _subject;
			_document.Info.Author = "Mariposa Training";

			DefineStyles();
			DefineContentSection();
		}

		public virtual void TestDocument()
		{
			_document = new Document();
			_document.Info.Title = _title;
			_document.Info.Subject = _subject;
			_document.Info.Author = "Mariposa Training";

			DefineStyles();
			DefineContentSection();
		}

		/// <summary>
		/// Defines the basic styles
		/// </summary>
		protected virtual void DefineStyles()
		{
			// Get the predefined style Normal.
			Style style = _document.Styles["Normal"];
			// Because all styles are derived from Normal, the next line changes the 
			// font of the whole document. Or, more exactly, it changes the font of
			// all styles and paragraphs that do not redefine the font.
			style.Font.Name = "Times New Roman"; // "Times New Roman";
			style.Font.Size = 10;
			style.ParagraphFormat.SpaceAfter = Unit.FromInch(0.2f);

			// Heading1 to Heading9 are predefined styles with an outline level. An outline level
			// other than OutlineLevel.BodyText automatically creates the outline (or bookmarks) 
			// in PDF.

			style = _document.Styles["Heading1"];
			style.Font.Name = "Tahoma";
			style.Font.Size = 14;
			style.Font.Bold = true;
			style.ParagraphFormat.Shading.Color = Colors.LightGray;
			style.ParagraphFormat.Borders.Top.Style = BorderStyle.Single;
			style.ParagraphFormat.Borders.Right.Style = BorderStyle.Single;
			style.ParagraphFormat.Borders.Bottom.Style = BorderStyle.Single;
			style.ParagraphFormat.Borders.Left.Style = BorderStyle.Single;
			style.ParagraphFormat.Borders.DistanceFromLeft = 5;
			//style.ParagraphFormat.PageBreakBefore = true;
			style.ParagraphFormat.SpaceAfter = 6;

			style = _document.Styles["Heading2"];
			style.Font.Size = 11;
			style.Font.Bold = true;
			style.Font.Color = Colors.White;
			style.Font.Name = "Arial Narrow";
			style.ParagraphFormat.PageBreakBefore = false;
			style.ParagraphFormat.SpaceBefore = 12;
			style.ParagraphFormat.SpaceAfter = 6;
			style.ParagraphFormat.Borders.DistanceFromLeft = 3;

			style = _document.Styles["Heading3"];
			style.Font.Size = 10;
			style.Font.Bold = true;
			style.Font.Italic = true;
			style.ParagraphFormat.Shading.Color = Colors.DarkGray;
			style.ParagraphFormat.SpaceBefore = 6;
			style.ParagraphFormat.SpaceAfter = 3;

			style = _document.Styles[StyleNames.Header];
			style.ParagraphFormat.AddTabStop(Unit.FromInch(6.5), TabAlignment.Right);

			style = _document.Styles[StyleNames.Footer];
			style.ParagraphFormat.AddTabStop(Unit.FromInch(3.25), TabAlignment.Center);
			style.ParagraphFormat.AddTabStop(Unit.FromInch(6.50), TabAlignment.Right);

			// Create a new style called NormalBold based on style Normal
			style = _document.Styles.AddStyle("NormalBold", "Normal");
			style.ParagraphFormat.Font.Bold = true;

			// Create a new style called NormalItalic based on style Normal
			style = _document.Styles.AddStyle("NormalItalic", "Normal");
			style.ParagraphFormat.Font.Italic = true;

			// Create a new style called NormalBoldItalic based on style Normal
			style = _document.Styles.AddStyle("NormalBoldItalic", "Normal");
			style.ParagraphFormat.Font.Bold = true;
			style.ParagraphFormat.Font.Italic = true;

			// Create a new style called TextBox based on style Normal
			style = _document.Styles.AddStyle("TextBox", "Normal");
			style.ParagraphFormat.Alignment = ParagraphAlignment.Justify;
			style.ParagraphFormat.Borders.Width = 2.5;
			style.ParagraphFormat.Borders.Distance = "3pt";
			//TODO: Colors
			style.ParagraphFormat.Shading.Color = Colors.SkyBlue;

			// Create a new style called TOC based on style Normal
			style = _document.Styles.AddStyle("TOC", "Normal");
			style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right, TabLeader.Dots);
			style.ParagraphFormat.Font.Color = Colors.Blue;

			// Small Caps
			style = _document.Styles.AddStyle("SmallCaps", "Normal");
			style.ParagraphFormat.Font.Size = 8;

			// Small Caps Bold
			style = _document.Styles.AddStyle("SmallCapsBold", "Normal");
			style.Font.Bold = true;
			style.ParagraphFormat.Font.Size = 8;

			// Bullet List
			style = _document.Styles.AddStyle("BulletList", "Normal");
			style.ParagraphFormat.LeftIndent = "-0in";
			style.ParagraphFormat.SpaceAfter = Unit.FromInch(0.1f);
		}

		/// <summary>
		/// Defines page setup, headers, and footers.
		/// </summary>
		protected virtual void DefineContentSection()
		{
			Section section = _document.AddSection();
			//section.PageSetup.OddAndEvenPagesHeaderFooter = true;
			section.PageSetup.DifferentFirstPageHeaderFooter = true;
			section.PageSetup.StartingNumber = 1;
			section.PageSetup.PageFormat = PageFormat.Letter;
			section.PageSetup.TopMargin = Unit.FromInch(1);
			section.PageSetup.RightMargin = Unit.FromInch(1);
			section.PageSetup.BottomMargin = Unit.FromInch(1);
			section.PageSetup.LeftMargin = Unit.FromInch(1);
		}

		protected void SaveFile()
		{
			_pdfDocument = new PdfDocument();
			var renderer = new MigraDoc.Rendering.DocumentRenderer(_document);
			renderer.PrepareDocument();
			for (int i = 1; i <= renderer.FormattedDocument.PageCount; ++i)
			{
				var page = _pdfDocument.AddPage();
				page.Size = PdfSharp.PageSize.Letter;
				if (_document.LastSection.PageSetup.Orientation == Orientation.Landscape)
					page.Orientation = PdfSharp.PageOrientation.Landscape;
				PdfSharp.Drawing.XGraphics gfx = PdfSharp.Drawing.XGraphics.FromPdfPage(page);
				renderer.RenderPage(gfx, i);
			}
			_pdfDocument.Save(FileFullName);
		}

		protected Table AddTable(params float[] widths)
		{
			Table table = new Table();
			table.AddColumn(Unit.FromInch(0.05)).Format.Alignment = ParagraphAlignment.Left;
			foreach (float width in widths)
				table.AddColumn(Unit.FromInch(width)).Format.Alignment = ParagraphAlignment.Left;
			_document.LastSection.Add(table);
			return table;
		}

		protected Paragraph AddCellParagraph(Table table, int row, int column, string text)
		{
			if (table == null)
				return new Paragraph();
			if (column >= table.Columns.Count)
				column = table.Columns.Count - 1;
			while (table.Rows.Count <= row)
				table.Rows.AddRow();
			return table.Rows[row].Cells[column].AddParagraph(text);
		}
	}
}
