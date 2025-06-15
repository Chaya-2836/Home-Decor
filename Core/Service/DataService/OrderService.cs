using Core.Dao;
using Core.Dto;
using Core.IRepositories;
using Core.IServices;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Service.DataService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductInStockService _productInStockServices;
        private readonly EmailService _emailService;
        private readonly IMapper _mapper;

        public OrderService(
            IOrderRepository orderRepository,
            IProductInStockService productInStockServices,
            EmailService emailService,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _productInStockServices = productInStockServices;
            _emailService = emailService;
            _mapper = mapper;
        }

        public async Task<Order> addOrderAsync(Order newOrder)
        {
            try
            {
                // כדי להימנע מבעיה של שינוי רשימה בזמן מעבר עליה
                var itemsToRemove = new List<ProductOrdered>();

                foreach (ProductOrdered p in newOrder.ordered)
                {
                    try
                    {
                        _productInStockServices.decreaseStock(p.Product.SKU, p.Quantity);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Equals("Not enough in stock"))
                        {
                            itemsToRemove.Add(p);
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                foreach (var item in itemsToRemove)
                {
                    newOrder.ordered.Remove(item);
                }

                // הוספת ההזמנה למסד הנתונים
                Order savedOrder = await _orderRepository.addOrderAsync(newOrder);

                // המרת ההזמנה ל־DTO ושליחת מייל
                OrderDto orderDto = _mapper.Map<OrderDto>(savedOrder);
                string htmlContent = BuildOrderEmailHtml(orderDto);
                await _emailService.SendEmailAsync(orderDto.CustomerEmail, "קבלה על הזמנתך מ־HomeDecor", htmlContent);

                return savedOrder;
            }
            catch (Exception e)
            {
                // לוגינג אופציונלי
                throw new Exception("שגיאה במהלך יצירת ההזמנה ושליחת המייל", e);
            }
        }

        public string BuildOrderEmailHtml(OrderDto order)
        {
            var sb = new StringBuilder();

            sb.Append("<div style='direction: rtl; font-family: Arial;'>");

            sb.Append("<h2 style='color: #2c3e50;'>תודה שקנית ב־HomeDecor</h2>");
            sb.Append($"<p>לכבוד <strong>{order.CustomerFirstName} {order.CustomerLastName}</strong></p>");
            sb.Append($"<p>תאריך הזמנה: {order.OrderDate:dd/MM/yyyy}</p>");

            sb.Append("<table border='1' cellpadding='6' cellspacing='0' style='border-collapse: collapse; width: 100%; text-align: right;'>");
            sb.Append("<thead style='background-color: #f0f0f0;'>");
            sb.Append("<tr>");
            sb.Append("<th>שם פריט</th>");
            sb.Append("<th>כמות</th>");
            sb.Append("<th>סה\"כ לפריט</th>");
            sb.Append("</tr>");
            sb.Append("</thead>");
            sb.Append("<tbody>");

            foreach (var item in order.Ordered)
            {
                sb.Append("<tr>");
                sb.Append($"<td>{item.Product.Name}</td>");
                sb.Append($"<td>{item.Quantity}</td>");
                sb.Append($"<td>{(item.Quantity * item.Product.Price):N2} ₪</td>");
                sb.Append("</tr>");
            }

            sb.Append("</tbody>");
            sb.Append("</table>");

            double total = order.Ordered.Sum(i => i.Quantity * i.Product.Price);
            sb.Append($"<p style='margin-top: 20px;'><strong>סה\"כ להזמנה: {total:N2} ₪</strong></p>");

            sb.Append("</div>");
            return sb.ToString();
        }
    }
}
