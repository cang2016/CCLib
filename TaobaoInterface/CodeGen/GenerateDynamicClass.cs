using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CodeGen
{
    class GenerateDynamicClass
    {
        public void GenerateAssembly(DataTable[] dts, string classNamePrefix, bool usePrefix = false)
        {
            AssemblyName assemblyName = new AssemblyName("DynamicAssemblyForClass");
            AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndSave);

            ModuleBuilder moduleName = assemblyBuilder.DefineDynamicModule(assemblyName.Name, assemblyName.Name + ".dll");

            foreach(DataTable dt in dts)
            {
                TypeBuilder typeBuilder = null;
                if(usePrefix)
                {
                    typeBuilder = moduleName.DefineType(classNamePrefix + dt.TableName, TypeAttributes.Public, typeof(MarshalByRefObject));
                }
                else
                {
                    typeBuilder = moduleName.DefineType(dt.TableName, TypeAttributes.Public, typeof(MarshalByRefObject));
                }

                foreach(DataColumn dc in dt.Columns)
                {
                    FieldBuilder fb = typeBuilder.DefineField("m_" + dc.ColumnName, dc.DataType, FieldAttributes.Private);

                    PropertyBuilder pb = typeBuilder.DefineProperty(dc.ColumnName, System.Reflection.PropertyAttributes.HasDefault, dc.DataType, null);

                    MethodAttributes getSetAttr = MethodAttributes.Public |
                        MethodAttributes.SpecialName | MethodAttributes.HideBySig;

                    MethodBuilder mbGetAccessor = typeBuilder.DefineMethod("get_" + dc.ColumnName, getSetAttr, dc.DataType, Type.EmptyTypes);

                    ILGenerator getIL = mbGetAccessor.GetILGenerator();

                    getIL.Emit(OpCodes.Ldarg_0);
                    getIL.Emit(OpCodes.Ldfld, fb);
                    getIL.Emit(OpCodes.Ret);

                    MethodBuilder mbSetAccessor = typeBuilder.DefineMethod("set_" + dc.ColumnName, getSetAttr, null, new Type[] { dc.DataType });

                    ILGenerator setIL = mbSetAccessor.GetILGenerator();

                    setIL.Emit(OpCodes.Ldarg_0);
                    setIL.Emit(OpCodes.Ldarg_1);
                    setIL.Emit(OpCodes.Stfld, fb);
                    setIL.Emit(OpCodes.Ret);

                    pb.SetGetMethod(mbGetAccessor);
                    pb.SetSetMethod(mbSetAccessor);
                }

                Type targetType = typeBuilder.CreateType();
            }

            assemblyBuilder.Save("DynamicAssemblyForClass.dll");
        }
    }
}


