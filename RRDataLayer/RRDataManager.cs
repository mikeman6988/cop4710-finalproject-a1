using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RRDataLayer
{


    public class RRDataManager
    {
        private static String connectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Willie\\" +
        "cop4710-finalproject-a1\\RescueReceiving\\App_Data\\emergency_call_database.mdf;Integrated Security=True;" +
        "Connect Timeout=30;User Instance=True";

        private SqlConnection conn;
        private SqlDataReader rdr;
        private SqlTransaction tran;
        private List<string> fieldnames = new List<string>();

        public List<string> getFieldNames()
        {
            return this.fieldnames;
        }

        public SqlConnection getDataConnection(bool isTransaction)
        {
            try
            {
                
                conn = new SqlConnection(connectionString);
                conn.Open();
                if (isTransaction)
                {
                    tran = conn.BeginTransaction();
                }
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException("Cannot open the connection: ", connectionString, ex);

            }
            return conn;
        }

        public void createEmergencyCall(EmergencyCall ec)
        {
            String sqlString = "INSERT INTO EmergencyCall ";
            sqlString += createColValueString(ec);
            SqlCommand cmd = new SqlCommand(sqlString, getDataConnection(true));
            cmd.CommandType = CommandType.Text;
            cmd.Transaction = tran;
            try
            {
                int z = cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (SqlException ex)
            {
                tran.Rollback();
                throw ex;
            }
            
        }


        public void createHistory(RRDataObject ec)
        {
            String sqlString = "INSERT INTO hxjunction ";
            sqlString += createColValueString(ec);
            SqlCommand cmd = new SqlCommand(sqlString, getDataConnection(true));
            cmd.CommandType = CommandType.Text;
            cmd.Transaction = tran;
            try
            {
                int z = cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (SqlException ex)
            {
                tran.Rollback();
                throw ex;
            }

        }


        public void createTreatment(RRDataObject ec)
        {
            String sqlString = "INSERT INTO txjunction ";
            

            sqlString += createColValueString(ec);
            SqlCommand cmd = new SqlCommand(sqlString, getDataConnection(true));
            cmd.CommandType = CommandType.Text;
            cmd.Transaction = tran;
            try
            {
                int z = cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (SqlException ex)
            {
                tran.Rollback();
                throw ex;
            }

        }

        public void createHistoryItem(RRDataObject daOb)
        {
            String sqlString = "INSERT INTO history\n";


            sqlString += createColValueString(daOb);
            SqlCommand cmd = new SqlCommand(sqlString, getDataConnection(true));
            cmd.CommandType = CommandType.Text;
            cmd.Transaction = tran;
            try
            {
                int z = cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (SqlException ex)
            {
                tran.Rollback();
                throw ex;
            }
        }

        public void createTreatementItem(RRDataObject daOb)
        {
            String sqlString = "INSERT INTO treatment ";


            sqlString += createColValueString(daOb);
            SqlCommand cmd = new SqlCommand(sqlString, getDataConnection(true));
            cmd.CommandType = CommandType.Text;
            cmd.Transaction = tran;
            try
            {
                int z = cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (SqlException ex)
            {
                tran.Rollback();
                throw ex;
            }
        }


        public void createCountyItem(RRCounty rc)
        {
            String sqlString = "INSERT INTO county ";


            sqlString += createColValueString(rc);
            SqlCommand cmd = new SqlCommand(sqlString, getDataConnection(true));
            cmd.CommandType = CommandType.Text;
            cmd.Transaction = tran;
            try
            {
                int z = cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (SqlException ex)
            {
                tran.Rollback();
                throw ex;
            }
        }



        public void createDepartmentItem(RRDataObject daOb)
        {
            String sqlString = "INSERT INTO department ";


            sqlString += createColValueString(daOb);
            SqlCommand cmd = new SqlCommand(sqlString, getDataConnection(true));
            cmd.CommandType = CommandType.Text;
            cmd.Transaction = tran;
            try
            {
                int z = cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (SqlException ex)
            {
                tran.Rollback();
                throw ex;
            }
        }


        public void createUnitItem(RRUnit ru)
        {
            String sqlString = "INSERT INTO unit ";


            sqlString += createColValueString(ru);
            SqlCommand cmd = new SqlCommand(sqlString, getDataConnection(true));
            cmd.CommandType = CommandType.Text;
            cmd.Transaction = tran;
            try
            {
                int z = cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (SqlException ex)
            {
                tran.Rollback();
                throw ex;
            }
        }

        public void createCategoryItem(RRCategory rc)
        {
            String sqlString = "INSERT INTO category ";


            sqlString += createColValueString(rc);
            SqlCommand cmd = new SqlCommand(sqlString, getDataConnection(true));
            cmd.CommandType = CommandType.Text;
            cmd.Transaction = tran;
            try
            {
                int z = cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (SqlException ex)
            {
                tran.Rollback();
                throw ex;
            }
        }

        public void createCCListItem(RRDataObject daOb)
        {
            String sqlString = "INSERT INTO cclist ";


            sqlString += createColValueString(daOb);
            SqlCommand cmd = new SqlCommand(sqlString, getDataConnection(true));
            cmd.CommandType = CommandType.Text;
            cmd.Transaction = tran;
            try
            {
                int z = cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (SqlException ex)
            {
                tran.Rollback();
                throw ex;
            }
        }

        public void createDoctorItem(RRDataObject daOb)
        {
            String sqlString = "INSERT INTO doctor ";


            sqlString += createColValueString(daOb);
            SqlCommand cmd = new SqlCommand(sqlString, getDataConnection(true));
            cmd.CommandType = CommandType.Text;
            cmd.Transaction = tran;
            try
            {
                int z = cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (SqlException ex)
            {
                tran.Rollback();
                throw ex;
            }
        }

        public void createMedicationItem(RRDataObject daOb)
        {
            String sqlString = "INSERT INTO medication ";


            sqlString += createColValueString(daOb);
            SqlCommand cmd = new SqlCommand(sqlString, getDataConnection(true));
            cmd.CommandType = CommandType.Text;
            cmd.Transaction = tran;
            try
            {
                int z = cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (SqlException ex)
            {
                tran.Rollback();
                throw ex;
            }
        }

        private String createColValueString(RRDataObject ec)
        {
            String str = "";
            String fields = "(\n";
            String values = "values(\n";
            //SqlCommand cmd = new SqlCommand(sqlString, getDataConnection(false));
            foreach (String x in ec.Keys)
            {

                fields += x + ",\n";
                values += "'" + ec[x] + "',";
                //values += ec[x] + ",\n";
            }
            char[] trimchar = { ',', '\n' };
            fields = fields.TrimEnd(trimchar) + ") ";
            values = values.TrimEnd(trimchar) + ")";
            str += fields + values;
            return str;
        }

        private List<RRDataObject> getDataObjects(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.Text;
            RRDataObject daOb = null;
            List<RRDataObject> daObs = new List<RRDataObject>();
            try
            {
                //execute the query
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    daOb = new EmergencyCall();
                    fieldnames.Clear();
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        this.fieldnames.Add(rdr.GetName(i).ToString());
                        daOb.Add(fieldnames[i],rdr[fieldnames[i]]);
                                             
                    }

                    daObs.Add(daOb);
                    
                    
                }


            }
            catch (Exception ex)
            {
                String x = ex.Message;
            }
            finally
            {
                rdr.Close();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }



            return daObs;
        
        }

        public List<RRDataObject> getAllEmergencyCall()
        {
            
            SqlCommand cmd = new SqlCommand("Select * from EmergencyCall", getDataConnection(false));
            List<RRDataObject> ecs = getDataObjects(cmd);
            return ecs;
         
        }


        public List<RRDataObject> getEmergencyCallByPrimaryKey(DateTime key)
        {
            String sqlString = "Select * from EmergencyCall where created_date_time=" + key;
            SqlCommand cmd = new SqlCommand(sqlString, getDataConnection(false));
            List<RRDataObject> ecs = getDataObjects(cmd);
            return ecs;

        }

        public List<RRDataObject> getHistoryByPrimaryKey(DateTime key)
        {
            String sqlString = "Select * from hxjunction where created_date_time=" + key;
            SqlCommand cmd = new SqlCommand(sqlString, getDataConnection(false));
            List<RRDataObject> ecs = getDataObjects(cmd);
            return ecs;

        }

        public List<RRDataObject> getTreatmentByPrimaryKey(DateTime key)
        {
            String sqlString = "Select * from txjunction where created_date_time=" + key;
            SqlCommand cmd = new SqlCommand(sqlString, getDataConnection(false));
            List<RRDataObject> ecs = getDataObjects(cmd);
            return ecs;

        }

        public List<RRDataObject> getAllEmergencyCall(DateTime key)
        {
            String sqlString = "Select * from EmergencyCall where created_date_time=" + key;
            SqlCommand cmd = new SqlCommand(sqlString, getDataConnection(false));
            List<RRDataObject> ecs = getDataObjects(cmd);
            return ecs;

        }

        public List<RRDataObject> getAllCountyItems()
        {

            SqlCommand cmd = new SqlCommand("Select * from county", getDataConnection(false));
            List<RRDataObject> ecs = getDataObjects(cmd);
            return ecs;

        }


        public List<RRDataObject> getAllHistoryItems()
        {

            SqlCommand cmd = new SqlCommand("Select * from history", getDataConnection(false));
            List<RRDataObject> ecs = getDataObjects(cmd);
            return ecs;

        }

        public List<RRDataObject> getAllTreatmentItems()
        {

            SqlCommand cmd = new SqlCommand("Select * from treatment", getDataConnection(false));
            List<RRDataObject> ecs = getDataObjects(cmd);
            return ecs;

        }

        public List<RRDataObject> getAllDepartmentItems()
        {

            SqlCommand cmd = new SqlCommand("Select * from department", getDataConnection(false));
            List<RRDataObject> ecs = getDataObjects(cmd);
            return ecs;

        }

        public List<RRDataObject> getAllUnitItems()
        {

            SqlCommand cmd = new SqlCommand("Select * from unit", getDataConnection(false));
            List<RRDataObject> ecs = getDataObjects(cmd);
            return ecs;

        }

        public List<RRDataObject> getAllCategoryItems()
        {

            SqlCommand cmd = new SqlCommand("Select * from category", getDataConnection(false));
            List<RRDataObject> ecs = getDataObjects(cmd);
            return ecs;

        }

        public List<RRDataObject> getCCListItems()
        {

            SqlCommand cmd = new SqlCommand("Select * from cclist", getDataConnection(false));
            List<RRDataObject> ecs = getDataObjects(cmd);
            return ecs;

        }

        public List<RRDataObject> getAllDoctorItems()
        {

            SqlCommand cmd = new SqlCommand("Select * from doctor", getDataConnection(false));
            List<RRDataObject> ecs = getDataObjects(cmd);
            return ecs;

        }

        public List<RRDataObject> getAllMedicationItems()
        {

            SqlCommand cmd = new SqlCommand("Select * from medication", getDataConnection(false));
            List<RRDataObject> ecs = getDataObjects(cmd);
            return ecs;

        }
    }


    
    
}
