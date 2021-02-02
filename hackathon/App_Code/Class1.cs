//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Data;
//using System.Data.SqlClient;
//using System.Configuration;
//using System.Drawing;
//using System.IO;

//namespace hackathon
//{

//    public interface emergency
//    {
//        int id { get; set; }
//        string name { get; set; }
//        string email { get; set; }
//        float lat { get; set; }
//        float longt { get; set; }
//        string desc { get; set; }
//        string address { get; set; }
//        long mobile { get; set; }
//        Image image { get; set; }
//    }
//    public class prpemergency : emergency
//    {
//        private int pid;
//        private long pmobile;
//        private float plat,plongt;
//        private string pname, pemail, pdesc,paddress;
//        private Image pimage;

//        public int id
//        {
//            get
//            {
//                return pid;
//            }
//            set
//            {
//                pid = value;
//            }
//        }
//        public string desc
//        {
//            get
//            {
//                return pdesc;
//            }
//            set
//            {
//                pdesc = value;
//            }
//        }
//        public string address
//        {
//            get
//            {
//                return paddress;
//            }
//            set
//            {
//                paddress = value;
//            }
//        }
//        public float lat
//        {
//            get
//            {
//                return plat;
//            }
//            set
//            {
//                plat = value;
//            }
//        }
//        public float longt
//        {
//            get
//            {
//                return plongt;
//            }
//            set
//            {
//                plongt = value;
//            }
//        }
//        public string name
//        {
//            get
//            {
//                return pname;
//            }
//            set
//            {
//                pname = value;
//            }
//        }
//        public string email
//        {
//            get
//            {
//                return pemail;
//            }
//            set
//            {
//                pemail = value;
//            }
//        }
//        public long mobile
//        {
//            get
//            {
//                return pmobile;
//            }
//            set
//            {
//                pmobile = value;
//            }
//        }
//        public Image image
//        {
//            get
//            {
//                return pimage;
//            }
//            set
//            {
//                pimage = value;
//            }
//        }
        
//    }


//    public abstract class clscon
//    {
//        protected SqlConnection con = new SqlConnection();
//        public clscon()
//        {
//            con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
//        }
//    }

//    public class mainemergency : clscon
//    {
//        public List<prpemergency> Disp_Rec()
//        {
//            if (con.State == ConnectionState.Closed)
//            {
//                con.Open();
//            }
//            SqlCommand cmd = new SqlCommand("select * from emergency", con);
//            cmd.CommandType = CommandType.Text;
//            SqlDataReader dr = cmd.ExecuteReader();
//            List<prpemergency> obj1 = new List<prpemergency>();
//            while (dr.Read())
//            {
//                prpemergency k = new prpemergency();
//                k.id = Convert.ToInt32(dr[0]);
//                k.name = dr[1].ToString();
//                k.email= dr[2].ToString();
//                k.mobile = Convert.ToInt64(dr[3]);
//                MemoryStream ms = new MemoryStream(Convert.ToString(dr[4]));
//                k.image = System.Drawing.Image.FromStream(ms); 
//                k.lat = Convert.ToSingle(dr[5]);
//                k.longt = Convert.ToSingle(dr[6]);
//                k.desc = dr[7].ToString();
//                k.address = dr[8].ToString();

//                obj1.Add(k);
//            }

//            dr.Close();
//            cmd.Dispose();
//            con.Close();
//            return obj1;

//        }

//    }

//}
