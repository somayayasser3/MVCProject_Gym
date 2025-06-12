using GymApp.Models;
using GymApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace GymApp.Controllers
{
    public class TraineeController : Controller
    {
        GymManagementContext2 con;
        public TraineeController(GymManagementContext2 c)
        {
            con = c;
        }
        public IActionResult Index()
        {
            List<TraineeViewModel> tvm = new List<TraineeViewModel>();
            List<Trainee> t = con.Trainees.ToList();
            foreach (Trainee trinee in t)
            {
                TraineeViewModel tt = new TraineeViewModel()
                {
                    Gender = trinee.Gender,
                    CoachID = trinee.CoachID,
                    ClassID = trinee.ClassID,
                    MembershipTypeID = trinee.MembershipTypeID,
                    DietPlanID = trinee.DietPlanID,
                    DOB = trinee.DOB,
                    Email = trinee.Email,
                    FullName = trinee.FullName,
                    JoinDate = trinee.JoinDate,
                    Phone = trinee.Phone
                };
                tvm.Add(tt);
            }
            return View(tvm);
        }
    }
}
