using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;

namespace TimeOfficeTestSystem
{
    public partial class Form1 : Form
    {
        private Config Cfg;

        public Form1()
        {
            InitializeComponent();
            Cfg = new Config();

        }

        private  void runTest()
        {
            for (int i = 0; i < 50; i++)
            {
                //Console.WriteLine(i);
                Invoke((MethodInvoker)delegate
                {
                    Log(i.ToString());
                });


            }
            
        }

        private void startSQL(Config Cfg)
        {

            SqlConnection cnn = new SqlConnection(Cfg.connectionstring);
       
            Invoke((MethodInvoker)delegate { Log("Verbinde " + cnn.ConnectionString); });
            try
            {
                cnn.Open();
            }
            catch (Exception ex)
            {
                
                Invoke((MethodInvoker)delegate { Log("Fehler: " + ex.Message); });
            }

            if(cnn.State == ConnectionState.Open)
            {
                bool gotError = false;

                Invoke((MethodInvoker)delegate { btnRefreshTestsystem.Text += System.Environment.NewLine + "Gestartet, bitte warten... (3 Minuten Timeout)"; });
                foreach (string cmd in Cfg.sqlcmdList)
                {
                    Loginvoke(cmd);

                    
                    try {
                        SqlCommand command = new SqlCommand(cmd, cnn);
                        command.CommandTimeout = 180;
                        using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                          /*  for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Log(String.Format("{0}", reader[i]));
                            }
                          */
                        }
                        if(reader.RecordsAffected <= -1)
                            {
                                Loginvoke("-----> Abgeschlossen... ");
                            }
                            else
                            {
                                Loginvoke("-----> Abgeschlossen - Einträge aktualisiert: " + reader.RecordsAffected);
                            }
                            
                    }

                   



                }
                catch (SqlException sqlerr)
                {
                        Loginvoke("-----> Fehler: " + sqlerr.Message);
                        gotError =true;
                }
                catch (Exception ex)
                {
                        Loginvoke("-----> Fehler: " + ex.Message);
                        gotError = true;
                }

                if (gotError) {
                        break;
                    }

            }
                cnn.Close();
            }
            
            Loginvoke("------------------------------------------------------------------------------------------");
            Loginvoke("Beendet ");
            Invoke((MethodInvoker)delegate { btnRefreshTestsystem.Text = "Timeoffice Testsystem refresh"; });
        }


        private void Loginvoke(String str)
        {
            Invoke((MethodInvoker)delegate
            {
                Log(str);
            });
        }

        private void btnTest_Click(object sender, EventArgs e)
        {

           // SqlConnection cnn = new SqlConnection(Cfg.connectionstring);
            // - jetzt in config connetionString = @"Data Source=" + Cfg.server + ";Integrated Security=sspi;";

            //Thread runThread = new Thread(new ThreadStart(runTest));
            //runThread.Start();

            Log("starting");

            // Test Thread methode
            Thread some_thread = new Thread(delegate () { runTest(); });
            //some_thread.Start();

            Thread sqlThread = new Thread(delegate () { startSQL(Cfg); });
            sqlThread.Start();



            //runSqlCommands(cnn);



            /*

            SqlCommand command = new SqlCommand(this.tbSQLString.Text, cnn);

            try
            {
                cnn.Open();
                //MessageBox.Show("Connection Open  !");
                Log("Connection openend");
              

                // ----------------------

                
                //command.Parameters.AddWithValue("@zip", "india");
                // int result = command.ExecuteNonQuery();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        for (int i=0; i < reader.FieldCount; i++)
                        {
                            Log(String.Format("{0}", reader[i]));
                        }

                    }
                    Log("finished: " + reader.RecordsAffected);
                }
                
                cnn.Close();



            }
            catch (SqlException sqlerr)
            {
                Log("Fehler: " + sqlerr.Message);
            }
            catch (Exception ex)
            {
                Log("Fehler: " + ex.Message);
                //MessageBox.Show("Fehler...: "+ ex.Message);
               // throw;
            }

            */
        }

       

        private void runSqlCommands(SqlConnection cnn)
        {

            
            try
            {
              
                cnn.Open();
                Log("Verbindung hergestellt..." );
            }
            catch (Exception ex)
            {
                Log("Fehler: " + ex.Message);
             
            }



            if(cnn.State == ConnectionState.Open)
            {
                cnn.Close();
                Log("Verbindung geschlossen...");
                
            }else
            {
                
            }

        }

        private  void Log(String _text)
        {
            //tbResult.Text += Environment.NewLine + _text;
            tbResult.AppendText(Environment.NewLine + _text);
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            tbResult.Text = "";
        }

        private void btnStartTestsystem_Click(object sender, EventArgs e)
        {
            try
            {
                Log("Starte Testsystem: " + Cfg.timeofficeTestsystemStartExe + " " + Cfg.timeofficeTestsystemStartArguments);

                var startInfo = new ProcessStartInfo();
                //string exeFile = @Cfg.timeofficeTestsystemStartExe;
                string  exePath = @Cfg.timeofficeTestsystemStartExe;
                startInfo.FileName = exePath;
                startInfo.WorkingDirectory =  Path.GetDirectoryName(startInfo.FileName);
                Log("Dir: " + startInfo.WorkingDirectory);
                startInfo.Arguments = Cfg.timeofficeTestsystemStartArguments;
                startInfo.UseShellExecute = true;
                Process.Start(startInfo);
                
                //Thread.Sleep(3000);
                //Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Log("Fehler beim Starten des Testsystems: " + ex.Message);
            }
            
        }
    }
}

