using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeGen
{
    public class GenerateCode
    {
        public bool GenerateClassCode(List<DataTable> dts, string nameSpace, string folderPath, string tableName = "")
        {
            GenerateDynamicClass gc = new GenerateDynamicClass();

            gc.GenerateAssembly(dts.ToArray(), string.Empty);

            Assembly ass = Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory + "DynamicAssemblyForClass.dll");

            if (!File.Exists(Path.GetDirectoryName(folderPath)))
            {
                Directory.CreateDirectory(folderPath);
            }

            FileAttributes attr = File.GetAttributes(folderPath);
            File.SetAttributes(folderPath, attr & ~FileAttributes.ReadOnly);

            foreach (Type type in ass.GetTypes())
            {
                Console.SetOut(new StreamWriter(new FileStream(Path.Combine(folderPath,FirstLetterToUpper(type.Name) + ".cs"), FileMode.Create)));
                Console.WriteLine("namespace " + nameSpace);
                Console.WriteLine("{");

                Console.WriteLine("\tusing System;");
                Console.WriteLine("\t[TableName(\"" + type.Name.ToLower() + "\")]");
                Console.WriteLine("\tpublic class " + type.Name);
                Console.WriteLine("\t{");
                type.GetProperties().ToList().ForEach(p =>
                {
                    //if(p.Name.ToLower().Equals("id"))
                    //{
                    //    Console.WriteLine("\t\t[Column(\"" + p.Name.ToLower() + "\",PrimaryKey=true,IsIdentification=false)]");
                    //    Console.WriteLine("\t\tpublic " + p.PropertyType.Name + " " + p.Name + Environment.NewLine + "\t\t{" + Environment.NewLine + "\t\t\tget;" + Environment.NewLine + "\t\t\tset;" + Environment.NewLine + "\t\t}");
                    //}
                    //else
                    //{
                    Console.WriteLine("\t\tpublic " + ConvertTypeName(p.PropertyType.Name) + " " + FirstLetterToUpper(p.Name) + Environment.NewLine + "\t\t{" + Environment.NewLine + "\t\t\tget;" + Environment.NewLine + "\t\t\tset;" + Environment.NewLine + "\t\t}");
                    //}
                });
                Console.WriteLine("\t}");
                Console.WriteLine("}");
                Console.Out.Flush();
            }

            Console.Out.Close();

            return true;
        }

        private string FirstLetterToUpper(string text)
        {

            if (!string.IsNullOrWhiteSpace(text))
            {
                if (text.Length > 0 && char.IsLower(text[0]))
                {
                    text = text.Substring(0, 1).ToUpper() + text.Substring(1);
                }
            }

            return text;
        }


        private string ConvertTypeName(string propTypeName)
        {
            switch (propTypeName)
            {
                case "String":
                    return "string";
                case "Decimal":
                    return "decimal";
                case "Int32":
                    return "int";
                case "Int64":
                    return "long";
                case "Double":
                    return "double";
                case "Boolean":
                    return "bool";
                case "Int16":
                    return "short";
                case "Single":
                    return "float";

                default:
                    return "string";
            }

        }
    }
}
