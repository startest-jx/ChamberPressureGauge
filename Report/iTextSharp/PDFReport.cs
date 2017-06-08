using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Font = iTextSharp.text.Font;
using Image = iTextSharp.text.Image;



namespace Report.iTextSharp
{
    public class PDFReport
    {
        private Document Document;  // 文档
        private BaseFont BF_Light;  // 字体
        private PdfPTable Table;  // 表格
        public string FilePath { set; get; }  // 路径
        public string Author { set; get; }  // 作者
        public string Creator { set; get; }  // 创建人
        public string Subject { set; get; }  // 主题
        public string Title { set; get; }  // 标题
        public string Keywords { set; get; }  // 关键字

        public PDFReport()
        {
            Document = new Document(PageSize.A4);
            BF_Light = BaseFont.CreateFont(@"C:\Windows\Fonts\simsun.ttc,0", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            Table = new PdfPTable(1);
        }

        public void AddTitle(string Text)
        {
            Paragraph MyParagraph = new Paragraph(Text, new Font(BF_Light, 20, 1));
            PdfPCell MyCell = new PdfPCell(MyParagraph);
            MyCell.HorizontalAlignment = Element.ALIGN_CENTER;
            MyCell.Border = 0;
            Table.AddCell(MyCell);

        }

        public void AddEmptyLine()
        {
            AddText(" ");
        }

        public void AddText(string Text)
        {
            Paragraph MyParagraph = new Paragraph(Text, new Font(BF_Light, 13));
            PdfPCell MyCell = new PdfPCell(MyParagraph);
            MyCell.Border = 0;
            Table.AddCell(MyCell);
        }

        public void AddImage(Bitmap BitMap)
        {
            Image MyImage = Image.GetInstance(BitMap, System.Drawing.Imaging.ImageFormat.Bmp);
            PdfPCell MyCell = new PdfPCell(MyImage, true);
            MyCell.Border = 0;
            Table.AddCell(MyCell);
        }

        public void Print()
        {
            PdfWriter.GetInstance(Document, new FileStream(FilePath, FileMode.Create));

            Document.AddAuthor(Author);
            Document.AddCreationDate();
            Document.AddCreator(Creator);
            Document.AddSubject(Subject);
            Document.AddTitle(Title);
            Document.AddKeywords(Keywords);
            Document.Open();
            Document.Add(Table);
            Document.Close();
        }

        public void Open()
        {
            Process.Start(FilePath);
        }
    }
}
