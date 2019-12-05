using BusinessEntities;
using System;
using System.Collections;
using System.Collections.Generic;
namespace DataAccessLayer
{
    public interface IDataLayer
    {

        void addNewUserToDB(BusinessEntities.IUser theUser);

        bool deleteUserFromDB(BusinessEntities.IUser user);
        bool editUserInDB(BusinessEntities.IUser user);
        void closeConnection();
        List<IUser> getAllUsers();
        System.Data.SqlClient.SqlConnection getConnection();
        void openConnection();
        List<IOrder> getAllOrders();

        List<IItem> getAllItems();
        List<IClient> getAllClients();
        List<IPrescription> getAllPrescriptions();
        List<ISupplier> getAllSuppliers();
        List<IProductLine> getProductLinesForOrder(int OrderCode);
        List<IGp> getAllGps();
        List<IConsultation> getAllCons();
        List<IEmployee> getAllEmployees();
        List<IStockOrder> getAllStockOrder();
        List<ITransaction_has_items> getAllItemsInTransaction();
        List<ITransaction> getAllTransactions();
        List<ILog> getAllLogs();
        List<IRoster> getAllRosters();
        List<IRoster_has_employees> getAllRosterHasEmployees();
        List<IReport> getAllReports();

        bool editProductLineInDB(BusinessEntities.IProductLine productLine);
        bool deleteItemFromDB(BusinessEntities.IItem item);
        void addNewItemToDB(BusinessEntities.IItem theItem);
        
        bool editItemInDB(BusinessEntities.IItem item);
        void addNewClientToDB(BusinessEntities.IClient theClient);
        bool deleteClientFromDB(BusinessEntities.IClient client);
        bool editClientInDB(BusinessEntities.IClient client);

        void addNewPrescriptionToDB(BusinessEntities.IPrescription thePrescription);

        void addNewSupplierToDB(BusinessEntities.ISupplier theSupplier);
        bool deleteSupplierFromDB(BusinessEntities.ISupplier supplier);
        bool editSupplierInDB(BusinessEntities.ISupplier supplier);

        void addNewTransactionToDB(BusinessEntities.ITransaction theTransaction);


        void addNewGpToDB(BusinessEntities.IGp theGp);
        bool deleteGpFromDB(BusinessEntities.IGp gp);
        bool editGpInDB(BusinessEntities.IGp gp);

        void editStockOrderInDB(IStockOrder StockOrder);
        void addNewStockOrderToDB(IStockOrder StockOrder);
        bool deleteStockOrderFromDB(IStockOrder StockOrder);

        void addNewEmployeeToDB(BusinessEntities.IEmployee theEmployee);
        bool deleteEmployeeFromDB(BusinessEntities.IEmployee employee);
        bool editEmployeeInDB(BusinessEntities.IEmployee employee);

        void addNewConToDB(BusinessEntities.IConsultation theCon);
        bool deleteConFromDB(BusinessEntities.IConsultation cons);
        bool editConInDB(BusinessEntities.IConsultation con);

        void addNewItemInTransactionToDB(BusinessEntities.ITransaction_has_items theItemInTransaction);

        void addNewLogToDB(BusinessEntities.ILog theLog);

        void addNewRosterToDB(BusinessEntities.IRoster theRoster);
        bool deleteRosterFromDB(BusinessEntities.IRoster roster);
        void addNewRosterHasEmployeesToDB(BusinessEntities.IRoster_has_employees theRoster);


        void addNewReportToDB(BusinessEntities.IReport theReport);
        bool deleteReportFromDB(BusinessEntities.IReport report);

    }


}
