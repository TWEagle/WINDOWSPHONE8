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
                
                
                // Map the show products request to ShowProducts.xaml
                return new Uri("/QuestionPage.xaml?kysymys=" + kysymysID, UriKind.Relative);
            }

            // Otherwise perform normal launch.
            return uri;
        }
    }
}