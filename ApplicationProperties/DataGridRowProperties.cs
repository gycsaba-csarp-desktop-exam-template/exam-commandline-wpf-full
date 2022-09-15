using ApplicationPropertiesSettings.Properties;
using CommunityToolkit.HighPerformance;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationPropertiesSettings
{
    public class DataGridRowProperties
    {
        public List<string> GetPossibleNumberOfRowOnTheDataGridTable()
        {

            List<string>  rowPerPage = AppConfigControl.getAppSettingsToList("PossibleNumberOfElementsOnDataGridTable");
            if (rowPerPage == null)
            {
                rowPerPage = GetPossibleNumberOfRowOnTheDataGridTableToList();
                AppConfigControl.AddOrUpdateAppSettings("PossibleNumberOfElementsOnDataGridTable", GetPossibleNumberOfRowOnTheDataGridTableToString());
            }
            return rowPerPage;
        }

        public string GetPossibleNumberOfRowOnTheDataGridTableToString()
        {
            string rowPerPageData = Resources.ResourceManager.GetString("GetPossibleNumberOfRowOnTheDataGridTable");
            return rowPerPageData;
        }

        public static List<string> GetPossibleNumberOfRowOnTheDataGridTableToList()
        {
            string rowPerPageData = Resources.ResourceManager.GetString("GetPossibleNumberOfRowOnTheDataGridTable");
            List<string> result = new List<string>();

            foreach (var token in rowPerPageData.Tokenize(','))
            {
                result.Add(token.ToString());
            }
            return result;
        }
    }
}
