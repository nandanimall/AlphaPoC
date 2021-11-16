using NetCoreODAT_api.Model;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.Common;
using System.Collections.Generic;
using System.Data.Odbc;


namespace NetCoreODAT_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HiveOdataController : ODataController
    {
        /* private BookStoreContext _db;

         public BooksController(BookStoreContext context)
         {
             _db = context;
             if (context.Books.Count() == 0)
             {
                 foreach (var b in DataSource.GetBooks())
                 {
                     context.Books.Add(b);
                     context.Presses.Add(b.Press);
                 }
                 context.SaveChanges();
             }
         }*/

        /* public BooksController(HiveOdataContext context)
         {
             DataSource datasource = new DataSource();
             _db = context;
             if (context.students1.Count() == 0)
             {
                 foreach (var b in datasource.FetchHiveData())
                 {
                     context.students1.Add(b);
                 }
                 context.SaveChanges();
             }

         }*/

        [HttpGet]
        public List<HiveDataModel> FetchHiveData()
        {
            List<HiveDataModel> hdm_list = new List<HiveDataModel>();

            //using (OdbcConnection conn = new OdbcConnection("DSN=Hive ODBC Driver;UID=admin;PWD=A!s2d3f4g5h6"))
            var connectionstring = @"DRIVER={Microsoft Hive ODBC Driver};
                                        Host=alpha-cluster-for-hive.azurehdinsight.net;
                                        Port=443;
                                        Schema=default;
                                        RowsFetchedPerBlock = 10000;
                                        HiveServerType=2;
                                        ApplySSPWithQueries=1;
                                        AsyncExecPollInterval=100;
                                        HS2AuthMech=6;
                                        UserName=admin;
                                        PWD=A!s2d3f4g5h6;
                                        trustedcerts={C:\Program Files\Microsoft Hive ODBC Driver\lib\cacerts.pem}";

            using (var connect = new OdbcConnection(connectionstring))
            {
                try
                {
                    //connectionstring.Open();


                    connect.Open();


                    OdbcCommand cmd = connect.CreateCommand();
                    cmd.CommandText = "select * from students;";

                    DbDataReader dr = cmd.ExecuteReader();




                    while (dr.Read())
                    {
                        HiveDataModel hdm_obj = new HiveDataModel();

                        hdm_obj.name = dr.GetString(0);
                        hdm_obj.address = dr.GetString(1);
                        hdm_obj.student_id = dr.GetInt32(2);

                        hdm_list.Add(hdm_obj);

                    }

                }

                catch (Exception ex)
                {
                  // log.Info("Failed to connect to data source");
                }

                finally
                {
                    connect.Close();
                }
            }

            return hdm_list;
        }
    }
}

    

