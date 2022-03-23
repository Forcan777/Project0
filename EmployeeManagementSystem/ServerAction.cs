using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;


namespace EmployeeManagementSystem
{
    class ServerAction
    {

        #region SQL Database Connection
        SqlConnection Connect = new SqlConnection(@"server=ASUS-TUF-F15\MLAIMSSQL;database=EmployeeDB;user=sa;password=SQL_Access01");

        #endregion
        public void Create(ref Employee NewEmp)
        {
            #region SQL Database - Adding Employee Information

            SqlCommand cmd_addEmp = new SqlCommand("INSERT INTO EmpList VALUES(@EmpName, @EmpEmail, @EmpSalary, @EmpStatus, @EmpRole, @EmpAccPower)", Connect);

            cmd_addEmp.Parameters.AddWithValue("@EmpName", NewEmp.EmpName);
            cmd_addEmp.Parameters.AddWithValue("@EmpEmail", NewEmp.EmpEmail);
            cmd_addEmp.Parameters.AddWithValue("@EmpSalary", NewEmp.EmpSalary);
            cmd_addEmp.Parameters.AddWithValue("@EmpStatus", NewEmp.EmpStatus);
            cmd_addEmp.Parameters.AddWithValue("@EmpRole", NewEmp.EmpRole);
            cmd_addEmp.Parameters.AddWithValue("@EmpAccPower", NewEmp.EmpUserAccLevel);

            try
            {
                Connect.Open();
                cmd_addEmp.ExecuteNonQuery();
            }
            catch(SqlException exEnc)
            {
                System.Console.WriteLine(exEnc.Message);
            }
            finally
            {
                Connect.Close();
            }
            #endregion
            System.Console.WriteLine("You have added an employee record.");


        }
        public void CreateLogin(ref Employee NewEmp)
        {
            SqlCommand cmd_addEmpLogin = new SqlCommand("INSERT INTO LoginAccount VALUES(@EmpEmail, @EmpPassword, @EmpID)", Connect);

            cmd_addEmpLogin.Parameters.AddWithValue("@EmpEmail", NewEmp.EmpEmail);
            cmd_addEmpLogin.Parameters.AddWithValue("@EmpPassword", "password");
            cmd_addEmpLogin.Parameters.AddWithValue("@EmpID", NewEmp.EmpNo);
            
            try
            {
                Connect.Open();
                cmd_addEmpLogin.ExecuteNonQuery();
            }
            catch(SqlException exEnc)
            {
                System.Console.WriteLine(exEnc.Message);
            }
            finally
            {
                Connect.Close();
            }
            System.Console.WriteLine("You have added an employee login.");
        }
        public void CreateTeam(ref Employee NewEmp)
        {
            SqlCommand cmd_addEmpTeam = new SqlCommand("INSERT INTO TeamList VALUES(@TeamID, @EmpID)", Connect);

            cmd_addEmpTeam.Parameters.AddWithValue("@TeamID", 0);
            cmd_addEmpTeam.Parameters.AddWithValue("@EmpID", NewEmp.EmpNo);
            try
            {
                Connect.Open();
                cmd_addEmpTeam.ExecuteNonQuery();
            }
            catch(SqlException exEnc)
            {
                System.Console.WriteLine(exEnc.Message);
            }
            finally
            {
                Connect.Close();
            }
            System.Console.WriteLine("Employee team number is default to 0.");
        }
        
