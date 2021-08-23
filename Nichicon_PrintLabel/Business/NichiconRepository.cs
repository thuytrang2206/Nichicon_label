using Nichicon_PrintLabel.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nichicon_PrintLabel.Business
{
    public class NichiconRepository
    {
        public static Nichicon_ItemSeiral1 GetLastSerial1(string model)
        {
            using (DataContext context = new DataContext())
            {
                return context.Nichicon_ItemSeiral1.Find(model);
            }
        }
        public static Nichicon_model GetModel(string model)
        {
            using (DataContext context = new DataContext())
            {
                return context.Nichicon_model.Where(c=>c.Model_Name==model).SingleOrDefault();
            }
        }
        public static bool SaveHistoryOfSerial1(Nichicon_ItemSeiral1 item, List<Nichicon_HistoriesSerial1> histories)
        {
            using (DataContext context = new DataContext())
            {
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Nichicon_HistoriesSerial1.AddRange(histories);
                        context.SaveChanges();

                        var itemExist = context.Nichicon_ItemSeiral1.Find(item.Model_Name);
                        if (itemExist != null)
                        {
                            itemExist.BarCode_Last = item.BarCode_Last;
                            itemExist.Create_Date = item.Create_Date;
                            context.Entry<Nichicon_ItemSeiral1>(itemExist).State = EntityState.Modified;
                            context.SaveChanges();
                        }
                        else
                        {
                            context.Nichicon_ItemSeiral1.Add(item);
                            context.SaveChanges();
                        }
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }
        public static Nichicon_ItemSerial2 GetLastSerial2(string model)
        {
            using (DataContext context = new DataContext())
            {
                return context.Nichicon_ItemSerial2.Find(model);
            }
        }
        public static bool SaveHistoryOfSerial2(Nichicon_ItemSerial2 item, List<Nichicon_HistoriesSerial2> histories)
        {
            using (DataContext context = new DataContext())
            {
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Nichicon_HistoriesSerial2.AddRange(histories);
                        context.SaveChanges();

                        var itemExist = context.Nichicon_ItemSerial2.Find(item.Model_Name);
                        if (itemExist != null)
                        {
                            itemExist.BarCode_Last = item.BarCode_Last;
                            itemExist.Code_productcustomer = item.Code_productcustomer;
                            itemExist.Create_Date = item.Create_Date;
                            context.Entry<Nichicon_ItemSerial2>(itemExist).State = EntityState.Modified;
                            context.SaveChanges();
                        }
                        else
                        {
                            context.Nichicon_ItemSerial2.Add(item);
                            context.SaveChanges();
                        }
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }
    }
}
