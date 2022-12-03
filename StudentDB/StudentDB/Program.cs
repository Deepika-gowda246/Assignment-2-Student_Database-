using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace StudentDB
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string cs = @"Data Source=BLR1-LHP-N80939\SQLEXPRESS;Initial Catalog=StudentData;Integrated Security=True";

            SqlConnection con = new SqlConnection(cs);
            con.Open();
            Boolean temp = true;
            while (temp)
            {
                Console.WriteLine("Select the table\n 1.Student\t2.Subjects\t 3.All_Student_Data\t4. Exit");
                int ch = int.Parse(Console.ReadLine());
                switch (ch)
                {

                    case 1:
                        Console.WriteLine("Enter your Choice\n1. Add\t 2. Update\t3. Delete\t4. Display\t5.Search by StudentID");

                        int ch1 = int.Parse(Console.ReadLine());
                        switch (ch1)
                        {
                            case 1:
                                Console.WriteLine("Enter the Name");
                                string _sname = Console.ReadLine();
                                Console.WriteLine("Enter the Address");
                                string _sadd = Console.ReadLine();
                                Console.WriteLine("Enter the Class");
                                string _scls = Console.ReadLine();
                                SqlCommand cmd2 = new SqlCommand();
                                cmd2.CommandType = CommandType.Text;
                                cmd2.Connection = con;
                                cmd2.CommandText = "insert into Student(name,Address,Class) values(@sname,@sadd,@scls)";
                                cmd2.Parameters.AddWithValue("@sname", _sname);
                                cmd2.Parameters.AddWithValue("@sadd", _sadd);
                                cmd2.Parameters.AddWithValue("@scls", _scls);
                                int _rows = cmd2.ExecuteNonQuery();
                                if (_rows > 0)
                                {
                                    Console.WriteLine("Inserted Succesfully");
                                }
                                else
                                {
                                    Console.WriteLine("Fail to insert");
                                }

                                break;

                            case 2:
                                Console.WriteLine("Enter Student ID to update: ");
                                int _Studid = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter the new Name");
                                string _sname1 = Console.ReadLine();
                                Console.WriteLine("Enter the New Address");
                                string _sadd1 = Console.ReadLine();
                                Console.WriteLine("Enter the New Class");
                                string _scls1 = Console.ReadLine();
                                SqlCommand cmd3 = new SqlCommand();
                                cmd3.CommandType = CommandType.Text;
                                cmd3.Connection = con;
                                cmd3.CommandText = "update Student set Name=@sname1, Address=@sadd1, Class=@scls1 where StudentID=@Studid";
                                cmd3.Parameters.AddWithValue("@Studid", _Studid);
                                cmd3.Parameters.AddWithValue("@sname1", _sname1);
                                cmd3.Parameters.AddWithValue("@sadd1", _sadd1);
                                cmd3.Parameters.AddWithValue("@scls1", _scls1);
                                int _rows1 = cmd3.ExecuteNonQuery();
                                if (_rows1 > 0)
                                {
                                    Console.WriteLine("Updated Succesfully");
                                }
                                else
                                {
                                    Console.WriteLine("Fail to Update");
                                }

                                break;

                            case 3:
                                Console.WriteLine("Enter Student ID to Delete: ");
                                int _Studid1 = int.Parse(Console.ReadLine());
                                SqlCommand cmd4 = new SqlCommand();
                                cmd4.CommandType = CommandType.Text;
                                cmd4.Connection = con;
                                cmd4.CommandText = "delete from Student where StudentID=@Studid1";
                                cmd4.Parameters.AddWithValue("@Studid1", _Studid1);
                                try
                                {
                                    int _rows2 = cmd4.ExecuteNonQuery();
                                    if (_rows2 > 0)
                                    {
                                        Console.WriteLine("Deleted Succesfully");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Fail to Delete");
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine("The DELETE statement conflicted with the REFERENCE constraint ");
                                }


                                break;


                            case 4:
                                SqlCommand cmd = new SqlCommand("select * from Student;", con);
                                SqlDataReader dr = cmd.ExecuteReader();
                                Console.WriteLine("Student Table");
                                Console.WriteLine("----------------------------------------------------------------------------------------------------");
                                Console.WriteLine("StudentID\tName\tAddress\tClass");
                                Console.WriteLine("----------------------------------------------------------------------------------------------------");

                                while (dr.Read())
                                {
                                    string id = dr["StudentID"].ToString();
                                    string name = dr["Name"].ToString();
                                    string Addr = dr["Address"].ToString();
                                    string cls = dr["Class"].ToString();

                                    Console.WriteLine(id + "\t\t" + name + "\t" + Addr + "\t" + cls);
                                    Console.WriteLine("----------------------------------------------------------------------------------------------------");

                                }
                                dr.Close();
                                break;
                            case 5:

                                Console.WriteLine("Enter StudentID to Search...");
                                int _idnum = int.Parse(Console.ReadLine());
                                SqlCommand cmd9 = new SqlCommand("select * from Student where StudentID=@idnum;", con);
                                cmd9.Parameters.AddWithValue("@idnum", _idnum);
                                SqlDataReader dr3 = cmd9.ExecuteReader();

                                if (dr3.Read() == false)
                                {

                                    Console.WriteLine("Student ID Does not Exist...!");
                                  
                                   

                                }

                                else
                                {
                                    dr3.Close();
                                    SqlDataReader dr4 = cmd9.ExecuteReader();

                                    Console.WriteLine("Student Table");
                                    Console.WriteLine("----------------------------------------------------------------------------------------------------");
                                    Console.WriteLine("StudentID\tName\tAddress\tClass");
                                    Console.WriteLine("----------------------------------------------------------------------------------------------------");
                                    while (dr4.Read())
                                    {
                                        string id = dr4["StudentID"].ToString();
                                        string name = dr4["Name"].ToString();
                                        string Addr = dr4["Address"].ToString();
                                        string cls = dr4["Class"].ToString();

                                        Console.WriteLine(id + "\t\t" + name + "\t" + Addr + "\t" + cls);
                                        Console.WriteLine("----------------------------------------------------------------------------------------------------");

                                    }
                                    dr4.Close();





                                }
                                
                               
                              
                                break;




                        }

                        break;

                    case 2:
                        Console.WriteLine("Enter your Choice\n1. Add\t 2. Update\t3. Delete\t4. Display\t5. Search Subject by ID");

                        int ch2 = int.Parse(Console.ReadLine());
                        switch (ch2)
                        {
                            case 1:
                                Console.WriteLine("Enter the Student ID");
                                int _sid = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter the Subject Name");
                                string _subName = Console.ReadLine();
                                Console.WriteLine("Enter the Marks Obtaines. Note Maximum Marks is 100.!!!!");
                                string _marksObt = Console.ReadLine();
                                SqlCommand cmd5 = new SqlCommand();
                                cmd5.CommandType = CommandType.Text;
                                cmd5.Connection = con;
                                cmd5.CommandText = "insert into Subjects(StudentID,SubjectName,Marks_obtained) values(@sid,@subName,@marksObt)";
                                cmd5.Parameters.AddWithValue("@sid", _sid);
                                cmd5.Parameters.AddWithValue("@subName", _subName);
                                cmd5.Parameters.AddWithValue("@marksObt", _marksObt);
                                int _rows3 = cmd5.ExecuteNonQuery();
                                if (_rows3 > 0)
                                {
                                    Console.WriteLine("Inserted Succesfully");
                                }
                                else
                                {
                                    Console.WriteLine("Fail to insert");
                                }

                                break;

                            case 2:
                                Console.WriteLine("Enter Subject ID to update:");
                                int _subId = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter the new Student ID");
                                int _sid1 = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter the new Subject Name");
                                string _subName1 = Console.ReadLine();
                                Console.WriteLine("Enter the new Marks Obtaines. Note Maximum Marks is 100.!!!!");
                                string _marksObt1 = Console.ReadLine();
                                SqlCommand cmd6 = new SqlCommand();
                                cmd6.CommandType = CommandType.Text;
                                cmd6.Connection = con;
                                cmd6.CommandText = "update Subjects set StudentID=@sid1, SubjectName=@subName1, Marks_obtained=@marksObt1 where SubjectID=@subId";
                                cmd6.Parameters.AddWithValue("@subId", _subId);
                                cmd6.Parameters.AddWithValue("@sid1", _sid1);
                                cmd6.Parameters.AddWithValue("@subName1", _subName1);
                                cmd6.Parameters.AddWithValue("@marksObt1", _marksObt1);
                                int _rows4 = cmd6.ExecuteNonQuery();
                                if (_rows4 > 0)
                                {
                                    Console.WriteLine("Updated Succesfully");
                                }
                                else
                                {
                                    Console.WriteLine("Fail to Update");
                                }

                                break;

                            case 3:
                                Console.WriteLine("Enter Subject ID to Delete: ");
                                int _subId2 = int.Parse(Console.ReadLine());
                                SqlCommand cmd7 = new SqlCommand();
                                cmd7.CommandType = CommandType.Text;
                                cmd7.Connection = con;
                                cmd7.CommandText = "delete from Subjects where SubjectID=@subId2";
                                cmd7.Parameters.AddWithValue("@subId2", _subId2);
                                try
                                {
                                    int _rows5 = cmd7.ExecuteNonQuery();
                                    if (_rows5 > 0)
                                    {
                                        Console.WriteLine("Deleted Succesfully");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Fail to Delete");
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine("The DELETE statement conflicted with the REFERENCE constraint ");
                                }


                                break;


                            case 4:
                                SqlCommand cmd1 = new SqlCommand("select * from Subjects;", con);
                                SqlDataReader dr1 = cmd1.ExecuteReader();
                                Console.WriteLine("\n\nSubjects Detail Table");
                                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("SubjectID\tStudentID\tSubject Name\tMarks Obtained\tMaximum Marks ");
                                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------");

                                while (dr1.Read())
                                {
                                    string id = dr1["SubjectID"].ToString();
                                    string StudID = dr1["StudentID"].ToString();
                                    string Subject_Name = dr1["SubjectName"].ToString();
                                    string Marks_Obtained = dr1["Marks_Obtained"].ToString();
                                    string Maximum_Marks = dr1["Maximum_Marks"].ToString();

                                    Console.WriteLine(id + "\t\t" + StudID + "\t\t" + Subject_Name + "\t\t" + Marks_Obtained + "\t\t" + Maximum_Marks);
                                    Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------");

                                }
                                dr1.Close();

                                break;

                            case 5:
                                Console.WriteLine("Enter Subject ID to Search...");
                                int _idnum1 = int.Parse(Console.ReadLine());
                                SqlCommand cmd10 = new SqlCommand("select * from Subjects where SubjectID=@idnum1;", con);
                                cmd10.Parameters.AddWithValue("@idnum1", _idnum1);
                                SqlDataReader dr4 = cmd10.ExecuteReader();
                                if(dr4.Read()==false)
                                {
                                    Console.WriteLine("Subject ID Does not Exist..!");
                                }
                                else
                                {
                                    dr4.Close();
                                    SqlDataReader dr5 = cmd10.ExecuteReader();
                                    Console.WriteLine("\n\nSubjects Detail Table");
                                    Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------");
                                    Console.WriteLine("SubjectID\tStudentID\tSubject Name\tMarks Obtained\tMaximum Marks ");
                                    Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------");

                                    while (dr5.Read())
                                    {
                                        string id = dr5["SubjectID"].ToString();
                                        string StudID = dr5["StudentID"].ToString();
                                        string Subject_Name = dr5["SubjectName"].ToString();
                                        string Marks_Obtained = dr5["Marks_Obtained"].ToString();
                                        string Maximum_Marks = dr5["Maximum_Marks"].ToString();

                                        Console.WriteLine(id + "\t\t" + StudID + "\t\t" + Subject_Name + "\t\t" + Marks_Obtained + "\t\t" + Maximum_Marks);
                                        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------");

                                    }
                                    dr5.Close();
                                }
                                
                               
                                break;
                                con.Close();
                                Console.Read();

                        }
                        break;

                    case 3:
                        SqlCommand cmd8 = new SqlCommand("select * from All_Student_Data;", con);
                        SqlDataReader dr2 = cmd8.ExecuteReader();
                        Console.WriteLine("\n\nAll Student Data");
                        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine("StudentID\tName\t\tAddress\t\tClass\tSubjectID\tSubjectName\tMarks Obtained\tMaximum Marks ");
                        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------");

                        while (dr2.Read())
                        {
                            string StudentID = dr2["StudentID"].ToString();
                            string Name = dr2["Name"].ToString();
                            string Address = dr2["Address"].ToString();
                            string Class = dr2["Class"].ToString();
                            string SubjectID = dr2["SubjectID"].ToString();
                            string SubjectName = dr2["SubjectName"].ToString();
                            string Marks_Obtained = dr2["Marks_Obtained"].ToString();
                            string Maximum_Marks = dr2["Maximum_marks"].ToString();

                            Console.WriteLine(StudentID + "\t\t" + Name + "\t\t" + Address + "\t\t" + Class + "\t" + SubjectID + "\t\t" + SubjectName + "\t\t" + Marks_Obtained + "\t\t" + Maximum_Marks);
                            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------");

                        }
                        dr2.Close();

                        break;
                    case 4:

                        temp = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                        con.Close();
                        Console.Read();
                }

            }





        }
    }
}
