using ADit.Interfaces;
using ADit.Interfaces.ValueTypes;
using ADit.Repositories.DataAccess;
using ADit.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace ADit.Repositories.Services
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbContextFactory dbContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="LookupRepository"/> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public OrderRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }


        /// <summary>
        /// Gets the branding transactions.
        /// </summary>
        /// <param name="OrderNumber">The order number.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetBrandingTransactions</exception>
        public IList<IBrandingTransaction> GetBrandingTransactions(int orderId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var list = OrderQueries.GetActiveBrandingTransaction(dbContext, orderId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetBrandingTransactions", e);
            }
        }

        /// <summary>
        /// Updates the status code.
        /// </summary>
        /// <param name="orderFulfilmentId">The order fulfilment identifier.</param>
        /// <param name="statusCurrentCode">The status current code.</param>
        /// <returns></returns>
        public string UpdateStatusCode(int orderFulfilmentId, string statusCurrentCode)
        {
            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var orderDetails =
                        dbContext.OrderFulfilments.FirstOrDefault(x => x.OrderFulfilmentId == orderFulfilmentId);
                    orderDetails.FulfilmentStatusCode = statusCurrentCode;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveOrderFulfilment - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Gets the production fulfilment payment.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Get Scripting Fulfilent Payment</exception>
        public IList<IFulfilmentPayment> GetProductionFulfilmentPayment(int Id)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var list = OrderQueries.GetProductionPendingFulfilmentPayments(dbContext, Id).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Get Scripting Fulfilent Payment", e);
            }
        }

        /// <summary>            
        /// <summary>
        /// Gets the scripting fulfilment payment.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Get Scripting Fulfilent Payment</exception>
        public IList<IFulfilmentPayment> GetScriptingFulfilmentPayment(int Id)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var list = OrderQueries.GetScriptngPendingFulfilmentPayments(dbContext, Id).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Get Scripting Fulfilent Payment", e);
            }
        }

        /// <summary>
        /// <summary>
        /// Gets the branding transactions.
        /// </summary>
        /// <param name="OrderNumber">The order number.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetBrandingTransactions</exception>
        public IOrderFulfilment GetOrderFulfilmentById(int orderFulfilmentId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var list = OrderQueries.GetFulfilmentOrderById(dbContext, orderFulfilmentId);

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetOrderFulfilmentById", e);
            }
        }

        /// <summary>
      


        /// <summary>
        /// Saves the order fulfilment.
        /// </summary>
        /// <param name="orderFulfilmentActivityView">The order fulfilment activity view.</param>
        /// <param name="orderFulfilmentActivityId">The order fulfilment activity identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">orderFulfilmentActivityView</exception>
        public string saveOrderFulfilmentDocument(IOrderFulfilmentActivityView orderFulfilmentActivityView,
            int OrderFulfilmentActivityId, int DigitalFileId)
        {
            var result = string.Empty;

            bool isSendWithMail = false;
            if (orderFulfilmentActivityView == null)
            {
                throw new ArgumentNullException(nameof(orderFulfilmentActivityView));
            }

            if (orderFulfilmentActivityView.MailMessage != null)
            {
                isSendWithMail = true;
            }


            var order = new OrderFulfilmentActivityDocument
            {
                DigitalFileId = DigitalFileId,
                IsAttachWithMail = isSendWithMail,
                OrderFulfilmentActivityId = OrderFulfilmentActivityId,
            };

            try
            {
                using (
                    var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    dbContext.OrderFulfilmentActivityDocuments.Add(order);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveOrderFulfilment - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }


        /// <summary>
        /// Saves the order payment scriping fulilment.
        /// </summary>
        /// <param name="fulfilmentPayment">The fulfilment payment.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">fulfilmentPayment</exception>
        public string saveOrderPaymentScripingFulfilment(IFulfilmentPaymentView fulfilmentPayment)
        {
            var result = string.Empty;


            if (fulfilmentPayment == null)
            {
                throw new ArgumentNullException(nameof(fulfilmentPayment));
            }

            var order = new FulfilmentScriptingPayment
            {
                Price = fulfilmentPayment.Price,
                DateCreated = DateTime.Now,
                FulfilmentPaymentStatus = "AP",
                IsActive = true,
                OrderFulfilmentId = fulfilmentPayment.OrderFulfilmentId
            };

            try
            {
                using (
                    var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var orderStatus = dbContext.OrderFulfilments.FirstOrDefault(x =>
                        x.OrderFulfilmentId == fulfilmentPayment.OrderFulfilmentId);

                    orderStatus.FulfilmentStatusCode = "SY";
                    dbContext.FulfilmentScriptingPayments.Add(order);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("FulfilmentScriptingPayment - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }


        /// <summary>
        /// Saves the order payment scriping fulilment.
        /// </summary>
        /// <param name="fulfilmentPayment">The fulfilment payment.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">fulfilmentPayment</exception>
        public string updateOrderPaymentScripingFulfilment(int orderpaymentId, string refrenceCode)
        {
            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var orderStatus =
                        dbContext.FulfilmentScriptingPayments.FirstOrDefault(x =>
                            x.FulfilmentScriptingPaymentId == orderpaymentId);

                    orderStatus.RefrenceCode = refrenceCode;
                    orderStatus.FulfilmentPaymentStatus = "P";
                    orderStatus.DatePaid = DateTime.Now;

                    var orderFulfilment =
                        dbContext.OrderFulfilments.FirstOrDefault(x =>
                            x.OrderFulfilmentId == orderStatus.OrderFulfilmentId);
                    orderFulfilment.FulfilmentStatusCode = "S";

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("update FulfilmentScriptingPayment - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }


        /// </summary>
        /// <param name="fulfilmentPayment">The fulfilment payment.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">fulfilmentPayment</exception>
        public string updateOrderPaymentProductionFulfilment(int orderpaymentId, string refrenceCode)
        {
            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var orderStatus =
                        dbContext.FulfilmentProductionPayments.FirstOrDefault(x =>
                            x.FulfilmentProductionPaymentId == orderpaymentId);

                    orderStatus.RefrenceCode = refrenceCode;
                    orderStatus.FulfilmentPaymentStatus = "P";
                    orderStatus.DatePaid = DateTime.Now;
                    var orderFulfilment =
                        dbContext.OrderFulfilments.FirstOrDefault(x =>
                            x.OrderFulfilmentId == orderStatus.OrderFulfilmentId);
                    orderFulfilment.FulfilmentStatusCode = "S";

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("update FulfilmentProductionPayment - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }


        /// <summary>
        /// Saves the order payment production fulfilment.
        /// </summary>
        /// <param name="fulfilmentPayment">The fulfilment payment.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">fulfilmentPayment</exception>
        public string saveOrderPaymentProductionFulfilment(IFulfilmentPaymentView fulfilmentPayment)
        {
            var result = string.Empty;


            if (fulfilmentPayment == null)
            {
                throw new ArgumentNullException(nameof(fulfilmentPayment));
            }

            var order = new FulfilmentProductionPayment
            {
                DateCreated = DateTime.Now,
                FulfilmentPaymentStatus = "AP",
                IsActive = true,
                Price = fulfilmentPayment.Price,
                OrderFulfilmentId = fulfilmentPayment.OrderFulfilmentId
            };

            try
            {
                using (
                    var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var orderStatus = dbContext.OrderFulfilments.FirstOrDefault(x =>
                        x.OrderFulfilmentId == fulfilmentPayment.OrderFulfilmentId);

                    orderStatus.FulfilmentStatusCode = "SY";
                    dbContext.FulfilmentProductionPayments.Add(order);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("FulfilmentProductionPayment - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }


        /// <summary>
        /// Gets the online transactions.
        /// </summary>
        /// <param name="OrderNumber">The order number.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetOnlineTransactions</exception>
        public IList<IOnlineTransaction> GetOnlineTransactions(int orderId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var list = OrderQueries.getActiveOnlineTransaction(dbContext, orderId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetOnlineTransactions", e);
            }
        }


        /// <summary>
        /// Gets the orders.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetOrders</exception>
        public IList<IOrder> GetOrders(int UserId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var list = OrderQueries.GetOrder(dbContext, UserId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetOrders", e);
            }
        }


        /// <summary>
        /// Gets the print transactions.
        /// </summary>
        /// <param name="OrderNumber">The order number.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetPrintTransaction</exception>
        public IList<IPrintTransaction> GetPrintTransactions(int orderId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var list = OrderQueries.GetActivePmTransaction(dbContext, orderId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetPrintTransaction", e);
            }
        }


        /// <summary>
        /// Gets the radio transactions.
        /// </summary>
        /// <param name="OrderNumber">The order number.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetRadioTransactions</exception>
        public IList<IRadioTransaction> GetRadioTransactions(int orderId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var list = OrderQueries.getActiveRadioTranasction(dbContext, orderId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetRadioTransactions", e);
            }
        }

        /// <summary>
        /// Gets the tv transactions.
        /// </summary>
        /// <param name="OrderNumber">The order number.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetTvTransactions</exception>
        public IList<ITvTransaction> GetTvTransactions(int orderId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var list = OrderQueries.GetActiveTvTransactions(dbContext, orderId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetTvTransactions", e);
            }
        }


        /// <summary>
        /// Gets the fulfilment statuses.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetTvTransactions</exception>
        public IList<IOrderFulfilmentStatus> GetFulfilmentStatuses(string statusCode)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var list = OrderQueries.GetOrderFulfilmentStatuses(dbContext, statusCode).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetTvTransactions", e);
            }
        }


        /// <summary>
        /// Gets the fulfilment statuses.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetTvTransactions</exception>
        public IOrderFulfilmentStatus GetOrderFulfilmentStatusCode(string statusCode)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var list = OrderQueries.GetOrderFulfilmentStatusCode(dbContext, statusCode);

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetOrderFulfilmentStatusCode", e);
            }
        }


        /// <summary>
        /// Gets the fulfilment status rule.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetTvTransactions</exception>
        public IList<IFulfilmentStatusRule> GetFulfilmentStatusRule()
        {
            try
            {
                using (
                    var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var list = OrderQueries.GetOrderFulfilmentStatusRule(dbContext).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetTvTransactions", e);
            }
        }


        /// <summary>
        /// Creates the order.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>processing message</returns>
        public string CreateOrder(int userId, out int orderId)
        {
            if (userId < 1)
            {
                throw new ArgumentNullException("userId");
            }

            var result = string.Empty;
            orderId = -1;

            var order = new Order
            {
                UserId = userId,
                OrderNumber = "",
                OrderStatusCode = "O", //Pending
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
            };

            try
            {
                using (var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    dbContext.Orders.Add(order);
                    dbContext.SaveChanges();
                    orderId = order.OrderId;
                }

             
            }

            catch (Exception e)
            {
                result = string.Format("CreateOrder - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Updates the order code status.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="orderNumber">The order number.</param>
        /// <returns>processing message</returns>
        /// <exception cref="ApplicationException">order should not be null</exception>
        /// <exception cref="ArgumentNullException">orderNumber</exception>
        public string UpdateOrderNumber(int orderId, string orderNumber)
        {
            if (orderNumber == null)
            {
                throw new ArgumentNullException(nameof(orderNumber));
            }

            var result = string.Empty;
            try
            {
                using (var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var order = dbContext.Orders.SingleOrDefault(x => x.OrderId == orderId);
                    if (order == null)
                    {
                        throw new ApplicationException("order should not be null");
                    }

                    order.OrderNumber = orderNumber;
                    order.DateModified = DateTime.Now; //Date Modified

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("UpdateOrderNumber - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Changes the order status.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <exception cref="ArgumentNullException">Order Id is null</exception>
        /// <exception cref="ApplicationException">Repository GetRadioStationPrice</exception>
        public void ChangeOrderStatus(int orderId)
        {
            if (orderId < 1)
            {
                throw new ArgumentNullException("Order Id is null");
            }


            try
            {
                using (
                    var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var Order = dbContext.Orders.FirstOrDefault(x => x.OrderId == orderId);
                    Order.OrderStatusCode = "I";

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository ChangeOrderStatus", e);
            }
        }

        /// <summary>
        /// Updates the ordertatus.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="status">The status.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentNullException">status</exception>
        /// <exception cref="ApplicationException">order should not be null</exception>
        public string UpdateOrderStatus(int orderId, string status)
        {
            var fulfilmentOrder = new OrderFulfilment();
            if (string.IsNullOrEmpty(status))
            {
                throw new ArgumentNullException(nameof(status));
            }

            var result = string.Empty;
            try
            {
                using (var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var order = dbContext.Orders.SingleOrDefault(x => x.OrderId == orderId);


                    if (order == null)
                    {
                        throw new ApplicationException("order should not be null");
                    }

                    order.OrderStatusCode = "P";

                    var radioOrder = dbContext.RadioTransactions.Where(x => x.OrderId == orderId).ToList();

                    if (radioOrder.Count > 0)
                    {
                        foreach (var o in radioOrder)
                        {
                            fulfilmentOrder = new OrderFulfilment
                            {
                                CreatedByUserId = o.UserId,
                                DateCreated = o.DateCreated,
                                FulfilmentStatusCode = "S",
                                OrderId = o.OrderId,
                                ServiceCode = "R",
                                ServiceTransactionId = o.RadioTransactionId
                            };


                            dbContext.OrderFulfilments.Add(fulfilmentOrder);
                            dbContext.SaveChanges();
                        }
                    }


                    var tvOrder = dbContext.TVTransactions.Where(x => x.OrderId == orderId).ToList();

                    if (tvOrder.Count > 0)
                    {
                        foreach (var o in tvOrder)
                        {
                            fulfilmentOrder = new OrderFulfilment
                            {
                                CreatedByUserId = o.UserId,
                                DateCreated = o.DateCreated,
                                FulfilmentStatusCode = "S",
                                OrderId = o.OrderId,
                                ServiceCode = "T",
                                ServiceTransactionId = o.TVTransactionId
                            };


                            dbContext.OrderFulfilments.Add(fulfilmentOrder);
                            dbContext.SaveChanges();
                        }
                    }

                    var onlineOrder = dbContext.OnlineTransactions.Where(x => x.OrderId == orderId).ToList();

                    if (onlineOrder.Count > 0)
                    {
                        foreach (var o in onlineOrder)
                        {
                            fulfilmentOrder = new OrderFulfilment
                            {
                                CreatedByUserId = o.UserId,
                                DateCreated = o.DateCreated,
                                FulfilmentStatusCode = "S",
                                OrderId = o.OrderId,
                                ServiceCode = "O",
                                ServiceTransactionId = o.OnlineTransactionId
                            };


                            dbContext.OrderFulfilments.Add(fulfilmentOrder);
                            dbContext.SaveChanges();
                        }
                    }

                    var printOrder = dbContext.PrintTransactions.Where(x => x.OrderId == orderId).ToList();

                    if (printOrder.Count > 0)
                    {
                        foreach (var o in printOrder)
                        {
                            fulfilmentOrder = new OrderFulfilment
                            {
                                CreatedByUserId = o.UserId,
                                DateCreated = o.DateCreated,
                                FulfilmentStatusCode = "S",
                                OrderId = o.OrderId,
                                ServiceCode = "P",
                                ServiceTransactionId = o.PrintTransactionId
                            };

                            dbContext.OrderFulfilments.Add(fulfilmentOrder);
                            dbContext.SaveChanges();
                        }
                    }

                    var brandingOrder = dbContext.BrandingTransactions.Where(x => x.OrderId == orderId).ToList();

                    if (brandingOrder.Count > 0)
                    {
                        foreach (var o in brandingOrder)
                        {
                            fulfilmentOrder = new OrderFulfilment
                            {
                                CreatedByUserId = o.UserId,
                                DateCreated = o.DateCreated,
                                FulfilmentStatusCode = "S",
                                OrderId = o.OrderId,
                                ServiceCode = "B",
                                ServiceTransactionId = o.BrandingTransactionId
                            };


                            dbContext.OrderFulfilments.Add(fulfilmentOrder);
                            dbContext.SaveChanges();
                        }
                    }

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("UpdateOrdertatus - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Gets all orders.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetOrders</exception>
        public IList<IOrder> GetAllOrders()
        {
            try
            {
                using (
                    var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var list = OrderQueries.GetAllOrders(dbContext).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetOrders", e);
            }
        }

        


        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public string DeleteAllOrder(int orderId)
        {
            var result = string.Empty;


            try
            {
                using (var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var onlineTransaction =
                        dbContext.OnlineTransactions.Where(x =>
                            x.OrderId == orderId);
                    var radioTransaction =
                        dbContext.RadioTransactions.Where(x =>
                            x.OrderId == orderId);
                    var printTransaction =
                        dbContext.PrintTransactions.Where(x =>
                            x.OrderId == orderId);
                    var tvTransaction =
                        dbContext.TVTransactions.Where(x =>
                            x.OrderId == orderId);
                    var brandingTransaction =
                        dbContext.BrandingTransactions.Where(x =>
                            x.OrderId == orderId);

                    foreach (var a in onlineTransaction)
                    {
                        a.TransactionStatusCode = "D";
                    }

                    foreach (var b in radioTransaction)
                    {
                        b.TransactionStatusCode = "D";
                    }

                    foreach (var c in printTransaction)
                    {
                        c.TransactionStatusCode = "D";
                    }

                    foreach (var d in tvTransaction)
                    {
                        d.TransactionStatusCode = "D";
                    }

                    foreach (var e in brandingTransaction)
                    {
                        e.TransactionStatusCode = "D";
                    }
                    //var a =       onlineTransaction.TransactionStatusCode = "D";
                    //      var b = radioTransaction.TransactionStatusCode = "D";
                    //      var c = printTransaction.TransactionStatusCode = "D";
                    //      var d = tvTransaction.TransactionStatusCode = "D";
                    //      var e = brandingTransaction.TransactionStatusCode = "D";


                    dbContext.SaveChanges();


                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("DeleteAllOrder- {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }


            return result;
        }


        // <summary>
        /// Gets the radio transactions.
        /// </summary>
        /// <param name="OrderNumber">The order number.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetRadioTransactions</exception>
        public IOrder GetOrderNumberByOrderId(int orderId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities) this.dbContextFactory.GetDbContext())
                {
                    var list = OrderQueries.GetOrderNumberByOrderId(orderId, dbContext);

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetOrderNumberByOrderId", e);
            }
        }
    }
}