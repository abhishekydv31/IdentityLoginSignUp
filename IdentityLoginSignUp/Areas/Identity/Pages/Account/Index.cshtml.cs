using IdentityLoginSignUp.Areas.Identity.Data;
using IdentityLoginSignUp.Interfaces;
using IdentityLoginSignUp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace IdentityLoginSignUp.Areas.Identity.Pages.Account
{

    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IStudentRepositoryAsync _student;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRazorRenderService _renderService;
        private readonly ILogger<IndexModel> _logger;
        public IndexModel(ILogger<IndexModel> logger, IStudentRepositoryAsync student, IUnitOfWork unitOfWork, IRazorRenderService renderService)
        {
            _logger = logger;
            _student = student;
            _unitOfWork = unitOfWork;
            _renderService = renderService;
        }

        public IEnumerable<Student> Students{ get; set; }
        public void OnGet()
        {
            //OnGetDashboard();
        }

        public async Task<PartialViewResult> OnGetDashboard()
        {
            Students = await _student.GetAllAsync();
            return new PartialViewResult
            {
                ViewName = "_Dashboard",
                ViewData = new ViewDataDictionary<IEnumerable<Student>>(ViewData, Students)
            };
        }

        public async Task<JsonResult> OnGetCreateOrEditAsync(int id = 0)
        {
            if (id == 0)
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEdit", new Student()) });
            else
            {
                var thisStudent = await _student.GetByIdAsync(id);
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEdit", thisStudent) });
            }
        }

        public async Task<JsonResult> OnPostCreateOrEditAsync(int id, Student student)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await _student.AddAsync(student);
                    await _unitOfWork.Commit();
                }
                else
                {
                    await _student.UpdateAsync(student);
                    await _unitOfWork.Commit();
                }
                Students = await _student.GetAllAsync();
                var html = await _renderService.ToStringAsync("_Dashboard", Students);
                return new JsonResult(new { isValid = true, html = html });
            }
            else
            {
                var html = await _renderService.ToStringAsync("_CreateOrEdit", student);
                return new JsonResult(new { isValid = false, html = html });
            }
        }
        public async Task<JsonResult> OnPostDeleteAsync(int id)
        {
            var customer = await _student.GetByIdAsync(id);
            await _student.DeleteAsync(customer);
            await _unitOfWork.Commit();
            Students = await _student.GetAllAsync();
            var html = await _renderService.ToStringAsync("_Dashboard", Students);
            return new JsonResult(new { isValid = true, html = html });
        }
    }
}
