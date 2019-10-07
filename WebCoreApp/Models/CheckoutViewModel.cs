using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreApp.Application.ViewModels.Common;
using WebCoreApp.Application.ViewModels.Product;
using WebCoreApp.Data.Enums;
using WebCoreApp.Utilities.Extensions;

namespace WebCoreApp.Models
{
    public class CheckoutViewModel : BillViewModel
    {
        public List<ShoppingCartViewModel> Carts { get; set; }
        public List<EnumModel> PaymentMethods
        {
            get
            {
                return ((PaymentMethod[])Enum.GetValues(typeof(PaymentMethod)))
                    .Select(c => new EnumModel
                    {
                        Value = (int)c,
                        Name = c.GetDescription()
                    }).ToList();
            }
        }
    }
}
