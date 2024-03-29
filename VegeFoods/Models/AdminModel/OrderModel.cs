﻿using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VegeFoods.Models.BD_VegeFoods;

namespace VegeFoods.Models.CustomerModel
{
    public class OrderModel
    {
        DB_VegeFoodEntities db = null;
        public OrderModel()
        {
            db = new DB_VegeFoodEntities();
        }

        public List<Order> getAllOrderList()
        {
            return db.Orders.ToList();
        }

        public IEnumerable<Order> getOrderByPageList(int page = 1, int pageSize = 10)
        {
            return db.Orders.OrderBy(m => m.ID).ToPagedList(page, pageSize);
        }

        public List<Order> getOrderByUser(int id)
        {
            var result = (from order in db.Orders
                          where order.User_ID == id 
                          select order).ToList();

            return result;
        }

        public List<Order> getOrder(int id)
        {
            var result = (from order in db.Orders
                          where order.User_ID == id
                          select order).ToList();

            return result;
        }

        public int Insert(Order entity)
        {
            try
            {
                db.Orders.Add(entity);
                db.SaveChanges();
                return entity.ID;
            }
            catch
            {
                return 0;
            }
        }
    }
}