using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ClassLibrary1
{
    

    public class Logic

        
    {
        Context database = new Context();

        

        public void AddProduct(string id, string name, int sellprice, int buyprice)
        {

           
                int i = 0;
                List<Product> p = database.product.ToList();
                foreach (Product pr in p)
                {

                    if (pr.Id == id)
                    { i++; }
                }

                if ((i == 0) && (sellprice > buyprice)&&(id.Length==4))
                {
                    Product prod = new Product
                    {
                        Id = id,
                        Name = name,
                        Sellprice = sellprice,
                        BuyPrice = buyprice,


                    };

                    database.product.Add(prod);
                    database.SaveChanges();
                }

            
        
        }

        public void AddVm(string location)
        {
            string b = "[{ \"Banknotes\":\"5000\" ,\"Qantity\":\"1\", \"Banknotes\":\"500\" ,\"Qantity\":\"10\",  \"Banknotes\":\"1000\" ,\"Qantity\":\"100\",\"Banknotes\":\"100\" ,\"Qantity\":\"2\",\"Banknotes\":\"50\",\"Qantity\":\"50\",\"Banknotes\":\"10\" ,\"Qantity\":\"5\"}]";
            string c = "[{ \"Banknotes\":\"5\" ,\"Qantity\":\"1\", \"Banknotes\":\"2\" ,\"Qantity\":\"1\",  \"Banknotes\":\"1\" ,\"Qantity\":\"10\"}]";  
            Vm vm = new Vm
            {
                Location = location,
                Banknotes = b,
                Coins=c,

                };
                database.vm.Add(vm);
                database.SaveChanges();
            
            
        }

        public void UpdateProduct(string id, string name, int sellprice, int buyprice)
        {
            
                if (sellprice > buyprice)
                {
                    Product pr = database.product.FirstOrDefault(x => x.Id == id);
                    pr.Name = name;
                    pr.Sellprice = sellprice;
                    pr.BuyPrice = buyprice;
                    database.SaveChanges();
                }
            
            
        }


        public void UpdateVm(string id, string location)
        {
             Vm vend = database.vm.FirstOrDefault(x => x.Id == int.Parse(id));
                vend.Id = int.Parse(id);
                vend.Location = location;
                database.SaveChanges();
            
            
        }
        public void DeliteProduct(string id)

        {
            
                List<AmountOfProducts> am = database.allst.ToList();
                foreach (AmountOfProducts m in am)
                { if (m.amountofproduct == 0)
                    { if (m.ProductId == id)
                    {
                        AmountOfProducts amo = database.allst.FirstOrDefault(x => x.ProductId == id);
                        database.allst.Remove(amo);
                        database.SaveChanges();
                    }
                   
                        Product pr = database.product.FirstOrDefault(x => x.Id == id);
                        database.product.Remove(pr);
                        database.SaveChanges();
                    List<SellStatistic> s = database.sellst.ToList();
                    foreach (SellStatistic se in s)
                    {
                        if (se.ProductId == id)
                        {
                            SellStatistic sel = database.sellst.FirstOrDefault(x => x.ProductId == id);
                            database.sellst.Remove(sel);
                            database.SaveChanges();
                        }
                    }

                    }
                }
            }
          
        

        public void DeliteVm(string id)

        {
            
                int a;
                a = int.Parse(id);
                Vm vm = database.vm.FirstOrDefault(x => x.Id == a);
                database.vm.Remove(vm);
                database.SaveChanges();
            List<AmountOfProducts> am = database.allst.ToList();
            foreach (AmountOfProducts m in am)
            {

                if (m.VmId == a)
                {

                    AmountOfProducts amo = database.allst.FirstOrDefault(x => x.VmId == a);
                    database.allst.Remove(amo);
                    database.SaveChanges();
                }
            }

                List<SellStatistic> s = database.sellst.ToList();
                foreach (SellStatistic se in s)
                {
                    if (se.VmId == a)
                    {
                        SellStatistic sel = database.sellst.FirstOrDefault(x => x.VmId == a);
                        database.sellst.Remove(sel);
                        database.SaveChanges();
                    }
                }
          
           
        }
        public void Miss(ListView b)
        {
            try
            {
                var missingproduct = from mis in database.allst.ToList()
                                     where mis.amountofproduct == 0
                                     select mis.VmId;
                var amproduct = from am in database.allst.ToList()
                                group am by am.VmId into g
                                select new
                                {
                                    ID = g.Key,
                                    Products = g.Sum(a => a.amountofproduct)
                                };
                var totalproduct = from i in missingproduct
                                   join f in amproduct on i equals f.ID into k
                                   select k;



                var list = totalproduct.ToList();
                var list2 = list.OrderByDescending(x => x.First().Products);
                b.ItemsSource = list2;
            }
            catch { MessageBox.Show("Данных элементов нет"); }
        }
        public void LeastSold(ListView a, string b, string d)
        {
            try
            {
                string date = "01" + "-" + b + "-" + d;
                var t = DateTime.Parse(date);
                var t1 = (DateTime.Parse(date)).AddMonths(1);
                var mounth = (from s in database.sellst
                              where s.datetime >= t && s.datetime < t1
                              group s by s.ProductId into gr
                              select new
                              {
                                  ProductId = gr.Key,
                                  Sold = gr.Sum(x => x.amountofproductsold)
                              }).OrderByDescending(h => h.Sold).ToList().Take(5);
                a.ItemsSource = mounth;
            }
            catch { MessageBox.Show("Данных элементов нет"); }
        }
        public void Income(ListView a, string b, string d)
        {
            try
            {
                string date = "01" + "-" + b + "-" + d;
                var t = DateTime.Parse(date);
                var t1 = (DateTime.Parse(date)).AddMonths(1);
                var request = from s in database.sellst
                              where s.datetime >= t && s.datetime < t1
                              group s by s.VmId into gr
                              select gr;
                List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>();
                foreach (var item in request)
                {
                    var ggg = (from j in item
                               join q in database.product on j.ProductId equals q.Id into s
                               select j.amountofproductsold * s.Where(e => e.Id == j.ProductId).Sum(x => x.Sellprice - x.BuyPrice));
                    int total = 0;
                    foreach (var it in ggg)
                    {
                        total += it;
                    }
                    list.Add(new KeyValuePair<int, int>(item.Key, total));

                }
                var sorted = list.OrderByDescending(x => x.Value).ToList();

                a.ItemsSource = sorted;
            }
            catch { MessageBox.Show("Данных элементов нет"); }
        }
                            
    }

}




