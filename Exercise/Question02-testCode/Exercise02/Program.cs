using Exercise02;

List<Product> itemlist = new List<Product>
            {
           new Product { Id = 1,  Name = "Biscuit  " },
           new Product { Id = 2,  Name = "Chocolate" },
           new Product { Id = 3,  Name = "Butter   " },
           new Product { Id = 4,  Name = "Brade    " },
           new Product { Id = 5,  Name = "Honey    " }
            };

List<Purchase> purchlist = new List<Purchase>
            {
           new Purchase { InvoiceNo=100, ProductId = 3,  Quantity = 800 },
           new Purchase { InvoiceNo=101, ProductId = 5,  Quantity = 650 },
           new Purchase { InvoiceNo=102, ProductId = 3,  Quantity = 900 },
           new Purchase { InvoiceNo=103, ProductId = 4,  Quantity = 700 },
           new Purchase { InvoiceNo=104, ProductId = 3,  Quantity = 900 },
           new Purchase { InvoiceNo=105, ProductId = 4,  Quantity = 650 },
           new Purchase { InvoiceNo=106, ProductId = 1,  Quantity = 458 }
            };

Console.Write("\nSample : Generate a Right Join between two data sets : ");
Console.Write("\n--------------------------------------------------\n");
Console.Write("Here is the Product List : ");
Console.Write("\n-------------------------\n");

// to do
foreach (var item in itemlist)
{
    Console.WriteLine("Item Id: {0}, Title: {1}",item.Id,item.Name);
}


Console.Write("\nHere is the Purchase List : ");
Console.Write("\n--------------------------\n");

// to do
foreach (var item in purchlist)
{
    Console.WriteLine("Invoice No: {0}, Product Id : {1},  Quantity : {2}", item.InvoiceNo, item.ProductId , item.Quantity);
}


Console.Write("\nHere is the list after joining  : \n\n");


// to do
var bill = purchlist.GroupJoin(
         itemlist,
         right => right.ProductId,
         left => left.Id,
         (right, leftGroup) => new { Right = right, LeftGroup = leftGroup.DefaultIfEmpty() }
     )
     .SelectMany(
         rg => rg.LeftGroup,
         (rg, left) => new Bill
         {
             ProductId = (int)(left?.Id),
             ProductName = left?.Name,
             PurchaseQuantity = rg.Right.Quantity,
            
         }
     );


/*
var left = itemlist;
var right = purchlist;

List<Bill> bill = new List<Bill>();

for (int i = 0; i < right.Count; i++)
{
    for (int j = 0;j <left.Count; j++)
    {
        if (right[i].ProductId == left[j].Id)
        {

            bill.Add(new Bill
                {
                    ProductId = right[i].ProductId,
                    ProductName = left[j].Name,
                    PurchaseQuantity = right[i].Quantity,
                }
            );
            
        }
    }
    
}
*/



Console.WriteLine("Product ID\tProduct Name\tPurchase Quantity");
Console.WriteLine("-------------------------------------------------------");

// to do
foreach (var item in bill)
{
    Console.WriteLine("{0}\t\t{1}\t{2}",item.ProductId,item.ProductName,item.PurchaseQuantity);
}

Console.ReadLine();