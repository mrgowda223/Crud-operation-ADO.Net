using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CURD
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        SqlCommand comm;
        SqlDataReader dreader;

        DataSet dset;
        SqlDataAdapter dadapter;

        string connstring = "Data Source=AXDESK53\\SQLEXPRESS;Initial Catalog = Student; User ID = sa; Password=Axcend123";  

        

        //SqlConnection conn = new SqlConnection(@"Data Source=AXDESK53\\SQLEXPRESS;Initial Catalog=Student;User ID=sa;Password=Axcend123");


        //private string connstring;
        //SqlConnection conn = new SqlConnection();
        //conn.ConnectionString = ConfigurationSettings.AppSettings["databasepath"];

        //conn.Open();

        public Form1()
        {
            InitializeComponent();
        }

       


        private void btnsave_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            comm = new SqlCommand("insert into student_detail1 values(" + txtrn.Text + ",'" + txtname.Text + "'," + txtage.Text + ",'" + txtcourse.Text + "')", conn);
            try
            {
                comm.ExecuteNonQuery();
                MessageBox.Show("Saved...");
            }
            catch (Exception)
            {
                MessageBox.Show("Not Saved");
            }
            finally
            {
                conn.Close();
            }

           
            {
                dadapter = new SqlDataAdapter("select * from student_detail1", connstring);
                dset = new System.Data.DataSet();
                dadapter.Fill(dset);
                dataGridView1.DataSource = dset.Tables[0].DefaultView;
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            {
                txtage.Clear();
                txtcourse.Clear();
                txtname.Clear();
                txtrn.Clear();
                txtrn.Focus();
            }

            //{
            //    dadapter = new SqlDataAdapter("select * from student_detail1", connstring);
            //    dset = new System.Data.DataSet();
            //    dadapter.Fill(dset);
            //    dataGridView1.DataSource = dset.Tables[0].DefaultView;
            //}
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            {
                conn = new SqlConnection(connstring);
                conn.Open();
                comm = new SqlCommand("delete from student_detail1 where roll_no = " + txtrn.Text + " ", conn);
                try
                {
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Deleted...");
                    txtage.Clear();
                    txtcourse.Clear();
                    txtname.Clear();
                    txtrn.Clear();
                    txtrn.Focus();
                }
                catch (Exception x)
                {
                    MessageBox.Show(" Not Deleted" + x.Message);
                }
                finally
                {
                    conn.Close();
                }

                {
                    dadapter = new SqlDataAdapter("select * from student_detail1", connstring);
                    dset = new System.Data.DataSet();
                    dadapter.Fill(dset);
                    dataGridView1.DataSource = dset.Tables[0].DefaultView;
                }
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            {
                conn = new SqlConnection(connstring);
                conn.Open();
                comm = new SqlCommand("select * from student_detail1 where roll_no = " + txtrn.Text + " ", conn);
                try
                {
                    dreader = comm.ExecuteReader();
                    if (dreader.Read())
                    {
                        txtname.Text = dreader[1].ToString();
                        txtage.Text = dreader[2].ToString();
                        txtcourse.Text = dreader[3].ToString();
                    }
                    else
                    {
                        MessageBox.Show(" No Record");
                    }
                    dreader.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show(" No Record");
                }
                finally
                {
                    conn.Close();
                }

                {
                    dadapter = new SqlDataAdapter("select * from student_detail1", connstring);
                    dset = new System.Data.DataSet();
                    dadapter.Fill(dset);
                    dataGridView1.DataSource = dset.Tables[0].DefaultView;
                }
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            {
                conn = new SqlConnection(connstring);
                conn.Open();
                comm = new SqlCommand("update student_detail1 set s_name= '" + txtname.Text + "', age= " + txtage.Text + " , course=' " + txtcourse.Text + "' where roll_no = "+txtrn.Text+" ", conn);       


               
            try
                {
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Updated..");
                }
                catch (Exception)
                {
                    MessageBox.Show(" Not Updated");
                }
                finally
                {
                    conn.Close();
                }

                {
                    dadapter = new SqlDataAdapter("select * from student_detail1", connstring);
                    dset = new System.Data.DataSet();
                    dadapter.Fill(dset);
                    dataGridView1.DataSource = dset.Tables[0].DefaultView;
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'studentDataSet.student_detail1' table. You can move, or remove it, as needed.
            this.student_detail1TableAdapter.Fill(this.studentDataSet.student_detail1);
            txtrn.Focus();

          
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtrn.Text = row.Cells[0].Value.ToString();
                txtname.Text = row.Cells[1].Value.ToString();
                txtage.Text = row.Cells[2].Value.ToString();
                txtcourse.Text = row.Cells[3].Value.ToString();
            }
        }







        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtrn_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
