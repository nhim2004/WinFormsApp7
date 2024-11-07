using System.Data.SqlClient;

namespace WinFormsApp7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            string connectionString = "Server=DESKTOP-OVN06OJ\\MSSQLSERVER02;Database=SimThe;Trusted_Connection=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT Sim.ID, Sim.SoSim, Mang.TenMang, Sim.NgayKichHoat, Sim.NgayHetHan FROM Sim JOIN Mang ON Sim.MangID = Mang.ID ORDER BY Sim.NgayKichHoat ASC", conn);
                    SqlDataReader reader = cmd.ExecuteReader();


                    dataGridView1.Rows.Clear();

                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(
                            reader["ID"],       
                            reader["SoSim"],    
                            reader["TenMang"],   
                            reader["NgayKichHoat"], 
                            reader["NgayHetHan"]  
                        );
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kết nối CSDL: " + ex.Message);
                }
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
