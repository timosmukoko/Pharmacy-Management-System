using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DataAccessLayer;
using BusinessEntities;

namespace BusinessLayer
{
    public class Model : IModel
    {
        #region Static Attributes
        private static IModel modelSingletonInstance;  // Model object is a singleton so only one instance allowed
        static readonly object padlock = new object(); // Need this for thread safety on the Model singleton creation. ie in GetInstance () method
        #endregion
        #region Instance Attribures
        private IDataLayer dataLayer;
        private IUser currentUser;
        private List<IUser> userList;
        private List<IProductLine> productLineList = new List<IProductLine>();
        private List<IOrder> orderList;
        private List<IItem> itemList;
        private List<IClient> clientList;
        private List<ISupplier> supplierList;
        private List<IPrescription> prescriptionList;
        private List<ITransaction> transactionList;
        private List<IGp> gpList;
        private List<IConsultation> conList;
        private List<IStockOrder> stockOrderList;
        private List<IEmployee> employeeList;
        private List<ITransaction_has_items> itemsInTransaction;
        private List<ILog> logList;
        private List<IRoster> rosterList;
        private List<IRoster_has_employees> rosterHasEmployees;
        private List<IReport> reportList;
        public List<IOrder> OrderList
        {
            get { return orderList; }
            set { orderList = value; }
        }

        public List<IItem> ItemList
        {
            get { return itemList; }
            set { itemList = value; }
        }
        public List<ISupplier> SupplierList
        {
            get { return supplierList; }
            set { supplierList = value; }
        }
        public List<IClient> ClientList
        {
            get { return clientList; }
            set { clientList = value; }
        }

        public List<IPrescription> PrescriptionList
        {
            get { return prescriptionList; }
            set { prescriptionList = value; }
        }

        public List<IProductLine> ProductLineList
        {
            get { return productLineList; }
            set { productLineList = value; }
        }

        public List<ITransaction> TransactionList
        {
            get { return transactionList; }
            set { transactionList = value; }
        }

        public List<IUser> UserList
        {
            get { return userList; }
            set { userList = value; }
        }

        public List<IGp> GpList
        {
            get { return gpList; }
            set { gpList = value; }
        }

        public List<IConsultation> ConList
        {
            get { return conList; }
            set { conList = value; }
        }

        public List<IStockOrder> StockOrderList
        {
            get { return stockOrderList; }
            set { stockOrderList = value; }
        }

        public List<IEmployee> EmployeeList
        {
            get { return employeeList; }
            set { employeeList = value; }
        }

        public List<ITransaction_has_items> ItemsInTransaction
        {
            get { return itemsInTransaction; }
            set { itemsInTransaction = value; }
        }

        public List<IRoster> RosterList
        {
            get { return rosterList; }
            set { rosterList = value; }
        }

        public List<IRoster_has_employees> RosterHasEmployees
        {
            get { return rosterHasEmployees; }
            set { rosterHasEmployees = value; }
        }

        public List<IReport> ReportList
        {
            get { return reportList; }
            set { reportList = value; }
        }
        #endregion
        #region Instance Properties
        public IDataLayer DataLayer
        {
            get { return dataLayer; }
            set { dataLayer = value; }
        }

        public List<ILog> LogList
        {
            get { return logList; }
            set { logList = value; }
        }

        public IUser CurrentUser
        {
            get
            {
                return currentUser;
            }
            set
            {
                currentUser = value;
            }
        }





        #endregion

