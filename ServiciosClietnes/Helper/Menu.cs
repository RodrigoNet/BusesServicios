using BLL;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTIL.Objetos;

namespace ServiciosClietnes.Helper
{
    public static class MenuHelper
    {
        public static MvcHtmlString Menu(this HtmlHelper helper)
        {
            var menu = new Control();
            var menuList = string.Empty;
            var datosUsuario = (ObjetoUsuario)HttpContext.Current.Session["VariableSesionUsuario"];
            if (datosUsuario != null)
            {
                if (menu.MenuUsuario(datosUsuario.Perfil).Count > 0)
                {
                    var urlMenu = menu.MenuUsuario(datosUsuario.Perfil).ToList();
                    menuList = menuList + "<ul class='nav'>" +
                        "<li class='nav-header'>Menu</li>";

                    for (var i = 0; i <= urlMenu.Count; i++)
                    {
                        if (i > urlMenu.Count)
                        {
                            break;
                        }
                        menuList = menuList + string.Format("<li class='has-sub'>" +
                            "<a ref='javascript:;'>" +
                            "<b class='caret'></b>");
                        menuList = menuList + string.Format("<i class='{0}'></i><span>{1}</span></a>", urlMenu[i].Clase, urlMenu[i].PieMenu);
                        menuList = menuList + string.Format("<ul class='sub-menu'>");

                        var nombreModulo = urlMenu[i].PieMenu;
                        for (var x = 0; x <= i; x++)
                        {
                            if (i >= urlMenu.Count)
                            {
                                break;
                            }
                            if (nombreModulo == urlMenu[i].PieMenu)
                            {
                                menuList = menuList + string.Format("<li><a href='../{2}/{1}'>{0}</a></li>", urlMenu[i].Titulo,
                                    urlMenu[i].Action, urlMenu[i].Controller);
                                i++;
                            }
                            else
                            {
                                i--;
                                break;
                            }
                        }
                        menuList = menuList + "</ul>";
                    }
                    menuList = menuList + "</li></ul>";
                }
            }
            return new MvcHtmlString(menuList);
        }
    }
}