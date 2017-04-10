using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pocACIAF
{
    public partial class pocACIAFagent : Form
    {
        public pocACIAFagent()
        {
            InitializeComponent();
        }

        private void launchAsACIAFagent_Click(object sender, EventArgs e)
        {
            //launchAsACIAFagent
            //http://localhost/Addition/Addition.svc?wsdl

            string uriLink = "http://" + "localhost" + "/Addition/Addition.svc";
            System.Uri uri = new Uri(uriLink);
            WebServiceInvoker wsInv = new WebServiceInvoker(uri);

            List<string> mthdList = new List<string>();
            mthdList = wsInv.EnumerateServiceMethods("AdditionClient");

            for (int i = 0; i < mthdList.Count; i++)
            {
                Console.WriteLine(mthdList[i]);
            }

            //FArg1
            //FArg2
            //FRsltArg
            //FRsltArg
            //StrArg1 
            //StrArg2 
            //StrConcatRslt

            dynamic cmplxTyp_op = new object();
            //AdditionService.MathData[] cmplxTyp_op;
            //AdditionService.MathData [] cmplxTyp_ip = new AdditionService.MathData [4];
            //cmplxTyp_ip[0] = new AdditionService.MathData();
            //cmplxTyp_ip[1] = new AdditionService.MathData();
            //cmplxTyp_ip[2] = new AdditionService.MathData();
            //cmplxTyp_ip[3] = new AdditionService.MathData();

            var cmplxTyp_ip = new Addition.MathData[4];
            cmplxTyp_ip[0] = new Addition.MathData();
            cmplxTyp_ip[1] = new Addition.MathData();
            cmplxTyp_ip[2] = new Addition.MathData();
            cmplxTyp_ip[3] = new Addition.MathData();

            cmplxTyp_ip[0].FArg1 = 10;
            cmplxTyp_ip[0].FArg2 = 11;

            cmplxTyp_ip[1].FArg1 = 210;
            cmplxTyp_ip[1].FArg2 = 211;
            cmplxTyp_ip[2].FArg1 = 310;
            cmplxTyp_ip[2].FArg2 = 311;
            cmplxTyp_ip[3].FArg1 = 410;
            cmplxTyp_ip[3].FArg2 = 411;

            //AdditionService.AdditionClient client = new AdditionService.AdditionClient();
            //AdditionService.AddUDRequest rq= 
            //client.AddUD();

            cmplxTyp_op = wsInv.InvokeMethod<dynamic>("AdditionClient", "GetData", new object[] { 32 }); //cmplxTyp_ip);

            var cmplxTyp_op1 = new object();
            cmplxTyp_op1 = wsInv.InvokeMethod<dynamic>("AdditionClient", "GetDataUsingDataContract1", new object[] { "venkat--" });

            var ip = new Addition.CompositeType
            {
                BoolValue = true,
                StringValue = "venkat--"
            };

            //Addition.CompositeType cmplxTyp_op2 = new Addition.CompositeType();
            var cmplxTyp_op3 = wsInv.InvokeMethod<Addition.CompositeType>("AdditionClient", "GetDataUsingDataContract", 
                ip
                );

            //Console.WriteLine("op is    "+ cmplxTyp_op);

            //      Console.WriteLine("arg1   " + Convert.ToString(cmplxTyp_op[0].FArg1));
            //      Console.WriteLine("arg2   " + Convert.ToString(cmplxTyp_op[0].FArg2));
            //      Console.WriteLine("summed arg2   " + Convert.ToString(cmplxTyp_op[0].FRsltArg));


        }  // end of launchAsACIAFagent_Click(object sender, EventArgs e)
    }
}

