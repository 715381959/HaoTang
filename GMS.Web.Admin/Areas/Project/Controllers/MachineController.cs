﻿using GMS.Account.Contract;
using GMS.Project.Contract;
using GMS.Web.Admin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GMS.Web.Admin.Areas.Project.Controllers
{   

    [Permission(EnumBusinessPermission.ProjectManage_Machine)]
    public class MachineController : AdminControllerBase
    {

        public ActionResult Index(MachineryCostRequest request)
        {
            var result = this.ProjectService.GetMachineryCostList(request);
            return View(result);
        }

        //
        // GET: /Project/Labor/Create

        public ActionResult Create()
        {
            var model = new MachineryCost();
            return View("Edit", model);

        }
        //
        // POST: /Project/Labor/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var model = new MachineryCost();

            this.TryUpdateModel<MachineryCost>(model);
            this.ProjectService.SaveMachineryCost(model);

            return this.RefreshParent();
        }
        //
        // GET: /Project/Labor/Edit/5

        public ActionResult Edit(int id)
        {
            var model = this.ProjectService.GetMachineryCost(id);
            return View(model);
        }

        //
        // POST: /Project/Labor/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        { 
            var model = this.ProjectService.GetMachineryCost(id);
            this.TryUpdateModel<MachineryCost>(model);
            model.MachineryTotal = 0;
            if (model.Transport != null)
                model.MachineryTotal += (int)model.Transport;
            if (model.Operating != null)
                model.MachineryTotal += (int)model.Operating;
            if (model.Repair != null)
                model.MachineryTotal += (int)model.Repair;
            if (model.Fuel != null)
                model.MachineryTotal += (int)model.Fuel;
            if (model.Depreciation != null)
                model.MachineryTotal += (int)model.Depreciation;
            if (model.TravelTax != null)
                model.MachineryTotal += (int)model.TravelTax;
            if (model.OtherFee != null)
                model.MachineryTotal += (int)model.OtherFee; this.ProjectService.SaveMachineryCost(model);

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
            this.ProjectService.DeleteMachineryCost(ids);
            return RedirectToAction("Index");
        }
    }
}