        #region Constructors/Destructors
        public static IModel GetInstance(IDataLayer _DataLayer) // With Singleton pattern this method is used rather than constructor
        {
            lock (padlock) //   only one thread can entry this block of code
            {
                if (modelSingletonInstance == null)
                {
                    modelSingletonInstance = new Model(_DataLayer);
                }
                return modelSingletonInstance;
            }
        }
        private Model(IDataLayer _DataLayer)  // The constructor is private as its a singleton and I only allow one instance which is created with the GetInstance() method
        {
            userList = new List<IUser>();
            itemList = new List<IItem>();
            clientList = new List<IClient>();
            supplierList = new List<ISupplier>();
            transactionList = new List<ITransaction>();
            gpList = new List<IGp>();
            conList = new List<IConsultation>();
            employeeList = new List<IEmployee>();
            itemsInTransaction = new List<ITransaction_has_items>();
            logList = new List<ILog>();
            prescriptionList = new List<IPrescription>();
            rosterList = new List<IRoster>();
            rosterHasEmployees = new List<IRoster_has_employees>();
            reportList = new List<IReport>();

            dataLayer = _DataLayer;
            userList = dataLayer.getAllUsers(); // setup Models userList so we can login
            itemList = dataLayer.getAllItems();
            clientList = dataLayer.getAllClients();
            transactionList = dataLayer.getAllTransactions();
            supplierList = dataLayer.getAllSuppliers();
            gpList = dataLayer.getAllGps();
            conList = dataLayer.getAllCons();
            StockOrderList = dataLayer.getAllStockOrder();
            employeeList = dataLayer.getAllEmployees();
            itemsInTransaction = dataLayer.getAllItemsInTransaction();
            logList = dataLayer.getAllLogs();
            prescriptionList = dataLayer.getAllPrescriptions();
            rosterList = dataLayer.getAllRosters();
            rosterHasEmployees = dataLayer.getAllRosterHasEmployees();
            reportList = dataLayer.getAllReports();

        }

        ~Model()
        {
            tearDown();
        }
        #endregion
        public Boolean login(String name, String password)
        {

            foreach (User user in userList) // now using template so can simplify this code as shown below
            {
                if (name == user.Username && password == user.Password)
                {

                    CurrentUser = user;
                    return true;
                }
            }
            return false;

            IUser matchUser = userList.FirstOrDefault(user => user.Username == name && user.Password == password);
            if (matchUser == null)
            {
                return false;
            }
            else
            {
                CurrentUser = matchUser;
                return true;
            }
        }
        public Boolean addNewUser(int userID, string username, string password, string userType, bool online)
        {
            //// some validation on userName, we won't allow duplicate usernames. Business rule
            //IUser duplicateUser = this.UserList.FirstOrDefault(user => user.Username == name.Trim());
            ///* provides a shortcut to accessing the element that occurs first in the collection or query,
            //while protecting against invalid accesses if there are no elements.It'sa linq query. FirstOrDefault is a generic method which means it accepts a type parameter that indicates what types it acts upon. 
            //The => is a lambda operator. Anything before the => are the input parameters, and anything after is the expression. You can have multiple input parameters.
            //Think of a lambda expression as"given x, do something with x" * */
            //if (duplicateUser != null)
            //    return false;
            //else
            //{
            //    try
            //    {
            //        if (name.Length < 5) // Won't allow usernames with less than 5 characters. Business Rule
            //            return false; // Maybe other rules on Usernames such as some Uppercase etc
            //        if (password.Length < 5)// Won't allow passwords with less than 5 characters. Business Rule
            //            return false; // Maybe password policy such as at least one Upper case, one number etc see 
            //                          // see Regex - regular expressions

            //        int maxId = 0;

            //        // maybe add some logic (busiess rules) about password policy
            //        // IUser user = new User(name, password, userType); // Construct a User Object
            //        foreach (User user in UserList)
            //        {
            //            if (user.UserID > maxId)
            //                maxId = user.UserID;
            //        }
            //        IUser theUser = UserFactory.GetUser(name, password, userType, maxId + 1); // Using a Factory to create the user entity object. ie seperating object creation from business logic
            //        UserList.Add(theUser); // Add a reference to the newly created object to the Models UserList
            //        DataLayer.addNewUserToDB(theUser); //Gets the DataLayer to add the new user to the DB. 
            //        return true;
            //    }
            //    catch (System.Exception excep)
            //    {
            //        return false;
            //    }
            //}

            try
            {
                //int maxId = 0;
                //// need some code to avoid dulicate usernames
                //// maybe add some logic (busiess rules) about password policy
                ////      IUser user = new User(name, password, userType); // Construct a User Object
                //foreach (User user in UserList)
                //{
                //    if (user.UserID > maxId)
                //        maxId = user.UserID;
                //}
                IUser theUser = UserFactory.GetUser(userID, username, password, userType, online);   // Using a Factory to create the user entity object. ie seperating object creation from business logic
                UserList.Add(theUser);                             // Add a reference to the newly created object to the Models UserList
                DataLayer.addNewUserToDB(theUser); //Gets the DataLayer to add the new user to the DB. 
                return true;
            }
            catch (System.Exception excep)
            {
                return false;
            }
        }

