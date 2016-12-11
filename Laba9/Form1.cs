using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using Microsoft.Office.Core;
using Microsoft.Office.Interop;

namespace Laba9
{
    public partial class Form1 : Form
    {
        Huffman huffman;
        Fano fano;
        DefCode def;
        string path = AppDomain.CurrentDomain.BaseDirectory;
        string defImg = "defImg.jpg";
        string grayImg = "grayImg.jpg";
        Object _missingObj = System.Reflection.Missing.Value; //null ref

        public Form1()
        {
            InitializeComponent();
            huffman = new Huffman();
            fano = new Fano();
            def = new DefCode();

            generate(TextInput.Text);
        }


        private Word.Range findText(object findTextObj, Word.Document document)
        {
            Word.Range wordRange;
            bool rangeFound = false;
            for (int i = 1; i <= document.Sections.Count; i++)
            {
                wordRange = document.Sections[i].Range;
                Word.Find wordFindObj = wordRange.Find;

                object[] wordFindParameters = new object[15] { findTextObj, _missingObj, _missingObj, _missingObj, _missingObj, _missingObj, _missingObj, _missingObj, _missingObj, _missingObj, _missingObj, _missingObj, _missingObj, _missingObj, _missingObj };
                rangeFound = (bool)wordFindObj.GetType().InvokeMember("Execute", BindingFlags.InvokeMethod, null, wordFindObj, wordFindParameters);

                if (rangeFound) { return wordRange; }
            }

            return null;
        }

