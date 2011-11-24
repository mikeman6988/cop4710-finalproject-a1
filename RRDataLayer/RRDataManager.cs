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
        private string conString = null;
        private SqlConnection conn;
        private SqlDataReader rdr;
        private SqlTransaction tran;
        private List<string> fieldnames = new List<string>();

        public RRDataManager()
        {
        }

        public RRDataManager(string conString)
        {
            this.conString = conString;
        }

        public List<string> getFieldNames()
        {
            return this.fieldnames;
        }

        private string getConnectionString()
        {
            string connectionString = null;
            if (!String.IsNullOrEmpty(conString))
            {
                connectionString = this.conString;
            }
            else
            {
                connectionString = "Data Source=lyra.ccec.unf.edu;Initial " +
                    "Catalog=cop4710fall2011dma1;Persist Security Info=True;User ID=cop4710fall2011dma1;Password=xkqED0cl7e";
            }
            return connectionString;
        }

        public SqlConnection getDataConnection(bool isTransaction)
        {
            try
            {
                conn = new SqlConnection(getConnectionString());
                conn.Open();
                if (isTransaction)
                {
                    tran = conn.BeginTransaction();
                }
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException("Cannot open the connection: ", getConnectionString(), ex);
            }
            return conn;
        }

        public void createEmergencyCall(RREmergencyCall ec)
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

        public void createHistory(RRHistoryJunction ec)
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

        public void deleteHistory(DateTime date)
        {
            String sqlString = "DELETE FROM hxjunction WHERE date='" + date.ToString() + "'";
            //sqlString += createWhereString(ec);
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

        public void deleteTreatment(DateTime date)
        {
            String sqlString = "DELETE FROM txjunction WHERE date_time='" + date.ToString() + "'";
            //sqlString += createWhereString(ec);
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

        public void deleteEmergencyCall(DateTime date)
        {
            String sqlString = "DELETE FROM EmergencyCall WHERE created_date_time='" + date.ToString() + "'";
            //sqlString += createWhereString(ec);
            SqlCommand cmd = new SqlCommand(sqlString, getDataConnection(true));
            cmd.CommandType = CommandType.Text;
            cmd.Transaction = tran;
            try
            {
                
                int z = cmd.ExecuteNonQuery();
                tran.Commit();
                deleteHistory(date);
                deleteTreatment(date);
                
            }
            catch (SqlException ex)
            {
                tran.Rollback();
                throw ex;
            }
        }

        private String createWhereString(RRDataObject daOb)
        {
            String where = null;
            foreach (var key in daOb.Keys)
            {
                if (daOb[key] is int)
                {
                    where += key + "=" + daOb[key].ToString() + " and ";
                }
                else
                {
                    where += key + "='" + daOb[key].ToString() + "' and ";
                }
                
            }
            
            where = where.Substring(0, where.Length - 4);
            return where;
        }

        public void createTreatment(RRTreatmentJunction ec)
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

        public void createHistoryItem(RRHistory daOb)
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

        public void createTreatmentItem(RRTreatment daOb)
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

        public void createDepartmentItem(RRDepartment daOb)
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

        public void createCCListItem(RRChiefComplaint daOb)
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

        public void createDoctorItem(RRDoctor daOb)
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

        public void createMedicationItem(RRMedication daOb)
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
            String fields = "(";
            String values = "values(";
            //SqlCommand cmd = new SqlCommand(sqlString, getDataConnection(false));
            foreach (String x in ec.Keys)
            {
               
                fields += x + ",";
                values += "'" + ec[x] + "',";
                //values += ec[x] + ",\n";
            }
            char[] trimchar = { ',', '\n' };
            fields = fields.TrimEnd(trimchar) + ") ";
            values = values.TrimEnd(trimchar) + ")";
            str += fields + values;
            return str;
        }

        private List<RRType> getDataObjects<RRType>(SqlCommand cmd) where RRType : RRDataObject, new()
        {
            cmd.CommandType = CommandType.Text;
            List<RRType> daObs = new List<RRType>();
            try
            {
                //execute the query
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    RRType daOb = new RRType();
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

        public List<RREmergencyCall> getAllEmergencyCall()
        {
            SqlCommand cmd = new SqlCommand("Select * from EmergencyCall", getDataConnection(false));
            return getDataObjects<RREmergencyCall>(cmd);
        }

        public List<RREmergencyCall> getEmergencyCallByPrimaryKey(DateTime key)
        {
            String sqlString = "Select * from EmergencyCall where created_date_time='" + key + "'";
            SqlCommand cmd = new SqlCommand(sqlString, getDataConnection(false));
            return getDataObjects<RREmergencyCall>(cmd);
        }

        public List<RRHistoryJunction> getHistoryByPrimaryKey(DateTime key)
        {
            String sqlString = "Select * from hxjunction where date='" + key + "'";
            //sqlString += createWhereString(key);
            SqlCommand cmd = new SqlCommand(sqlString, getDataConnection(false));
            return getDataObjects<RRHistoryJunction>(cmd);
        }

        public List<RRTreatmentJunction> getTreatmentByPrimaryKey(DateTime key)
        {
            String sqlString = "Select * from txjunction where date_time='" + key + "'";
            //sqlString += createWhereString(key);
            SqlCommand cmd = new SqlCommand(sqlString, getDataConnection(false));
            return getDataObjects<RRTreatmentJunction>(cmd);
        }

        public List<RRDataObject> getRecordsForQuery()
        {
            String sqlString = "Select created_date_time, unitname, age, sex, categoryname," +
            "ccdescription, cc, bp_sys1,bp_dia1, pulse1, resp1, 02_sat1," +
            "init_bgl, sec_bgl,loc,gcs,t_a,s_a,stemi,deptname,level,eta " +
            "from EmergencyCall left join unit on unit=unitid left join category on category=catid left join " +
            "cclist on EmergencyCall.ccid = cclist.ccid left join department on EmergencyCall.receiving_dept=deptid";
            //sqlString += createWhereString(key);
            SqlCommand cmd = new SqlCommand(sqlString, getDataConnection(false));
            return getDataObjects<RRDataObject>(cmd);
        }

        public List<RRDataObject> getRecordsForQuery(Nullable<DateTime> startdate, Nullable<DateTime> stopdate)
        {
            String sqlString = "Select created_date_time, unitname, age, sex, categoryname," +
            "ccdescription, cc, bp_sys1,bp_dia1, pulse1, resp1, 02_sat1," +
            "init_bgl, sec_bgl,loc,gcs,t_a,s_a,stemi,deptname,level,eta " +
            "from EmergencyCall left join unit on unit=unitid left join category on category=catid left join " +
            "cclist on EmergencyCall.ccid = cclist.ccid left join department on EmergencyCall.receiving_dept=deptid " +
            "where created_date_time between '" + startdate.ToString() + "' and '" + stopdate.ToString() + "'";
            //sqlString += createWhereString(key);
            SqlCommand cmd = new SqlCommand(sqlString, getDataConnection(false));
            return getDataObjects<RRDataObject>(cmd);
        }

        public List<RRDataObject> getRecordsForQueryStart(Nullable<DateTime> date)
        {
            String sqlString = "Select created_date_time, unitname, age, sex, categoryname," +
            "ccdescription, cc, bp_sys1,bp_dia1, pulse1, resp1, 02_sat1," +
            "init_bgl, sec_bgl,loc,gcs,t_a,s_a,stemi,deptname,level,eta " +
            "from EmergencyCall left join unit on unit=unitid left join category on category=catid left join " +
            "cclist on EmergencyCall.ccid = cclist.ccid left join department on EmergencyCall.receiving_dept=deptid " +
            "where created_date_time >= '" + date.ToString() + "'";
            //sqlString += createWhereString(key);
            SqlCommand cmd = new SqlCommand(sqlString, getDataConnection(false));
            return getDataObjects<RRDataObject>(cmd);
        }

        public List<RRDataObject> getRecordsForQueryStop(Nullable<DateTime> date)
        {
            String sqlString = "Select created_date_time, unitname, age, sex, categoryname," +
            "ccdescription, cc, bp_sys1,bp_dia1, pulse1, resp1, 02_sat1," +
            "init_bgl, sec_bgl,loc,gcs,t_a,s_a,stemi,deptname,level,eta " +
            "from EmergencyCall left join unit on unit=unitid left join category on category=catid left join " +
            "cclist on EmergencyCall.ccid = cclist.ccid left join department on EmergencyCall.receiving_dept=deptid " +
            "where created_date_time <= '" + date.ToString() + "'";
            //sqlString += createWhereString(key);
            SqlCommand cmd = new SqlCommand(sqlString, getDataConnection(false));
            return getDataObjects<RRDataObject>(cmd);
        }

        public List<RRCounty> getAllCountyItems()
        {
            SqlCommand cmd = new SqlCommand("Select * from county", getDataConnection(false));
            return getDataObjects<RRCounty>(cmd);
        }

        public List<RRHistory> getAllHistoryItems()
        {

            SqlCommand cmd = new SqlCommand("Select * from history", getDataConnection(false));
            return getDataObjects<RRHistory>(cmd);
        }

        public List<RRTreatment> getAllTreatmentItems()
        {
            SqlCommand cmd = new SqlCommand("Select * from treatment", getDataConnection(false));
            return getDataObjects<RRTreatment>(cmd);
        }

        public List<RRDepartment> getAllDepartmentItems()
        {
            SqlCommand cmd = new SqlCommand("Select * from department", getDataConnection(false));
            return getDataObjects<RRDepartment>(cmd);
        }

        public List<RRUnit> getAllUnitItems()
        {

            SqlCommand cmd = new SqlCommand("Select * from unit", getDataConnection(false));
            return getDataObjects<RRUnit>(cmd);
        }

        public List<RRCategory> getAllCategoryItems()
        {
            SqlCommand cmd = new SqlCommand("Select * from category", getDataConnection(false));
            return getDataObjects<RRCategory>(cmd);
        }

        public List<RRChiefComplaint> getCCListItems()
        {

            SqlCommand cmd = new SqlCommand("Select * from cclist", getDataConnection(false));
            return getDataObjects<RRChiefComplaint>(cmd);
        }

        public List<RRDoctor> getAllDoctorItems()
        {
            SqlCommand cmd = new SqlCommand("Select * from doctor", getDataConnection(false));
            return getDataObjects<RRDoctor>(cmd);
        }

        public List<RRMedication> getAllMedicationItems()
        {
            SqlCommand cmd = new SqlCommand("Select * from medication", getDataConnection(false));
            return getDataObjects<RRMedication>(cmd);
        }
    }
}
