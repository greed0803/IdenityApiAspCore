// See https://aka.ms/new-console-template for more information
using Data.Context;
using Repo;
using Service.Impl;

Console.WriteLine("Hello, World!");
UserService userService = new UserService(new UserRepository(IdentityProviderContext.GetContext()));


foreach (var item in userService.GetAll())
{
    Console.WriteLine(item.UserName);
}//userService.Create(new Data.Model.User()
//{
//    UserName = "Test2",
//    Password = "Test",
//    UserTypeId = 1,
//    StatusId = 0,
//}) ;