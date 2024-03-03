namespace OrderManagementAPI.Domen.Entites.Enums
{
    public enum Permission
    { 
        Create = 1,
        GetById=2,
        GetAll=3,
        UpdateCountById=4,
        SelProduct=5,
        Update=6,
        UpdateName=7,
        UpdateDescription=8,
        UpdateCaunt=9,
        Delete=11,
        GetPdfPath=12,
        //User service
        CreateUser=20,
        GetUserById=21,
        GetUserByLogin=22,
        GetAllUser=23,
        UpdateUser=24,
        UpdateUserName=25,
        UpdateUserOrder=26,
        UpdateUserEmail=27,
        UpdateUserPassword=28,
        UpdateUserLogin=29
    }
}
