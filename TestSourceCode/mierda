
using System.Drawing;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using VinculacionBackend.Interfaces;

namespace VinculacionBackend.Services
{
    public class TextDocumentServices:ITextDocumentServices
    {
        private readonly ITextDoucment _textDoucment;

        public TextDocumentServices(ITextDoucment textDoucment)
        {
            _textDoucment = textDoucment;
        }

        public void AddDataToTable(Table table, string[][] data, string font, float fontsize, int offset)
        {

            for (int r = 0; r < data.Length; r++)
            {
                TableRow dataRow = table.Rows[r + offset];
                dataRow.Height = 20;
                for (int c = 0; c < data[r].Length; c++)
                {
                    dataRow.Cells[c].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                    Paragraph p2 = dataRow.Cells[c].AddParagraph();
                    TextRange tr2 = p2.AppendText(data[r][c]);
                    p2.Format.HorizontalAlignment = HorizontalAlignment.Left;
                    tr2.CharacterFormat.FontName = font;
                    tr2.CharacterFormat.FontSize = fontsize;
                    tr2.CharacterFormat.Bold = true;
                }

            }
            table.TableFormat.Borders.BorderType = BorderStyle.Single;
            table.TableFormat.HorizontalAlignment = RowAlignment.Left;
            table.TableFormat.LeftIndent = 8f;
        }

        public void AddDataToTableWithHeader(Table table, string[] header, string[][] data, int columnCount, string font, float fontsize)
        {
            table.ResetCells(data.Length + 1, columnCount);

            TableRow frow = table.Rows[0];
            frow.Height = 30;

            frow.HeightType = TableRowHeightType.Exactly;
            frow.RowFormat.BackColor = Color.LightGray;
            for (int i = 0; i < header.Length; i++)
            {
                frow.Cells[i].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                Paragraph p = frow.Cells[i].AddParagraph();
                p.Format.HorizontalAlignment = HorizontalAlignment.Center;
                TextRange txtRange = p.AppendText(header[i]);
                txtRange.CharacterFormat.FontName = font;
                txtRange.CharacterFormat.FontSize = fontsize;
                if (i == header.Length - 1)
                {
                    txtRange.CharacterFormat.Bold = true;
                    txtRange.CharacterFormat.TextColor = Color.Red;
                }
            }
            AddDataToTable(table, data, font, fontsize, 1);
        }

        public ParagraphStyle CreateParagraphStyle(Document doc, string styleName, string fontName, float fontSize, bool bold)
        {
            return new ParagraphStyle(doc)
            {
                Name = styleName,
                CharacterFormat =
                {
                    FontName = fontName,
                    FontSize =fontSize,
                    Bold = bold,
                }
            };
        }


        public void AddImageToParagraph(Paragraph paragraph, Bitmap image, float height, float width, TextWrappingStyle textWrappingStyle)
        {
            var picture = CreateImage(paragraph, image);
            picture.Height = height;
            picture.Width = width;
            picture.VerticalPosition = picture.VerticalPosition + 45;
            picture.TextWrappingStyle = textWrappingStyle;
        }

        public DocPicture AppendPictureToHeader(Paragraph headParagraph,Bitmap image,float height,float width,float horizontalPosition,float verticalPosition)
        {
            var picture= CreateImage(headParagraph, image);
            picture.TextWrappingStyle=TextWrappingStyle.Tight;
            picture.TextWrappingType=TextWrappingType.Both;
            picture.HorizontalOrigin = HorizontalOrigin.Page;
            picture.HorizontalPosition = horizontalPosition;
            picture.VerticalOrigin=VerticalOrigin.Paragraph;
            picture.VerticalPosition = verticalPosition;
            picture.Height = height;
            picture.Width = width;
            return picture;
        }

        public void AppendTextToFooter(Paragraph footerParagraph, string text,string fontName,float fontSize)
        {
            var textRange=footerParagraph.AppendText(text);
            textRange.CharacterFormat.FontName = fontName;
            textRange.CharacterFormat.FontSize = fontSize;
        }


        public void SetPageMArgins(Section page,float top, float bottom, float left, float right)
        {
            page.PageSetup.Margins.Top = top;
            page.PageSetup.Margins.Bottom = bottom;
            page.PageSetup.Margins.Left = left;
            page.PageSetup.Margins.Right = right;

        }


        public TextRange AddTextToParagraph(string text, Paragraph paragraph, ParagraphStyle style, Document document,HorizontalAlignment aligment=HorizontalAlignment.Left,float linespacing=0)
        {
            var textrange=paragraph.AppendText(text);
            document.Styles.Add(style);
            paragraph.ApplyStyle(style.Name);
            if(linespacing!=0)
                paragraph.Format.LineSpacing =linespacing;
            paragraph.Format.HorizontalAlignment=aligment;
            return textrange;
        }


        public Paragraph CreateHeaderParagraph(HeaderFooter header)
        {
            return header.AddParagraph();
        }

        public Paragraph CreateFooterParagraph(HeaderFooter footer)
        {
            return footer.AddParagraph();
        }

        public DocPicture CreateImage(Paragraph p,Bitmap image)
        {
            return _textDoucment.AddImage(p, image);
        }

        public Paragraph CreateParagraph(Section page)
        {
            return _textDoucment.CreateParagraph(page);
        }

        public Section CreatePage(Document doc)
        {
            return _textDoucment.CreatePage(doc);
        }


        public Document CreaDocument()
        {
            return _textDoucment.CreateDocument();
        }

        public Table CreateTable(Section page)
        {
            return _textDoucment.CreateTable(page);
        }

        public HeaderFooter CreateHeader(Document doc)
        {
            return _textDoucment.CreateHeader(doc);
        }

        public HeaderFooter CreaFooter(Document doc)
        {
            return _textDoucment.CreaFooter(doc);
        }

    }
}