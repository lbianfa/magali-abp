namespace magali.Permissions;

public static class magaliPermissions
{
    public const string GroupName = "magali";

    public static class Authors
    {
        public const string Default = GroupName + ".Authors";
        public const string Create = Default + ".create";
        public const string Edit = Default + ".edit";
        public const string Delete = Default + ".delete";
    }

    public static class Books
    {
        public const string Default = GroupName + ".Books";
        public const string Create = Default + ".create";
        public const string Edit = Default + ".edit";
        public const string Delete = Default + ".delete";
    }
}
