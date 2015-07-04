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
   
    [Permission(EnumBusinessPermission.ProjectManage_Measure)]
    public class MeasureController : AdminControllerBase
    {

        public ActionResult Index(MeasureRequest request)
        {
            var result = this.ProjectService.GetMeasureList(request);
            return View(result);
        }

        //
        // GET: /Project/Labor/Create

        public ActionResult Create()
        {
            var model = new Measure();
            return View("Edit", model);

        }
        //
        // POST: /Project/Labor/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var model = new Measure();

            this.TryUpdateModel<Measure>(model);
            this.ProjectService.SaveMeasure(model);

            return this.RefreshParent();
        }
        //
        // GET: /Project/Labor/Edit/5

        public ActionResult Edit(int id)
        {
            var model = this.ProjectService.GetMeasure(id);
            return View(model);
        }

        //
        // POST: /Project/Labor/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = this.ProjectService.GetMeasure(id);
            this.TryUpdateModel<Measure>(model);
            model.MeasureTotal = model.Water + model.Electric + model.TempTool + model.TempFacility + model.Secure + model.Test + model.QualityCosts + model.Civilization + model.SecondHand + model.OtherFee;

            this.ProjectService.SaveMeasure(model);

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
            this.ProjectService.DeleteMeasure(ids);
            return RedirectToAction("Index");
        }
    }

}
