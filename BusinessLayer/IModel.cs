using System;
using BusinessEntities;
using System.Collections.Generic;
namespace BusinessLayer
{
    public interface IModel
    {
        bool addNewUser(int userID, string username, string password, string usertype, bool online);
        BusinessEntities.IUser CurrentUser { get; set; }
        DataAccessLayer.IDataLayer DataLayer { get; set; }
        bool deleteUser(IUser user);
        bool editUser(BusinessEntities.IUser user);
        string getUserTypeForCurrentuser();
        string getUserNameForCurrentuser();
        bool login(string name, string password);
        List<IProductLine> ProductLineList { get; set; }
        void tearDown();
        List<IUser> UserList { get; set; }
        List<IOrder> OrderList { get; set; }
       
        //comment

        void populateOrders();
        bool updateProductLine(IProductLine productLine);

        //item methods
        #region
            List<IItem> ItemList { get; set; }
            bool deleteItem(IItem item);
            bool addNewItem(string category, string vendor, int quantity, double purchaseUnit, string itemName, string description, double saleUnit, string isDeleted);
            bool editItem(BusinessEntities.IItem item);
    
        #endregion

        //client methods
        #region
        List<IClient> ClientList { get;set; }
        bool deleteClient(IClient item);
        bool addNewClient(string PPS, string firstName, string lastName, string street, string county, string country, string phone, string medicalCardHolder, string cardNumber, string nextOfKinName, string nextOfKinPhone, int gpID);
        bool editClient(BusinessEntities.IClient client);
        #endregion

        //suplier methods
        #region
        List<ISupplier> SupplierList { get; set; }
        bool deleteSupplier(ISupplier item);
        bool addnewSupplier(string SupplierID, string CompanyName, string Email, string Phone, string Street, string City, string County, string Country);
        bool editSupplier(BusinessEntities.ISupplier supplier);
        #endregion

        //transaction
        #region
        List<ITransaction> TransactionList { get; set; }
        bool addNewTransaction(int userID, DateTime transactionDate, double transactionCost, double tax, string paymentMethod);
     
        #endregion

        //Prescription
        #region
        List<IPrescription> PrescriptionList { get; set; }
        bool addNewPrescription(string drugName, DateTime dateWritten, DateTime dateProcessed, DateTime dateDispensed, DateTime dateExpires, string instruction, int quantityWritten, int quantityDispensed, string drugCategory, string clientID);
        #endregion

        //gp methods
        #region
        List<IGp> GpList { get; set; }
        bool addNewGp(int gpID, string firstName, string lastName, string address, string phone, string email);
        bool deleteGp(IGp gp);
        bool editGp(BusinessEntities.IGp gp);
        #endregion

        //consultation methods
        #region
        List<IConsultation> ConList { get; set; }
        bool addNewCon(int gpID, string firstName, string lastName, string phone, string dob, string address, string symptoms, string date, string time);
        bool deleteCon(IConsultation cons);
        bool editCon(BusinessEntities.IConsultation con);
        #endregion

        //Stock Order methods
        #region 
        List<IStockOrder> StockOrderList { get; set; }
        bool deleteStockOrder(IStockOrder StockOrder);
        bool addnewStockOrder(int stockOrderId, int UserID, string date);
        bool editStockOrder(BusinessEntities.IStockOrder stockorder);
        #endregion

        //employee methods
        #region
        List<IEmployee> EmployeeList { get; set; }
        bool addNewEmployee(string firstName, string lastName, string address, string phone, string email, string nextOfKinName, string nextOfKinPhone, decimal salery, string usertype);
        bool deleteEmployee(IEmployee employee);
        bool editEmployee(BusinessEntities.IEmployee employee);
        #endregion


        //items in transaction method
        #region
        List<ITransaction_has_items> ItemsInTransaction { get; set; }
        bool addNewItemToTransaction(int transactionID, int itemID);
        #endregion

        //system logs
        #region
        List<ILog> LogList { get; set; }
        bool addNewLog(DateTime date, string tableName, int userId, string action);
        #endregion

        //roster
        #region
        List<IRoster> RosterList { get; set; }
        bool addNewRoster(int weekNumber, string day, string name);
        bool deleteRoster(IRoster roster);
        #endregion

        //employees in roster
        #region
        List<IRoster_has_employees> RosterHasEmployees { get; set; }
        bool addRoster_has_employees(int rosterID, int employeeID);
        #endregion

        //report
        #region
        List<IReport> ReportList { get; set; }
        bool addNewReport(int numTransactions, double totalSales, double totalTax, DateTime startDate, DateTime endDate);
        bool deleteReport(IReport report);
        #endregion
    }
}
