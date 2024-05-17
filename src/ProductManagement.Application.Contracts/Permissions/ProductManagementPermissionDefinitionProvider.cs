using ProductManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ProductManagement.Permissions;

public class ProductManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {

        //Define your own permissions here. Example:
        //myGroup.AddPermission(ProductManagementPermissions.MyPermission1, L("Permission:MyPermission1"));
        var productManagementGroup = context.AddGroup(ProductManagementPermissions.GroupName, L("Permission:ProductManagement"));

        var booksPermission = productManagementGroup.AddPermission(ProductManagementPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(ProductManagementPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(ProductManagementPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(ProductManagementPermissions.Books.Delete, L("Permission:Books.Delete"));

        var productsPermission = productManagementGroup.AddPermission(ProductManagementPermissions.Products.Default, L("Permission:Products"));
        productsPermission.AddChild(ProductManagementPermissions.Products.Create, L("Permission:Products.Create"));
        productsPermission.AddChild(ProductManagementPermissions.Products.Edit, L("Permission:Products.Edit"));
        productsPermission.AddChild(ProductManagementPermissions.Products.Delete, L("Permission:Products.Delete"));

        var authorsPermission = productManagementGroup.AddPermission(ProductManagementPermissions.Authors.Default, L("Permission:Authors"));
        authorsPermission.AddChild(
            ProductManagementPermissions.Authors.Create, L("Permission:Authors.Create"));
        authorsPermission.AddChild(
            ProductManagementPermissions.Authors.Edit, L("Permission:Authors.Edit"));
        authorsPermission.AddChild(
            ProductManagementPermissions.Authors.Delete, L("Permission:Authors.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ProductManagementResource>(name);
    }
}
