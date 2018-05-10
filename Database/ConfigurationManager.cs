using System;
using System.Windows.Forms;

namespace Database
{
    public static class ConfigurationManager
    {
        public static string ConnectionString = $@"Data Source=(localdb)\MSSQLLocalDB;
                                                Initial Catalog=VacationDecision;
                                                Integrated Security=True;
                                                Connect Timeout=30;
                                                Encrypt=False;
                                                TrustServerCertificate=False;
                                                ApplicationIntent=ReadWrite;
                                                MultiSubnetFailover=False";
             //AttachDbFilename={Application.StartupPath}\VacationDecision.mdf;
    }
}