        public bool deleteUser(IUser user)
        {

            DataLayer.deleteUserFromDB(user);
            UserList.Remove(user); //remove object from collection
            return true;

        }
        public bool editUser(IUser user)
        {
            DataLayer.editUserInDB(user);
            return true;
        }

        public String getUserTypeForCurrentuser()
        {
            return currentUser.UserType;
        }

        public String getUserNameForCurrentuser()
        {
            return currentUser.Username;
        }

        public void populateOrders()
        {
            OrderList = dataLayer.getAllOrders(); // setup Models orderList 
                                                  // an order can have one or many productLines so need to setup ProductLineList in each order object.
            foreach (Order order in OrderList)
            {
                order.ProductLineList = DataLayer.getProductLinesForOrder(order.OrderCode); // pass the order code to get back the product lines for the order ie the produc lines that were ordered on that order.
                                                                                            // Each order object has its own ArrayList of reference to ProductLineObjects ie the ProductLines for that specific order.
                                                                                            // Now the small list of ProductLines is sorted for this order so keep looping until the small ProductLineList is set for all orders. 
                foreach (ProductLine productLine in order.ProductLineList)         // There is also an ArrayList for each entity class in the model, these are the big lists. This is an ArrayList of references to all ProductLines (for all orders)
                {
                    this.ProductLineList.Add(productLine); // This adds the reference to the ProductLine to the Models ProductLineList ie big list. 
                }
            }

        }

        public void tearDown()
        {
            DataLayer.closeConnection();
        }

        public bool updateProductLine(IProductLine productLine)
        {
            DataLayer.editProductLineInDB(productLine);
            return true;
        }

        public bool deleteItem(IItem item)
        {

            DataLayer.deleteItemFromDB(item);
            ItemList.Remove(item); //remove object from collection
            return true;

        }


        public Boolean addNewItem(string category, string vendor, int quantity, double purchaseUnit, string itemName, string description, double saleUnit, string isDeleted)
        {
            try
            {
                int maxId = 0;
                //need some code to avoid dulicate usernames
                //maybe add some logic (busiess rules) about password policy
                //IUser user = new User(name, password, userType); // Construct a User Object
                foreach (Item item in ItemList)
                {
                    if (item.ItemID > maxId)
                        maxId = item.ItemID;
                }
                IItem theItem = ItemFactory.GetItem(maxId + 1, category, vendor, quantity, purchaseUnit, itemName, description, saleUnit, "NO");   // Using a Factory to create the user entity object. ie seperating object creation from business logic
                ItemList.Add(theItem);                             // Add a reference to the newly created object to the Models UserList
                DataLayer.addNewItemToDB(theItem); //Gets the DataLayer to add the new user to the DB. 
                return true;
            }
            catch (System.Exception excep)
            {
                return false;
            }
        }

        public bool editItem(IItem item)
        {
            DataLayer.editItemInDB(item);
            return true;
        }

      

        public bool deleteClient(IClient client)
        {
            DataLayer.deleteClientFromDB(client);
            ClientList.Remove(client); //remove object from collection
            return true;
        }

        public Boolean addNewClient(string PPS, string firstName, string lastName, string street, string county, string country, string phone, string medicalCardHolder, string cardNumber, string nextOfKinName, string nextOfKinPhone, int gpID)
        {
            try
            {
                IClient theClient = ClientFactory.GetClient(PPS, firstName, lastName, street, county, country, phone, medicalCardHolder, cardNumber, nextOfKinName, nextOfKinPhone, gpID);  // Using a Factory to create the user entity object. ie seperating object creation from business logic
                ClientList.Add(theClient);                             // Add a reference to the newly created object to the Models UserList
                DataLayer.addNewClientToDB(theClient); //Gets the DataLayer to add the new user to the DB. 
                return true;
            }
            catch (System.Exception excep)
            {
                return false;
            }
        }

        public bool editClient(IClient client)
        {
            DataLayer.editClientInDB(client);
            return true;
        }

