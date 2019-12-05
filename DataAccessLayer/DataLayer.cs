using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using BusinessEntities;

namespace DataAccessLayer
{
    public class DataLayer : IDataLayer
    {
        #region Instance Attributes
        private SqlConnection con;   // DB Connection
        DataSet ds;                 //Declare the DataSet object
        SqlDataAdapter da;          //Declare the DataAdapter object
        int totUsers;
        SqlCommandBuilder cb;
        #endregion
        #region Static Attributes
        private static IDataLayer dataLayerSingletonInstance;  // DataLayer object is a singleton so only one instance allowed
        static readonly object padlock = new object(); // Need this for thread safety on the DataLayer singleton creation. ie in GetInstance () method
        #endregion
        #region Constructors
        public static IDataLayer GetInstance() // With Singleton pattern this method is used rather than constructor
        {
            lock (padlock) //   only one thread can entry this block of code
            {
                if (dataLayerSingletonInstance == null)
                {
                    dataLayerSingletonInstance = new DataLayer();
                }
                return dataLayerSingletonInstance;
            }
        }
        private DataLayer()  // The constructor is private as its a singleton and I only allow one instance which is created with the GetInstance() method
        {
            openConnection();
        }
        #endregion
        public void openConnection()
        {
            con = new SqlConnection();
            con.ConnectionString = "Data Source=SQL1.student.litdom.lit.ie\\BWTeam5 ;Initial Catalog=dbPharmacy;Integrated Security=True";
            try
            {
                con.Open();
                //MessageBox.Show("Database Open");
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                Environment.Exit(0); //Force the application to close
            }
        }

        public void closeConnection()
        {
            con.Close();
        }

        public SqlConnection getConnection()
        {
            return con;
        }

