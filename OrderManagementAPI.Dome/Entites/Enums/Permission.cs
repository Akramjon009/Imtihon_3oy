namespace OrderManagementAPI.Domen.Entites.Enums
{
    public enum Permission
    { 
        Create = 1,
        GetById,
        GetAll,
        UpdateCountById,
        SelProduct,
        Update,
        UpdateName,
        UpdateDescription,
        UpdateCaunt,
        Delete,
        GetPdfPath,
        //User service
        CreateUser,
        GetUserById,
        GetUserByLogin,
        GetAllUser,
        UpdateUser,
        UpdateUserName,
        UpdateUserOrder,
        UpdateUserEmail,
        UpdateUserPassword,
        UpdateUserLogin
    }
}
