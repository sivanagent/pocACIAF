using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.Text;
using System.Web.Services.Description;
using System.Xml;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Runtime.Serialization;

namespace pocACIAF
{
    public partial class pocMATHTUTOR_ACIAF_agent : Form
    {
        public pocMATHTUTOR_ACIAF_agent()
        {
            InitializeComponent();
        }
        
        private void calculateAddition(Uri additionServiceURI , Addition.MathData[] cmplxTyp_ip)
        {
            try
            {
                Uri mexAddress = additionServiceURI; 
                MetadataExchangeClientMode mexMode = MetadataExchangeClientMode.HttpGet;
                string contractName = "IAddition";
                string operationName = "GetDataUsingDataContract";
                string operationName1 = "AddArray";

                Addition.CompositeType ip = new Addition.CompositeType
                {
                    BoolValue = true,
                    StringValue = "---test string--"
                };

                object[] operationParameters = new object[] { ip };
                object[] operationParameters1 = new object[] { cmplxTyp_ip };

                MetadataExchangeClient mexClient = new MetadataExchangeClient(mexAddress, mexMode);
                mexClient.ResolveMetadataReferences = true;
                MetadataSet metaSet = mexClient.GetMetadata();

                WsdlImporter importer = new WsdlImporter(metaSet);
                //BEGIN INSERT
                XsdDataContractImporter xsd = new XsdDataContractImporter();
                xsd.Options = new ImportOptions();
                xsd.Options.ImportXmlType = true;
                xsd.Options.GenerateSerializable = true;
                //xsd.Options.ReferencedTypes.Add(typeof(KeyValuePair<string, string>));
                //xsd.Options.ReferencedTypes.Add(typeof(System.Collections.Generic.List<KeyValuePair<string, string>>));

                xsd.Options.ReferencedTypes.Add(typeof(Addition.CompositeType));
                xsd.Options.ReferencedTypes.Add(typeof(Addition.MathData));
                xsd.Options.ReferencedTypes.Add(typeof(System.Collections.Generic.List<Addition.MathData>));


                importer.State.Add(typeof(XsdDataContractImporter), xsd);
                //END INSERT


                Collection<ContractDescription> contracts = importer.ImportAllContracts();
                ServiceEndpointCollection allEndpoints = importer.ImportAllEndpoints();

                ServiceContractGenerator generator = new ServiceContractGenerator();
                var endpointsForContracts = new Dictionary<string, IEnumerable<ServiceEndpoint>>();

                foreach (ContractDescription contract in contracts)
                {
                    generator.GenerateServiceContractType(contract);
                    endpointsForContracts[contract.Name] = allEndpoints.Where(
                        se => se.Contract.Name == contract.Name).ToList();
                }

                if (generator.Errors.Count != 0)
                    throw new Exception("There were errors during code compilation.");

                CodeGeneratorOptions options = new CodeGeneratorOptions();
                options.BracingStyle = "C";
                CodeDomProvider codeDomProvider = CodeDomProvider.CreateProvider("C#");

                CompilerParameters compilerParameters = new CompilerParameters(
                    new string[] {
                "System.dll", "System.ServiceModel.dll",
                "System.Runtime.Serialization.dll" });
                compilerParameters.GenerateInMemory = true;

                CompilerResults results = codeDomProvider.CompileAssemblyFromDom(
                    compilerParameters, generator.TargetCompileUnit);

                if (results.Errors.Count > 0)
                {
                    throw new Exception("There were errors during generated code compilation");
                }
                else
                {
                    Type clientProxyType = results.CompiledAssembly.GetTypes().First(
                        t => t.IsClass &&
                            t.GetInterface(contractName) != null &&
                            t.GetInterface(typeof(ICommunicationObject).Name) != null);

                    ServiceEndpoint se = endpointsForContracts[contractName].First();

                    object instance = results.CompiledAssembly.CreateInstance(
                        clientProxyType.Name,
                        false,
                        System.Reflection.BindingFlags.CreateInstance,
                        null,
                        new object[] { se.Binding, se.Address },
                        CultureInfo.CurrentCulture, null);


                    var methodInfo = instance.GetType().GetMethod(operationName);
                    var methodInfo1 = instance.GetType().GetMethod(operationName1);

                    object retVal = methodInfo.Invoke(instance, BindingFlags.InvokeMethod, null, operationParameters, null);
                    dynamic retVal1 = methodInfo1.Invoke(instance, BindingFlags.InvokeMethod, null, operationParameters1, null);
                    Console.WriteLine(retVal.ToString());

                    for (int x = 0; x < cmplxTyp_ip.Length; x++)
                    {
                        Console.WriteLine(" --addition output RECORD {0 } ----", x);
                        Console.WriteLine(" FArg1+farg2 : {0 } ", retVal1[x].FRsltArg);
                        Console.WriteLine(" strFArg1+arg2 : {0 }", retVal1[x].StrConcatRslt);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            } //end of mex binding try block


        }//end addtion function


        private void calculateSubtraction(Uri subtractServiceURI, SubtractionService.MathData[] cmplxTyp_ip)
        {
            try
            {
                Uri mexAddress = subtractServiceURI;
                MetadataExchangeClientMode mexMode = MetadataExchangeClientMode.HttpGet;
                string contractName = "ISubtraction";
                string operationName1 = "SubtractArray";

                object[] operationParameters1 = new object[] { cmplxTyp_ip };

                MetadataExchangeClient mexClient = new MetadataExchangeClient(mexAddress, mexMode);
                mexClient.ResolveMetadataReferences = true;
                MetadataSet metaSet = mexClient.GetMetadata();

                WsdlImporter importer = new WsdlImporter(metaSet);
                //BEGIN INSERT
                XsdDataContractImporter xsd = new XsdDataContractImporter();
                xsd.Options = new ImportOptions();
                xsd.Options.ImportXmlType = true;
                xsd.Options.GenerateSerializable = true;
                //xsd.Options.ReferencedTypes.Add(typeof(KeyValuePair<string, string>));
                //xsd.Options.ReferencedTypes.Add(typeof(System.Collections.Generic.List<KeyValuePair<string, string>>));

                xsd.Options.ReferencedTypes.Add(typeof(SubtractionService.CompositeType));
                xsd.Options.ReferencedTypes.Add(typeof(SubtractionService.MathData));
                xsd.Options.ReferencedTypes.Add(typeof(System.Collections.Generic.List<SubtractionService.MathData>));


                importer.State.Add(typeof(XsdDataContractImporter), xsd);
                //END INSERT

                Collection<ContractDescription> contracts = importer.ImportAllContracts();
                ServiceEndpointCollection allEndpoints = importer.ImportAllEndpoints();

                ServiceContractGenerator generator = new ServiceContractGenerator();
                var endpointsForContracts = new Dictionary<string, IEnumerable<ServiceEndpoint>>();

                foreach (ContractDescription contract in contracts)
                {
                    generator.GenerateServiceContractType(contract);
                    endpointsForContracts[contract.Name] = allEndpoints.Where(
                        se => se.Contract.Name == contract.Name).ToList();
                }

                if (generator.Errors.Count != 0)
                    throw new Exception("There were errors during code compilation.");

                CodeGeneratorOptions options = new CodeGeneratorOptions();
                options.BracingStyle = "C";
                CodeDomProvider codeDomProvider = CodeDomProvider.CreateProvider("C#");

                CompilerParameters compilerParameters = new CompilerParameters(
                    new string[] {
                "System.dll", "System.ServiceModel.dll",
                "System.Runtime.Serialization.dll" });
                compilerParameters.GenerateInMemory = true;

                CompilerResults results = codeDomProvider.CompileAssemblyFromDom(
                    compilerParameters, generator.TargetCompileUnit);

                if (results.Errors.Count > 0)
                {
                    throw new Exception("There were errors during generated code compilation");
                }
                else
                {
                    Type clientProxyType = results.CompiledAssembly.GetTypes().First(
                        t => t.IsClass &&
                            t.GetInterface(contractName) != null &&
                            t.GetInterface(typeof(ICommunicationObject).Name) != null);

                    ServiceEndpoint se = endpointsForContracts[contractName].First();

                    object instance = results.CompiledAssembly.CreateInstance(
                        clientProxyType.Name,
                        false,
                        System.Reflection.BindingFlags.CreateInstance,
                        null,
                        new object[] { se.Binding, se.Address },
                        CultureInfo.CurrentCulture, null);

                    var methodInfo1 = instance.GetType().GetMethod(operationName1);

                    dynamic retVal1 = methodInfo1.Invoke(instance, BindingFlags.InvokeMethod, null, operationParameters1, null);

                    for (int x = 0; x < cmplxTyp_ip.Length; x++)
                    {
                        Console.WriteLine(" --Subtraction output RECORD {0 } ----", x);
                        Console.WriteLine(" FArg1 -farg2 : {0 } ", retVal1[x].FRsltArg);
                        Console.WriteLine(" strFArg1 - arg2 : {0 }", retVal1[x].StrConcatRslt);
                    }


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            } //end try block...
        }//end subtraction..

        private void calculateMultiplication(Uri multiplicationServiceURI, Multiplication.MathData[] cmplxTyp_ip)
        {
            try
            {
                Uri mexAddress = multiplicationServiceURI;
                MetadataExchangeClientMode mexMode = MetadataExchangeClientMode.HttpGet;
                string contractName = "IMultiplication";
                string operationName = "GetDataUsingDataContract";
                string operationName1 = "MultiplyArray";

                Multiplication.CompositeType ip = new Multiplication.CompositeType()
                {
                    BoolValue = true,
                    StringValue = "---test string--"
                };

                object[] operationParameters = new object[] { ip };
                object[] operationParameters1 = new object[] { cmplxTyp_ip };

                MetadataExchangeClient mexClient = new MetadataExchangeClient(mexAddress, mexMode);
                mexClient.ResolveMetadataReferences = true;
                MetadataSet metaSet = mexClient.GetMetadata();

                WsdlImporter importer = new WsdlImporter(metaSet);
                //BEGIN INSERT
                XsdDataContractImporter xsd = new XsdDataContractImporter();
                xsd.Options = new ImportOptions();
                xsd.Options.ImportXmlType = true;
                xsd.Options.GenerateSerializable = true;
                //xsd.Options.ReferencedTypes.Add(typeof(KeyValuePair<string, string>));
                //xsd.Options.ReferencedTypes.Add(typeof(System.Collections.Generic.List<KeyValuePair<string, string>>));

                xsd.Options.ReferencedTypes.Add(typeof(Multiplication.CompositeType));
                xsd.Options.ReferencedTypes.Add(typeof(Multiplication.MathData));
                xsd.Options.ReferencedTypes.Add(typeof(System.Collections.Generic.List<Multiplication.MathData>));


                importer.State.Add(typeof(XsdDataContractImporter), xsd);
                //END INSERT


                Collection<ContractDescription> contracts = importer.ImportAllContracts();
                ServiceEndpointCollection allEndpoints = importer.ImportAllEndpoints();

                ServiceContractGenerator generator = new ServiceContractGenerator();
                var endpointsForContracts = new Dictionary<string, IEnumerable<ServiceEndpoint>>();

                foreach (ContractDescription contract in contracts)
                {
                    generator.GenerateServiceContractType(contract);
                    endpointsForContracts[contract.Name] = allEndpoints.Where(
                        se => se.Contract.Name == contract.Name).ToList();
                }

                if (generator.Errors.Count != 0)
                    throw new Exception("There were errors during code compilation.");

                CodeGeneratorOptions options = new CodeGeneratorOptions();
                options.BracingStyle = "C";
                CodeDomProvider codeDomProvider = CodeDomProvider.CreateProvider("C#");

                CompilerParameters compilerParameters = new CompilerParameters(
                    new string[] {
                "System.dll", "System.ServiceModel.dll",
                "System.Runtime.Serialization.dll" });
                compilerParameters.GenerateInMemory = true;

                CompilerResults results = codeDomProvider.CompileAssemblyFromDom(
                    compilerParameters, generator.TargetCompileUnit);

                if (results.Errors.Count > 0)
                {
                    throw new Exception("There were errors during generated code compilation");
                }
                else
                {
                    Type clientProxyType = results.CompiledAssembly.GetTypes().First(
                        t => t.IsClass &&
                            t.GetInterface(contractName) != null &&
                            t.GetInterface(typeof(ICommunicationObject).Name) != null);

                    ServiceEndpoint se = endpointsForContracts[contractName].First();

                    object instance = results.CompiledAssembly.CreateInstance(
                        clientProxyType.Name,
                        false,
                        System.Reflection.BindingFlags.CreateInstance,
                        null,
                        new object[] { se.Binding, se.Address },
                        CultureInfo.CurrentCulture, null);


                    var methodInfo = instance.GetType().GetMethod(operationName);
                    var methodInfo1 = instance.GetType().GetMethod(operationName1);

                    object retVal = methodInfo.Invoke(instance, BindingFlags.InvokeMethod, null, operationParameters, null);
                    dynamic retVal1 = methodInfo1.Invoke(instance, BindingFlags.InvokeMethod, null, operationParameters1, null);
                    Console.WriteLine(retVal.ToString());

                    for (int x = 0; x < cmplxTyp_ip.Length; x++)
                    {
                        Console.WriteLine(" --Multiplication output RECORD {0 } ----", x);
                        Console.WriteLine(" FArg1 *farg2 : {0 } ", retVal1[x].FRsltArg);
                        Console.WriteLine(" strFArg1 * arg2 : {0 }", retVal1[x].StrConcatRslt);
                    }


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            } //end of mex binding try block

        } //end of MULTIPLICATION FUNCTION...

        private void readUserInputToAgent()
        {
            int loopCounter;
            Console.WriteLine("Give number of objects to send to server .... ");
            try
            {
                loopCounter = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Sending this -- {0} --many Objects ", loopCounter);
            }
            catch (Exception)
            {
                Console.WriteLine("user gave wrong number of objects to send to server");
                throw;
            }
            Addition.MathData[] cmplxTyp_ip_toAdditionService = new Addition.MathData[loopCounter];

            for (int x = 0; x < loopCounter; x++)
            {
                cmplxTyp_ip_toAdditionService[x] = (new Addition.MathData());
            }

            Console.WriteLine("****************START INPUT DATA: Addition service***************************");

            for (int x = 0; x < loopCounter; x++)
            {
                cmplxTyp_ip_toAdditionService[x].FArg1 = x * 2;
                cmplxTyp_ip_toAdditionService[x].FArg2 = x * 3;
                cmplxTyp_ip_toAdditionService[x].StrArg1 = "StrArg..1.." + Convert.ToString(cmplxTyp_ip_toAdditionService[x].FArg1);
                cmplxTyp_ip_toAdditionService[x].StrArg2 = "StrArg..2.." + Convert.ToString(cmplxTyp_ip_toAdditionService[x].FArg2);

                Console.WriteLine(" --RECORD {0 } ----", x);
                Console.WriteLine(" FArg1 : {0 }", cmplxTyp_ip_toAdditionService[x].FArg1);
                Console.WriteLine(" FArg2 : {0 }", cmplxTyp_ip_toAdditionService[x].FArg2);
                Console.WriteLine(" strFArg1 : {0 }", cmplxTyp_ip_toAdditionService[x].StrArg1);
                Console.WriteLine(" strFArg2 : {0 }", cmplxTyp_ip_toAdditionService[x].StrArg2);
            }

            Console.WriteLine("***************END INPUT DATA: Addition service***************************");

            SubtractionService.MathData[] cmplxTyp_ip_to_SUBTRACTIONservice = new SubtractionService.MathData[loopCounter];

            for (int x = 0; x < loopCounter; x++)
            {
                cmplxTyp_ip_to_SUBTRACTIONservice[x] = (new SubtractionService.MathData());
            }

            Console.WriteLine("****************START INPUT DATA*: SUBTRACTION --**************************");

            for (int x = 0; x < loopCounter; x++)
            {
                cmplxTyp_ip_to_SUBTRACTIONservice[x].FArg1 = x * 2;
                cmplxTyp_ip_to_SUBTRACTIONservice[x].FArg2 = x * 3;
                cmplxTyp_ip_to_SUBTRACTIONservice[x].StrArg1 = "StrArg..1.." + Convert.ToString(cmplxTyp_ip_to_SUBTRACTIONservice[x].FArg1);
                cmplxTyp_ip_to_SUBTRACTIONservice[x].StrArg2 = "StrArg..2.." + Convert.ToString(cmplxTyp_ip_to_SUBTRACTIONservice[x].FArg2);

                Console.WriteLine(" --RECORD {0 } ----", x);
                Console.WriteLine(" FArg1 : {0 }", cmplxTyp_ip_to_SUBTRACTIONservice[x].FArg1);
                Console.WriteLine(" FArg2 : {0 }", cmplxTyp_ip_to_SUBTRACTIONservice[x].FArg2);
                Console.WriteLine(" strFArg1 : {0 }", cmplxTyp_ip_to_SUBTRACTIONservice[x].StrArg1);
                Console.WriteLine(" strFArg2 : {0 }", cmplxTyp_ip_to_SUBTRACTIONservice[x].StrArg2);
            }
            Console.WriteLine("****************End INPUT DATA*: SUBTRACTION service--**************************");


        }



        private void launchAsACIAFagent_Click(object sender, EventArgs e)
        {
            Uri additionServiceURI = new Uri("http://localhost/Addition/Addition.svc?wsdl");
            Uri subtractServiceURI = new Uri("http://localhost/Subtraction/Subtraction.svc?wsdl");
            Uri multiplicationServiceURI = new Uri("http://localhost/Multiplication/Multiplication.svc?wsdl");

            calculateAddition(additionServiceURI, cmplxTyp_ip_toAdditionService);
            calculateSubtraction(subtractServiceURI, cmplxTyp_ip_to_SUBTRACTIONservice);
            calculateMultiplication(multiplicationServiceURI, cmplxTyp_ip_to_MULTIPLICATIONservice);
        }  // end of launchAsACIAFagent_Click(object sender, EventArgs e)

    } //end of class...

} //end of namespace...


