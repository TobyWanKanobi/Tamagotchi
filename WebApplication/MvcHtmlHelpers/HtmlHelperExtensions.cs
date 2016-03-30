using System.Web.Mvc;

/*
  Hunger : 0px 74px;
  Health : -800px 74px;
  Boredom : -498px 74px;
  Sleep : -270px 74px;
*/
namespace WebApplication.MvcHtmlHelpers
{
    public static class HtmlHelperExtensions
    {
        private const string KAK = "<div style=\"height:74px; width:74px; background: url('{0}')  {1}px 74px;\"></div>";

        public static MvcHtmlString ConvertStatusToImage(this HtmlHelper helper, string status)
        {
            int left    = 0;
            switch (status)
            {
                case "HEALTH":
                    left = -800;
                    break;
                case "HUNGER":
                    left = -800;
                    break;
                case "BOREDOM":
                    left = -498;
                    break;
                case "SLEEP":
                    left = -270;
                    break;
            }

            return new MvcHtmlString(string.Format(KAK, UrlHelper.GenerateContentUrl("~/Content/tamagotchi_sprites.jpg", helper.ViewContext.HttpContext), left));
        }
    }
}