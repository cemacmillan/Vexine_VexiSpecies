using System;
using System.Reflection;
using Verse;

namespace Vexine
{
    public static class VexiUtil
    {

        public static bool HasFired;

        public static bool isVexine(Pawn pawn)
        {
          if (pawn?.genes?.HasGene(VexiDefOf.dIl_Vexi_Body) == true)
             {
              return true;
              }
            return false;

        }
      // Borrowed from VRESaurids
        public static bool SameXenotype(Pawn pawn, Pawn other)
        {
            if (pawn?.genes?.Xenotype == other?.genes?.Xenotype)
            {
                return true;
            }
            return false;
        }

        public static bool GotIt()
        {

          if (VexiUtil.HasFired == false) {
            VexiUtil.HasFired = true;
            return false;
          }

          return true;

        }

        // try to find out what is in a pawn.
        public static void DumpObject(object obj, int indentLevel = 0)
        {
            if (obj == null)
            {
               // Log.Message("null");
                return;
            }

            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (PropertyInfo property in properties)
            {
                string propertyName = property.Name;
                object propertyValue = property.GetValue(obj);
                string indent = new string(' ', indentLevel * 2);
                Log.Message(indent + " " + propertyName + ": " + propertyValue);
                if (propertyValue != null)
                {
                    DumpObject(propertyValue, indentLevel + 1);
                }
            }
            foreach (FieldInfo field in fields)
            {
                string fieldName = field.Name;
                object fieldValue = field.GetValue(obj);
                string indent = new string(' ', indentLevel * 2);
                Log.Message(indent + " " + fieldName + ":" + fieldValue);
                if (fieldValue != null)
                {
                    DumpObject(fieldValue, indentLevel + 1);
                }
            }
        }
        //
    }

}