        private void createReport(string Text)
        {
            Object templateName = path + "templateReport.dotx";
            Object fileName = path + "Report.docx";

            Word.Application wordApp = new Word.Application();

            Word.Document WordDocument = wordApp.Documents.Add(templateName);
            object findTextObj;
            Word.Range range;
            Word.InlineShape inline_shape;
            Word.Shape shape;

            if (DefImg.Image != null)
            {
                findTextObj = "Исходной изображение";
                range = findText(findTextObj, WordDocument); //ищем наш Range на текст
                range.End++; //переходим на след строку
                range.Start = range.End;
                inline_shape = range.InlineShapes.AddPicture(path + defImg); //вставляем изображение
                shape = inline_shape.ConvertToShape();
                shape.WrapFormat.Type = Word.WdWrapType.wdWrapTopBottom; //обтекание сверху и снизу
                shape.Left = (float)Word.WdShapePosition.wdShapeCenter; //ставим в центр
                shape.Top = (float)Word.WdShapePosition.wdShapeCenter;

                findTextObj = "Черно-белое изображение";
                range = findText(findTextObj, WordDocument); //ищем наш Range на текст
                range.End++; //переходим на след строку
                range.Start = range.End;
                inline_shape = range.InlineShapes.AddPicture(path + grayImg); //вставляем изображение
                shape = inline_shape.ConvertToShape();
                shape.WrapFormat.Type = Word.WdWrapType.wdWrapTopBottom; //обтекание сверху и снизу
                shape.Left = (float)Word.WdShapePosition.wdShapeCenter; //ставим в центр
                shape.Top = (float)Word.WdShapePosition.wdShapeCenter;
            }
            else
            {
                findTextObj = "Исходной изображение";
                range = findText(findTextObj, WordDocument); //ищем наш Range на текст
                range.End++; //переходим на след строку
                range.Start = range.End;
                range.Text += "Нет изображения";

                findTextObj = "Черно-белое изображение";
                range = findText(findTextObj, WordDocument); //ищем наш Range на текст
                range.End++; //переходим на след строку
                range.Start = range.End;
                range.Text += "Нет изображения";
            }

            WordDocument.Variables["Text"].Value = TextInput.Text;
            WordDocument.Variables["Kvant"].Value = Kvant.Text;

            WordDocument.Variables["defCode"].Value = def.TextCode;
            WordDocument.Variables["defCodeLen"].Value = def.TextCode.Length.ToString();
            WordDocument.Variables["defH"].Value = def.H.ToString();
            WordDocument.Variables["defI"].Value = (def.H * def.TextCode.Length).ToString();
            WordDocument.Variables["defTableCount"].Value = def.table.Count.ToString();
            WordDocument.Variables["defAvLen"].Value = def.AvLen.ToString();
            WordDocument.Variables["defMinLen"].Value = def.minLen.ToString();

            WordDocument.Variables["defTable"].Value = "\r\n";
            for (int i = 0; i < def.table.Count; i++)
            {
                if (checkBox1.Checked) WordDocument.Variables["defTable"].Value += ((int)def.table[i].symbol).ToString();
                else WordDocument.Variables["defTable"].Value += def.table[i].symbol.ToString();

                WordDocument.Variables["defTable"].Value += (" - " + def.table[i].count.ToString() + " - " + (double)def.table[i].count / Text.Length * 100 + "% - ");

                for (int j = 0; j < def.table[i].code.Count; j++)
                    WordDocument.Variables["defTable"].Value += def.table[i].code[j].ToString();

                WordDocument.Variables["defTable"].Value += "\r\n";
            }

            WordDocument.Variables["HufCode"].Value = huffman.codeText;
            WordDocument.Variables["HufCodeLen"].Value = huffman.codeText.Length.ToString();
            WordDocument.Variables["hufH"].Value = huffman.H.ToString();
            WordDocument.Variables["hufI"].Value = (huffman.H * huffman.codeText.Length).ToString();
            WordDocument.Variables["HufK"].Value = (def.H * def.TextCode.Length) / (huffman.H * huffman.codeText.Length) + "";
            WordDocument.Variables["HufTableCount"].Value = huffman.table.Count.ToString();
            WordDocument.Variables["HufAvLen"].Value = huffman.avLen.ToString();
            WordDocument.Variables["HufEf"].Value = def.H / huffman.avLen + "";
            WordDocument.Variables["HufMinLen"].Value = huffman.minLen.ToString();
            WordDocument.Variables["HufQ"].Value = (1.0 - (double)huffman.codeText.Length / def.TextCode.Length) * 100 + "%";

            WordDocument.Variables["HufTable"].Value = "\r\n";
            for (int i = 0; i < huffman.table.Count; i++)
            {
                if (checkBox1.Checked) WordDocument.Variables["HufTable"].Value += "" + (int)huffman.table[i].symbol;
                else WordDocument.Variables["HufTable"].Value += huffman.table[i].symbol.ToString();

                WordDocument.Variables["HufTable"].Value += " - " + huffman.table[i].count.ToString() + " - " + (double)huffman.table[i].count / Text.Length * 100 + "% - ";

                for (int j = 0; j < huffman.table[i].code.Count; j++)
                    WordDocument.Variables["HufTable"].Value += huffman.table[i].code[j].ToString();

                WordDocument.Variables["HufTable"].Value += "\r\n";
            }

            WordDocument.Variables["FanoCode"].Value = fano.codeText;
            WordDocument.Variables["FanoCodeLen"].Value = fano.codeText.Length.ToString();
            WordDocument.Variables["fanoH"].Value = fano.H.ToString();
            WordDocument.Variables["fanoI"].Value = (fano.H * fano.codeText.Length).ToString();
            WordDocument.Variables["FanoK"].Value = (def.H * def.TextCode.Length) / (fano.H * fano.codeText.Length) + "";
            WordDocument.Variables["FanoTableCount"].Value = fano.table.Count.ToString();
            WordDocument.Variables["FanoAvLen"].Value = fano.avLen.ToString();
            WordDocument.Variables["FanoEf"].Value = def.H / fano.avLen + "";
            WordDocument.Variables["FanoMinLen"].Value = fano.minLen.ToString();
            WordDocument.Variables["FanoQ"].Value = (1.0 - (double)fano.codeText.Length / def.TextCode.Length) * 100 + "%";

            WordDocument.Variables["FanoTable"].Value = "\r\n";
            for (int i = 0; i < fano.table.Count; i++)
            {
                if (checkBox1.Checked) WordDocument.Variables["FanoTable"].Value += "" + (int)fano.table[i].symbol;
                else WordDocument.Variables["FanoTable"].Value += fano.table[i].symbol.ToString();

                WordDocument.Variables["FanoTable"].Value += " - " + fano.table[i].count.ToString() + " - " + (double)fano.table[i].count / Text.Length * 100 + "% - ";

                for (int j = 0; j < fano.table[i].code.Count; j++)
                    WordDocument.Variables["FanoTable"].Value += fano.table[i].code[j].ToString();

                WordDocument.Variables["FanoTable"].Value += "\r\n";
            }

            findTextObj = "Кодирование по Фано";
            range = findText(findTextObj, WordDocument); //ищем наш Range на текст
            range.Start--; //переходим на след строку
            range.End = range.Start;
            inline_shape = range.InlineShapes.AddPicture(path + "huffman.png"); //вставляем изображение
            shape = inline_shape.ConvertToShape();
            shape.WrapFormat.Type = Word.WdWrapType.wdWrapTopBottom; //обтекание сверху и снизу
            shape.Left = (float)Word.WdShapePosition.wdShapeCenter; //ставим в центр
            shape.Top = (float)Word.WdShapePosition.wdShapeCenter;

            findTextObj = "Вывод";
            range = findText(findTextObj, WordDocument); //ищем наш Range на текст
            range.Start--; //переходим на след строку
            range.End = range.Start;
            inline_shape = range.InlineShapes.AddPicture(path + "fano.png"); //вставляем изображение
            shape = inline_shape.ConvertToShape();
            shape.WrapFormat.Type = Word.WdWrapType.wdWrapTopBottom; //обтекание сверху и снизу
            shape.Left = (float)Word.WdShapePosition.wdShapeCenter; //ставим в центр
            shape.Top = (float)Word.WdShapePosition.wdShapeCenter;

            WordDocument.Fields.Update();
            WordDocument.SaveAs2(fileName);
            WordDocument.Close();
            wordApp.Quit();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (TextInput.Text.Length == 0) Generate.Enabled = false;
            else Generate.Enabled = true;
        }

