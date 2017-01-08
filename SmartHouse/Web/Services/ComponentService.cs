﻿using System;
using Web.DataAccess.Interfaces;
using Web.DataAccess.Repositories;
using Web.Models.Components;

namespace Web.Services
{
    public class ComponentService
    {
        private readonly IUnitOfWork unitOfWork;

        public ComponentService()
        {
            this.unitOfWork = new UnitOfWork();
        }

        public void CreateSmoothSlider(SmoothSlider smoothSlider)
        {
            var slider = new SmoothSlider(smoothSlider.Name, smoothSlider.MinValue, smoothSlider.MaxValue);
            unitOfWork.GetRepository<SmoothSlider>().Insert(slider);
            unitOfWork.Save();
        }

        public SmoothSlider GetSmoothSlider(Guid? id)
        {
            var component = unitOfWork.GetRepository<SmoothSlider>().GetById(id);
            return component;
        }
    }
}