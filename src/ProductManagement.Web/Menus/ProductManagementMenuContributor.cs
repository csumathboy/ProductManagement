using System.Threading.Tasks;
using ProductManagement.Localization;
using ProductManagement.MultiTenancy;
using ProductManagement.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace ProductManagement.Web.Menus;

public class ProductManagementMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<ProductManagementResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                ProductManagementMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        //add Menu
        context.Menu.AddItem(
            new ApplicationMenuItem(
                "ProductManagement",
                l["Menu:ProductManagement"],
                icon: "fas fa-shopping-cart"
                    ).AddItem(
                new ApplicationMenuItem(
                    "ProductManagement.Products",
                    l["Menu:Products"],
                    url: "/Products"
                )
            )
        );
        var bookStoreMenu = new ApplicationMenuItem(
                "ProductManagement",
                l["Menu:BookStore"],
                icon: "fa fa-book"
            );

        context.Menu.AddItem(bookStoreMenu);

        //CHECK the PERMISSION
        if (await context.IsGrantedAsync(ProductManagementPermissions.Books.Default))
        {
            bookStoreMenu.AddItem(new ApplicationMenuItem(
                "ProductManagement.Books",
                l["Menu:Books"],
                url: "/Books"
            ));
        }

        if (await context.IsGrantedAsync(ProductManagementPermissions.Authors.Default))
        {
            bookStoreMenu.AddItem(new ApplicationMenuItem(
                "ProductManagement.Authors",
                l["Menu:Authors"],
                url: "/Authors"
            ));
        }


    }
}