        private void generate(string Text)
        {
            if(HuffmanImg.Image != null) HuffmanImg.Image.Dispose();
            if(FanoImg.Image != null) FanoImg.Image.Dispose();

            Report.Enabled = false;
            Generate.Enabled = false;
            LoadImg.Enabled = false;
            ClearButton.Enabled = false;
            checkBox1.Enabled = false;

            huffman.build(Text, checkBox1.Checked);
            fano.build(Text, checkBox1.Checked);
            def.build(huffman.table, Text);

            if(!checkBox1.Checked)
            {
                if (DefImg.Image != null)
                {
                    DefImg.Image.Dispose();
                    DefImg.Image = null;
                }
                DefImg.Invalidate();
            }

            //huffman page
            HuffmanImg.Image = new Bitmap(path + "huffman.png");
            KodHuffman.Text = "";
            KodHuffman.SelectionFont = new Font(KodHuffman.Font, FontStyle.Bold);
            KodHuffman.AppendText("Закодированное сообщение: ");

            KodHuffman.SelectionFont = new Font(KodHuffman.Font, FontStyle.Regular);
            KodHuffman.AppendText(huffman.codeText + "\r\n");

            KodHuffman.SelectionFont = new Font(KodHuffman.Font, FontStyle.Bold);
            KodHuffman.AppendText("Длина сообщения: ");

            KodHuffman.SelectionFont = new Font(KodHuffman.Font, FontStyle.Regular);
            KodHuffman.AppendText(huffman.codeText.Length + "\r\n");

            KodHuffman.SelectionFont = new Font(KodHuffman.Font, FontStyle.Bold);
            KodHuffman.AppendText("Значение энтропии: ");

            KodHuffman.SelectionFont = new Font(KodHuffman.Font, FontStyle.Regular);
            KodHuffman.AppendText(huffman.H.ToString() + "\r\n");

            KodHuffman.SelectionFont = new Font(KodHuffman.Font, FontStyle.Bold);
            KodHuffman.AppendText("Информационный объем сообщения: ");

            KodHuffman.SelectionFont = new Font(KodHuffman.Font, FontStyle.Regular);
            KodHuffman.AppendText(huffman.H * huffman.codeText.Length + "\r\n");

            KodHuffman.SelectionFont = new Font(KodHuffman.Font, FontStyle.Bold);
            KodHuffman.AppendText("Степень сжатия: ");

            KodHuffman.SelectionFont = new Font(KodHuffman.Font, FontStyle.Regular);
            KodHuffman.AppendText( (def.H * def.TextCode.Length) / (huffman.H * huffman.codeText.Length) + "\r\n");

            KodHuffman.SelectionFont = new Font(KodHuffman.Font, FontStyle.Bold);
            KodHuffman.AppendText("Количесвто символов алфавита: ");

            KodHuffman.SelectionFont = new Font(KodHuffman.Font, FontStyle.Regular);
            KodHuffman.AppendText(huffman.table.Count + "\r\n");

            KodHuffman.SelectionFont = new Font(KodHuffman.Font, FontStyle.Bold);
            KodHuffman.AppendText("Средняя длина кода: ");

            KodHuffman.SelectionFont = new Font(KodHuffman.Font, FontStyle.Regular);
            KodHuffman.AppendText(huffman.avLen.ToString() + "\r\n");

            KodHuffman.SelectionFont = new Font(KodHuffman.Font, FontStyle.Bold);
            KodHuffman.AppendText("Эффективность сжатия: ");

            KodHuffman.SelectionFont = new Font(KodHuffman.Font, FontStyle.Regular);
            KodHuffman.AppendText(def.H / huffman.avLen + "\r\n");

            KodHuffman.SelectionFont = new Font(KodHuffman.Font, FontStyle.Bold);
            KodHuffman.AppendText("Минимальная длина кода: ");

            KodHuffman.SelectionFont = new Font(KodHuffman.Font, FontStyle.Regular);
            KodHuffman.AppendText(huffman.minLen.ToString() + "\r\n");

            KodHuffman.SelectionFont = new Font(KodHuffman.Font, FontStyle.Bold);
            KodHuffman.AppendText("Избыточность: ");

            KodHuffman.SelectionFont = new Font(KodHuffman.Font, FontStyle.Regular);
            KodHuffman.AppendText((1.0 - (double)huffman.codeText.Length / def.TextCode.Length) * 100 + "%\r\n");

            KodHuffman.SelectionFont = new Font(KodHuffman.Font, FontStyle.Bold);
            KodHuffman.AppendText("Частота появления символов и их код: " + "\r\n");

            KodFano.SelectionFont = new Font(KodHuffman.Font, FontStyle.Regular);
            for (int i = 0; i < huffman.table.Count; i++)
            {
                if (checkBox1.Checked) KodHuffman.AppendText("" + (int)huffman.table[i].symbol);
                else KodHuffman.AppendText(huffman.table[i].symbol.ToString());

                KodHuffman.AppendText(" - " + huffman.table[i].count.ToString() + " - " + (double)huffman.table[i].count / Text.Length * 100 + "% - ");

                for (int j = 0; j < huffman.table[i].code.Count; j++)
                    KodHuffman.AppendText(huffman.table[i].code[j].ToString());

                KodHuffman.AppendText("\r\n");
            }

            //fano page
            FanoImg.Image = new Bitmap(path + "fano.png");
            KodFano.Text = "";
            KodFano.SelectionFont = new Font(KodFano.Font, FontStyle.Bold);
            KodFano.AppendText("Закодированное сообщение: ");

            KodFano.SelectionFont = new Font(KodFano.Font, FontStyle.Regular);
            KodFano.AppendText(fano.codeText + "\r\n");

            KodFano.SelectionFont = new Font(KodFano.Font, FontStyle.Bold);
            KodFano.AppendText("Длина сообщения: ");

            KodFano.SelectionFont = new Font(KodFano.Font, FontStyle.Regular);
            KodFano.AppendText(fano.codeText.Length + "\r\n");

            KodFano.SelectionFont = new Font(KodFano.Font, FontStyle.Bold);
            KodFano.AppendText("Значение энтропии: ");

            KodFano.SelectionFont = new Font(KodFano.Font, FontStyle.Regular);
            KodFano.AppendText(fano.H.ToString() + "\r\n");

            KodFano.SelectionFont = new Font(KodFano.Font, FontStyle.Bold);
            KodFano.AppendText("Информационный объем сообщения: ");

            KodFano.SelectionFont = new Font(KodFano.Font, FontStyle.Regular);
            KodFano.AppendText(fano.H * fano.codeText.Length + "\r\n");

            KodFano.SelectionFont = new Font(KodFano.Font, FontStyle.Bold);
            KodFano.AppendText("Степень сжатия: ");

            KodFano.SelectionFont = new Font(KodFano.Font, FontStyle.Regular);
            KodFano.AppendText( (def.H * def.TextCode.Length) / (fano.H * fano.codeText.Length)  + "\r\n");

            KodFano.SelectionFont = new Font(KodFano.Font, FontStyle.Bold);
            KodFano.AppendText("Количесвто символов алфавита: ");

            KodFano.SelectionFont = new Font(KodFano.Font, FontStyle.Regular);
            KodFano.AppendText(fano.table.Count + "\r\n");

            KodFano.SelectionFont = new Font(KodFano.Font, FontStyle.Bold);
            KodFano.AppendText("Средняя длина кода: ");

            KodFano.SelectionFont = new Font(KodFano.Font, FontStyle.Regular);
            KodFano.AppendText(fano.avLen.ToString() + "\r\n");

            KodFano.SelectionFont = new Font(KodFano.Font, FontStyle.Bold);
            KodFano.AppendText("Эффективность сжатия: ");

            KodFano.SelectionFont = new Font(KodFano.Font, FontStyle.Regular);
            KodFano.AppendText(def.H / fano.avLen + "\r\n");

            KodFano.SelectionFont = new Font(KodFano.Font, FontStyle.Bold);
            KodFano.AppendText("Минимальная длина кода: ");

            KodFano.SelectionFont = new Font(KodFano.Font, FontStyle.Regular);
            KodFano.AppendText(fano.minLen.ToString() + "\r\n");

            KodFano.SelectionFont = new Font(KodFano.Font, FontStyle.Bold);
            KodFano.AppendText("Избыточность: ");

            KodFano.SelectionFont = new Font(KodFano.Font, FontStyle.Regular);
            KodFano.AppendText((1.0 - (double)fano.codeText.Length / def.TextCode.Length) * 100 + "%\r\n");

            KodFano.SelectionFont = new Font(KodFano.Font, FontStyle.Bold);
            KodFano.AppendText("Частота появления символов и их код: " + "\r\n");

            KodFano.SelectionFont = new Font(KodFano.Font, FontStyle.Regular);
            for (int i = 0; i < fano.table.Count; i++)
            {
                if (checkBox1.Checked) KodFano.AppendText("" + (int)fano.table[i].symbol);
                else KodFano.AppendText(fano.table[i].symbol.ToString());

                KodFano.AppendText(" - " + fano.table[i].count.ToString() + " - " + (double)fano.table[i].count / Text.Length * 100 + "% - ");

                for (int j = 0; j < fano.table[i].code.Count; j++)
                    KodFano.AppendText(fano.table[i].code[j].ToString());

                KodFano.AppendText("\r\n");
            }

            //default page
            DefaultInfo.Text = "";
            DefaultInfo.SelectionFont = new Font(DefaultInfo.Font, FontStyle.Bold);
            DefaultInfo.AppendText("Закодированное сообщение: ");

            DefaultInfo.SelectionFont = new Font(DefaultInfo.Font, FontStyle.Regular);
            DefaultInfo.AppendText(def.TextCode + "\r\n");

            DefaultInfo.SelectionFont = new Font(DefaultInfo.Font, FontStyle.Bold);
            DefaultInfo.AppendText("Длина сообщения: ");

            DefaultInfo.SelectionFont = new Font(DefaultInfo.Font, FontStyle.Regular);
            DefaultInfo.AppendText(def.TextCode.Length + "\r\n");

            DefaultInfo.SelectionFont = new Font(DefaultInfo.Font, FontStyle.Bold);
            DefaultInfo.AppendText("Значение энтропии: ");

            DefaultInfo.SelectionFont = new Font(DefaultInfo.Font, FontStyle.Regular);
            DefaultInfo.AppendText(def.H.ToString() + "\r\n");

            DefaultInfo.SelectionFont = new Font(DefaultInfo.Font, FontStyle.Bold);
            DefaultInfo.AppendText("Информационный объем сообщения: ");

            DefaultInfo.SelectionFont = new Font(DefaultInfo.Font, FontStyle.Regular);
            DefaultInfo.AppendText(def.H * def.TextCode.Length + "\r\n");

            DefaultInfo.SelectionFont = new Font(DefaultInfo.Font, FontStyle.Bold);
            DefaultInfo.AppendText("Количесвто символов алфавита: ");

            DefaultInfo.SelectionFont = new Font(DefaultInfo.Font, FontStyle.Regular);
            DefaultInfo.AppendText(def.table.Count + "\r\n");

            DefaultInfo.SelectionFont = new Font(DefaultInfo.Font, FontStyle.Bold);
            DefaultInfo.AppendText("Средняя длина кода: ");

            DefaultInfo.SelectionFont = new Font(DefaultInfo.Font, FontStyle.Regular);
            DefaultInfo.AppendText(def.AvLen + "\r\n");

            DefaultInfo.SelectionFont = new Font(DefaultInfo.Font, FontStyle.Bold);
            DefaultInfo.AppendText("Минимальная длина кода: ");

            DefaultInfo.SelectionFont = new Font(DefaultInfo.Font, FontStyle.Regular);
            DefaultInfo.AppendText(def.minLen + "\r\n");

            DefaultInfo.SelectionFont = new Font(DefaultInfo.Font, FontStyle.Bold);
            DefaultInfo.AppendText("Частота появления символов и их код: \r\n");

            DefaultInfo.SelectionFont = new Font(DefaultInfo.Font, FontStyle.Regular);
            for (int i = 0; i < def.table.Count; i++)
            {
                if (checkBox1.Checked) DefaultInfo.AppendText("" + (int)def.table[i].symbol);
                else DefaultInfo.AppendText("" + def.table[i].symbol);

                DefaultInfo.AppendText(" - " + def.table[i].count.ToString() + " - " + (double)def.table[i].count / Text.Length * 100 + "% - ");

                for (int j = 0; j < def.table[i].code.Count; j++)
                    DefaultInfo.AppendText(def.table[i].code[j].ToString());

                DefaultInfo.AppendText("\r\n");
            }

            
            if(Report.Checked) createReport(Text);
            Report.Enabled = true;
            Generate.Enabled = true;
            LoadImg.Enabled = true;
            ClearButton.Enabled = true;
            checkBox1.Enabled = true;
        }

