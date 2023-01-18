using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITraining_3_2
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        public string massage = "Количество воздуховодов";

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;
            
            List<FamilyInstance> fInstances = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_DuctCurves)
                .WhereElementIsNotElementType()
                .Cast<FamilyInstance>()
                .ToList();
            
            TaskDialog.Show(massage, fInstances.Count.ToString());
            return Result.Succeeded;
        }

    }

}

