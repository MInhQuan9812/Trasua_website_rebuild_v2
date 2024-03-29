﻿using Microsoft.AspNetCore.Mvc.Rendering;
using trasua_web_mvc.Dtos;
using trasua_web_mvc.Infracstructures;
using trasua_web_mvc.Infracstructures.Entities;
using trasua_web_mvc.Infracstructures.Singleton;
using trasua_web_mvc.Repositories;

namespace trasua_web_mvc.CommonData
{
    public static class OrderData
    {
        private static TraSuaContext _context;
        public static List<SelectListItem> getPaymentList(TraSuaContext context)
        {
            _context = context;
            PaymentSingleton.Instance.GetPaymentList(_context);
            List<SelectListItem> lstPayment = PaymentSingleton.Instance.listPayments.Select(x => new SelectListItem { Text = x.Title, Value = x.Id.ToString(), }).ToList();
            return lstPayment;
        }


        public static List<CheckBoxViewModelOrderPromotion> getPromotionList(TraSuaContext context)
        {
            _context = context;
            PromotionSingleton.Instance.GetPromotionList(_context);
            List<CheckBoxViewModelOrderPromotion> lstPromotion = PromotionSingleton.Instance.listPromotions.Select(x => new CheckBoxViewModelOrderPromotion { Text = x.Name, Value = x.Id.ToString(),Price=x.Percentdiscount }).ToList();
            return lstPromotion;
        }




    }
}
