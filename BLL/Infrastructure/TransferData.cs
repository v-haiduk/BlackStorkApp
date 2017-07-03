using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Exel = Microsoft.Office.Interop.Excel;
using BLL.DTO;
using BLL.Interfaces;

namespace BLL.Infrastructure
{
    public class TransferData
    {
        private IMainService<ProductDTO> productService;

        public TransferData() { }
        public TransferData(IMainService<ProductDTO> pServic)
        {
            productService = pServic;
        }

        public void ExportToXML(IEnumerable<ProductDTO> products, string filePath)
        {
            try
            {
                XElement xmlDoc = new XElement("Catalog",
                    from product in products
                    orderby product.ProductId
                    select new XElement("Product",
                        new XElement("ProductID", product.ProductId),
                        new XElement("Name", product.Name),
                        new XElement("Description", product.Description)));
                xmlDoc.Save(filePath);

            }
            catch (FileNotFoundException ex)
            {
                //TODO
            }           
        }

        public void ImportFromXML(string filePath)
        {
            XDocument xmlDoc = XDocument.Load(filePath);
            var collectionOfProducts = from product in xmlDoc.Element("Catalog").Elements("Product")
                                        select new ProductDTO
                                        {
                                            ProductId = 0,
                                            Name = product.Element("Name").Value,
                                            Description = product.Element("Description").Value
                                        };

            foreach (var currentProduct in collectionOfProducts)
            {
                productService.CreateElement(currentProduct);
            }
        }

        public void ExportToXLSX(IEnumerable<ProductDTO> products, string filePath)
        {
            var exelApp = new Exel.Application();
            var exelWorkbook = exelApp.Workbooks.Add();
            Exel.Worksheet workSheet = exelApp.ActiveSheet;

            workSheet.Cells[1, "A"] = "ID";
            workSheet.Cells[1, "B"] = "Название";
            workSheet.Cells[1, "C"] = "Описание";

            var row = 1;
            foreach (var currentProduct in products)
            {
                row++;
                workSheet.Cells[row, "A"] = currentProduct.ProductId;
                workSheet.Cells[row, "B"] = currentProduct.Name;
                workSheet.Cells[row, "C"] = currentProduct.Description;
            }
            workSheet.Columns[2].AutoFit();
            workSheet.Columns[3].AutoFit();

            exelWorkbook.SaveAs(filePath);
            exelWorkbook.Close();
        }

        public void ImportFromXLSX(string filepath)
        {
            var exelApp = new Exel.Application();
            Exel.Workbook workBook =  exelApp.Workbooks.Open(filepath);
            Exel.Worksheet workSheet = exelApp.ActiveSheet;
            Exel.Range range = workSheet.UsedRange;

            int numberOfFilledRow = range.Rows.Count;

            ProductDTO productDTO;
            for (int i = 1; i <= numberOfFilledRow; i++)
            {
                productDTO = new ProductDTO
                {
                    Name = (range.Cells[i, 2] as Exel.Range).Value2,
                    Description = (range.Cells[i, 3] as Exel.Range).Value2
                };
                productService.CreateElement(productDTO);
                
            }
            workBook.Close();
            exelApp.Quit();
        }
    }
}
