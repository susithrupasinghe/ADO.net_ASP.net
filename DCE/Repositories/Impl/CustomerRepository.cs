using System;
using DCE.Models;
using DCE.Models.RequestDto;
using System.Data.SqlClient;
using System.Data;
using System.Formats.Asn1;
using DCE.Controllers;
using System.Data.Common;

namespace DCE.Repositories.Impl
{
    public class CustomerRepository: ICustomerRepository
    {

        private String SqlConnectionStringBuilder = "Server=tcp:mssqlserver-dummy.database.windows.net,1433;Initial Catalog=dce;Persist Security Info=False;User ID=root123;Password=root@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public CustomerRepository()
        {
            
        }

        public bool CreateCustomer(CreateCustomerDto customer)
        {
            using (SqlConnection connection = new SqlConnection(SqlConnectionStringBuilder))
            {
      
                const string sql = "INSERT INTO Customer (UserId, Username, Email, FirstName, LastName, CreatedOn, IsActive) " +
                    "VALUES( @userId, @username, @email, @firstName, @lastName, @CreatedOn, @IsActive)";

               
                using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                {
                  
                    sqlCommand.Parameters.Add(new SqlParameter("@userId", SqlDbType.UniqueIdentifier));
                    sqlCommand.Parameters["@userId"].Value = Guid.NewGuid();

                    sqlCommand.Parameters.Add(new SqlParameter("@Username", SqlDbType.VarChar));
                    sqlCommand.Parameters["@Username"].Value = customer.username;

                    sqlCommand.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar));
                    sqlCommand.Parameters["@email"].Value = customer.email;

                    sqlCommand.Parameters.Add(new SqlParameter("@firstName", SqlDbType.VarChar));
                    sqlCommand.Parameters["@firstName"].Value = customer.firstName;

                    sqlCommand.Parameters.Add(new SqlParameter("@lastName", SqlDbType.VarChar));
                    sqlCommand.Parameters["@lastName"].Value = customer.lastName;

                    sqlCommand.Parameters.Add(new SqlParameter("@CreatedOn", SqlDbType.DateTime));
                    sqlCommand.Parameters["@CreatedOn"].Value = DateTime.Now;

                    sqlCommand.Parameters.Add(new SqlParameter("@IsActive", SqlDbType.Bit));
                    sqlCommand.Parameters["@IsActive"].Value = true;

                    bool isSuccess = false;

                    try
                    {
                        connection.Open();
                        if (sqlCommand.ExecuteNonQuery() > 0)
                        {
                            isSuccess = true;
                        }
                        else
                        {
                            isSuccess =  false;
                        }

                    }
                    catch (SqlException ex)
                    {
                        connection.Close();
                        throw ex;
                    }
                    finally {

             
                        connection.Close();
                    }

                    return isSuccess;
                    
                }
            }
        }

        bool ICustomerRepository.DeleteCustomer(string customerId)
        {
            using (SqlConnection connection = new SqlConnection(SqlConnectionStringBuilder))
            {

                const string sql = "DELETE FROM Customer WHERE UserId= @userID";


                using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                {

                    sqlCommand.Parameters.Add(new SqlParameter("@userId", SqlDbType.VarChar));
                    sqlCommand.Parameters["@userId"].Value = customerId;

                
                    bool isSuccess = false;

                    try
                    {
                        connection.Open();
                        if (sqlCommand.ExecuteNonQuery() > 0)
                        {
                            isSuccess = true;
                        }
                        else
                        {
                            isSuccess = false;
                        }

                    }
                    catch (SqlException ex)
                    {
                        connection.Close();
                        throw ex;
                    }
                    finally
                    {

                        connection.Close();
                    }

                    return isSuccess;

                }
            }
        }

        IEnumerable<Order> ICustomerRepository.GetActiveOrders(string customerId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Customer> ICustomerRepository.GetAllCustomers()
        {
            using (SqlConnection connection = new SqlConnection(SqlConnectionStringBuilder))
            {

                const string sql = "SELECT * FROM Customer";


                using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                {


                    List<Customer> customers = new List<Customer>();

                    try
                    {
                        connection.Open();
                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            while (dataReader.Read()) {

                                customers.Add(new Customer
                                {
                                    UserId = dataReader.GetValue(0).ToString(),
                                    Username = dataReader.GetString(1),
                                    Email = dataReader.GetString(2),
                                    FirstName = dataReader.GetString(3),
                                    LastName = dataReader.GetString(4),
                                    CreatedOn = dataReader.GetDateTime(5),
                                    IsActive = dataReader.GetBoolean(6)
                                });
                            }
                            dataReader.Close();
                        }

                    }
                    catch (SqlException ex)
                    {
                        connection.Close();
                        throw ex;
                    }
                    finally
                    {
                        connection.Close();
                    }

                    return customers;

                }
            }
        }

        bool ICustomerRepository.UpdateCustomer(UpdateCustomerDto customer, String userId)
        {
            using (SqlConnection connection = new SqlConnection(SqlConnectionStringBuilder))
            {

                const string sql = "UPDATE Customer SET Username = @Username, Email = @Email, FirstName = @FirstName, LastName = @LastName WHERE UserId = @UserId";


                using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                {

                    sqlCommand.Parameters.Add(new SqlParameter("@userId", SqlDbType.VarChar));
                    sqlCommand.Parameters["@userId"].Value = userId;

                    sqlCommand.Parameters.Add(new SqlParameter("@Username", SqlDbType.VarChar));
                    sqlCommand.Parameters["@Username"].Value = customer.username;

                    sqlCommand.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar));
                    sqlCommand.Parameters["@email"].Value = customer.email;

                    sqlCommand.Parameters.Add(new SqlParameter("@firstName", SqlDbType.VarChar));
                    sqlCommand.Parameters["@firstName"].Value = customer.firstName;

                    sqlCommand.Parameters.Add(new SqlParameter("@lastName", SqlDbType.VarChar));
                    sqlCommand.Parameters["@lastName"].Value = customer.lastName;


                    bool isSuccess = false;

                    try
                    {
                        connection.Open();
                        if (sqlCommand.ExecuteNonQuery() > 0)
                        {
                            isSuccess = true;
                        }
                        else
                        {
                            isSuccess = false;
                        }

                    }
                    catch (SqlException ex)
                    {
                        connection.Close();
                        throw ex;
                    }
                    finally
                    {


                        connection.Close();
                    }

                    return isSuccess;

                }
            }
        }
    }
}

