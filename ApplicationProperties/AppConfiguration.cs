using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationPropertiesSettings
{
    public class AppConfiguration
    {
        //TODO: CurrentCulture

        public List<string> GetPossibleNumberOfRowOnTheDataGridTable()
        {

            List<string>  rowPerPage = AppConfigControl.getAppSettingsToList("PossibleNumberOfElementsOnDataGridTable");
            if (rowPerPage == null)
            {
                rowPerPage=ApplicationProperties.GetPossibleNumberOfRowOnTheDataGridTableToList();
                AppConfigControl.AddOrUpdateAppSettings("PossibleNumberOfElementsOnDataGridTable", ApplicationProperties.GetPossibleNumberOfRowOnTheDataGridTableToString());
            }
            return rowPerPage;
        }
    }
}
