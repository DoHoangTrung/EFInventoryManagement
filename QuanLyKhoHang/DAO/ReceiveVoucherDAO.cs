using PagedList;
using QuanLyKhoHang.DTO;
using QuanLyKhoHang.Entity;
using QuanLyKhoHang.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.DAO
{
    public class ReceiveVoucherDAO
    {
        private static ReceiveVoucherDAO instance;

        InventoryContext db = new InventoryContext();

        public static ReceiveVoucherDAO Instance
        {
            get { if (instance == null) instance = new ReceiveVoucherDAO(); return instance; }
            set { }
        }

        public List<ReceiveVoucher> GetListReceiveVoucher()
        {
            List<ReceiveVoucher> receiveVouchers = db.ReceiveVouchers.ToList();

            foreach (var voucher in receiveVouchers)
            {
                // a receive voucher has a list receiveVoucherInfos, a receiveVoucherInfos has a product
                List<ReceiveVoucherInfo> voucherInfos = (from info in db.ReceiveVoucherInfoes
                                                         where info.IDReceiveVoucher == voucher.ID
                                                         select info).ToList();

                foreach (var vInfo in voucherInfos)
                {
                    Product product = db.Products.Find(vInfo.IDProduct);
                    vInfo.Product = product;
                }

                voucher.ReceiveVoucherInfoes = voucherInfos;

                // a receive voucher have a supplier
                Supplier supplier = db.Suppliers.Find(voucher.IDSupplier);
                voucher.Supplier = supplier;

            }

            return receiveVouchers;
        }

        public List<ReceiveVoucherInfo> Search(string keyWord)
        {
            List<ReceiveVoucherInfo> receiveVoucherInfos = db.ReceiveVoucherInfoes.ToList();
            var searchList = receiveVoucherInfos.Where((i) =>
            {
                //find keywords in text
                string text, key;
                text = i.IDReceiveVoucher + " " + i.IDProduct + " " + i.Product.Name + " " + i.Product.Unit + " "
                + i.Note + " " + i.ReceiveVoucher.ID + " " + i.ReceiveVoucher.Supplier.Name + " " + i.ReceiveVoucher.Supplier.Phone
                + " " + i.ReceiveVoucher.Supplier.Address + " " + i.ReceiveVoucher.Supplier.Email;
                key = keyWord;

                text = text.Format();
                key = key.Format();

                if (text.Contains(key))
                    return true;
                else
                    return false;
            }).Select(i => i).ToList();

            return searchList;
        }

        public List<string> GetListID()
        {
            List<string> IDs = (from v in db.ReceiveVouchers
                                select v.ID).ToList<string>();
            return IDs;
        }

        public bool CheckID(string _id)
        {
            bool result = true;

            bool checkLength = true;
            if (_id.Length == 0 || _id.Length > 30)
            {
                checkLength = false;
            }

            bool notDuplicate = true;
            List<string> listID = GetListID();
            foreach (string id in listID)
            {
                if (_id == id)
                {
                    notDuplicate = false;
                    break;
                }
            }

            result = checkLength && notDuplicate;
            return result;
        }

        public int InserReceivetVoucher(string idVoucher, DateTime date, string IDSupplier , List<ReceiveVoucherInfo> voucherInfos)
        {
            int rowAffected = 0;

            ReceiveVoucher voucher = new ReceiveVoucher();
            voucher.ID = idVoucher;
            voucher.Date = date;
            voucher.IDSupplier = IDSupplier;
            foreach (var info in voucherInfos)
            {
                voucher.ReceiveVoucherInfoes.Add(info);
            }

            db.ReceiveVouchers.Add(voucher);
            rowAffected = db.SaveChanges();

            db.Entry(voucher).Reference(v => v.Supplier).Load();

            return rowAffected;
        }
        public int InserReceivetVoucher(string id, DateTime date, string IDSupplier)
        {
            int rowAffected = 0;

            ReceiveVoucher v = new ReceiveVoucher();
            v.ID = id;
            v.Date = date;
            v.IDSupplier = IDSupplier;

            db.ReceiveVouchers.Add(v);
            rowAffected = db.SaveChanges();

            return rowAffected;
        }

        public ReceiveVoucher GetByID(string id)
        {
            return db.ReceiveVouchers.Find(id);
        }

        public int UpdateReceiveVoucher(ReceiveVoucher vUpdate)
        {
            int rowAffected = 0;
            string idVoucher = vUpdate.ID;

            ReceiveVoucher voucher = db.ReceiveVouchers.Find(idVoucher);
            if (voucher != null)
            {
                //voucher.Supplier = null;
                voucher.IDSupplier = vUpdate.IDSupplier;
                voucher.Date = vUpdate.Date;

                //remove old info
                foreach (var oInfo in voucher.ReceiveVoucherInfoes.ToList())
                {
                    voucher.ReceiveVoucherInfoes.Remove(oInfo);
                }

                //add new info
                foreach (var nInfo in vUpdate.ReceiveVoucherInfoes)
                {
                    voucher.ReceiveVoucherInfoes.Add(nInfo);
                }

                rowAffected = db.SaveChanges();
                db.Entry(voucher).Reference(v => v.Supplier).Load();
            }

            return rowAffected;
        }

        public bool HaveTheProductBeenSold(string idVoucher)
        {
            bool check = false;

            ReceiveVoucher voucher = GetByID(idVoucher);
            foreach (var info in voucher.ReceiveVoucherInfoes)
            {
                if (info.QuantityOutput > 0) check = true;
                break;
            }

            return check;
        }

        public int RemoveReceiveVoucher(string idVoucher)
        {
            int rowAffected = 0;

            //we check HaveTheProductBeenSold before remove

            if (!HaveTheProductBeenSold(idVoucher))
            {
                ReceiveVoucher voucher = GetByID(idVoucher);
                if(voucher != null)
                {
                    foreach (var info in voucher.ReceiveVoucherInfoes.ToList())
                    {
                        voucher.ReceiveVoucherInfoes.Remove(info);
                    }

                    db.ReceiveVouchers.Remove(voucher);

                    rowAffected = db.SaveChanges();
                }
            }
            return rowAffected;
        }

        public List<ReceiveVoucherDTO> GetList(SearchModel searchModel)
        {
            var vouchers = db.Database.SqlQuery<ReceiveVoucherDTO>("select * from ReceiveVoucherDTO").ToList();

            if (!string.IsNullOrEmpty(searchModel.KeyWords))
            {
                vouchers = vouchers.Where((v) =>
                {
                    //find keywords in text
                    string text, key;
                    text = v.ReceiveVoucherID + " " + v.ProductID + " " + v.ProductName + " " + v.Unit + " "
                    + v.Note + " " + v.SupplierName + " " + v.Phone
                    + " " + v.Address;
                    key = searchModel.KeyWords;

                    text = text.Format();
                    key = key.Format();

                    if (text.Contains(key))
                        return true;
                    else
                        return false;
                }).Select(v => v).ToList();
            }

            if (searchModel.MaxValue != null)
            {
                int max, min;
                max = (int)searchModel.MaxValue;
                min = (int)searchModel.MinValue;

                vouchers = vouchers.Where(v =>
                {
                    return min <= v.PriceInput && v.PriceInput <= max;

                }).Select(v => v).ToList();
            }

            if (searchModel.FromDate != null)
            {
                DateTime fromDate, toDate;
                fromDate = (DateTime)searchModel.FromDate;
                toDate = (DateTime)searchModel.ToDate;

                vouchers = vouchers.Where(v =>
                {
                    return fromDate <= v.Date && v.Date <= toDate;

                }).Select(v => v).ToList();
            }

            return vouchers;
        }
    }
}
