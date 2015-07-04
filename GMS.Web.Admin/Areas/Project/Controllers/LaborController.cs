﻿using GMS.Account.Contract;
using GMS.Project.Contract;
using GMS.Web.Admin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace GMS.Web.Admin.Areas.Project.Controllers
{
    [Permission(EnumBusinessPermission.ProjectManage_Labor)]
    public class LaborController : AdminControllerBase
    {   

        public ActionResult Index(LaborCostRequest request)
        {
            var result = this.ProjectService.GetLaborCostList(request);
            return View(result);
        }
 
        //
        // GET: /Project/Labor/Create

        public ActionResult Create()
        {
            var model = new LaborCost();
            return View("Edit", model);

        }
        //
        // POST: /Project/Labor/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var model = new LaborCost();  
            this.TryUpdateModel<LaborCost>(model);
            this.ProjectService.SaveLaborCost(model);

            return this.RefreshParent();
        }
        //
        // GET: /Project/Labor/Edit/5

        public ActionResult Edit(int id)
        {
            var model = this.ProjectService.GetLaborCost(id);
            return View(model);
        }

        //
        // POST: /Project/Labor/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = this.ProjectService.GetLaborCost(id); 
            this.TryUpdateModel<LaborCost>(model);
            model.LaborTotal = model.Masons + model.Painter + model.Steel + model.OtherLabor + model.Plumbers + model.TearDown + model.Transportor + model.Carpenter + model.Cleaner + model.ELectricWelder;
            this.ProjectService.SaveLaborCost(model);

           


            return this.RefreshParent();
        }

        //
        // GET: /Project/Labor/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Project/Labor/Delete/5

        [HttpPost]
        public ActionResult Delete(List<int> ids)
        {
            this.ProjectService.DeleteLaborCost(ids);
            return RedirectToAction("Index");
        }


     
    }
}
