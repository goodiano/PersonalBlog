using GoodianoBlog.Application.Interfaces.Contexts;
using GoodianoBlog.Application.Services.Common.GetHomePagePosts;
using GoodianoBlog.Application.Services.Common.GetItemMenu;
using GoodianoBlog.Application.Services.HomePage.Query.GetSliders;
using GoodianoBlog.Application.Services.Posts.Command.Admin.Categories.AddCategory;
using GoodianoBlog.Application.Services.Posts.Command.Admin.Categories.DeleteCategory;
using GoodianoBlog.Application.Services.Posts.Command.Admin.Categories.EditCategory;
using GoodianoBlog.Application.Services.Posts.Command.Admin.Comments.ChangeStatus;
using GoodianoBlog.Application.Services.Posts.Command.Admin.Posts.AddPost;
using GoodianoBlog.Application.Services.Posts.Command.Admin.Posts.DeletePost;
using GoodianoBlog.Application.Services.Posts.Command.Admin.Posts.EditPost;
using GoodianoBlog.Application.Services.Posts.Command.Admin.Tags.AddTag;
using GoodianoBlog.Application.Services.Posts.Command.Admin.Tags.DeleteTag;
using GoodianoBlog.Application.Services.Posts.Command.ClientSide.AddComment;
using GoodianoBlog.Application.Services.Posts.Query.Admin.Authors.GetAllAuthors;
using GoodianoBlog.Application.Services.Posts.Query.Admin.Categories.GetCategory;
using GoodianoBlog.Application.Services.Posts.Query.Admin.Comments.GetAllComments;
using GoodianoBlog.Application.Services.Posts.Query.Admin.Posts.GetAllCategory;
using GoodianoBlog.Application.Services.Posts.Query.Admin.Posts.GetAllPosts;
using GoodianoBlog.Application.Services.Posts.Query.Admin.Tags.GetAllTags;
using GoodianoBlog.Application.Services.Posts.Query.ClientSide.Posts.GetPostDetail;
using GoodianoBlog.Application.Services.Posts.Query.ClientSide.Posts.GetPostForEdit;
using GoodianoBlog.Application.Services.Posts.Query.ClientSide.Posts.GetPosts;
using GoodianoBlog.Application.Services.Users.Command.Admin.ChangeStatusInAdmin;
using GoodianoBlog.Application.Services.Users.Command.Admin.DeleteUserInAdmin;
using GoodianoBlog.Application.Services.Users.Command.Admin.EditUserInAdmin;
using GoodianoBlog.Application.Services.Users.Command.ClientSide.ForgetPassword.EmailSender;
using GoodianoBlog.Application.Services.Users.Command.ClientSide.LogIn;
using GoodianoBlog.Application.Services.Users.Command.ClientSide.LogIn.ForgetPassword;
using GoodianoBlog.Application.Services.Users.Command.EmailSender;
using GoodianoBlog.Application.Services.Users.Command.SignUp;
using GoodianoBlog.Application.Services.Users.Command.SignUpForAdmin;
using GoodianoBlog.Application.Services.Users.Query.GetAllUserForAdmin;
using GoodianoBlog.Application.Services.Users.Query.GetRolesForAdmin;
using GoodianoBlog.Common.RoleList;
using GoodianoBlog.Persistance.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(RoleItems.Admin, policy => policy.RequireRole(RoleItems.Admin));
    options.AddPolicy(RoleItems.Customer, policy => policy.RequireRole(RoleItems.Customer));
});


builder.Services.AddAuthentication(options =>
{
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie();


#region DbContext
builder.Services.AddDbContext<DataBaseContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("GoodianoConnection")));
#endregion

#region IOC
builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddScoped<ISignUpServices, SignUpServices>();
builder.Services.AddScoped<IGetAllUserServices, GetAllUserServices>();
builder.Services.AddScoped<ISignUpForAdminServices, SignUpForAdminServices>();
builder.Services.AddScoped<IGetRolesServices, GetRolesServices>();
builder.Services.AddScoped<IDeleteUserServices, DeleteUserServices>();
builder.Services.AddScoped<IUserEditServices, UserEditService>();
builder.Services.AddScoped< IChangeStatusServices, ChangeStatusService>();
builder.Services.AddScoped<ILogInUserServices, LogInUserServices>();
builder.Services.AddScoped<IViewRenderService, RenderViewToString>();
builder.Services.AddScoped<IForgetPasswordServices, ForgetPasswordServices>();
builder.Services.AddScoped<IAddNewCategory, AddNewCategory>();
builder.Services.AddScoped<IGetCategoryServices, GetCategoryServices>();
builder.Services.AddScoped<IDeleteCategoryServices, DeleteCategoryService>();
builder.Services.AddScoped<IEditCategoryServices, EditCategoryServices>();
builder.Services.AddScoped<IGetItemMenuServices, GetItemMenuServices>();
builder.Services.AddScoped<IAddPostServices, AddPostServices>();
builder.Services.AddScoped<IGetAllCategory, GetAllCategory>();
builder.Services.AddScoped<IGetAllAuthorServices, GetAllAuthorServices>();
builder.Services.AddScoped<IGetAllPostsServices, GetAllPostsServices>();
builder.Services.AddScoped<IDeletePostServices, DeletePostServices>();
builder.Services.AddScoped<IEditPostServices, EditPostServices>();
builder.Services.AddScoped<IGetPostForClientSideServices, GetPostForClientSideServices>();
builder.Services.AddScoped<IGetPostDetailServices, GetPostDetailServices>();
builder.Services.AddScoped<IGetPostForEditServices, GetPostForEditServices>();
builder.Services.AddScoped<IAddCommentsServices, AddCommentsService>();
builder.Services.AddScoped<IGetAllCommentsServices, GetAllCommentsService>();
builder.Services.AddScoped<ICommentChangeStatusServices, CommentChangeStatusServices>();
builder.Services.AddScoped<IAddTagServices, AddTagService>();
builder.Services.AddScoped<IDeleteTagServices, DeleteTagService>();
builder.Services.AddScoped<IGetAllTagsServices, GetAllTagsService>();
builder.Services.AddScoped<IGetHomePageImageServices, GetHomePageImageServices>();
builder.Services.AddScoped<IGetSliderServices, GetSliderServices>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Users}/{action=Index}/{id?}");

app.Run();
