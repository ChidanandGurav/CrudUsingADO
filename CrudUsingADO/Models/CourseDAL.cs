using System.Data.SqlClient;
using System.Security.Cryptography;

namespace CrudUsingADO.Models
{
    public class CourseDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public CourseDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConection"));
        }


        public List<Course> GetCourses()
        {
            List<Course> courses = new List<Course>();
            string qry = "select * from Course";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Course cours = new Course();
                    cours.Cid = Convert.ToInt32(dr["cid"]);
                    cours.CName = dr["cname"].ToString();
                    cours.Fees = Convert.ToInt32(dr["fees"]);
                    cours.Duration = dr["duration"].ToString();


                    courses.Add(cours);
                }
            }
            con.Close();
            return courses;
        }
        public Course GetCourseById(int id)
        {
            Course course = new Course();
            string qry = "select * from Course where cid=@cid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@cid", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    course.Cid = Convert.ToInt32(dr["cid"]);
                    course.CName = dr["cname"].ToString();
                    course.Fees = Convert.ToInt32(dr["fees"]);
                    course.Duration = dr["duration"].ToString();


                }
            }
            con.Close();
            return course;
        }
        public int AddCourse(Course course)
        {
            int result = 0;
            string qry = "insert into Course values(@cname,@fees,@duration)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@cname", course.CName);
            cmd.Parameters.AddWithValue("@fees", course.Fees);
            cmd.Parameters.AddWithValue("@duration", course.Duration);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateCourse(Course course)
        {
            int result = 0;
            string qry = "update Course set cname=@cname,fees=@fees,duration=@duration where cid=@cid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@cname", course.CName);
            cmd.Parameters.AddWithValue("@fees", course.Fees);
            cmd.Parameters.AddWithValue("@duration", course.Duration);
            cmd.Parameters.AddWithValue("@cid", course.Cid);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteCourse(int id)
        {
            int result = 0;
            string qry = "delete from Course where cid=@cid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@cid", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;


        }
    }
}

