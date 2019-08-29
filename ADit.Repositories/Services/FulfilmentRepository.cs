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
    public class FulfilmentRepository : IFulfilmentRepository
    {
        private readonly IDbContextFactory dbContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="LookupRepository"/> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public FulfilmentRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        /// 
        /// </summary>
        /// <param name="orderFulfilmentActivityView"></param>
        /// <param name="orderFulfilmentActivityId"></param>
        /// <returns></returns>
        public string SaveOrderFulfilment(IOrderFulfilmentActivityView orderFulfilmentActivityView,
            out int orderFulfilmentActivityId)
        {
            var result = string.Empty;
            if (orderFulfilmentActivityView == null)
            {
                throw new ArgumentNullException(nameof(orderFulfilmentActivityView));
            }

            orderFulfilmentActivityView.IsSendMail = orderFulfilmentActivityView.MailMessage != null;

            var order = new OrderFulfilmentActivity
            {
                CreatedByUserId = orderFulfilmentActivityView.CreatedByUserId,
                DateCreated = DateTime.Now,
                FromStatus = orderFulfilmentActivityView.FromStatus,
                ToStatus = orderFulfilmentActivityView.ToStatus,
                IsResponseRequired = orderFulfilmentActivityView.IsResponseRequired,
                ActvityDescription = orderFulfilmentActivityView.Activityescription,
                IsSendMail = orderFulfilmentActivityView.IsSendMail,
                IsTreated = true,
                MailMessage = orderFulfilmentActivityView.MailMessage,
                OrderFulfilmentId = orderFulfilmentActivityView.OrderFulfilmentId,
            };

            try
            {
                using (
                    var dbContext = (ADitEntities)dbContextFactory.GetDbContext())
                {
                    dbContext.OrderFulfilmentActivities.Add(order);
                    dbContext.SaveChanges();
                }
            }
            catch (DbEntityValidationException e)
            {
                List<String> lstErrors = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    string msg = string.Format(
                        "Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name,
                        eve.Entry.State);

                    lstErrors.Add(msg);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        msg = string.Format("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                        lstErrors.Add(msg);
                    }
                }

                if (lstErrors != null && lstErrors.Count() > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in lstErrors)
                    {
                        sb.Append(item + "; ");
                    }

                    throw new Exception("Repository.Save. Db Entity Validation Exception. Data not saved. Error: " +
                                        sb.ToString());
                }
            }


            catch (NotSupportedException)
            {
            }

            orderFulfilmentActivityId = order.OrderFulfilmentActivityId;
            return result;
        }


        /// <summary>
        /// Gets all orders.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetOrders</exception>
        public IList<IOrderFulfilment> GetFulfilmentOrders()
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)dbContextFactory.GetDbContext())
                {
                    var list = FulfilmentQueries.GetFulfilmentOrders(dbContext).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetFulfilmentOrders", e);
            }
        }


        /// <summary>
        /// Gets the fulfilment orders by code.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetFulfilmentOrders</exception>
        public IList<IOrderFulfilment> GetFulfilmentOrdersByCode(string fulfilmentCode)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)dbContextFactory.GetDbContext())
                {
                    var list = FulfilmentQueries.GetFulfilmentOrdersByCode(dbContext, fulfilmentCode).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetFulfilmentOrders", e);
            }
        }


        /// <summary>
        /// Gets the fulfilment orders by code.
        /// </summary>
        /// <param name="scriptingStatusList">The scripting status list.</param>
        /// <returns>IList&lt;IOrderFulfilment&gt;.</returns>
        public IList<IOrderFulfilment> GetFulfilmentOrdersByCode(IList<string> scriptingStatusList)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)dbContextFactory.GetDbContext())
                {
                    var list = FulfilmentQueries.GetFulfilmentOrdersByCode(dbContext, scriptingStatusList).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetFulfilmentOrders", e);
            }
        }


        /// <summary>
        /// Gets the fulfilment status summary.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetFulfilmentStatusSummary</exception>
        public IList<IFulfilmentStatusSummaryModel> GetFulfilmentStatusSummary()
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)dbContextFactory.GetDbContext())
                {
                    var list = FulfilmentQueries.GetFulfilmentSummary(dbContext).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetFulfilmentStatusSummary", e);
            }
        }

        public string ChangeOrderStatus(int orderFulfilmentId, string toStatus, int userId)
        {
            if (orderFulfilmentId < 1)
            {
                throw new ArgumentNullException(nameof(orderFulfilmentId));
            }

            var result = string.Empty;
            try
            {
                using (var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var order = dbContext.OrderFulfilments.FirstOrDefault(x => x.OrderFulfilmentId.Equals(orderFulfilmentId));
                    if (order == null)
                    {
                        throw new ApplicationException($"Order not found for orderFulfilmentId {orderFulfilmentId}");
                    }

                    order.FulfilmentStatusCode = toStatus;
                    dbContext.SaveChanges();
                }
            }

            catch (Exception e)
            {
                result = $"Change Order Status for orderFulfilmentId {orderFulfilmentId} - {e.Message} , {(e.InnerException != null ? e.InnerException.Message : "")}";
            }

            return result;
        }


        /// <summary>
        /// Gets the fulfilment service summary by status code.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetFulfilmentStatusSummary</exception>
        public IList<IFulfilmentServiceSummaryModel> GetFulfilmentServiceSummaryByStatusCode(string statusCode)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)dbContextFactory.GetDbContext())
                {
                    var list = FulfilmentQueries.GetFulfilmentServiceSummaryByStatusCode(dbContext, statusCode).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetFulfilmentServiceSummaryByStatusCode", e);
            }
        }

        /// <summary>
        /// Gets the fulfilment order by fulfilment identifier.
        /// </summary>
        /// <param name="orderFulfilmentId">The order fulfilment identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetFulfilmentOrderByFulfilmentId</exception>
        public IOrderFulfilment GetFulfilmentOrderByFulfilmentId(int orderFulfilmentId)
        {
            try
            {
                using (
                    var dbContext = (ADitEntities)dbContextFactory.GetDbContext())
                {
                    var list = OrderQueries.GetFulfilmentOrderById(dbContext, orderFulfilmentId);

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetFulfilmentOrderByFulfilmentId", e);
            }
        }
    }
}
