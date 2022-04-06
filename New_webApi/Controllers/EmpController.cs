using MySql.Data.MySqlClient;
using New_webApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace New_webApi.Controllers
{
    public class EmpController : Controller
    {
        // GET: Emp
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public Int32 getid()
        {
            return new Random().Next();
        }

        [HttpPost]
        public string PostEmpData(Employees employees)
        {
            dynamic obj = new ExpandoObject();

            if (string.IsNullOrEmpty(employees.Name) || string.IsNullOrEmpty(employees.Emp_ID) || string.IsNullOrEmpty(employees.Designation) || string.IsNullOrEmpty(employees.DOB) || string.IsNullOrEmpty(employees.Address))
            {
                obj.status = "Fail";
                obj.Message = "name/Emp_ID/Designation/DOB/Address Code cannot be Empty";
                // Logger.Log("Response", JsonConvert.SerializeObject(obj));

                return "Failed";
            }
            else
            {
                //General.DML($"Insert into wave(`wave_id`,`status`) values ('{employees.WaveID}','PENDING')");
                string query = "insert into Emp_master(`Name`,`Emp_ID`,`Designation`,`DOB`,`Address`)values('" + employees.Name + "','" + employees.Emp_ID + "','" + employees.Designation + "','" + employees.DOB + "','" + employees.Address + "')";
                //"insert into Emp_master(`Name`,`Emp_ID`,`Designation`,`DOB`,`Address`)values ('{employees.Name}','{employees.Emp_ID}','{employees.Designation}','{employees.DOB}','{employees.Address}','ADDED')");
                General.DML(query);
                obj.status = "Success";
                obj.Message = "Data Added";
                return "Sucess";
            }
        }


        // [HttpGet]
        //public string GetEmployeeData(Employees employee)
        //{
        //    MySqlDataReader rdr = cmd.ExecuteReader();
        //    while (rdr.Read())
        //    {
        //        var employees = new Employees();

        //        employees.Name = rdr["Name"].ToString();
        //        employees.Emp_ID = rdr["Emp_ID"].ToString();
        //        employees.Designation = rdr["Designation"].ToString();
        //        employees.DOB = rdr["DOB"].ToString();
        //        employees.Address = rdr["Address"].ToString();



        //    }

        //    return Employees;
        //}
        [HttpGet]
        public string GetEmployeeData(string employee)
        {

            try
            {
                string query = "select * from emp_master";
                DataTable dt = General.SelectQuery(query);

                // string query = ("select * from emp_master");
                //General.DML(query);
                string output = JsonConvert.SerializeObject(dt);
                return output;
            }
            catch (Exception ex)
            {
                return "NONE";
            }
        }

        [HttpDelete]
        
        public string DeleteEmployeeData(string Emp_id)
        {
            dynamic obj = new ExpandoObject();
            try
            {
                string query = "Delete from emp_master WHERE Id = " + Emp_id.ToString(); 
                General.DML(query);
                obj.status = "Success";
                obj.Message = "Data Added";
                
            }
            catch (Exception ex)
            {
                return "failure";
            }
            return obj;
        }

      
    
    
    }






}