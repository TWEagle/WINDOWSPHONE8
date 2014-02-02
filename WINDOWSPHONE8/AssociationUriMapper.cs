using System;
using System.Windows.Navigation;

namespace WINDOWSPHONE8
{
    class AssociationUriMapper : UriMapperBase
    {
        private string tempUri;

        public override Uri MapUri(Uri uri)
        {
            tempUri = System.Net.HttpUtility.UrlDecode(uri.ToString());

            // URI association launch for contoso.
            if (tempUri.Contains("poriqrvisa:MainPage.xaml?kysymys="))
            {
                // Get the category ID (after "CategoryID=").
                int categoryIdIndex = tempUri.IndexOf("kysymys")+8;
                var kysymysID = tempUri.Substring(categoryIdIndex);
                string kysymysString;
                switch(kysymysID)
                {
                    case "1":
                        kysymysString = "Kysymys 1. Mikä on aakkosten kolmas kirjain?";
                        break;
                    case "2":
                        kysymysString = "Kysymys 2. Mitä kuuluu?";
                        break;
                    case "3":
                        kysymysString = "Kysymys 3. Kissa vai koira?";
                        break;
                    case "4":
                        kysymysString = "Kysymys 4. Whats yo name?";
                        break;
                    case "5":
                        kysymysString = "Kysymys 5. ...?";
                        break;
                    default:
                        kysymysString = "Kysymystä ei voitu hakea.";
                        break;
                }
                
                // Map the show products request to ShowProducts.xaml
                return new Uri("/QuestionPage.xaml?kysymys=" + kysymysString, UriKind.Relative);
            }

            // Otherwise perform normal launch.
            return uri;
        }
    }
}