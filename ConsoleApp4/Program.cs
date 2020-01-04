using System;
using System.Data.SqlClient;
using System.Data;

class DBDemo2
{
    SqlConnection conn;
    SqlCommandBuilder cb;
    SqlDataAdapter da;
    DataSet ds;

    public DBDemo2()
    {
        conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\practicec#\ConsoleApp4\ConsoleApp4\Database1.mdf;Integrated Security=True");
        da = new SqlDataAdapter("Select * From Emp", conn);
        ds = new DataSet();
        da.Fill(ds, "Emp");
        cb = new SqlCommandBuilder(da);
    }
    public void SaveEmp()
    {
        int ecode,esal;
        string ename;
        Console.WriteLine("enter employee code,name,salary");
        ecode = int.Parse(Console.ReadLine());
        ename = Console.ReadLine();
        esal = int.Parse(Console.ReadLine());
        int count = ds.Tables["Emp"].Rows.Count;
        ds.Tables["Emp"].Rows.Add(count);
        ds.Tables["Emp"].Rows[count]["ECode"] = ecode;
        ds.Tables["Emp"].Rows[count]["EName"] = ename;
        ds.Tables["Emp"].Rows[count]["ESal"] = esal;
        da.InsertCommand = cb.GetInsertCommand();
        da.Update(ds.Tables["Emp"]);
        Console.WriteLine("data saved");
    }

    public static void Main()
    {
        DBDemo2 obj1 = new DBDemo2();
        obj1.SaveEmp();
    }
}