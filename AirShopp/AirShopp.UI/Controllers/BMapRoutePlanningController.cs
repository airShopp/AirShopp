using System;
using System.Collections.Generic;
using AirShopp.UI.Models.ViewModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirShopp.UI.Controllers
{
    public class BMapRoutePlanningController : Controller
    {
        //
        // GET: /BMapRoutePlanning/
        public ActionResult Index()
        {
            // 1. Click query delivery info button and pass params()
            // 2. 

            List<OriginPointsViewModel> pointsList = new List<OriginPointsViewModel>();

            OriginPointsViewModel startUpPoint = new OriginPointsViewModel(){
                Name = "起点",
                Address = "江苏昆山物流转运中心",
                Longitude = 120.964369,
                Latitude = 31.372474,
                Remark = ""
            };
            pointsList.Add(startUpPoint);


            OriginPointsViewModel endPoint = new OriginPointsViewModel()
            {
                Name = "终点",
                Address = "上海市浦东新区浦东软件园17号楼",
                Longitude = 121.605791,
                Latitude = 31.213232,
                Remark = ""
            };








            return View();
        }
	}
}