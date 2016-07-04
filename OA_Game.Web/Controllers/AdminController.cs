using System;
using System.IO;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using OA_Game.Library.Services;
using OA_Game.Service.Services;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OfficeOpenXml;

namespace OA_Game.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminUserService _adminUserService;
        private readonly IRequiredService _requiredService;
        public AdminController()
        {
            _adminUserService = new AdminUserService(new Service.OaGameDataContext());
            _requiredService= new RequiredService(new Service.OaGameDataContext());
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login()
        {
            var userName = HttpContext.Request["userName"];
            var password = HttpContext.Request["password"];
            var user = _adminUserService.GetAdminUser(userName, password);
            if (user != null)
            {
                var identity = UserService.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                HttpContext.GetOwinContext().Authentication.SignIn(new AuthenticationProperties { IsPersistent = true }, identity);
                return Redirect("Admin");
            }
            return Redirect("Index");
        }
        [Authorize]
        public ActionResult Admin()
        {

            return View();
        }
        [Authorize]
        public FileResult ExportRequired()
        {
            //获取list数据
            var checkList = _requiredService.GetRequireds().ToList().Select(n => new
            {
                Phone = n.Phone,
                Email = n.Email,
                Date = n.CreatedTime.ToShortDateString()
            }).ToList();
            //return null;
            using (ExcelPackage pck = new ExcelPackage())
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Sheet1");
                ws.Cells["A1"].LoadFromCollection(checkList, true);

                // 写入到客户端 
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                pck.SaveAs(ms);
                ms.Seek(0, SeekOrigin.Begin);
                DateTime dt = DateTime.Now;
                string dateTime = dt.ToString("yyMMddHHmmssfff");
                string fileName = "导出结果" + dateTime;
                return File(ms, "application/vnd.ms-excel", fileName);
            }

           

            ////创建Excel文件的对象
            //NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            ////添加一个sheet
            //NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");

            ////貌似这里可以设置各种样式字体颜色背景等，但是不是很方便，这里就不设置了

            ////给sheet1添加第一行的头部标题
            //NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
            //row1.CreateCell(0).SetCellValue("姓名");
            //row1.CreateCell(1).SetCellValue("Email");
            //row1.CreateCell(2).SetCellValue("时间");
            ////....N行

            ////将数据逐步写入sheet1各个行
            //for (int i = 0; i < checkList.Count; i++)
            //{
            //    NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);
            //    rowtemp.CreateCell(0).SetCellValue(checkList[i].PersonName.ToString());
            //    rowtemp.CreateCell(1).SetCellValue(checkList[i].Email.ToString());
            //    rowtemp.CreateCell(2).SetCellValue(checkList[i].Date.ToShortDateString());
            //    //....N行
            //}
            //// 写入到客户端 
            //System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //book.Write(ms);
            //ms.Seek(0, SeekOrigin.Begin);
            //DateTime dt = DateTime.Now;
            //string dateTime = dt.ToString("yyMMddHHmmssfff");
            //string fileName = "导出结果" + dateTime + ".xls";
            //return File(ms, "application/vnd.ms-excel", fileName);
        }
    }
}