        public Boolean addnewSupplier(string SupplierID, string CompanyName, string Email, string Phone, string Street, string City, string County, string Country)
        {
            try
            {

                ISupplier theSupplier = SupplierFactory.GetSupplier(SupplierID, CompanyName, Email, Phone, Street, City, County, Country);   // Using a Factory to create the user entity object. ie seperating object creation from business logic
                SupplierList.Add(theSupplier);                             // Add a reference to the newly created object to the Models UserList
                DataLayer.addNewSupplierToDB(theSupplier); //Gets the DataLayer to add the new user to the DB. 
                return true;
            }
            catch (System.Exception excep)
            {
                return false;
            }
        }

        public bool editSupplier(ISupplier supplier)
        {
            DataLayer.editSupplierInDB(supplier);
            return true;
        }

        public bool deleteSupplier(ISupplier supplier)
        {
            DataLayer.deleteSupplierFromDB(supplier);
            SupplierList.Remove(supplier); //remove object from collection
            return true;
        }

        public Boolean addNewPrescription( string drugName, DateTime dateWritten, DateTime dateProcessed, DateTime dateDispensed, DateTime dateExpires, string instruction, int quantityWritten, int quantityDispensed, string drugCategory,  string clientID)
        {
            try
            {
                int maxId = 0;
                int maxUserID = 0;
                int maxGpID = 0;

                foreach (Prescription prescription in PrescriptionList)
                {
                    if (prescription.PrescriptionID > maxId)
                    { maxId = prescription.PrescriptionID; }
                        
                    if (prescription.UserID > maxUserID)
                    { maxUserID = prescription.UserID; }

                    if (prescription.GpID > maxGpID)
                    { maxGpID = prescription.GpID; }
                       
                }

                IPrescription thePrescription = PrescriptionFactory.GetPrescription(maxId + 1, drugName, dateWritten, dateProcessed, dateDispensed, dateExpires, instruction, quantityDispensed, quantityWritten, drugCategory, maxUserID + 1, clientID, maxGpID + 1);  // Using a Factory to create the user entity object. ie seperating object creation from business logic
                PrescriptionList.Add(thePrescription);                             // Add a reference to the newly created object to the Models UserList
                DataLayer.addNewPrescriptionToDB(thePrescription); //Gets the DataLayer to add the new user to the DB. 
                return true;
            }
            catch (System.Exception excep)
            {
                return false;
            }
        }

        public bool addNewTransaction(int userID, DateTime transactionDate, double transactionCost, double tax, string paymentMethod)
        {
            try
            {
                int maxTransactionId = 0;
                int maxCustomerId = 0;
                //need some code to avoid dulicate usernames
                //maybe add some logic (busiess rules) about password policy
                //IUser user = new User(name, password, userType); // Construct a User Object
                foreach (Transaction transaction in TransactionList)
                {
                    if (transaction.TransactionID > maxTransactionId)
                        maxTransactionId = transaction.TransactionID;

                    if (transaction.CustomerID > maxCustomerId)
                        maxCustomerId = transaction.CustomerID;
                }
                ITransaction theTransaction = TransactionFactory.GetTransaction(maxTransactionId + 1, maxCustomerId + 1, userID, transactionDate, transactionCost, paymentMethod, tax);   // Using a Factory to create the user entity object. ie seperating object creation from business logic
                TransactionList.Add(theTransaction);                             // Add a reference to the newly created object to the Models UserList
                DataLayer.addNewTransactionToDB(theTransaction); //Gets the DataLayer to add the new user to the DB. 
                return true;
            }
            catch (System.Exception excep)
            {
                return false;
            }
        }

        public Boolean addNewGp(int gpID, string firstName, string lastName, string address, string phone, string email)
        {
            try
            {
                int maxId = 0;
                //need some code to avoid dulicate usernames
                //maybe add some logic (busiess rules) about password policy
                //IUser user = new User(name, password, userType); // Construct a User Object
                foreach (Gp gp in GpList)
                {
                    if (gp.GpID > maxId)
                        maxId = gp.GpID;
                }
                IGp theGp = GpFactory.GetGp(maxId + 1, firstName, lastName, address, phone, email);   // Using a Factory to create the user entity object. ie seperating object creation from business logic
                GpList.Add(theGp);                             // Add a reference to the newly created object to the Models UserList
                DataLayer.addNewGpToDB(theGp); //Gets the DataLayer to add the new user to the DB. 
                return true;
            }
            catch (System.Exception excep)
            {
                return false;
            }
        }

