using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusAutomationSuite.Helper;
using System.Configuration;
using ZeusAutomationSuite.DataProviders;

namespace RunAutomation.Helpers
{
    class PopulateCOnfigurations
    {
        public PopulateCOnfigurations()
        {
            ConfigHelper.ADDomain = ConfigurationManager.AppSettings["ADDomain"].ToString();
            ConfigHelper.AndroidActivityName = ConfigurationManager.AppSettings["AndroidAppActivity"];
            ConfigHelper.AndroidPackageName = ConfigurationManager.AppSettings["AndroidAppPackage"];
            ConfigHelper.AndroidVersion = ConfigurationManager.AppSettings["AndroidVersion"];
            ConfigHelper.ArtifactPath = ConfigurationManager.AppSettings["TestCaseFolderFullPath"].ToString();
            ConfigHelper.CaptureScreenshotonstepFailure = Convert.ToBoolean(ConfigurationManager.AppSettings["CaptureScreenshotonstepFailure"].ToString());
            ConfigHelper.ClickItemSeperator = ConfigurationManager.AppSettings["ClickItemSeperator"];
            ConfigHelper.DBConnectionString = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            ConfigHelper.DeviceList = ConfigurationManager.AppSettings["DeviceList"];
            ConfigHelper.DriverPath = ConfigurationManager.AppSettings["TestCaseFolderFullPath"].ToString() + @"\Drivers";
            ConfigHelper.Environment = ConfigurationManager.AppSettings["EnvrionmentURL"].ToString();
            ConfigHelper.IfTestAreforMobileBrowser = ConfigurationManager.AppSettings["IsWebTest"];
            ConfigHelper.MasterPlanSheetName = ConfigurationManager.AppSettings["MasterPlanSheet"].ToString();
            ConfigHelper.MasterPlanSheetPath = ConfigurationManager.AppSettings["ExcelFilePath"].ToString();
            ConfigHelper.MobileServiceURL = ConfigurationManager.AppSettings["Appium-MobileDeviceServiceURL"];
            ConfigHelper.ObjectPropertySeparator = Convert.ToChar(ConfigurationManager.AppSettings["ObjectPropertySeparator"].ToString());
            ConfigHelper.ObjectPropertyValueSeparator = Convert.ToChar(ConfigurationManager.AppSettings["ObjectPropertyValueSeparator"].ToString());
            ConfigHelper.TestCaseSheetName = ConfigurationManager.AppSettings["TestCaseSheet"].ToString();
            ConfigHelper.TFSProject = ConfigurationManager.AppSettings["TFSProject"].ToString();
            ConfigHelper.TFSService = ConfigurationManager.AppSettings["TFSService"].ToString();
            ConfigHelper.UWPAppName = ConfigurationManager.AppSettings["UWPAppNameorPath"];
            ConfigHelper.UWPServiceURL = ConfigurationManager.AppSettings["Appium-UWPServiceURL"];
            ApplicationObjectProvider.FullExternalResxFilePath = ConfigurationManager.AppSettings["FullExternalResxFilePath"];

        }
    }
}