        public int ReadExist(ref Accounts loginSearch)
        {
            SqlCommand cmd_searchLogin = new SqlCommand("SELECT COUNT(*) FROM LoginAccount WHERE Username = @uName AND Password = @uPass COLLATE SQL_Latin1_General_CP1_CS_AS", Connect);
            // SQL command clause COLLATE SQL_Latin1_General_CP1_CS_AS will make case sensitive string comparison
            // SQL command clause COLLATE SQL_Latin1_General_CP1_CI_AS will make case insensitive string comparison
            cmd_searchLogin.Parameters.AddWithValue("@uName", loginSearch.Username);
            cmd_searchLogin.Parameters.AddWithValue("@uPass", loginSearch.Password);
            
            int userExist = 0;
            try
            {
                Connect.Open();
                userExist = Convert.ToInt32(cmd_searchLogin.ExecuteScalar());
            }
            catch (System.Exception exEnc)
            {
                System.Console.WriteLine(exEnc.Message);
            }
            finally
            {
                Connect.Close();
            }

            return userExist;
        }
        public int ReadId(ref Accounts loginSearch)
        {
            SqlCommand cmd_searchLogin = new SqlCommand("SELECT * FROM LoginAccount WHERE Username = @uName AND Password = @uPass COLLATE SQL_Latin1_General_CP1_CS_AS", Connect);
            // SQL command clause COLLATE SQL_Latin1_General_CP1_CS_AS will make case sensitive string comparison
            // SQL command clause COLLATE SQL_Latin1_General_CP1_CI_AS will make case insensitive string comparison
            cmd_searchLogin.Parameters.AddWithValue("@uName", loginSearch.Username);
            cmd_searchLogin.Parameters.AddWithValue("@uPass", loginSearch.Password);
            SqlDataReader readId;

            int actId = 0;
            try
            {
                Connect.Open();
                readId = cmd_searchLogin.ExecuteReader();

                if(readId.Read())
                {
                    actId = Convert.ToInt32(readId[2]);
                }
            }
            catch (System.Exception exEnc)
            {
                
                System.Console.WriteLine(exEnc.Message);
            }
            finally
            {
                Connect.Close();
            }
            return actId;
        }
        public int ReadId(ref Employee NewEmp)
        {
            SqlCommand cmd_searchEmpID = new SqlCommand("SELECT * FROM EmpList WHERE EmpName = @EmpName AND EmpEmail = @EmpEmail", Connect);
            // SQL command clause COLLATE SQL_Latin1_General_CP1_CS_AS will make case sensitive string comparison
            // SQL command clause COLLATE SQL_Latin1_General_CP1_CI_AS will make case insensitive string comparison
            cmd_searchEmpID.Parameters.AddWithValue("@EmpName", NewEmp.EmpName);
            cmd_searchEmpID.Parameters.AddWithValue("@EmpEmail", NewEmp.EmpEmail);
            SqlDataReader readId;

            int actId = 0;
            try
            {
                Connect.Open();
                readId = cmd_searchEmpID.ExecuteReader();

                if(readId.Read())
                {
                    actId = Convert.ToInt32(readId[0]);
                }
            }
            catch (System.Exception exEnc)
            {
                
                System.Console.WriteLine(exEnc.Message);
            }
            finally
            {
                Connect.Close();
            }
            return actId;
        }
        public void Read(int empID, ref List<Employee> empSearch)
        {
            SqlCommand cmd_searchEmpID = new SqlCommand("SELECT * FROM EmpList WHERE EmpID = @EmpID", Connect);
            cmd_searchEmpID.Parameters.AddWithValue("@EmpID",empID);
            SqlDataReader readEmp;

            try
            {
                Connect.Open();
                readEmp = cmd_searchEmpID.ExecuteReader();

                if(readEmp.Read())
                {
                    empSearch.Add(new Employee()
                    {
                        EmpNo = empID,
                        EmpName = Convert.ToString(readEmp[1]),
                        EmpEmail = Convert.ToString(readEmp[2]),
                        EmpSalary = Convert.ToDouble(readEmp[3]),
                        EmpStatus = Convert.ToString(readEmp[4]),
                        EmpRole = Convert.ToString(readEmp[5]),
                        EmpUserAccLevel = Convert.ToString(readEmp[6])
                    });
                    
                }
            }
            catch (System.Exception exEnc)
            {
                
                System.Console.WriteLine(exEnc.Message);
            }
            finally
            {
                Connect.Close();
            }
        }
        public void ReadGroup(int roleNum, ref List<Employee> empSearch)
        {
            SqlCommand cmd_searchEmpRole = new SqlCommand("SELECT * FROM EmpList WHERE EmpAccPower = @EmpAccPower", Connect);
            switch (roleNum)
            {
                case 1:
                    cmd_searchEmpRole.Parameters.AddWithValue("@EmpAccPower", "A");
                    break;
                case 2:
                    cmd_searchEmpRole.Parameters.AddWithValue("@EmpAccPower", "M");
                    break;
                case 3:
                    cmd_searchEmpRole.Parameters.AddWithValue("@EmpAccPower", "H");
                    break;
                case 4:
                    cmd_searchEmpRole.Parameters.AddWithValue("@EmpAccPower", "D");
                    break;
            }

            SqlDataReader readEmp;
            try
            {
                Connect.Open();
                readEmp = cmd_searchEmpRole.ExecuteReader();
                while (readEmp.Read())
                {
                    int empIdCheck = Convert.ToInt32(readEmp[0]);
                    if (empIdCheck != 0)
                    {
                        empSearch.Add(new Employee()
                        {
                            EmpNo = Convert.ToInt32(readEmp[0]),
                            EmpName = Convert.ToString(readEmp[1]),
                            EmpEmail = Convert.ToString(readEmp[2]),
                            EmpSalary = Convert.ToDouble(readEmp[3]),
                            EmpStatus = Convert.ToString(readEmp[4]),
                            EmpRole = Convert.ToString(readEmp[5]),
                            EmpUserAccLevel = Convert.ToString(readEmp[6])
                        });
                    }
                }
            }
            catch (System.Exception exEnc)
            {
                
                System.Console.WriteLine(exEnc.Message);
            }
            finally
            {
                Connect.Close();
            }
        }
        public void ReadAll(ref List<Employee> empSearch)
        {
            SqlCommand cmd_searchEmpRole = new SqlCommand("SELECT * FROM EmpList", Connect);
            SqlDataReader readEmp;
            try
            {
                Connect.Open();
                readEmp = cmd_searchEmpRole.ExecuteReader();
                while (readEmp.Read())
                {
                    int empIdCheck = Convert.ToInt32(readEmp[0]);
                    if (empIdCheck != 0)
                    {
                        empSearch.Add(new Employee()
                        {
                            EmpNo = Convert.ToInt32(readEmp[0]),
                            EmpName = Convert.ToString(readEmp[1]),
                            EmpEmail = Convert.ToString(readEmp[2]),
                            EmpSalary = Convert.ToDouble(readEmp[3]),
                            EmpStatus = Convert.ToString(readEmp[4]),
                            EmpRole = Convert.ToString(readEmp[5]),
                            EmpUserAccLevel = Convert.ToString(readEmp[6])
                        });
                    }
                }
            }
            catch (System.Exception exEnc)
            {
                
                System.Console.WriteLine(exEnc.Message);
            }
            finally
            {
                Connect.Close();
            }
        }        
        public int ReadTeamID(int empID)
        {
            SqlCommand cmd_searchEmpID = new SqlCommand("SELECT TeamID FROM TeamList WHERE TeamEmpID = @TeamEmpID", Connect);
            
            cmd_searchEmpID.Parameters.AddWithValue("@TeamEmpID", empID);

            SqlDataReader readId;
            int teamId = 0;
            try
            {
                Connect.Open();
                readId = cmd_searchEmpID.ExecuteReader();

                if(readId.Read())
                {
                    teamId = Convert.ToInt32(readId[0]);
                }
            }
            catch (System.Exception exEnc)
            {
                
                System.Console.WriteLine(exEnc.Message);
            }
            finally
            {
                Connect.Close();
            }
            return teamId;
        }
        public void ReadTeam(int TeamID, ref List<Employee> empSearch)
        {
            SqlCommand cmd_searchEmpTeam = new SqlCommand("SELECT EmpID, EmpName, EmpEmail, EmpSalary, EmpStatus, EmpRole, EmpAccPower " +  
            "FROM EmpList FULL JOIN TeamList ON EmpList.EmpID = TeamList.TeamEmpID WHERE TeamList.TeamID = @TeamID", Connect);
            cmd_searchEmpTeam.Parameters.AddWithValue("@TeamID", TeamID);

            SqlDataReader readEmp;
            try
            {
                Connect.Open();
                readEmp = cmd_searchEmpTeam.ExecuteReader();
                while (readEmp.Read())
                {
                    int empIdCheck = Convert.ToInt32(readEmp[0]);
                    if (empIdCheck != 0)
                    {
                        empSearch.Add(new Employee()
                        {
                            EmpNo = Convert.ToInt32(readEmp[0]),
                            EmpName = Convert.ToString(readEmp[1]),
                            EmpEmail = Convert.ToString(readEmp[2]),
                            EmpSalary = Convert.ToDouble(readEmp[3]),
                            EmpStatus = Convert.ToString(readEmp[4]),
                            EmpRole = Convert.ToString(readEmp[5]),
                            EmpUserAccLevel = Convert.ToString(readEmp[6])
                        });
                    }
                }
            }
            catch (System.Exception exEnc)
            {
                
                System.Console.WriteLine(exEnc.Message);
            }
            finally
            {
                Connect.Close();
            }
        }
        public void ReadAvailableDev(ref List<Employee> empSearch)
        {
            SqlCommand cmd_searchEmpTeam = new SqlCommand("SELECT EmpID, EmpName, EmpEmail, EmpSalary, EmpStatus, EmpRole, EmpAccPower " +  
            "FROM EmpList FULL JOIN TeamList ON EmpList.EmpID = TeamList.TeamEmpID WHERE TeamList.TeamID = 0 AND EmpList.EmpAccPower = 'D'", Connect);

            SqlDataReader readEmp;
            try
            {
                Connect.Open();
                readEmp = cmd_searchEmpTeam.ExecuteReader();
                while (readEmp.Read())
                {
                    int empIdCheck = Convert.ToInt32(readEmp[0]);
                    if (empIdCheck != 0)
                    {
                        empSearch.Add(new Employee()
                        {
                            EmpNo = Convert.ToInt32(readEmp[0]),
                            EmpName = Convert.ToString(readEmp[1]),
                            EmpEmail = Convert.ToString(readEmp[2]),
                            EmpSalary = Convert.ToDouble(readEmp[3]),
                            EmpStatus = Convert.ToString(readEmp[4]),
                            EmpRole = Convert.ToString(readEmp[5]),
                            EmpUserAccLevel = Convert.ToString(readEmp[6])
                        });
                    }
                }
            }
            catch (System.Exception exEnc)
            {
                
                System.Console.WriteLine(exEnc.Message);
            }
            finally
            {
                Connect.Close();
            }
        }
        public void ReadLogin(ref List<Employee> empSearch)
        {
            SqlCommand cmd_searchEmpRole = new SqlCommand("SELECT * FROM EmpList", Connect);
            SqlDataReader readEmp;
            try
            {
                Connect.Open();
                readEmp = cmd_searchEmpRole.ExecuteReader();
                while (readEmp.Read())
                {
                    empSearch.Add(new Employee()
                    {
                        EmpNo = Convert.ToInt32(readEmp[0]),
                        EmpName = Convert.ToString(readEmp[1]),
                        EmpEmail = Convert.ToString(readEmp[2]),
                        EmpSalary = Convert.ToDouble(readEmp[3]),
                        EmpStatus = Convert.ToString(readEmp[4]),
                        EmpRole = Convert.ToString(readEmp[5]),
                        EmpUserAccLevel = Convert.ToString(readEmp[6])
                    });
                }
            }
            catch (System.Exception exEnc)
            {
                
                System.Console.WriteLine(exEnc.Message);
            }
            finally
            {
                Connect.Close();
            }
        }
        // NOT YET IMPLEMENTED

