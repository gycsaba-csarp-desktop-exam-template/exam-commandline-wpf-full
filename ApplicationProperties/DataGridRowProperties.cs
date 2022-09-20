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
                rowPerPage = GetPossibleNumberOfRowOnTheDataGridTableFromResourcesToList();
                AppConfigControl.AddOrUpdateAppSettings("PossibleNumberOfElementsOnDataGridTable", GetPossibleNumberOfRowOnTheDataGridTableFromResourcesToString());
            }
            return rowPerPage;
        }

        public string GetPossibleNumberOfRowOnTheDataGridTableFromResourcesToString()
        {
            string rowPerPageData = Resources.ResourceManager.GetString("GetPossibleNumberOfRowOnTheDataGridTable");
            return rowPerPageData;
        }

        public List<string> GetPossibleNumberOfRowOnTheDataGridTableFromResourcesToList()
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
