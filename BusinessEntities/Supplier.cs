using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Supplier : BusinessEntities.ISupplier
{
    private string SupplierID;
    private string CompanyName;
    private string Email;
    private string Phone;
    private string Street;
    private string City;
    private string County;
    private String Country;

    public Supplier(string SupplierID, string CompanyName, string Email, string Phone, string Street, string City, string County,string Country)
    {
        this.SupplierID = SupplierID;
        this.CompanyName = CompanyName;
        this.Email = Email;
        this.Phone = Phone;
        this.Street = Street;
        this.City = City;
        this.County = County;
        this.Country = Country;
    }

    public string supplierID { 
        get { return SupplierID; }
        set { SupplierID = value; }
    }

    public string companyName
    {
        get { return CompanyName; }
        set { CompanyName = value; }
    }

    public string email
    {
        get { return Email; }
        set { Email = value; }
    }

    public string phone
    {
        get { return Phone; }
        set { Phone = value; }
    }

    public string street
    {
        get { return Street; }
        set { Street = value; }
    }

    public string city
    {
        get { return City; }
        set { City = value; }
    }
    public string county
    {
        get { return County; }
        set { County = value; }
    }

    public string country
    {
        get { return Country; }
        set { Country = value; }
    }

    public Supplier()
    {
        throw new System.NotImplementedException();
    }
}