        public void Update(int empID, ref Employee UpdatedEmp)
        {
            #region SQL Database - Updating Employee Information

            SqlCommand cmd_UpEmp = new SqlCommand("UPDATE EmpList SET EmpName = @EmpName, EmpEmail = @EmpEmail, EmpSalary = @EmpSalary, EmpStatus = @EmpStatus, EmpRole = @EmpRole, EmpAccPower = @EmpAccPower WHERE EmpID = @EmpId", Connect);

            cmd_UpEmp.Parameters.AddWithValue("@EmpName", UpdatedEmp.EmpName);
            cmd_UpEmp.Parameters.AddWithValue("@EmpEmail", UpdatedEmp.EmpEmail);
            cmd_UpEmp.Parameters.AddWithValue("@EmpSalary", UpdatedEmp.EmpSalary);
            cmd_UpEmp.Parameters.AddWithValue("@EmpStatus", UpdatedEmp.EmpStatus);
            cmd_UpEmp.Parameters.AddWithValue("@EmpRole", UpdatedEmp.EmpRole);
            cmd_UpEmp.Parameters.AddWithValue("@EmpAccPower", UpdatedEmp.EmpUserAccLevel);
            cmd_UpEmp.Parameters.AddWithValue("@EmpId", empID);
            
            try
            {
                Connect.Open();
                cmd_UpEmp.ExecuteNonQuery();
            }
            catch(SqlException exEnc)
            {
                System.Console.WriteLine(exEnc.Message);
            }
            finally
            {
                Connect.Close();
            }
            #endregion

            System.Console.WriteLine("You have updated an employee.");
            System.Console.WriteLine("Press Any Key to Continue.");
            System.Console.ReadLine();
        }
        public void UpdateLogin(int empID, ref Employee UpdatedEmp)
        {
            
            #region SQL Database - Adding Employee Information

            SqlCommand cmd_UpLogin = new SqlCommand("UPDATE EmpList SET EmpName = @EmpName, EmpEmail = @EmpEmail, EmpSalary = @EmpSalary, EmpStatus = @EmpStatus, EmpRole = @EmpRole, EmpAccPower = @EmpAccPower WHERE EmpID = @EmpId", Connect);

            cmd_UpLogin.Parameters.AddWithValue("@EmpName", UpdatedEmp.EmpName);
            cmd_UpLogin.Parameters.AddWithValue("@EmpEmail", UpdatedEmp.EmpEmail);
            cmd_UpLogin.Parameters.AddWithValue("@EmpSalary", UpdatedEmp.EmpSalary);
            cmd_UpLogin.Parameters.AddWithValue("@EmpStatus", UpdatedEmp.EmpStatus);
            cmd_UpLogin.Parameters.AddWithValue("@EmpRole", UpdatedEmp.EmpRole);
            cmd_UpLogin.Parameters.AddWithValue("@EmpAccPower", UpdatedEmp.EmpUserAccLevel);
            cmd_UpLogin.Parameters.AddWithValue("@EmpId", empID);
            
            try
            {
                Connect.Open();
                cmd_UpLogin.ExecuteNonQuery();
            }
            catch(SqlException exEnc)
            {
                System.Console.WriteLine(exEnc.Message);
            }
            finally
            {
                Connect.Close();
            }
            #endregion

            System.Console.WriteLine("You have updated an employee.");
            System.Console.WriteLine("Press Any Key to Continue.");
            System.Console.ReadLine();
        }
        // NOT YET IMPLEMENTED
        public void UpdateTeamMember(int teamID, int empID)
        {
            #region SQL Database - Updating TeamList Information

            SqlCommand cmd_UpEmpTeam = new SqlCommand("UPDATE TeamList SET TeamID = @TeamID WHERE TeamEmpID = @TeamEmpId", Connect);
            cmd_UpEmpTeam.Parameters.AddWithValue("@TeamID", teamID);
            cmd_UpEmpTeam.Parameters.AddWithValue("@TeamEmpId", empID);
            
            try
            {
                Connect.Open();
                cmd_UpEmpTeam.ExecuteNonQuery();
            }
            catch(SqlException exEnc)
            {
                System.Console.WriteLine(exEnc.Message);
            }
            finally
            {
                Connect.Close();
            }
            #endregion
            if (teamID != 0)
                System.Console.WriteLine("You have added a developer to the team.");
            else
                System.Console.WriteLine("You have removed a developer to the team.");
            System.Console.WriteLine("Press Any Key to Continue.");
            System.Console.ReadLine();
        }
        public void Delete(int empID)
        {
            SqlCommand cmd_EmployeeRemoval = new SqlCommand("DELETE FROM EmpList WHERE EmpID = @empID", Connect);
            cmd_EmployeeRemoval.Parameters.AddWithValue("@empID",empID);
            try
            {
                Connect.Open();
                cmd_EmployeeRemoval.ExecuteNonQuery();
            }
            catch (System.Exception exEnc)
            {
                
                System.Console.WriteLine(exEnc.Message);
            }
            finally
            {
                Connect.Close();
            }
        }
        public void DeleteTeam(int empID)
        {
            SqlCommand cmd_EmployeeRemoval = new SqlCommand("DELETE FROM TeamList WHERE TeamEmpID = @empID", Connect);
            cmd_EmployeeRemoval.Parameters.AddWithValue("@empID",empID);
            try
            {
                Connect.Open();
                cmd_EmployeeRemoval.ExecuteNonQuery();
            }
            catch (System.Exception exEnc)
            {
                
                System.Console.WriteLine(exEnc.Message);
            }
            finally
            {
                Connect.Close();
            }
        }
        public void DeleteLogin(int empID)
        {
            SqlCommand cmd_EmployeeRemoval = new SqlCommand("DELETE FROM LoginAccount WHERE EmpID = @empID", Connect);
            cmd_EmployeeRemoval.Parameters.AddWithValue("@empID",empID);
            try
            {
                Connect.Open();
                cmd_EmployeeRemoval.ExecuteNonQuery();
            }
            catch (System.Exception exEnc)
            {
                
                System.Console.WriteLine(exEnc.Message);
            }
            finally
            {
                Connect.Close();
            }
        }
    }
}