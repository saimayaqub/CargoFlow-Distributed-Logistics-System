using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.APIMessages;

namespace MyFinance.Helpers
{
    public static class ToSelectListItemsHelper
    {
        public static IEnumerable<SelectListItem> ToSelectListItems(
              this IEnumerable<Customer> customers, int  selectedId)
        {
            return

                customers.OrderBy(customer => customer.RevLogUser.Name)
                      .Select(customer =>
                          new SelectListItem
                          {
                              Selected = (customer.RevLogUserId == selectedId),
                              Text = customer.RevLogUser.Name,
                              Value = customer.RevLogUserId.ToString()
                          });
        }
    }
}