using System.Web.Mvc;

namespace ControlEscolarMVCCapas.Areas.Mensajeros
{
    public class MensajerosAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Mensajeros";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Mensajeros_default",
                "Mensajeros/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}