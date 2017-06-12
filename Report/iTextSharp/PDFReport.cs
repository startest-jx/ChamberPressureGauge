using System.IO;
using System.Diagnostics;
using System.Drawing;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Font = iTextSharp.text.Font;
using Image = iTextSharp.text.Image;



namespace Report.iTextSharp
{
    public class PdfReport
    {
        private readonly Document _document;  // 文档
        private readonly BaseFont _bfLight;  // 字体
        private readonly PdfPTable _table;  // 表格
        public string FilePath { set; get; }  // 路径
        public string Author { set; get; }  // 作者
        public string Creator { set; get; }  // 创建人
        public string Subject { set; get; }  // 主题
        public string Title { set; get; }  // 标题
        public string Keywords { set; get; }  // 关键字

        public PdfReport()
        {
            _document = new Document(PageSize.A4);
            _bfLight = BaseFont.CreateFont(@"C:\Windows\Fonts\simsun.ttc,0", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            _table = new PdfPTable(1);
        }

        public void AddTitle(string text)
        {
            var myParagraph = new Paragraph(text, new Font(_bfLight, 20, 1));
            var myCell = new PdfPCell(myParagraph)
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                Border = 0
            };
            _table.AddCell(myCell);

        }

        public void AddEmptyLine()
        {
            AddText(" ");
        }

        public void AddText(string text)
        {
            var myParagraph = new Paragraph(text, new Font(_bfLight, 13));
            var myCell = new PdfPCell(myParagraph) {Border = 0};
            _table.AddCell(myCell);
        }

        public void AddImage(Bitmap bitMap)
        {
            var myImage = Image.GetInstance(bitMap, System.Drawing.Imaging.ImageFormat.Bmp);
            var myCell = new PdfPCell(myImage, true) {Border = 0};
            _table.AddCell(myCell);
        }

        public void Print()
        {
            PdfWriter.GetInstance(_document, new FileStream(FilePath, FileMode.Create));

            _document.AddAuthor(Author);
            _document.AddCreationDate();
            _document.AddCreator(Creator);
            _document.AddSubject(Subject);
            _document.AddTitle(Title);
            _document.AddKeywords(Keywords);
            _document.Open();
            _document.Add(_table);
            _document.Close();
        }

        public void Open()
        {
            Process.Start(FilePath);
        }
    }
}