        public bool deleteGp(IGp gp)
        {
            DataLayer.deleteGpFromDB(gp);
            GpList.Remove(gp); //remove object from collection
            return true;
        }

        public bool editGp(IGp gp)
        {
            DataLayer.editGpInDB(gp);
            return true;
        }

        public Boolean addNewCon(int conID, string firstName, string lastName,string phone, string dob, string address, string symptoms, string date, string time)
        {
            try
            {
                int maxId = 0;
                //need some code to avoid dulicate usernames
                //maybe add some logic (busiess rules) about password policy
                //IUser user = new User(name, password, userType); // Construct a User Object
                foreach (Consultation con in ConList)
                {
                    if (con.ConID > maxId)
                        maxId = con.ConID;
                }
                IConsultation theCon = ConsultationFactory.GetCon(maxId + 1, firstName, lastName, phone, dob, address, symptoms, date, time);   // Using a Factory to create the user entity object. ie seperating object creation from business logic
                ConList.Add(theCon);                             // Add a reference to the newly created object to the Models UserList
                DataLayer.addNewConToDB(theCon); //Gets the DataLayer to add the new user to the DB. 
                return true;
            }
            catch (System.Exception excep)
            {
                return false;
            }
        }

        public bool deleteCon(IConsultation cons)
        {
            DataLayer.deleteConFromDB(cons);
            ConList.Remove(cons); //remove object from collection
            return true;
        }

        public bool editCon(IConsultation con)
        {
            DataLayer.editConInDB(con);
            return true;
        }

        public Boolean addnewStockOrder(int stockOrderID, int UserID, string date)
        {
            try
            {

                IStockOrder aStockOrder = StockOrderFactory.GetStockOrder(stockOrderID, UserID, date);   // Using a Factory to create the user entity object. ie seperating object creation from business logic
                StockOrderList.Add(aStockOrder);                             // Add a reference to the newly created object to the Models UserList
                DataLayer.addNewStockOrderToDB(aStockOrder); //Gets the DataLayer to add the new user to the DB. 
                return true;
            }
            catch (System.Exception excep)
            {
                return false;
            }
        }


        public bool editStockOrder(IStockOrder StockOrder)
        {
            DataLayer.editStockOrderInDB(StockOrder);
            return true;
        }

        public bool deleteStockOrder(IStockOrder StockOrder)
        {
            DataLayer.deleteStockOrderFromDB(StockOrder);
            StockOrderList.Remove(StockOrder); //remove object from collection
            return true;
        }

        public Boolean addNewEmployee(string firstName, string lastName, string address, string phone, string email, string nextOfKinName, string nextOfKinPhone, decimal salery, string usertype)
        {
            try
            {
                int maxId = 0;
                int maxUserID = 0;
                //need some code to avoid dulicate usernames
                //maybe add some logic (busiess rules) about password policy
                //IUser user = new User(name, password, userType); // Construct a User Object
                foreach (Employee employee in EmployeeList)
                {
                    if (employee.EmployeeID > maxId && employee.UserID>maxUserID)
                        maxId = employee.EmployeeID;
                        maxUserID = employee.UserID;
                }
                IEmployee theEmployee = EmployeeFactory.GetEmployee(maxId + 1, maxUserID + 1, firstName, lastName, address, phone, email, nextOfKinName, nextOfKinPhone, salery,   usertype);   // Using a Factory to create the user entity object. ie seperating object creation from business logic
                EmployeeList.Add(theEmployee);                             // Add a reference to the newly created object to the Models UserList
                DataLayer.addNewEmployeeToDB(theEmployee); //Gets the DataLayer to add the new user to the DB. 
                return true;
            }
            catch (System.Exception excep)
            {
                return false;
            }
        }

        public bool deleteEmployee(IEmployee employee)
        {
            DataLayer.deleteEmployeeFromDB(employee);
            EmployeeList.Remove(employee); //remove object from collection
            return true;
        }

        public bool editEmployee(IEmployee employee)
        {
            DataLayer.editEmployeeInDB(employee);
            return true;
        }