        private void generate_Click(object sender, EventArgs e)
        {
            Kvant.Text = "";
            if (!checkBox1.Checked)
            {
                Kvant.Text = "Квантования не было.";
                generate(TextInput.Text);
            }
            else
            {
                bool ER = false;
                bool canSpace = false;
                string text = "";
                int p = 0;
                for (int i = 0; i < TextInput.Text.Length; i++)
                {
                    if (!(TextInput.Text[i] - '0' >= 0 && TextInput.Text[i] - '0' <= 9) && !(canSpace && TextInput.Text[i] == ' '))
                    {
                        ER = true;
                        break;
                    }

                    if (TextInput.Text[i] != ' ') canSpace = true;
                    else
                    {
                        canSpace = false;
                        p = (int)Math.Round(p / 20.0) * 20;
                        Kvant.Text += p + " ";
                        text += (char)p;
                        p = 0;
                        continue;
                    }

                    p *= 10;
                    p += TextInput.Text[i] - '0';
                    if(p > 255)
                    {
                        ER = true;
                        break;
                    }

                    if (i == TextInput.Text.Length - 1)
                    {
                        p = (int)Math.Round(p / 20.0) * 20;
                        Kvant.Text += p + " ";
                        text += (char)p;
                    }
                }

                if (!ER) generate(text);
                else
                {
                    Kvant.Text = "Квантования не было.";
                    MessageBox.Show("Невозможно преобразовать как изображение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FanoImg_Click(object sender, EventArgs e)
        {
                    
        }

        private void HuffmanImg_Click(object sender, EventArgs e)
        {

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            TextInput.Text = "";
        }

        private void LoadImg_Click(object sender, EventArgs e)
        {
            Bitmap image;
            OpenFileDialog open_dialog = new OpenFileDialog(); //создание диалогового окна для выбора файла
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; //формат загружаемого файла
            if (open_dialog.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {
                try
                {
                    if(DefImg.Image != null) DefImg.Image.Dispose();
                    image = new Bitmap(open_dialog.FileName);
                    image.Save(path + defImg);
                    checkBox1.Checked = true;

                    //выгружаем пиксели - центраьную строчку
                    TextInput.Text = "";
                    for (int i = 0; i < image.Width; i++)
                        for(int j = 0; j < image.Height; j++)
                        {
                            Color oc = image.GetPixel(i, j);
                            int grayScale = (int)((oc.R * 0.3) + (oc.G * 0.59) + (oc.B * 0.11));
                            Color nc = Color.FromArgb(oc.A, grayScale, grayScale, grayScale);
                            if(image.PixelFormat != PixelFormat.Format8bppIndexed && image.PixelFormat != PixelFormat.Format1bppIndexed && image.PixelFormat != PixelFormat.Format4bppIndexed) 
                                image.SetPixel(i, j, nc);
                            if(j == image.Height / 2) TextInput.Text += grayScale.ToString() + " ";
                        }

                    image.Save(path + grayImg);
                    DefImg.Image = new Bitmap(path + grayImg);
                    DefImg.Invalidate();
                }
                catch
                {
                    checkBox1.Checked = false;
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
