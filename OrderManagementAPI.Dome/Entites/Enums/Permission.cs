﻿using OrderManagementAPI.Domen.Entites.Models;

namespace OrderManagementAPI.Domen.Entites.Enums
{
    public enum Permission
    { 
        Create = 1,
        GetById=2,
        GetAll=3,
        SelProduct=5,
        Update=6,
        UpdateName=7,
        UpdateDescription=8,
        UpdateCaunt=9,
        DeleteProduct=10,
        GetPdfPath=11,
        //User service
        GetPicture =22,
        GetAllUser =23,
        UpdateUser=24,
        UpdateUserName=25,
        UpdateUserOrder=26,
        UpdateUserEmail=27,
        UpdateUserPassword=28,
        UpdateUserLogin=29,
        UpdatePhoto=30,
        DeleteUser=31,
        FillUp =32,
        GetMany=33,
        UpdatePrice=34
    }
}
