using System;
using System.Collections.Generic;
using System.Data;

namespace Nampula.DI.B1.Employees
{
    public class Employee : TableAdapter
    {

        public class FieldsName
        {
            public static readonly string EmpID = "EmpID";
            public static readonly string LastName = "LastName";
            public static readonly string FirstName = "FirstName";
            public static readonly string MiddleName = "MiddleName";
            public static readonly string UserId = "UserId";
            public static readonly string Dept = "dept";
            public static readonly string Email = "Email";
            public static readonly string SalesPrson = "SalesPrson";
        }

        public class Description
        {
            public static readonly string EmpID = "Nº Empregado";
            public static readonly string LastName = "Sobrenome";
            public static readonly string FirstName = "Nome";
            public static readonly string MiddleName = "Segundo Nome";
            public static readonly string UserId = "Usuário";
            public static readonly string Dept = "Departamento";
            public static readonly string Email = "Email";
            public static readonly string SalesPrson = "Vendedor";
        }

        public struct Definition
        {
            public static readonly string TableName = "OHEM";
        }

        readonly TableAdapterField m_EmpID = new TableAdapterField(FieldsName.EmpID, Description.EmpID, DbType.Int32, 11, null, true, false);
        readonly TableAdapterField m_LastName = new TableAdapterField(FieldsName.LastName, Description.LastName, 20);
        readonly TableAdapterField m_FirstName = new TableAdapterField(FieldsName.FirstName, Description.FirstName, 20);
        readonly TableAdapterField m_MiddleName = new TableAdapterField(FieldsName.MiddleName, Description.MiddleName, 20);
        readonly TableAdapterField m_UserID = new TableAdapterField(FieldsName.UserId, Description.UserId, DbType.Int32);
        readonly TableAdapterField m_Dept = new TableAdapterField(FieldsName.Dept, Description.Dept, DbType.Int32);
        readonly TableAdapterField m_Email = new TableAdapterField(FieldsName.Email, Description.Email, 250);
        readonly TableAdapterField m_SalesPrson = new TableAdapterField(FieldsName.SalesPrson, Description.SalesPrson, DbType.Int32);

        public Employee()
            : base("OHEM")
        {
        }

        public Employee(string pCompanyDb)
            : base(pCompanyDb, Definition.TableName)
        {
        }

        public Employee(Employee pEmployee)
            : this(pEmployee.DBName)
        {
            CopyBy(pEmployee);
        }

        public override void Add() { }

        public override void Update() { }

        public override void Remove() { }

        public int EmpID
        {
            get { return m_EmpID.GetInt32(); }
            set { m_EmpID.Value = value; }
        }

        public string LastName
        {
            get { return m_LastName.GetString(); }
            set { m_LastName.Value = value; }
        }

        public string FirstName
        {
            get { return m_FirstName.GetString(); }
            set { m_FirstName.Value = value; }
        }

        public string MiddleName
        {
            get { return m_MiddleName.GetString(); }
            set { m_MiddleName.Value = value; }
        }

        public Int32 UserID
        {
            get { return m_UserID.GetInt32(); }
            set { m_UserID.Value = value; }
        }

        public String Email
        {
            get { return m_Email.GetString(); }
            set { m_Email.Value = value; }
        }

        public Int32 SalesPrson
        {
            get { return m_SalesPrson.GetInt32(); }
            set { m_SalesPrson.Value = value; }
        }
        
        /// <summary>
        /// Departamento
        /// </summary>
        public Int32 Dept
        {
            get { return m_Dept.GetInt32(); }
            set { m_Dept.Value = value; }
        }


        public bool GetByKey(int pEmpId)
        {
            EmpID = pEmpId;
            return GetByKey();
        }

        public bool GetByUserID(int pUserId)
        {
            var query = new TableQuery(this);

            query.Where.Add(
                new QueryParam(m_UserID, pUserId));

            var data = GetData(query);

            if (data.Rows.Count > 0)
                FillFields(data.Rows[0]);

            return data.Rows.Count > 0;
        }

        public List<Employee> GetAll()
        {
            return FillCollection<Employee>();
        }

    }
}
