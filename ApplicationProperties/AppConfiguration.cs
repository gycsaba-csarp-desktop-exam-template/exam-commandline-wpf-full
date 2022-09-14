using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationPropertiesSettings
{
    public class AppConfiguration
    {
        //TODO: CurrentCulture
        public void setCultureInfo()
        {
            CultureInfo cultureInfo = new CultureInfo(ApplicationProperties.GetDefaultCulture());
            Thread.CurrentThread.CurrentCulture = cultureInfo;
        }

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
