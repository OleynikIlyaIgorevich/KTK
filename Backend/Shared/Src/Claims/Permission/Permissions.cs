namespace Shared.Constants.Permission;

public static class Permissions
{
    public static class Users
    {
        public static string Get = "Permission.Users.Get";
        public static string Create = "Permission.Users.Create";
        public static string Update = "Permission.Users.Update";
        public static string Delete = "Permission.Users.Delete";
        
        public static string Export = "Permission.Users.Export";
        public static string Import = "Permission.Users.Import";
    }
    
    
    public static List<string> GetRegisteredPermissions()
    {
        var permissions = new List<string>();
        foreach (var prop in typeof(Permissions).GetNestedTypes().SelectMany(c =>
                     c.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)))
        {
            var propertyValue = prop.GetValue(null);
            if (propertyValue != null) permissions.Add(propertyValue.ToString());
        }
        return permissions;
    }
}