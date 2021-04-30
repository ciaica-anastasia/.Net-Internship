using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace AdoNet
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            string sqlCreate1 =
                "CREATE TABLE Students(StudentId INT NOT NULL IDENTITY(1,1) PRIMARY KEY, FirstName NVARCHAR(100) NOT NULL, LastName NVARCHAR(100) NOT NULL, GradeId INT NOT NULL)";
            string sqlCreate2 =
                "CREATE TABLE Grades(GradeId INT NOT NULL IDENTITY(1, 1) PRIMARY KEY, Grade NVARCHAR(100) NOT NULL)";

            string sqlSelectStudents = "SELECT * FROM Students";
            //string sqlSelectGrades = "SELECT * FROM Grades";

            string sqlInsertStudents =
                "INSERT INTO Students(FirstName, LastName, GradeId) VALUES (@First, @Last, @Grade)";

            string sqlUpdateStudents =
                "UPDATE Students SET FirstName = @First, LastName = @Last, GradeId = @Grade WHERE StudentId = @Id";

            string sqlDeleteStudents = "DELETE FROM Students WHERE StudentId = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                using (SqlCommand sqlCommand = new SqlCommand(sqlCreate2, connection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
                
                using (SqlCommand sqlCommand = new SqlCommand(sqlCreate1, connection))
                {
                    sqlCommand.ExecuteNonQuery();
                }

                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                SqlCommand sqlSelectStudentsCommand = new SqlCommand(sqlSelectStudents, connection);
                dataAdapter.SelectCommand = sqlSelectStudentsCommand;

                SqlCommand sqlInsertStudentsCommand = new SqlCommand(sqlInsertStudents, connection);
                sqlInsertStudentsCommand.Parameters.Add("@First", SqlDbType.NVarChar, 100, "FirstName");
                sqlInsertStudentsCommand.Parameters.Add("@Last", SqlDbType.NVarChar, 100, "LastName");
                sqlInsertStudentsCommand.Parameters.Add("@Grade", SqlDbType.Int, 10, "GradeId");
                dataAdapter.InsertCommand = sqlInsertStudentsCommand;
                
                SqlCommand sqlUpdateStudentsCommand = new SqlCommand(sqlUpdateStudents, connection);
                sqlUpdateStudentsCommand.Parameters.Add("@First", SqlDbType.NVarChar, 100, "FirstName");
                sqlUpdateStudentsCommand.Parameters.Add("@Last", SqlDbType.NVarChar, 100, "LastName");
                sqlUpdateStudentsCommand.Parameters.Add("@Grade", SqlDbType.Int, 10, "GradeId");
                sqlUpdateStudentsCommand.Parameters.Add("@Id", SqlDbType.Int, 100, "StudentId");
                dataAdapter.UpdateCommand = sqlUpdateStudentsCommand;
                
                SqlCommand sqlDeleteStudentsCommand = new SqlCommand(sqlDeleteStudents, connection);
                sqlDeleteStudentsCommand.Parameters.Add("@Id", SqlDbType.Int, 100, "StudentId");
                dataAdapter.DeleteCommand = sqlDeleteStudentsCommand;

                DataTable studentsTable = new DataTable("Students");
                DataTable gradesTable = new DataTable("Grades");
                
                DataSet dataSet = new DataSet("NewAdoDatabase");
                dataSet.Tables.Add(studentsTable);
                dataSet.Tables.Add(gradesTable);
                // dataSet.Relations.Add("StudentGradeRelation",
                //     dataSet.Tables["Grade"].Columns["GradeId"],
                //     dataSet.Tables["Students"].Columns["GradeId"]
                // );
                
                studentsTable.Columns.Add("StudentId", typeof(int));
                studentsTable.Columns.Add("FirstName", typeof(string));
                studentsTable.Columns.Add("LastName", typeof(string));
                studentsTable.Columns.Add("GradeId", typeof(string));

                DataRow row = studentsTable.NewRow();
                row["FirstName"] = "Lionel";
                row["LastName"] = "Workman";
                row["GradeId"] = 10;
                studentsTable.Rows.Add(row);
                dataAdapter.Update(studentsTable);
                
                dataAdapter.Fill(dataSet);
                //read from database in memory
                foreach (DataTable dt in dataSet.Tables)
                {
                    Console.WriteLine(dt.TableName);
                    foreach(DataColumn column in dt.Columns)
                        Console.Write("\t{0}", column.ColumnName);
                    Console.WriteLine();
                    foreach (DataRow dataRow in dt.Rows)
                    {
                        var cells = dataRow.ItemArray;
                        foreach (object cell in cells)
                            Console.Write("\t{0}", cell);
                        Console.WriteLine();
                    }
                }
                
                // row["FirstName"] = "Quinn";
                // row["LastName"] = "McKenzie";
                // row["GradeId"] = 7;
                // row["StudentId"] = 1;
                var row1 = studentsTable.Rows.Find(1);
                row1["FirstName"] = "Quinn";
                row1["LastName"] = "McKenzie";
                row1["GradeId"] = 7;
                dataAdapter.Update(studentsTable);
                dataAdapter.Fill(studentsTable);
                
                foreach (DataTable dt in dataSet.Tables)
                {
                    Console.WriteLine(dt.TableName);
                    foreach(DataColumn column in dt.Columns)
                        Console.Write("\t{0}", column.ColumnName);
                    Console.WriteLine();
                    foreach (DataRow dataRow in dt.Rows)
                    {
                        var cells = dataRow.ItemArray;
                        foreach (object cell in cells)
                            Console.Write("\t{0}", cell);
                        Console.WriteLine();
                    }
                }
                    
                // row.Delete();
                // dataAdapter.Update(studentsTable);
                
                //read from database in memory
                // SqlDataReader reader = sqlSelectStudentsCommand.ExecuteReader();
                // if (reader.HasRows) 
                // {
                //     Console.WriteLine("{0}\t{1}\t{2}\t{3}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3));
                //
                //     while (reader.Read()) 
                //     {
                //         object id = reader.GetValue(0);
                //         object lastName = reader.GetValue(1);
                //         object firstName = reader.GetValue(2);
                //         object gradeId = reader.GetValue(3);
                //
                //         Console.WriteLine("{0}\t{1}\t{2}\t{3}", id, lastName, firstName, gradeId);
                //     }
                // }
                // reader.Close();
            }
        }
    }
}