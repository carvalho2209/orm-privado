using Nampula.Framework;

namespace Nampula.UI.DinamicInterface
{
    internal class ThemeSkinManager
    {
        private ThemeSkinManager()
        {
            Theme = SignatureDesign;
        }

        internal const int GoldenThreadId = 2;
        internal const int GoldenThreadIdPl9 = 3;
        internal const int GoldenThreadIdPl91 = 4;
        internal const int SignatureDesignId = 0;

        internal const string GoldenThread = "Golden Thread";
        internal const string SignatureDesign = "Signature Design";

        public static ThemeSkinManager Instance
        {
            get
            {
                return Singleton<ThemeSkinManager>.Instance;
            }
        }

        public string Theme { get; set; }


        public void SetCurrentSchema(int skinId)
        {
            Theme = GoldenThreadId == skinId 
                || GoldenThreadIdPl9 == skinId
                || GoldenThreadIdPl91 == skinId 
                ? GoldenThread : SignatureDesign;

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(Theme);
            DevExpress.LookAndFeel.LookAndFeelHelper.ForceDefaultLookAndFeelChanged();


            //var xmlFile = Path.Combine(
            //    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            //    @"Local Settings\Application Data\SAP\SAP Business One\b1-current-user.xml");

            //var readXml = new XPathDocument(xmlFile);

            //var nav = readXml.CreateNavigator();

            //var nodeEle = nav.Select("/configuration/node[name='REGISTRY']/node[name='HKEY_CURRENT_USER']/node[name='SOFTWARE']/node[name='SAP']/node[name='SAP Manage']/node[name='SAP Business One']/leaf[name='SkinType']/value");


            //var value = nodeEle.Current.Value;

            //         <node name="REGISTRY">
            //<node name="HKEY_CURRENT_USER">
            //  <node name="SOFTWARE">
            //    <node name="SAP">
            //      <node name="SAP Manage">
            //        <node name="SAP Business One">
            //          <leaf kind="single" name="SkinType" type="String">
            //            <value>9.0</value>
        }

        public bool IsBlueThema()
        {
            return Theme.Equals(SignatureDesign);
        }
    }
}
