using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityProject
{
    public partial class Form1 : Form
    {
        Entity_CompanyEntities db = new Entity_CompanyEntities();
        public Form1()
        {
            InitializeComponent();
            
        }


        /// <summary>
        /// operation on warehouse throw warehouse tab page
        /// </summary>
        private void btn_AddWH_Click(object sender, EventArgs e)
        {
            
            if (txt_Wname.Text != string.Empty && txt_Wmanager.Text != string.Empty && txt_Waddress.Text != string.Empty)
            {
                Warehouse w = new Warehouse()
                {
                    War_Name = txt_Wname.Text,
                    War_Address = txt_Waddress.Text,
                    SK_Name = txt_Wmanager.Text

                };
                db.Warehouses.Add(w);
                db.SaveChanges();
                MessageBox.Show("Warehouse added successfully");
                txt_Wname.Text = string.Empty;
                txt_Waddress.Text = string.Empty;
                txt_Wmanager.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("please complete missing fields");

            }
        }

        private void btn_EditWH_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Wname.Text != string.Empty)
                {
                    Warehouse w = db.Warehouses.FirstOrDefault(a => a.War_Name == txt_Wname.Text);
                    txt_Waddress.Text = w.War_Address;
                    txt_Wmanager.Text = w.SK_Name;
                }
                btn_AddWH.Visible = false;
                btn_DeleteWH.Visible = false;
                btn_ModifyWH.Enabled = true;
                btn_EditWH.Enabled = false;
                txt_Wname.ReadOnly = true;
            }
            catch
            {
                MessageBox.Show("Can't find warehouse with giving information");
            }
        }

        private void btn_ModifyWH_Click(object sender, EventArgs e)
        {
            Warehouse w = db.Warehouses.FirstOrDefault(a => a.War_Name == txt_Wname.Text);
            if (txt_Waddress.Text != string.Empty && txt_Wmanager.Text != string.Empty)
            {
                w.War_Address = txt_Waddress.Text;
                w.SK_Name = txt_Wmanager.Text;
                MessageBox.Show("Warehouse is updated");
                txt_Wname.Text = string.Empty;
                txt_Waddress.Text = string.Empty;
                txt_Wmanager.Text = string.Empty;
            }
            btn_AddWH.Visible = true;
            btn_DeleteWH.Visible = true;
            btn_ModifyWH.Enabled = false;
            btn_EditWH.Enabled = true;
            txt_Wname.ReadOnly = false;
        }

        private void btn_DeleteWH_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Wname.Text != string.Empty)
                {
                    Warehouse w = db.Warehouses.FirstOrDefault(a => a.War_Name == txt_Wname.Text);
                    db.Warehouses.Remove(w);
                    db.SaveChanges();
                    MessageBox.Show("Warehouse deleted sucessfuly");
                    txt_Wname.Text = string.Empty;
                    txt_Waddress.Text = string.Empty;
                    txt_Wmanager.Text = string.Empty;
                }
            }
            catch
            {
                MessageBox.Show("Can't find warehouse with giving information");
            }
        }

        

        /// <summary>
        /// operation on product throw Product tab page
        /// </summary>
        private void btn_AddProd_Click(object sender, EventArgs e)
        {
            if (txt_Pid.Text != string.Empty && txt_Pname.Text != string.Empty)
            {
                Product p = new Product()
                {
                    Prod_Id = int.Parse(txt_Pid.Text),
                    Prod_Name = txt_Pname.Text
                };
                db.Products.Add(p);
                db.SaveChanges();
                MessageBox.Show("Product added successfully");
                txt_Pid.Text = string.Empty;
                txt_Pname.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("please complete missing fields");

            }
        }

        private void btn_EditProd_Click(object sender, EventArgs e)
        {
            try
            {

                if (txt_Pid.Text != string.Empty)
                {
                    int id = int.Parse(txt_Pid.Text);
                    Product p = db.Products.SingleOrDefault(a => a.Prod_Id == id);
                    txt_Pname.Text = p.Prod_Name;
                }
                btn_AddProd.Visible = false;
                btn_DeleteProd.Visible = false;
                btn_ModifyProd.Enabled = true;
                btn_EditProd.Enabled = false;
                txt_Pid.ReadOnly = true;
            }
            catch
            {
                MessageBox.Show("Can't find product with giving information");
            }

        }

        private void btn_ModifyProd_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txt_Pid.Text);
            Product p = db.Products.FirstOrDefault(a => a.Prod_Id == id);
            if (txt_Pname.Text != string.Empty)
            {
                p.Prod_Name = txt_Pname.Text;
                MessageBox.Show("Product is updated");
                txt_Pid.Text = string.Empty;
                txt_Pname.Text = string.Empty;
            }
            btn_AddProd.Visible = true;
            btn_DeleteProd.Visible = true;
            btn_ModifyProd.Enabled = false;
            btn_EditProd.Enabled = true;
            txt_Pid.ReadOnly = false;
        }

        private void btn_DeleteProd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Pid.Text != string.Empty)
                {
                    int id = int.Parse(txt_Pid.Text);
                    Product p = db.Products.FirstOrDefault(a => a.Prod_Id == id);
                    db.Products.Remove(p);
                    db.SaveChanges();
                    MessageBox.Show("Product deleted sucessfuly");
                    txt_Pid.Text = string.Empty;
                    txt_Pname.Text = string.Empty;
                }
            }
            catch
            {
                MessageBox.Show("Can't find product with giving information");
            }
        }


        /// <summary>
        /// operation on supplier throw supplier tab page
        /// </summary>
        private void btn_AddSup_Click(object sender, EventArgs e)
        {
            if (txt_Sname.Text != string.Empty && txt_Smobile.Text != string.Empty && txt_Semail.Text != string.Empty)
            {
                Supplier s = new Supplier()
                {
                    Sup_Name = txt_Sname.Text,
                    Sup_HomePhone = txt_Sphone.Text,
                    Sup_Fax = txt_Sfax.Text,
                    Sup_MobliePhone = txt_Smobile.Text,
                    Sup_Email = txt_Semail.Text,
                    Sup_Website = txt_Swebsite.Text

                };
                db.Suppliers.Add(s);
                db.SaveChanges();
                MessageBox.Show("Supplier added successfully");
                txt_Sname.Text = string.Empty;
                txt_Sphone.Text = string.Empty;
                txt_Sfax.Text = string.Empty;
                txt_Smobile.Text = string.Empty;
                txt_Semail.Text = string.Empty;
                txt_Swebsite.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("please complete missing fields");
            }
        }

        private void btn_EditSup_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Sname.Text != string.Empty)
                {
                    Supplier s = db.Suppliers.FirstOrDefault(a => a.Sup_Name == txt_Sname.Text);
                    txt_Sphone.Text = s.Sup_HomePhone;
                    txt_Sfax.Text = s.Sup_Fax;
                    txt_Smobile.Text = s.Sup_MobliePhone;
                    txt_Semail.Text = s.Sup_Email;
                    txt_Swebsite.Text = s.Sup_Website;
                }
                btn_AddSup.Visible = false;
                btn_DeleteSup.Visible = false;
                btn_ModifySup.Enabled = true;
                btn_EditSup.Enabled = false;
                txt_Sname.ReadOnly = true;
            }
            catch
            {
                MessageBox.Show("Can't find supplier with giving information");
            }
        }

        private void btn_ModifySup_Click(object sender, EventArgs e)
        {
            Supplier s = db.Suppliers.FirstOrDefault(a => a.Sup_Name == txt_Sname.Text);
            if (txt_Sname.Text != string.Empty && txt_Smobile.Text != string.Empty && txt_Semail.Text != string.Empty)
            {
                s.Sup_Name = txt_Sname.Text;
                s.Sup_HomePhone = txt_Sphone.Text;
                s.Sup_Fax = txt_Sfax.Text;
                s.Sup_MobliePhone = txt_Smobile.Text;
                s.Sup_Email = txt_Semail.Text;
                s.Sup_Website = txt_Swebsite.Text;
                MessageBox.Show("Supplier is updated");
                txt_Wname.Text = string.Empty;
                txt_Waddress.Text = string.Empty;
                txt_Wmanager.Text = string.Empty;
            }
            btn_AddSup.Visible = true;
            btn_DeleteSup.Visible = true;
            btn_ModifySup.Enabled = false;
            btn_EditSup.Enabled = true;
            txt_Sname.ReadOnly = false;
        }

        private void btn_DeleteSup_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Sname.Text != string.Empty)
                {
                    Supplier s = db.Suppliers.FirstOrDefault(a => a.Sup_Name == txt_Wname.Text);
                    db.Suppliers.Remove(s);
                    db.SaveChanges();
                    MessageBox.Show("Supplier deleted sucessfuly");
                    txt_Sname.Text = string.Empty;
                    txt_Sphone.Text = string.Empty;
                    txt_Sfax.Text = string.Empty;
                    txt_Smobile.Text = string.Empty;
                    txt_Semail.Text = string.Empty;
                    txt_Swebsite.Text = string.Empty;
                }
            }
            catch
            {
                MessageBox.Show("Can't find supplier with giving information");
            }
        }

        /// <summary>
        /// operation on customer throw customer tab page
        /// </summary>

        private void btn_AddCus_Click(object sender, EventArgs e)
        {
            if (txt_Cname.Text != string.Empty && txt_Cmobile.Text != string.Empty && txt_Cemail.Text != string.Empty)
            {
                Customer c = new Customer()
                {
                    Cus_Name = txt_Cname.Text,
                    Cus_HomePhone = txt_Cphone.Text,
                    Cus_MobilePhone = txt_Cmobile.Text,
                    Cus_Fax= txt_Cfax.Text,
                    Cus_Email = txt_Cemail.Text,
                    Cus_Website = txt_Cwebsite.Text

                };
                db.Customers.Add(c);
                db.SaveChanges();
                MessageBox.Show("Supplier added successfully");
                txt_Cname.Text = string.Empty;
                txt_Cphone.Text = string.Empty;
                txt_Cfax.Text = string.Empty;
                txt_Cmobile.Text = string.Empty;
                txt_Cemail.Text = string.Empty;
                txt_Cwebsite.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("please complete missing fields");
            }
        }

        private void btn_EditCus_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Cname.Text != string.Empty)
                {
                    Customer c = db.Customers.FirstOrDefault(a => a.Cus_Name == txt_Cname.Text);
                    txt_Cphone.Text = c.Cus_HomePhone;
                    txt_Cfax.Text = c.Cus_Fax;
                    txt_Cmobile.Text = c.Cus_MobilePhone;
                    txt_Cemail.Text = c.Cus_Email;
                    txt_Cwebsite.Text = c.Cus_Website;
                }
                btn_AddCus.Visible = false;
                btn_DeleteCus.Visible = false;
                btn_ModifyCus.Enabled = true;
                btn_EditCus.Enabled = false;
                txt_Cname.ReadOnly = true;
            }
            catch
            {
                MessageBox.Show("Can't find customer with giving information");
            }
        }

        private void btn_ModifyCus_Click(object sender, EventArgs e)
        {
            Customer c = db.Customers.FirstOrDefault(a => a.Cus_Name == txt_Cname.Text);
            if (txt_Cname.Text != string.Empty && txt_Cmobile.Text != string.Empty && txt_Cemail.Text != string.Empty)
            {
                c.Cus_Name = txt_Cname.Text;
                c.Cus_HomePhone = txt_Cphone.Text;
                c.Cus_MobilePhone = txt_Cmobile.Text;
                c.Cus_Fax = txt_Cfax.Text;
                c.Cus_Email = txt_Cemail.Text;
                c.Cus_Website = txt_Cwebsite.Text;
                MessageBox.Show("Customer is updated");
                txt_Cname.Text = string.Empty;
                txt_Cphone.Text = string.Empty;
                txt_Cfax.Text = string.Empty;
                txt_Cmobile.Text = string.Empty;
                txt_Cemail.Text = string.Empty;
                txt_Cwebsite.Text = string.Empty;
            }
            btn_AddCus.Visible = true;
            btn_DeleteCus.Visible = true;
            btn_ModifyCus.Enabled = false;
            btn_EditCus.Enabled = true;
            txt_Cname.ReadOnly = false;
        }

        private void btn_DeleteCus_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Cname.Text != string.Empty)
                {
                    Customer c = db.Customers.FirstOrDefault(a => a.Cus_Name == txt_Cname.Text);
                    db.Customers.Remove(c);
                    db.SaveChanges();
                    MessageBox.Show("Customer deleted sucessfuly");
                    txt_Cname.Text = string.Empty;
                    txt_Cphone.Text = string.Empty;
                    txt_Cfax.Text = string.Empty;
                    txt_Cmobile.Text = string.Empty;
                    txt_Cemail.Text = string.Empty;
                    txt_Cwebsite.Text = string.Empty;
                }
            }
            catch
            {
                MessageBox.Show("Can't find customer with giving information");
            }
        }


        /// <summary>
        /// operation on supply permission throw supply permission tab page
        /// </summary>
        private void tc_Main_MouseClick(object sender, MouseEventArgs e)
        {
            if(tc_Main.SelectedTab == tp_SupplyPermission)
            {
                var query1 = db.Warehouses.Select(a=>a.War_Name);
                var query2 = db.Suppliers.Select(a=>a.Sup_Name);
                var query3 = db.Products.Select(a => new { a.Prod_Name , a.Prod_Id });
                var query4 = db.Supply_Permission_Product;
                cb_Warehouses.DataSource = query1.ToList();
                cb_Suppliers.DataSource = query2.ToList();
                cb_Products.DataSource = query3.ToList();
                cb_Products.DisplayMember = "Prod_Name";
                cb_Products.ValueMember = "Prod_Id";
                dgv_Products.DataSource = query4.ToList();
            }
        }


        // create permission button handle
        private void btn_Create_Click(object sender, EventArgs e)
        {
            if (txt_SPid.Text != string.Empty && txt_SPdate.Text != string.Empty)
            {
                Supply_Permission sp = new Supply_Permission()
                {
                    Per_Id = int.Parse(txt_SPid.Text),
                    Per_Date = DateTime.Parse(txt_SPdate.Text),
                    War_Name = cb_Warehouses.SelectedItem.ToString(),
                    Sup_Name = cb_Suppliers.SelectedItem.ToString()
                };
                db.Supply_Permission.Add(sp);
                db.SaveChanges();
                MessageBox.Show("Permission created successfully you can now add products");
                dgv_Products.DataSource = db.Supply_Permission_Product.Where(a => a.Per_Id == sp.Per_Id).ToList();
                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
                if (txt_Quantity.Text != string.Empty || txt_PD.Text != string.Empty || txt_ED.Text != string.Empty)
                {
                    txt_Quantity.Text = string.Empty;
                    txt_PD.Text = string.Empty;
                    txt_ED.Text = string.Empty;
                }
            }
            else
            {
                MessageBox.Show("please complete missing fields Permission No. or Permission Date");
            }
        }


        // main 3 buttons of supply permission
        

        private void btn_EditSP_Click(object sender, EventArgs e)
        {
            try
            {
                groupBox2.Enabled = true;
                if (txt_SPid.Text != string.Empty)
                {
                    var id = int.Parse(txt_SPid.Text);
                    Supply_Permission sp = db.Supply_Permission.FirstOrDefault(a => a.Per_Id == id);
                    txt_SPdate.Text = sp.Per_Date.ToString();
                    cb_Warehouses.SelectedItem = sp.War_Name;
                    cb_Suppliers.SelectedItem = sp.Sup_Name;
                    var query = db.Supply_Permission_Product.Where(a => a.Per_Id == sp.Per_Id);
                    dgv_Products.DataSource = query.ToList();
                }
                btn_SubmitSP.Enabled = false;
                btn_DeleteSP.Enabled = false;
                btn_ModifySP.Enabled = true;
                btn_EditSP.Enabled = false;
                txt_SPid.ReadOnly = true;
            }
            catch
            {
                MessageBox.Show("Can't find permission with giving information");
            }
        }

        private void btn_ModifySP_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txt_SPid.Text);
            Supply_Permission sp = db.Supply_Permission.FirstOrDefault(a => a.Per_Id == id);
            if (txt_SPdate.Text != string.Empty)
            {
                sp.Per_Date = DateTime.Parse(txt_SPdate.Text);
                sp.War_Name = cb_Warehouses.SelectedItem.ToString();
                sp.Sup_Name = cb_Suppliers.SelectedItem.ToString();
                MessageBox.Show("Product is updated");
                txt_Pid.Text = string.Empty;
                txt_Pname.Text = string.Empty;
            }
            btn_SubmitSP.Enabled = true;
            btn_DeleteProd.Enabled = true;
            btn_ModifyProd.Enabled = false;
            btn_EditProd.Enabled = true;
            txt_Pid.ReadOnly = false;
            groupBox2.Enabled = false;
        }

        private void btn_DeleteSP_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Cname.Text != string.Empty)
                {
                    int id = int.Parse(txt_SPid.Text);
                    Supply_Permission sp = db.Supply_Permission.FirstOrDefault(a => a.Per_Id == id);
                    db.Supply_Permission.Remove(sp);
                    db.SaveChanges();
                    MessageBox.Show("permission deleted sucessfuly");
                    txt_SPid.Text = string.Empty;
                    txt_SPdate.Text = string.Empty;
                    
                }
            }
            catch
            {
                MessageBox.Show("Can't find permission with giving information");
            }
        }

        /// <summary>
        /// list product in permission operation inside supply permission tab page
        /// </summary>
        private void btn_AddtoDGV_Click(object sender, EventArgs e)
        {
            if(txt_Quantity.Text != string.Empty && txt_PD.Text != string.Empty && txt_ED.Text != string.Empty)
            {

                Supply_Permission_Product spp = new Supply_Permission_Product()
                {
                    Per_Id = int.Parse(txt_SPid.Text),
                    Prod_Id = cb_Products.SelectedIndex,
                    Prod_Name = cb_Products.Text,
                    Prod_Quantity = int.Parse(txt_Quantity.Text),
                    Production_Date = DateTime.Parse(txt_PD.Text),
                    Expiration_Date = DateTime.Parse(txt_ED.Text)
                };
                db.Supply_Permission_Product.Add(spp);
                db.SaveChanges();
                MessageBox.Show("product added successfully");
                dgv_Products.DataSource = db.Supply_Permission_Product.Where(a => a.Per_Id == spp.Per_Id).ToList();
                txt_Quantity.Text = string.Empty;
                txt_PD.Text = string.Empty;
                txt_ED.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("please complete missing fields in product form");
            }
        }
        
        // edit selected row by double click event
        private void dgv_Products_DoubleClick(object sender, EventArgs e)
        {
            if(dgv_Products.CurrentRow.Index != -1)
            {
                Supply_Permission_Product spp = new Supply_Permission_Product();
                spp.Per_Id = Convert.ToInt32(dgv_Products.CurrentRow.Cells["PermissionId"].Value);
                spp.Prod_Id = Convert.ToInt32(dgv_Products.CurrentRow.Cells["ProductId"].Value);
                spp = db.Supply_Permission_Product.Where(a => a.Per_Id == spp.Per_Id && a.Prod_Id == spp.Prod_Id).FirstOrDefault();
                txt_Quantity.Text = spp.Prod_Quantity.ToString();
                txt_PD.Text = spp.Production_Date.ToString();
                txt_ED.Text = spp.Expiration_Date.ToString();
                cb_Products.SelectedIndex = spp.Prod_Id;
                btn_EdittoDGV.Text = "Update";
                btn_AddtoDGV.Enabled = false;
            }
        }

        private void btn_EdittoDGV_Click(object sender, EventArgs e)
        {
            Supply_Permission_Product spp = new Supply_Permission_Product();
            spp.Per_Id = Convert.ToInt32(dgv_Products.CurrentRow.Cells["PermissionId"].Value);
            spp.Prod_Id = Convert.ToInt32(dgv_Products.CurrentRow.Cells["ProductId"].Value);
            spp = db.Supply_Permission_Product.Where(a => a.Per_Id == spp.Per_Id && a.Prod_Id == spp.Prod_Id).FirstOrDefault();
            if (txt_Quantity.Text != string.Empty && txt_PD.Text != string.Empty && txt_ED.Text != string.Empty)
            {
                spp.Prod_Id = cb_Products.SelectedIndex;
                spp.Prod_Name = cb_Products.Text;
                spp.Prod_Quantity = int.Parse(txt_Quantity.Text);
                spp.Production_Date = DateTime.Parse(txt_PD.Text);
                spp.Expiration_Date = DateTime.Parse(txt_ED.Text);
                MessageBox.Show("product is updated");
                dgv_Products.DataSource = db.Supply_Permission_Product.Where(a => a.Per_Id == spp.Per_Id).ToList();
                txt_Quantity.Text = string.Empty;
                txt_PD.Text = string.Empty;
                txt_ED.Text = string.Empty;
                btn_AddtoDGV.Enabled = true;
            }
            else
            {
                MessageBox.Show("please complete missing fields in product form");
            }
            
        }

        private void btn_DeletefromDGV_Click(object sender, EventArgs e)
        {
            Supply_Permission_Product spp = new Supply_Permission_Product();
            spp.Per_Id = Convert.ToInt32(dgv_Products.CurrentRow.Cells["PermissionId"].Value);
            spp.Prod_Id = Convert.ToInt32(dgv_Products.CurrentRow.Cells["ProductId"].Value);
            spp = db.Supply_Permission_Product.Where(a => a.Per_Id == spp.Per_Id && a.Prod_Id == spp.Prod_Id).FirstOrDefault();
            db.Supply_Permission_Product.Remove(spp);
            db.SaveChanges();
            MessageBox.Show("product deleted sucessfuly");
            dgv_Products.DataSource = db.Supply_Permission_Product.Where(a => a.Per_Id == spp.Per_Id && a.Prod_Id == spp.Prod_Id).ToList();
            txt_Quantity.Text = string.Empty;
            txt_PD.Text = string.Empty;
            txt_ED.Text = string.Empty;
            btn_AddtoDGV.Enabled = true;
        }
    }
}
