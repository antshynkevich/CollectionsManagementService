namespace CollectionsManagementService.Services;

public static class Helper
{
    public static void SortSignHelper(string sortOrder, out string nameSign, out string dateSign)
    {
        switch (sortOrder)
        {
            case "name":
                nameSign = "△";
                dateSign = "◇";
                break;
            case "name_desc":
                nameSign = "▽";
                dateSign = "◇";
                break;
            case "date":
                nameSign = "◇";
                dateSign = "△";
                break;
            default:
                dateSign = "▽";
                nameSign = "◇";
                break;
        }
    }
}