        public bool addNewItemToTransaction(int transactionID, int itemID)
        {
            try
            {
                ITransaction_has_items theItemInTransaction = Transaction_has_itemsFactory.GetItemInTransaction(transactionID,  itemID);   // Using a Factory to create the user entity object. ie seperating object creation from business logic
                ItemsInTransaction.Add(theItemInTransaction);                             // Add a reference to the newly created object to the Models UserList
                DataLayer.addNewItemInTransactionToDB(theItemInTransaction); //Gets the DataLayer to add the new user to the DB. 
                return true;
            }
            catch (System.Exception excep)
            {
                return false;
            }
        }

        public Boolean addNewLog( DateTime date, string tableName, int userId, string action)
        {
            try
            {
                int maxLogId = 0;
                
                //need some code to avoid dulicate usernames
                //maybe add some logic (busiess rules) about password policy
                //IUser user = new User(name, password, userType); // Construct a User Object
                foreach (Log log in LogList)
                {
                    if (log.LogId > maxLogId)
                        maxLogId = log.LogId;
                }
                ILog theLog = LogFactory.GetLog(maxLogId + 1, date, tableName, userId, action);   // Using a Factory to create the user entity object. ie seperating object creation from business logic
                LogList.Add(theLog);                             // Add a reference to the newly created object to the Models UserList
                DataLayer.addNewLogToDB(theLog); //Gets the DataLayer to add the new user to the DB. 
                return true;
            }
            catch (System.Exception excep)
            {
                return false;
            }
        }

        public bool deleteRoster(IRoster roster)
        {
            DataLayer.deleteRosterFromDB(roster);
            RosterList.Remove(roster); //remove object from collection
            return true;
        }

        public bool addNewRoster(int weekNumber, string day, string name)
        {
            try
            {
                int maxRosterId = 0;
       
                //need some code to avoid dulicate usernames
                //maybe add some logic (busiess rules) about password policy
                //IUser user = new User(name, password, userType); // Construct a User Object
                foreach (Roster roster in RosterList)
                {
                    if (roster.RosterID > maxRosterId)
                        maxRosterId = roster.RosterID;
                }
                IRoster theRoster = RosterFactory.GetRoster(maxRosterId + 1, weekNumber, day, name);   // Using a Factory to create the user entity object. ie seperating object creation from business logic
                RosterList.Add(theRoster);                             // Add a reference to the newly created object to the Models UserList
                DataLayer.addNewRosterToDB(theRoster); //Gets the DataLayer to add the new user to the DB. 
                return true;
            }
            catch (System.Exception excep)
            {
                return false;
            }
        }

        public bool addRoster_has_employees(int rosterID, int employeeID)
        {
            try
            {
                IRoster_has_employees theRoster = Roster_has_employeesFactory.GetRoster_has_employees(rosterID, employeeID);   // Using a Factory to create the user entity object. ie seperating object creation from business logic
                RosterHasEmployees.Add(theRoster);                             // Add a reference to the newly created object to the Models UserList
                DataLayer.addNewRosterHasEmployeesToDB(theRoster); //Gets the DataLayer to add the new user to the DB. 
                return true;
            }
            catch (System.Exception excep)
            {
                return false;
            }
        }

        public Boolean addNewReport(int numTransactions, double totalSales, double totalTax, DateTime startDate, DateTime endDate)
        {
            try
            {
                int maxId = 0;
                
                foreach (Report report in ReportList)
                {
                    if (report.ReportID > maxId)
                        maxId = report.ReportID;
                }
                IReport theReport = ReportFactory.GetReport(maxId + 1, numTransactions, totalSales, totalTax, startDate, endDate);   // Using a Factory to create the user entity object. ie seperating object creation from business logic
                ReportList.Add(theReport);                             // Add a reference to the newly created object to the Models UserList
                DataLayer.addNewReportToDB(theReport); //Gets the DataLayer to add the new user to the DB. 
                return true;
            }
            catch (System.Exception excep)
            {
                return false;
            }
        }

        public bool deleteReport(IReport report)
        {
            DataLayer.deleteReportFromDB(report);
            ReportList.Remove(report); //remove object from collection
            return true;
        }


    }
}
