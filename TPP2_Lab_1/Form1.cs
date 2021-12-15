using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPP2_Lab_1
{
    public partial class Form1 : Form
    {
        private DataGridViewColumn dataGridViewColumn1 = null;
        private DataGridViewColumn dataGridViewColumn2 = null;
        private DataGridViewColumn dataGridViewColumn3 = null;
        private DataGridViewColumn dataGridViewColumn4 = null;
        private DataGridViewColumn dataGridViewColumn5 = null;
        private HashSet<Book> bookSet = new HashSet<Book>();
        public Form1()
        {
            InitializeComponent();
            initDataGridView();
        }

        private void initDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Add(getDataGridViewColumn1());
            dataGridView1.Columns.Add(getDataGridViewColumn2());
            dataGridView1.Columns.Add(getDataGridViewColumn3());
            dataGridView1.Columns.Add(getDataGridViewColumn4());
            dataGridView1.Columns.Add(getDataGridViewColumn5());
            dataGridView1.AutoResizeColumns();
        }
        private DataGridViewColumn getDataGridViewColumn1()
        {
            if (dataGridViewColumn1 == null)
            {
                dataGridViewColumn1 = new DataGridViewTextBoxColumn();
                dataGridViewColumn1.Name = "";
                dataGridViewColumn1.HeaderText = "Name";
                dataGridViewColumn1.ValueType = typeof(string);
                dataGridViewColumn1.Width = dataGridView1.Width / 5;
            }
            return dataGridViewColumn1;
        }

        //Динамическое создание второй колонки в таблице
        private DataGridViewColumn getDataGridViewColumn2()
        {
            if (dataGridViewColumn2 == null)
            {
                dataGridViewColumn2 = new DataGridViewTextBoxColumn();
                dataGridViewColumn2.Name = "";
                dataGridViewColumn2.HeaderText = "Author";
                dataGridViewColumn2.ValueType = typeof(string);
                dataGridViewColumn2.Width = dataGridView1.Width / 5;
            }
            return dataGridViewColumn2;
        }

        //Динамическое создание третей колонки в таблице
        private DataGridViewColumn getDataGridViewColumn3()
        {
            if (dataGridViewColumn3 == null)
            {
                dataGridViewColumn3 = new DataGridViewTextBoxColumn();
                dataGridViewColumn3.Name = "";
                dataGridViewColumn3.HeaderText = "Price";
                dataGridViewColumn3.ValueType = typeof(int);
                dataGridViewColumn3.Width = dataGridView1.Width / 5;
            }
            return dataGridViewColumn3;
        }
        private DataGridViewColumn getDataGridViewColumn4()
        {
            if (dataGridViewColumn4 == null)
            {
                dataGridViewColumn4 = new DataGridViewTextBoxColumn();
                dataGridViewColumn4.Name = "";
                dataGridViewColumn4.HeaderText = "Publisher";
                dataGridViewColumn4.ValueType = typeof(string);
                dataGridViewColumn4.Width = dataGridView1.Width / 5;
            }
            return dataGridViewColumn4;
        }
        private DataGridViewColumn getDataGridViewColumn5()
        {
            if (dataGridViewColumn5 == null)
            {
                dataGridViewColumn5 = new DataGridViewTextBoxColumn();
                dataGridViewColumn5.Name = "";
                dataGridViewColumn5.HeaderText = "Pages";
                dataGridViewColumn5.ValueType = typeof(string);
                dataGridViewColumn5.Width = dataGridView1.Width / 5;
            }
            return dataGridViewColumn5;
        }
        private void addBook(string name, string author, int price, string publisher, int pages)
        {
            Book b = new Book(name, author, price, publisher, pages);
            bookSet.Add(b);
            NameTextField.Text = "";
            AuthorTextField.Text = "";
            PriceTextField.Text = "";
            PublisherTextField.Text = "";
            PagesTextField.Text = "";
            showListInGrid();
        }

        private void deleteBook(int elementIndex)
        {
            try
            {
            Book tBook = new Book((String)dataGridView1.SelectedCells[0].Value, (String)dataGridView1.SelectedCells[1].Value, (Int32)dataGridView1.SelectedCells[2].Value, (String)dataGridView1.SelectedCells[3].Value, (Int32)dataGridView1.SelectedCells[4].Value);
            Console.WriteLine(tBook.ToString() + "#"); 
            foreach(Book sBook in bookSet)
            {
                if (sBook.IsEqual(tBook))
                {
                    tBook = sBook;
                }
            }
            bookSet.Remove(tBook);
            //foreach (Book sBook in bookSet)
            //{
            //    Console.WriteLine("_After__" + sBook.ToString());
            //}
            showListInGrid();
            }
            catch(Exception)
            {
                MessageBox.Show(String.Format("Ошибка при попытке удалить ряд"),
                "",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }
        private void showListInGrid()
        {
            dataGridView1.Rows.Clear();
            foreach (Book b in bookSet)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell cell1 = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell2 = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell3 = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell4 = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell5 = new DataGridViewTextBoxCell();
                cell1.ValueType = typeof(string);
                cell1.Value = b.GetName();
                cell2.ValueType = typeof(string);
                cell2.Value = b.GetAuthor();
                cell3.ValueType = typeof(int);
                cell3.Value = b.GetPrice();
                cell4.ValueType = typeof(string);
                cell4.Value = b.GetPublisher();
                cell5.ValueType = typeof(int);
                cell5.Value = b.GetPages();
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);
                row.Cells.Add(cell4);
                row.Cells.Add(cell5);
                dataGridView1.Rows.Add(row);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            int price, pages;
            if(!Int32.TryParse(PriceTextField.Text, out price))
            {
                MessageBox.Show(String.Format("Значение {0} есть не корректным для данного поля", PriceTextField.Text),
                                "Установка по-умолчанию значения 0",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                price = 0;
            }
            if (!Int32.TryParse(PagesTextField.Text, out pages))
            {
                MessageBox.Show(String.Format("Значение {0} есть не корректным для данного поля", PagesTextField.Text),
                                "Установка по-умолчанию значения 0",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                pages = 0;
            }

            addBook(NameTextField.Text, AuthorTextField.Text, price, PublisherTextField.Text, pages);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int selectedRow = dataGridView1.SelectedCells[0].RowIndex;
            DialogResult dr = MessageBox.Show("Delete selected book?", "",
            MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    deleteBook(selectedRow);
                }
                catch (Exception)
                {
                }
            }
        }
    }                                   
}                                       