        public List<IUser> getAllUsers()
        {
            List<IUser> UserList = new List<IUser>();
            try
            {

                ds = new DataSet();
                string sql = "SELECT * From Users";
                da = new SqlDataAdapter(sql, con);
                cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "UsersData");
                totUsers = ds.Tables["UsersData"].Rows.Count;
                for (int i = 0; i < totUsers; i++)
                {
                    DataRow dRow = ds.Tables["UsersData"].Rows[i];
                    IUser user = UserFactory.GetUser(Convert.ToInt16(dRow.ItemArray.GetValue(0)),  // Using a Factory to create the user entity object. ie seperating object creation from business logic
                                                        dRow.ItemArray.GetValue(1).ToString(),
                                                        dRow.ItemArray.GetValue(2).ToString(),
                                                       dRow.ItemArray.GetValue(3).ToString(),
                                                       Convert.ToBoolean(dRow.ItemArray.GetValue(4)));

                    UserList.Add(user);
                    //MessageBox.Show(dRow.ItemArray.GetValue(1).ToString());
                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
                //Environment.Exit(0); //Force the application to close
            }
            return UserList;
        }
        public void addNewUserToDB(IUser theUser)
        {
            try
            {
                DataSet ds = new DataSet();
                string sql = "SELECT * From Users";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "UsersData");
                totUsers = ds.Tables["UsersData"].Rows.Count;
                DataRow dRow = ds.Tables["UsersData"].NewRow();
                dRow[0] = theUser.UserID;
                dRow[1] = theUser.Username;
                dRow[2] = theUser.Password;
                dRow[3] = theUser.UserType;
                dRow[4] = theUser.Online;

                ds.Tables["UsersData"].Rows.Add(dRow);
                da.Update(ds, "UsersData");
            }
            catch (System.Exception excep)
            {
                if (con.State.ToString() == "Open")
                    con.Close();
                //Application.Exit();
                //Environment.Exit(0); //Force the application to close
            }
        }
        public bool deleteUserFromDB(BusinessEntities.IUser user)
        {
            try
            {
                ds = new DataSet();
                string sql = "SELECT * From Users";
                da = new SqlDataAdapter(sql, con);
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "UsersData");
                DataRow findRow = ds.Tables["UsersData"].Rows.Find(user.UserID);
                if (findRow != null)
                {
                    findRow.Delete(); //mark row as deleted
                }
                da.Update(ds, "UsersData"); //remove row from database table
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                if (getConnection().ToString() == "Open")
                    closeConnection();
                Application.Exit();
            }
            return true;
        }


        public bool editUserInDB(IUser user)
        {
            try
            {
                ds = new DataSet();
                string sql = "SELECT * From Users";
                da = new SqlDataAdapter(sql, con);
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "UsersData");
                DataRow findRow = ds.Tables["UsersData"].Rows.Find(user.UserID);
                if (findRow != null)
                {
                    findRow[0] = user.UserID;
                    findRow[1] = user.Username;
                    findRow[2] = user.Password;
                    findRow[3] = user.UserType;
                    findRow[4] = user.Online;
                }
                da.Update(ds, "UsersData"); //remove row from database table
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                if (getConnection().ToString() == "Open")
                    closeConnection();
                Application.Exit();
            }
            return true;
        }


        public List<IOrder> getAllOrders()
        {
            List<IOrder> OrderList = new List<IOrder>();
            List<IProductLine> ProductLineList = new List<IProductLine>();
            DataSet ds;                 //Declare the DataSet object
            SqlDataAdapter da;   //Declare the DataAdapter object
            SqlCommandBuilder cb;
            try
            {
                ds = new DataSet();
                string sql = "SELECT * From Orders";
                da = new SqlDataAdapter(sql, con);
                cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "OrdersData");
                int totNumOrders = ds.Tables["OrdersData"].Rows.Count;
                for (int i = 0; i < totNumOrders; i++)
                {
                    DataRow dRow = ds.Tables["OrdersData"].Rows[i];

                    IOrder order = OrderFactory.GetOrder(Convert.ToInt16(dRow.ItemArray.GetValue(0).ToString()),
                                            Convert.ToInt16(dRow.ItemArray.GetValue(1).ToString()),
                                            Convert.ToInt16(dRow.ItemArray.GetValue(2).ToString()),
                                            Convert.ToBoolean(dRow.ItemArray.GetValue(3).ToString()),
                                            DateTime.Parse(dRow.ItemArray.GetValue(4).ToString()));
                    OrderList.Add(order);


                }
            }

            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
                //Environment.Exit(0); //Force the application to close
            }
            return OrderList;
        }

        public List<IProductLine> getProductLinesForOrder(int OrderCode)
        {
            List<IProductLine> ProductLineList = new List<IProductLine>();
            DataSet ds;                 //Declare the DataSet object
            SqlDataAdapter da;   //Declare the DataAdapter object
            SqlCommandBuilder cb;
            try
            {
                ds = new DataSet();
                string sql = "SELECT * From ProductLines  where OrderCode = " + OrderCode.ToString();
                // We only want the product lines for this order, so thats all we will select into our DataSet
                da = new SqlDataAdapter(sql, con);
                cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "ProductLinesData");
                int totNumLines = ds.Tables["ProductLinesData"].Rows.Count;
                for (int i = 0; i < totNumLines; i++)
                {
                    DataRow dRow = ds.Tables["ProductLinesData"].Rows[i];
                    IProductLine productLine = ProductLineFactory.GetProductLine(Convert.ToInt16(dRow.ItemArray.GetValue(0).ToString()),
                                            Convert.ToInt16(dRow.ItemArray.GetValue(1).ToString()),
                                            dRow.ItemArray.GetValue(2).ToString(),
                                            Convert.ToInt16(dRow.ItemArray.GetValue(3).ToString()),
                                            Convert.ToInt16(dRow.ItemArray.GetValue(4).ToString()),
                                            Convert.ToBoolean(dRow.ItemArray.GetValue(5).ToString()));
                    ProductLineList.Add(productLine);

                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
                //Environment.Exit(0); //Force the application to close
            }

            return ProductLineList;
        }

        public bool editProductLineInDB(IProductLine productLine)
        {
            try
            {
                ds = new DataSet();
                string sql = "SELECT * From ProductLines";
                da = new SqlDataAdapter(sql, getConnection());
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "ProductLinesData");
                object[] compK = new object[2] { productLine.ProductLineCode.ToString(), productLine.OrderCode }; // using a composite primiary key
                DataRow findRow = ds.Tables["ProductLinesData"].Rows.Find(compK);
                if (findRow != null)
                {
                    findRow[4] = productLine.QtyPrepared.ToString();
                    findRow[5] = productLine.Complete;

                }
                da.Update(ds, "ProductLinesData"); //update row in database table
                return true;
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                if (getConnection().State.ToString() == "Open")
                    getConnection().Close();
                Application.Exit();
                return false;
            }
        }

        public List<IItem> getAllItems()
        {
            List<IItem> ItemList = new List<IItem>();
            try
            {

                ds = new DataSet();
                string sql = "SELECT * From Item";
                da = new SqlDataAdapter(sql, con);
                cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "ItemsData");
                totUsers = ds.Tables["ItemsData"].Rows.Count;
                for (int i = 0; i < totUsers; i++)
                {
                    DataRow dRow = ds.Tables["ItemsData"].Rows[i];
                    IItem item = ItemFactory.GetItem(Convert.ToInt16(dRow.ItemArray.GetValue(0)),  // Using a Factory to create the user entity object. ie seperating object creation from business logic
                                                        dRow.ItemArray.GetValue(1).ToString(),
                                                        dRow.ItemArray.GetValue(2).ToString(),
                                                       Convert.ToInt16(dRow.ItemArray.GetValue(3)),
                                                       Convert.ToDouble(dRow.ItemArray.GetValue(4)),
                                                       dRow.ItemArray.GetValue(5).ToString(),
                                                        dRow.ItemArray.GetValue(6).ToString(),
                                                         Convert.ToDouble(dRow.ItemArray.GetValue(7)),
                                           
                                                          dRow.ItemArray.GetValue(8).ToString());

                    ItemList.Add(item);

                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
                //Environment.Exit(0); //Force the application to close
            }
            return ItemList;
        }

        public bool deleteItemFromDB(BusinessEntities.IItem item)
        {
            try
            {
                ds = new DataSet();
                string sql = "SELECT * From Item";
                da = new SqlDataAdapter(sql, con);
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "ItemsData");
                DataRow findRow = ds.Tables["ItemsData"].Rows.Find(item.ItemID);
                if (findRow != null)
                {
                    findRow.Delete(); //mark row as deleted
                }
                da.Update(ds, "ItemsData"); //remove row from database table
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                if (getConnection().ToString() == "Open")
                    closeConnection();
                Application.Exit();
            }
            return true;
        }

        public void addNewItemToDB(IItem theItem)
        {
            try
            {
                DataSet ds = new DataSet();
                string sql = "SELECT * From Item";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "ItemsData");
                totUsers = ds.Tables["ItemsData"].Rows.Count;
                DataRow dRow = ds.Tables["ItemsData"].NewRow();
                dRow[0] = theItem.ItemID;
                dRow[1] = theItem.Category;
                dRow[2] = theItem.Vendor;
                dRow[3] = theItem.Quantity;
                dRow[4] = theItem.PurchaseUnit;
                dRow[5] = theItem.ItemName;
                dRow[6] = theItem.Description;
                dRow[7] = theItem.SaleUnit;
                dRow[8] = theItem.IsDeleted;

                ds.Tables["ItemsData"].Rows.Add(dRow);
                da.Update(ds, "ItemsData");
            }
            catch (System.Exception excep)
            {
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
                //Environment.Exit(0); //Force the application to close
            }
        }

        public bool editItemInDB(IItem item)
        {
            try
            {
                ds = new DataSet();
                string sql = "SELECT * From Item";
                da = new SqlDataAdapter(sql, con);
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "ItemsData");
                DataRow findRow = ds.Tables["ItemsData"].Rows.Find(item.ItemID);
                if (findRow != null)
                {
                    findRow[0] = item.ItemID;
                    findRow[1] = item.Category;
                    findRow[2] = item.Vendor;
                    findRow[3] = item.Quantity;
                    findRow[4] = item.PurchaseUnit;
                    findRow[5] = item.ItemName;
                    findRow[6] = item.Description;
                    findRow[7] = item.SaleUnit;
             
                    findRow[8] = item.IsDeleted;
                }
                da.Update(ds, "ItemsData"); //remove row from database table
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                if (getConnection().ToString() == "Open")
                    closeConnection();
                Application.Exit();
            }
            return true;
        }

        

        public void addNewClientToDB(IClient theClient)
        {
            try
            {
                DataSet ds = new DataSet();
                string sql = "SELECT * From Client";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "ClientsData");
                totUsers = ds.Tables["ClientsData"].Rows.Count;
                DataRow dRow = ds.Tables["ClientsData"].NewRow();
                dRow[0] = theClient.Pps;
                dRow[1] = theClient.FirstName;
                dRow[2] = theClient.LastName;
                dRow[3] = theClient.Street;
                dRow[4] = theClient.County;
                dRow[5] = theClient.Country;
                dRow[6] = theClient.Phone;
                dRow[7] = theClient.MedicalCardHolder;
                dRow[8] = theClient.CardNumber;
                dRow[9] = theClient.NextOfKinName;
                dRow[10] = theClient.NextOfKinPhone;


                ds.Tables["ClientsData"].Rows.Add(dRow);
                da.Update(ds, "ClientsData");
            }
            catch (System.Exception excep)
            {
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
                //Environment.Exit(0); //Force the application to close
            }
        }

        public List<IClient> getAllClients()
        {
            List<IClient> ClientList = new List<IClient>();
            try
            {

                ds = new DataSet();
                string sql = "SELECT * From Client";
                da = new SqlDataAdapter(sql, con);
                cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "ClientData");
                totUsers = ds.Tables["ClientData"].Rows.Count;
                for (int i = 0; i < totUsers; i++)
                {
                    DataRow dRow = ds.Tables["ClientData"].Rows[i];
                    IClient client = ClientFactory.GetClient(dRow.ItemArray.GetValue(0).ToString(),  // Using a Factory to create the user entity object. ie seperating object creation from business logic
                                                        dRow.ItemArray.GetValue(1).ToString(),
                                                        dRow.ItemArray.GetValue(2).ToString(),
                                                        dRow.ItemArray.GetValue(3).ToString(),
                                                        dRow.ItemArray.GetValue(4).ToString(),
                                                        dRow.ItemArray.GetValue(5).ToString(),
                                                        dRow.ItemArray.GetValue(6).ToString(),
                                                        dRow.ItemArray.GetValue(7).ToString(),
                                                        dRow.ItemArray.GetValue(8).ToString(),
                                                        dRow.ItemArray.GetValue(9).ToString(),
                                                        dRow.ItemArray.GetValue(10).ToString(),
                                                        Convert.ToInt16(dRow.ItemArray.GetValue(11)));

                    ClientList.Add(client);

                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
                //Environment.Exit(0); //Force the application to close
            }
            return ClientList;
        }

        public bool deleteClientFromDB(BusinessEntities.IClient client)
        {
            try
            {
                ds = new DataSet();
                string sql = "SELECT * From Client";
                da = new SqlDataAdapter(sql, con);
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "ClientsData");
                DataRow findRow = ds.Tables["ClientsData"].Rows.Find(client.Pps);
                if (findRow != null)
                {
                    findRow.Delete(); //mark row as deleted
                }
                da.Update(ds, "ClientsData"); //remove row from database table
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                if (getConnection().ToString() == "Open")
                    closeConnection();
                Application.Exit();
            }
            return true;
        }

        public bool editClientInDB(IClient client)
        {
            try
            {
                ds = new DataSet();
                string sql = "SELECT * From Client";
                da = new SqlDataAdapter(sql, con);
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "ClientsData");
                DataRow findRow = ds.Tables["ClientsData"].Rows.Find(client.Pps);
                if (findRow != null)
                {
                    findRow[0] = client.Pps;
                    findRow[1] = client.FirstName;
                    findRow[2] = client.LastName;
                    findRow[3] = client.Street;
                    findRow[4] = client.County;
                    findRow[5] = client.Country;
                    findRow[6] = client.Phone;
                    findRow[7] = client.MedicalCardHolder;
                    findRow[7] = client.CardNumber; ;
                    findRow[9] = client.NextOfKinName;
                    findRow[10] = client.NextOfKinPhone;

                }
                da.Update(ds, "ClientsData"); //remove row from database table
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                if (getConnection().ToString() == "Open")
                    closeConnection();
                Application.Exit();
            }
            return true;
        }

        public void addNewPrescriptionToDB(IPrescription thePrescription)
        {
            try
            {
                DataSet ds = new DataSet();
                string sql = "SELECT * From Prescription";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "PrescriptionsData");
                totUsers = ds.Tables["PrescriptionsData"].Rows.Count;
                DataRow dRow = ds.Tables["PrescriptionsData"].NewRow();
                dRow[0] = thePrescription.PrescriptionID;
                dRow[1] = thePrescription.DrugName;
                dRow[2] = thePrescription.DateWritten;
                dRow[3] = thePrescription.DateProcessed;
                dRow[4] = thePrescription.DateDispensed;
                dRow[5] = thePrescription.DateExpires;
                dRow[6] = thePrescription.Instruction;
                dRow[7] = thePrescription.QuantityWritten;
                dRow[8] = thePrescription.QuantityDispensed;
                dRow[9] = thePrescription.DrugCategory;
                dRow[10] = thePrescription.UserID;
                dRow[11] = thePrescription.ClientID;
                dRow[12] = thePrescription.GpID;


                ds.Tables["PrescriptionsData"].Rows.Add(dRow);
                da.Update(ds, "PrescriptionsData");
            }
            catch (System.Exception excep)
            {
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
                //Environment.Exit(0); //Force the application to close
            }
        }

        public List<IPrescription> getAllPrescriptions()
        {
            List<IPrescription> PrescriptionList = new List<IPrescription>();
            try
            {

                ds = new DataSet();
                string sql = "SELECT * From Prescription";
                da = new SqlDataAdapter(sql, con);
                cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "PrescriptionData");
                totUsers = ds.Tables["PrescriptionData"].Rows.Count;
                for (int i = 0; i < totUsers; i++)
                {
                    DataRow dRow = ds.Tables["PrescriptionData"].Rows[i];
                    IPrescription prescription = PrescriptionFactory.GetPrescription(Convert.ToInt16(dRow.ItemArray.GetValue(0)),
                                                        dRow.ItemArray.GetValue(1).ToString(),  // Using a Factory to create the user entity object. ie seperating object creation from business logic
                                                        DateTime.Parse(dRow.ItemArray.GetValue(2).ToString()),
                                                        DateTime.Parse(dRow.ItemArray.GetValue(3).ToString()),
                                                        DateTime.Parse(dRow.ItemArray.GetValue(4).ToString()),
                                                        DateTime.Parse(dRow.ItemArray.GetValue(5).ToString()),
                                                        dRow.ItemArray.GetValue(6).ToString(),
                                                        Convert.ToInt16(dRow.ItemArray.GetValue(7)),
                                                        Convert.ToInt16(dRow.ItemArray.GetValue(8)),
                                                        dRow.ItemArray.GetValue(9).ToString(),
                                                        Convert.ToInt16(dRow.ItemArray.GetValue(10)),
                                                        dRow.ItemArray.GetValue(11).ToString(),
                                                        Convert.ToInt16(dRow.ItemArray.GetValue(12))
                                                        );



                    PrescriptionList.Add(prescription);

                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
                //Environment.Exit(0); //Force the application to close
            }
            return PrescriptionList;
        }

        public bool deleteSupplierFromDB(BusinessEntities.ISupplier supplier)
        {
            try
            {
                ds = new DataSet();
                string sql = "SELECT * From Supplier";
                da = new SqlDataAdapter(sql, con);
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "SuppliersData");
                DataRow findRow = ds.Tables["SuppliersData"].Rows.Find(supplier.supplierID);
                if (findRow != null)
                {
                    findRow.Delete(); //mark row as deleted
                }
                da.Update(ds, "SuppliersData"); //remove row from database table
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                if (getConnection().ToString() == "Open")
                    closeConnection();
                Application.Exit();
            }
            return true;
        }
        public void addNewSupplierToDB(ISupplier theSupplier)
        {
            try
            {
                DataSet ds = new DataSet();
                string sql = "SELECT * From Supplier";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "SuppliersData");
                totUsers = ds.Tables["SuppliersData"].Rows.Count;
                DataRow dRow = ds.Tables["SuppliersData"].NewRow();
                dRow[0] = theSupplier.supplierID;
                dRow[1] = theSupplier.companyName;
                dRow[2] = theSupplier.email;
                dRow[3] = theSupplier.phone;
                dRow[4] = theSupplier.street;
                dRow[5] = theSupplier.city;
                dRow[6] = theSupplier.county;
                dRow[7] = theSupplier.country;

                ds.Tables["SuppliersData"].Rows.Add(dRow);
                da.Update(ds, "SuppliersData");
            }
            catch (System.Exception excep)
            {
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
                //Environment.Exit(0); //Force the application to close
            }
        }

        public bool editSupplierInDB(ISupplier supplier)
        {
            try
            {
                ds = new DataSet();
                string sql = "SELECT * From Supplier";
                da = new SqlDataAdapter(sql, con);
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "SuppliersData");
                DataRow findRow = ds.Tables["SuppliersData"].Rows.Find(supplier.supplierID);
                if (findRow != null)
                {
                    findRow[0] = supplier.supplierID;
                    findRow[1] = supplier.companyName;
                    findRow[2] = supplier.email;
                    findRow[3] = supplier.phone;
                    findRow[4] = supplier.street;
                    findRow[5] = supplier.city;
                    findRow[6] = supplier.county;
                    findRow[7] = supplier.country;

                }
                da.Update(ds, "SuppliersData"); //remove row from database table
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                if (getConnection().ToString() == "Open")
                    closeConnection();
                Application.Exit();
            }
            return true;
        }

        public List<ISupplier> getAllSuppliers()
        {
            List<ISupplier> SupplierList = new List<ISupplier>();
            try
            {

                ds = new DataSet();
                string sql = "SELECT * From Supplier";
                da = new SqlDataAdapter(sql, con);
                cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "SuppliersData");
                totUsers = ds.Tables["SuppliersData"].Rows.Count;
                for (int i = 0; i < totUsers; i++)
                {
                    DataRow dRow = ds.Tables["SuppliersData"].Rows[i];
                    ISupplier supplier = SupplierFactory.GetSupplier(dRow.ItemArray.GetValue(0).ToString(),  // Using a Factory to create the user entity object. ie seperating object creation from business logic
                                                        dRow.ItemArray.GetValue(1).ToString(),
                                                        dRow.ItemArray.GetValue(2).ToString(),
                                                        dRow.ItemArray.GetValue(3).ToString(),
                                                        dRow.ItemArray.GetValue(4).ToString(),
                                                       dRow.ItemArray.GetValue(5).ToString(),
                                                        dRow.ItemArray.GetValue(6).ToString(),
                                                        dRow.ItemArray.GetValue(7).ToString());

                    SupplierList.Add(supplier);

                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
                //Environment.Exit(0); //Force the application to close
            }
            return SupplierList;
        }

        public void addNewTransactionToDB(ITransaction theTransaction)
        {
            try
            {
                DataSet ds = new DataSet();
                string sql = "SELECT * From Transactions";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "TransactionsData");
                totUsers = ds.Tables["TransactionsData"].Rows.Count;
                DataRow dRow = ds.Tables["TransactionsData"].NewRow();
                dRow[0] = theTransaction.TransactionID;
                dRow[1] = theTransaction.CustomerID;
                dRow[2] = theTransaction.UserID;
                dRow[3] = theTransaction.TransactionDate;
                dRow[4] = theTransaction.TransactionCost;
                dRow[5] = theTransaction.PaymentMethod;
                dRow[6] = theTransaction.Tax;

                ds.Tables["TransactionsData"].Rows.Add(dRow);
                da.Update(ds, "TransactionsData");
            }
            catch (System.Exception excep)
            {
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
                //Environment.Exit(0); //Force the application to close
            }
        }

        public List<ITransaction> getAllTransactions()
        {
            List<ITransaction> TransactionList = new List<ITransaction>();
            try
            {

                ds = new DataSet();
                string sql = "SELECT * From Transactions";
                da = new SqlDataAdapter(sql, con);
                cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "TransactionsData");
                totUsers = ds.Tables["TransactionsData"].Rows.Count;
                for (int i = 0; i < totUsers; i++)
                {
                    DataRow dRow = ds.Tables["TransactionsData"].Rows[i];
                    ITransaction transaction = TransactionFactory.GetTransaction(
                                                        Convert.ToInt32(dRow.ItemArray.GetValue(0)),  // Using a Factory to create the user entity object. ie seperating object creation from business logic
                                                        Convert.ToInt32(dRow.ItemArray.GetValue(1)),
                                                        Convert.ToInt32(dRow.ItemArray.GetValue(2)),
                                                        DateTime.Parse(dRow.ItemArray.GetValue(3).ToString()),
                                                        Convert.ToDouble(dRow.ItemArray.GetValue(4)),
                                                        dRow.ItemArray.GetValue(5).ToString(),
                                                        Convert.ToDouble(dRow.ItemArray.GetValue(6))
                                                        );

                    TransactionList.Add(transaction);

                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message + "hiiiiiiiiiii");
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
                //Environment.Exit(0); //Force the application to close
            }
            return TransactionList;
        }

        public List<IGp> getAllGps()
        {
            List<IGp> ItemList = new List<IGp>();
            try
            {
                ds = new DataSet();
                string sql = "SELECT * From GP";
                da = new SqlDataAdapter(sql, con);
                cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "GpsData");
                totUsers = ds.Tables["GpsData"].Rows.Count;
                for (int i = 0; i < totUsers; i++)
                {
                    DataRow dRow = ds.Tables["GpsData"].Rows[i];
                    IGp gp = GpFactory.GetGp(Convert.ToInt16(dRow.ItemArray.GetValue(0)),  // Using a Factory to create the user entity object. ie seperating object creation from business logic
                                                        dRow.ItemArray.GetValue(1).ToString(),
                                                        dRow.ItemArray.GetValue(2).ToString(),
                                                        dRow.ItemArray.GetValue(3).ToString(),
                                                        dRow.ItemArray.GetValue(4).ToString(),
                                                        dRow.ItemArray.GetValue(5).ToString());
                    ItemList.Add(gp);
                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
                //Environment.Exit(0); //Force the application to close
            }
            return ItemList;
        }

        public void addNewGpToDB(IGp theGp)
        {
            try
            {
                DataSet ds = new DataSet();
                string sql = "SELECT * From GP";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "GpsData");
                totUsers = ds.Tables["GpsData"].Rows.Count;
                DataRow dRow = ds.Tables["GpsData"].NewRow();
                dRow[0] = theGp.GpID;
                dRow[1] = theGp.FirstName;
                dRow[2] = theGp.LastName;
                dRow[3] = theGp.Address;
                dRow[4] = theGp.Phone;
                dRow[5] = theGp.Email;

                ds.Tables["GpsData"].Rows.Add(dRow);
                da.Update(ds, "GpsData");
            }
            catch (System.Exception excep)
            {
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
                //Environment.Exit(0); //Force the application to close
            }
        }

        public bool deleteGpFromDB(BusinessEntities.IGp gp)
        {
            try
            {
                ds = new DataSet();
                string sql = "SELECT * From GP";
                da = new SqlDataAdapter(sql, con);
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "GpsData");
                DataRow findRow = ds.Tables["GpsData"].Rows.Find(gp.GpID);
                if (findRow != null)
                {
                    findRow.Delete(); //mark row as deleted
                }
                da.Update(ds, "GpsData"); //remove row from database table
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                if (getConnection().ToString() == "Open")
                    closeConnection();
                Application.Exit();
            }
            return true;
        }

        public bool editGpInDB(IGp gp)
        {
            try
            {
                ds = new DataSet();
                string sql = "SELECT * From GP";
                da = new SqlDataAdapter(sql, con);
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "GpsData");
                DataRow findRow = ds.Tables["GpsData"].Rows.Find(gp.GpID);
                if (findRow != null)
                {
                    findRow[0] = gp.GpID;
                    findRow[1] = gp.FirstName;
                    findRow[2] = gp.LastName;
                    findRow[3] = gp.Address;
                    findRow[4] = gp.Phone;
                    findRow[5] = gp.Email;
                }
                da.Update(ds, "GpsData"); //remove row from database table
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                if (getConnection().ToString() == "Open")
                    closeConnection();
                Application.Exit();
            }
            return true;
        }

        public List<IConsultation> getAllCons()
        {
            List<IConsultation> ItemList = new List<IConsultation>();
            try
            {
                ds = new DataSet();
                string sql = "SELECT * From Consultation";
                da = new SqlDataAdapter(sql, con);
                cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "ConsData");
                totUsers = ds.Tables["ConsData"].Rows.Count;
                for (int i = 0; i < totUsers; i++)
                {
                    DataRow dRow = ds.Tables["ConsData"].Rows[i];
                    IConsultation con = ConsultationFactory.GetCon(Convert.ToInt16(dRow.ItemArray.GetValue(0)),  // Using a Factory to create the user entity object. ie seperating object creation from business logic
                                                        dRow.ItemArray.GetValue(1).ToString(),
                                                        dRow.ItemArray.GetValue(2).ToString(),
                                                        dRow.ItemArray.GetValue(3).ToString(),
                                                        dRow.ItemArray.GetValue(4).ToString(),
                                                        dRow.ItemArray.GetValue(5).ToString(),
                                                        dRow.ItemArray.GetValue(6).ToString(),
                                                        dRow.ItemArray.GetValue(7).ToString(),
                                                        dRow.ItemArray.GetValue(8).ToString());
                    ItemList.Add(con);
                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
                //Environment.Exit(0); //Force the application to close
            }
            return ItemList;
        }

        public void addNewConToDB(IConsultation theCon)
        {
            try
            {
                DataSet ds = new DataSet();
                string sql = "SELECT * From Consultation";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "ConData");
                totUsers = ds.Tables["ConData"].Rows.Count;
                DataRow dRow = ds.Tables["ConData"].NewRow();
                dRow[0] = theCon.ConID;
                dRow[1] = theCon.FirstName;
                dRow[2] = theCon.LastName;
                dRow[3] = theCon.Phone;
                dRow[4] = theCon.DOB;
                dRow[5] = theCon.Address;
                dRow[6] = theCon.Symptoms;
                dRow[7] = theCon.Date;
                dRow[8] = theCon.Time;

                ds.Tables["ConData"].Rows.Add(dRow);
                da.Update(ds, "ConData");
            }
            catch (System.Exception excep)
            {
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
                //Environment.Exit(0); //Force the application to close
            }
        }

        public bool deleteConFromDB(BusinessEntities.IConsultation cons)
        {
            try
            {
                ds = new DataSet();
                string sql = "SELECT * From Consultation";
                da = new SqlDataAdapter(sql, con);
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "ConData");
                DataRow findRow = ds.Tables["ConData"].Rows.Find(cons.ConID);
                if (findRow != null)
                {
                    findRow.Delete(); //mark row as deleted
                }
                da.Update(ds, "ConData"); //remove row from database table
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                if (getConnection().ToString() == "Open")
                    closeConnection();
                Application.Exit();
            }
            return true;
        }

        public bool editConInDB(IConsultation cons)
        {
            try
            {
                ds = new DataSet();
                string sql = "SELECT * From Consultation";
                da = new SqlDataAdapter(sql, con);
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "ConData");
                DataRow findRow = ds.Tables["ConData"].Rows.Find(cons.ConID);
                if (findRow != null)
                {
                    findRow[0] = cons.ConID;
                    findRow[1] = cons.FirstName;
                    findRow[2] = cons.LastName;
                    findRow[3] = cons.Phone;
                    findRow[4] = cons.DOB;
                    findRow[5] = cons.Address;
                    findRow[6] = cons.Symptoms;
                    findRow[7] = cons.Date;
                    findRow[8] = cons.Time;
                }
                da.Update(ds, "ConData"); //remove row from database table
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                if (getConnection().ToString() == "Open")
                    closeConnection();
                Application.Exit();
            }
            return true;
        }

        public void addNewEmployeeToDB(IEmployee theEmployee)
        {
            try
            {
                DataSet ds = new DataSet();
                string sql = "SELECT * From Employee";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "EmployeesData");
                totUsers = ds.Tables["EmployeesData"].Rows.Count;
                DataRow dRow = ds.Tables["EmployeesData"].NewRow();
                dRow[0] = theEmployee.EmployeeID;
                dRow[1] = theEmployee.UserID;
                dRow[2] = theEmployee.FirstName;
                dRow[3] = theEmployee.LastName;
                dRow[4] = theEmployee.Address;
                dRow[5] = theEmployee.Email;
                dRow[6] = theEmployee.Phone;
                dRow[7] = theEmployee.NextOfKinName;
                dRow[8] = theEmployee.NextOfKinPhone;
                dRow[9] = theEmployee.Salery;
                dRow[10] = theEmployee.Usertype;


                ds.Tables["EmployeesData"].Rows.Add(dRow);
                da.Update(ds, "EmployeesData");
            }
            catch (System.Exception excep)
            {
                if (con.State.ToString() == "Open")
                    con.Close();
                MessageBox.Show(excep.ToString());
                Application.Exit();
                //Environment.Exit(0); //Force the application to close
            }
        }

        public List<IEmployee> getAllEmployees()
        {
            List<IEmployee> ItemList = new List<IEmployee>();
            try
            {
                ds = new DataSet();
                string sql = "SELECT * From Employee";
                da = new SqlDataAdapter(sql, con);
                cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "EmployeesData");
                totUsers = ds.Tables["EmployeesData"].Rows.Count;
                for (int i = 0; i < totUsers; i++)
                {
                    DataRow dRow = ds.Tables["EmployeesData"].Rows[i];
                    IEmployee employee = EmployeeFactory.GetEmployee(Convert.ToInt32(dRow.ItemArray.GetValue(0)),  // Using a Factory to create the user entity object. ie seperating object creation from business logic
                                                        Convert.ToInt32(dRow.ItemArray.GetValue(1)),
                                                        dRow.ItemArray.GetValue(2).ToString(),
                                                        dRow.ItemArray.GetValue(3).ToString(),
                                                        dRow.ItemArray.GetValue(4).ToString(),
                                                        dRow.ItemArray.GetValue(5).ToString(),
                                                        dRow.ItemArray.GetValue(6).ToString(),
                                                        dRow.ItemArray.GetValue(7).ToString(),
                                                        dRow.ItemArray.GetValue(8).ToString(),
                                                        Convert.ToDecimal(dRow.ItemArray.GetValue(9)),
                                                        dRow.ItemArray.GetValue(10).ToString());

                    ItemList.Add(employee);
                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
                //Environment.Exit(0); //Force the application to close
            }
            return ItemList;
        }

        public bool deleteEmployeeFromDB(BusinessEntities.IEmployee employee)
        {
            try
            {
                ds = new DataSet();
                string sql = "SELECT * From Employee";
                da = new SqlDataAdapter(sql, con);
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "EmployeesData");
                DataRow findRow = ds.Tables["EmployeesData"].Rows.Find(employee.EmployeeID);
                if (findRow != null)
                {
                    findRow.Delete(); //mark row as deleted
                }
                da.Update(ds, "EmployeesData"); //remove row from database table
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                if (getConnection().ToString() == "Open")
                    closeConnection();
                Application.Exit();
            }
            return true;
        }


        public bool editEmployeeInDB(IEmployee employee)
        {
            try
            {
                ds = new DataSet();
                string sql = "SELECT * From Employee";
                da = new SqlDataAdapter(sql, con);
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "EmployeesData");
                DataRow findRow = ds.Tables["EmployeesData"].Rows.Find(employee.EmployeeID);
                if (findRow != null)
                {

                    findRow[0] = employee.EmployeeID;
                    findRow[1] = employee.UserID;
                    findRow[2] = employee.FirstName;
                    findRow[3] = employee.LastName;
                    findRow[4] = employee.Address;
                    findRow[5] = employee.Email;
                    findRow[6] = employee.Phone;
                    findRow[7] = employee.NextOfKinName;
                    findRow[8] = employee.NextOfKinPhone;
                    findRow[9] = employee.Salery;
                    findRow[10] = employee.Usertype;

                }
                da.Update(ds, "EmployeesData"); //remove row from database table
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                if (getConnection().ToString() == "Open")
                    closeConnection();
                Application.Exit();
            }
            return true;
        }

        public List<IStockOrder> getAllStockOrder()
        {
            List<IStockOrder> StockOrderList = new List<IStockOrder>();
            try
            {

                ds = new DataSet();
                string sql = "SELECT * From StockOrder";
                da = new SqlDataAdapter(sql, con);
                cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "StockOrderData");
                totUsers = ds.Tables["StockOrderData"].Rows.Count;
                for (int i = 0; i < totUsers; i++)
                {
                    DataRow dRow = ds.Tables["StockOrderData"].Rows[i];
                    IStockOrder StockOrder = StockOrderFactory.GetStockOrder(Convert.ToInt16(dRow.ItemArray.GetValue(0)),// Using a Factory to create the user entity object. ie seperating object creation from business logic
                                                        Convert.ToInt16(dRow.ItemArray.GetValue(1)),
                                                        dRow.ItemArray.GetValue(2).ToString());

                    StockOrderList.Add(StockOrder);

                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
                //Environment.Exit(0); //Force the application to close
            }
            return StockOrderList;
        }

        public void editStockOrderInDB(IStockOrder StockOrder)
        {

        }

        public void addNewStockOrderToDB(IStockOrder StockOrder)
        {

            try
            {
                DataSet ds = new DataSet();
                string sql = "SELECT * From StockOrder";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "StockOrderData");
                totUsers = ds.Tables["StockOrderData"].Rows.Count;
                DataRow dRow = ds.Tables["StockOrderData"].NewRow();
                dRow[0] = StockOrder.StockOrderID;
                dRow[1] = StockOrder.UserID;
                dRow[2] = StockOrder.Date;

                ds.Tables["StockOrderData"].Rows.Add(dRow);
                da.Update(ds, "StockOrderData");
            }
            catch (System.Exception excep)
            {
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
                //Environment.Exit(0); //Force the application to close
            }

        }
        //        
        public bool deleteStockOrderFromDB(IStockOrder StockOrder)
        {
            try
            {
                ds = new DataSet();
                string sql = "SELECT * From StockOrder";
                da = new SqlDataAdapter(sql, con);
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "StockOrdersData");
                DataRow findRow = ds.Tables["StockOrdersData"].Rows.Find(StockOrder.StockOrderID);
                if (findRow != null)
                {
                    findRow.Delete(); //mark row as deleted
                }
                da.Update(ds, "StockOrdersData"); //remove row from database table
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                if (getConnection().ToString() == "Open")
                    closeConnection();
                Application.Exit();
            }
            return true;
        }

        public List<ITransaction_has_items> getAllItemsInTransaction()
        {
            List<ITransaction_has_items> ItemList = new List<ITransaction_has_items>();
            try
            {

                ds = new DataSet();
                string sql = "SELECT * From transaction_has_items";
                da = new SqlDataAdapter(sql, con);
                cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "ItemsTransactionData");
                totUsers = ds.Tables["ItemsTransactionData"].Rows.Count;
                for (int i = 0; i < totUsers; i++)
                {
                    DataRow dRow = ds.Tables["ItemsTransactionData"].Rows[i];
                    ITransaction_has_items item = Transaction_has_itemsFactory.GetItemInTransaction(Convert.ToInt32(dRow.ItemArray.GetValue(0)),  // Using a Factory to create the user entity object. ie seperating object creation from business logic
                                                        Convert.ToInt32(dRow.ItemArray.GetValue(1))
                                                        );

                    ItemList.Add(item);

                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
                //Environment.Exit(0); //Force the application to close
            }
            return ItemList;
        }


        public void addNewItemInTransactionToDB(ITransaction_has_items theTransaction)
        {
            try
            {
                DataSet ds = new DataSet();
                string sql = "SELECT * From transaction_has_items";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "ItemsTransactionData");
                totUsers = ds.Tables["ItemsTransactionData"].Rows.Count;
                DataRow dRow = ds.Tables["ItemsTransactionData"].NewRow();
                dRow[0] = theTransaction.TransactionID;
                dRow[1] = theTransaction.ItemID;


                ds.Tables["ItemsTransactionData"].Rows.Add(dRow);
                da.Update(ds, "ItemsTransactionData");
            }
            catch (System.Exception excep)
            {
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
                //Environment.Exit(0); //Force the application to close
            }
        }

        public List<ILog> getAllLogs()
        {
            List<ILog> ItemList = new List<ILog>();
            try
            {
                ds = new DataSet();
                string sql = "SELECT * From Log";
                da = new SqlDataAdapter(sql, con);
                cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "LogsData");
                totUsers = ds.Tables["LogsData"].Rows.Count;
                for (int i = 0; i < totUsers; i++)
                {
                    DataRow dRow = ds.Tables["LogsData"].Rows[i];
                    ILog log = LogFactory.GetLog(Convert.ToInt16(dRow.ItemArray.GetValue(0)),  // Using a Factory to create the user entity object. ie seperating object creation from business logic
                                                        DateTime.Parse(dRow.ItemArray.GetValue(1).ToString()),
                                                        dRow.ItemArray.GetValue(2).ToString(),
                                                        Convert.ToInt32(dRow.ItemArray.GetValue(3).ToString()),
                                                        dRow.ItemArray.GetValue(4).ToString());

                    ItemList.Add(log);
                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
                //Environment.Exit(0); //Force the application to close
            }
            return ItemList;
        }

        public void addNewLogToDB(ILog theLog)
        {
            try
            {
                DataSet ds = new DataSet();
                string sql = "SELECT * From Log";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "LogData");
                totUsers = ds.Tables["LogData"].Rows.Count;
                DataRow dRow = ds.Tables["LogData"].NewRow();
                dRow[0] = theLog.LogId;
                dRow[1] = theLog.Date;
                dRow[2] = theLog.TableName;
                dRow[3] = theLog.UserId;
                dRow[4] = theLog.Action;
                
                ds.Tables["LogData"].Rows.Add(dRow);
                da.Update(ds, "LogData");
            }
            catch (System.Exception excep)
            {
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
                //Environment.Exit(0); //Force the application to close
            }
        }

        public List<IRoster> getAllRosters()
        {
            List<IRoster> RosterList = new List<IRoster>();
            try
            {

                ds = new DataSet();
                string sql = "SELECT * From Roster";
                da = new SqlDataAdapter(sql, con);
                cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "RosterData");
                totUsers = ds.Tables["RosterData"].Rows.Count;
                for (int i = 0; i < totUsers; i++)
                {
                    DataRow dRow = ds.Tables["RosterData"].Rows[i];
                    IRoster roster = RosterFactory.GetRoster(
                                                        Convert.ToInt32(dRow.ItemArray.GetValue(0)),  // Using a Factory to create the user entity object. ie seperating object creation from business logic
                                                        Convert.ToInt32(dRow.ItemArray.GetValue(1)),
                                                        dRow.ItemArray.GetValue(2).ToString(),
                                                        dRow.ItemArray.GetValue(3).ToString()
                                                        );

                    RosterList.Add(roster);

                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message + "hiiiiiiiiiii");
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
                //Environment.Exit(0); //Force the application to close
            }
            return RosterList;
        }

        public void addNewRosterToDB(IRoster theRoster)
        {
            try
            {
                DataSet ds = new DataSet();
                string sql = "SELECT * From Roster";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "RosterData");
                totUsers = ds.Tables["RosterData"].Rows.Count;
                DataRow dRow = ds.Tables["RosterData"].NewRow();
                dRow[0] = theRoster.RosterID;
                dRow[1] = theRoster.WeekNumber;
                dRow[2] = theRoster.Day;
                dRow[3] = theRoster.Name;
                ds.Tables["RosterData"].Rows.Add(dRow);
                da.Update(ds, "RosterData");
            }
            catch (System.Exception excep)
            {
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
                //Environment.Exit(0); //Force the application to close
            }
        }

        public bool deleteRosterFromDB(BusinessEntities.IRoster roster)
        {
            try
            {
                ds = new DataSet();
                string sql = "SELECT * From Roster";
                da = new SqlDataAdapter(sql, con);
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "RosterData");
                DataRow findRow = ds.Tables["RosterData"].Rows.Find(roster.RosterID);
                if (findRow != null)
                {
                    findRow.Delete(); //mark row as deleted
                }
                da.Update(ds, "RosterData"); //remove row from database table
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                if (getConnection().ToString() == "Open")
                    closeConnection();
                Application.Exit();
            }
            return true;
        }

        public List<IRoster_has_employees> getAllRosterHasEmployees()
        {
            List<IRoster_has_employees> RosterHasEmployees = new List<IRoster_has_employees>();
            try
            {

                ds = new DataSet();
                string sql = "SELECT * From roster_has_employees";
                da = new SqlDataAdapter(sql, con);
                cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "RosterEmployeeData");
                totUsers = ds.Tables["RosterEmployeeData"].Rows.Count;
                for (int i = 0; i < totUsers; i++)
                {
                    DataRow dRow = ds.Tables["RosterEmployeeData"].Rows[i];
                    IRoster_has_employees roster = Roster_has_employeesFactory.GetRoster_has_employees(
                                                        Convert.ToInt32(dRow.ItemArray.GetValue(0)),  // Using a Factory to create the user entity object. ie seperating object creation from business logic
                                                        Convert.ToInt32(dRow.ItemArray.GetValue(1))
                                                        );

                    RosterHasEmployees.Add(roster);

                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message + "hiiiiiiiiiii");
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
                //Environment.Exit(0); //Force the application to close
            }
            return RosterHasEmployees;
        }

        public void addNewRosterHasEmployeesToDB(IRoster_has_employees theRoster)
        {
            try
            {
                DataSet ds = new DataSet();
                string sql = "SELECT * From roster_has_employees";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "RosterEmployeeData");
                totUsers = ds.Tables["RosterEmployeeData"].Rows.Count;
                DataRow dRow = ds.Tables["RosterEmployeeData"].NewRow();
                dRow[0] = theRoster.RosterID;
                dRow[1] = theRoster.EmployeeID;
               

                ds.Tables["RosterEmployeeData"].Rows.Add(dRow);
                da.Update(ds, "RosterEmployeeData");
            }
            catch (System.Exception excep)
            {
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
                //Environment.Exit(0); //Force the application to close
            }
        }

        public void addNewReportToDB(IReport theReport)
        {
            try
            {
                DataSet ds = new DataSet();
                string sql = "SELECT * From Report";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "ReportData");
                totUsers = ds.Tables["ReportData"].Rows.Count;
                DataRow dRow = ds.Tables["ReportData"].NewRow();
                dRow[0] = theReport.ReportID;
                dRow[1] = theReport.NumTransactions;
                dRow[2] = theReport.TotalSales;
                dRow[3] = theReport.TotalTax;
                dRow[4] = theReport.StartDate;
                dRow[5] = theReport.EndDate;

                ds.Tables["ReportData"].Rows.Add(dRow);
                da.Update(ds, "ReportData");
            }
            catch (System.Exception excep)
            {
                if (con.State.ToString() == "Open")
                    con.Close();
                MessageBox.Show(excep.ToString());
                Application.Exit();
                //Environment.Exit(0); //Force the application to close
            }
        }

        public List<IReport> getAllReports()
        {
            List<IReport> ReportList = new List<IReport>();
            try
            {
                ds = new DataSet();
                string sql = "SELECT * From Report";
                da = new SqlDataAdapter(sql, con);
                cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "ReportData");
                totUsers = ds.Tables["ReportData"].Rows.Count;
                for (int i = 0; i < totUsers; i++)
                {
                    DataRow dRow = ds.Tables["ReportData"].Rows[i];
                    IReport report = ReportFactory.GetReport(Convert.ToInt32(dRow.ItemArray.GetValue(0)),  // Using a Factory to create the user entity object. ie seperating object creation from business logic
                                                        Convert.ToInt32(dRow.ItemArray.GetValue(1)),
                                                        Convert.ToDouble(dRow.ItemArray.GetValue(2).ToString()),
                                                        Convert.ToDouble(dRow.ItemArray.GetValue(3).ToString()),
                                                        DateTime.Parse(dRow.ItemArray.GetValue(4).ToString()),
                                                        DateTime.Parse(dRow.ItemArray.GetValue(5).ToString())
                                                        );

                    ReportList.Add(report);
                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
                //Environment.Exit(0); //Force the application to close
            }
            return ReportList;
        }

        public bool deleteReportFromDB(BusinessEntities.IReport report)
        {
            try
            {
                ds = new DataSet();
                string sql = "SELECT * From Report";
                da = new SqlDataAdapter(sql, con);
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "ReportData");
                DataRow findRow = ds.Tables["ReportData"].Rows.Find(report.ReportID);
                if (findRow != null)
                {
                    findRow.Delete(); //mark row as deleted
                }
                da.Update(ds, "ReportData"); //remove row from database table
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                if (getConnection().ToString() == "Open")
                    closeConnection();
                Application.Exit();
            }
            return true;
        }
    }
}
