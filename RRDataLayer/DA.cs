using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RRDataLayer
{


    public class DA
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


        public void createHistory(EmergencyCall ec)
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


        public void createTreatment(EmergencyCall ec)
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

        public void createHistoryItem(EmergencyCall ec)
        {
            String sqlString = "INSERT INTO history\n";


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

        public void createTreatementItem(EmergencyCall ec)
        {
            String sqlString = "INSERT INTO treatment ";


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


        public void createCountyItem(EmergencyCall ec)
        {
            String sqlString = "INSERT INTO county ";


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



        public void createDepartmentItem(EmergencyCall ec)
        {
            String sqlString = "INSERT INTO department ";


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


        public void createUnitItem(EmergencyCall ec)
        {
            String sqlString = "INSERT INTO unit ";


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

        public void createCategoryItem(EmergencyCall ec)
        {
            String sqlString = "INSERT INTO category ";


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

        public void createCCListItem(EmergencyCall ec)
        {
            String sqlString = "INSERT INTO cclist ";


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

        public void createDoctorItem(EmergencyCall ec)
        {
            String sqlString = "INSERT INTO doctor ";


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

        public void createMedicationItem(EmergencyCall ec)
        {
            String sqlString = "INSERT INTO medication ";


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

        private String createColValueString(EmergencyCall ec)
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

        private List<EmergencyCall> getEmergenyCalls(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.Text;
            EmergencyCall ec = null;
            List<EmergencyCall> ecs = new List<EmergencyCall>();
            try
            {
                //execute the query
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ec = new EmergencyCall();
                    fieldnames.Clear();
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        this.fieldnames.Add(rdr.GetName(i).ToString());
                        ec.Add(fieldnames[i],rdr[fieldnames[i]]);
                                             
                    }

                    ecs.Add(ec);
                    
                    
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



            return ecs;
        
        }

        public List<EmergencyCall> getAllEmergencyCall()
        {
            
            SqlCommand cmd = new SqlCommand("Select * from EmergencyCall", getDataConnection(false));
            List<EmergencyCall> ecs = getEmergenyCalls(cmd);
            return ecs;
         
        }

        public List<EmergencyCall> getAllCountyItems()
        {

            SqlCommand cmd = new SqlCommand("Select * from county", getDataConnection(false));
            List<EmergencyCall> ecs = getEmergenyCalls(cmd);
            return ecs;

        }


        public List<EmergencyCall> getAllHistoryItems()
        {

            SqlCommand cmd = new SqlCommand("Select * from history", getDataConnection(false));
            List<EmergencyCall> ecs = getEmergenyCalls(cmd);
            return ecs;

        }

        public List<EmergencyCall> getAllTreatmentItems()
        {

            SqlCommand cmd = new SqlCommand("Select * from treatment", getDataConnection(false));
            List<EmergencyCall> ecs = getEmergenyCalls(cmd);
            return ecs;

        }

        public List<EmergencyCall> getAllDepartmentItems()
        {

            SqlCommand cmd = new SqlCommand("Select * from department", getDataConnection(false));
            List<EmergencyCall> ecs = getEmergenyCalls(cmd);
            return ecs;

        }

        public List<EmergencyCall> getAllUnitItems()
        {

            SqlCommand cmd = new SqlCommand("Select * from unit", getDataConnection(false));
            List<EmergencyCall> ecs = getEmergenyCalls(cmd);
            return ecs;

        }

        public List<EmergencyCall> getAllCategoryItems()
        {

            SqlCommand cmd = new SqlCommand("Select * from category", getDataConnection(false));
            List<EmergencyCall> ecs = getEmergenyCalls(cmd);
            return ecs;

        }

        public List<EmergencyCall> getCCListItems()
        {

            SqlCommand cmd = new SqlCommand("Select * from cclist", getDataConnection(false));
            List<EmergencyCall> ecs = getEmergenyCalls(cmd);
            return ecs;

        }

        public List<EmergencyCall> getAllDoctorItems()
        {

            SqlCommand cmd = new SqlCommand("Select * from doctor", getDataConnection(false));
            List<EmergencyCall> ecs = getEmergenyCalls(cmd);
            return ecs;

        }

        public List<EmergencyCall> getAllMedicationItems()
        {

            SqlCommand cmd = new SqlCommand("Select * from medication", getDataConnection(false));
            List<EmergencyCall> ecs = getEmergenyCalls(cmd);
            return ecs;

        }
    }


    
    
}
