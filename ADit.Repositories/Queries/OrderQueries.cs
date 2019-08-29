using ADit.Interfaces;
using ADit.Repositories.DataAccess;
using ADit.Repositories.Models;
using System.Collections.Generic;
using System.Linq;

namespace ADit.Repositories.Queries
{
    public class OrderQueries
    {
        /// <summary>
        /// Gets the branding material.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IOrder> GetOrder(ADitEntities db, int UserId)
        {
            var result = (from b in db.Orders
                    where b.UserId == UserId
                    select new OrderModel
                    {
                        DateCreated = b.DateCreated,
                        DateModified = b.DateModified,
                        OrderId = b.OrderId,
                        OrderNumber = b.OrderNumber,
                        OrderStatus = b.OrderStatusCode,
                        UserId = b.UserId
                    }
                ).OrderBy(x => x.OrderId);
            return result;
        }
        /// <summary>
        /// Gets the active tv transactions.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="OrderId">The order identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<ITvTransaction> GetActiveTvTransactions(ADitEntities db, int OrderId)
        {
            var result = (from s in db.TVTransactions
                    // join t in db.TVTransactionAirings on s.TVTransactionId equals t.TVTransactionId
                    where s.OrderId == OrderId
                    where s.IsActive.Equals(true)
                    //group t by t.TVTransactionId into totalOrder
                    select new TvTransactionModel
                    {
                        TVTransactionId = s.TVTransactionId,
                        TransactionStatusCode = s.TransactionStatusCode,
                        ApconApprovalTypeId = s.ApconApprovalTypeId,
                        AiringInstruction = s.AiringInstruction,
                        ApconApprovalAmount = s.ApconApprovalAmount,
                        ApconApprovalNumber = s.ApconApprovalNumber,
                        ApconApprovalTypePriceId = s.ApconApprovalTypePriceId,
                        FinalAmount = s.FinalAmount,
                        IsHaveApconApproval = s.IsHaveApconApproval,
                        ScriptDescription = s.ScriptDescription,
                        ScriptingDigitalFileId = s.ScriptingDigitalFileId,
                        DateCreated = s.DateCreated,
                        ProductionDigitalFileId = s.ProductionDigitalFileId,
                        IsHaveMaterial = s.IsHaveMaterial,
                        OrderId = s.OrderId,
                        OrderTitle = s.OrderTitle,
                        UserId = s.UserId,
                        ProductionAmount = s.ProductionAmount,
                        ScriptingAmount = s.ScriptingAmount,
                    }
                ).OrderBy(x => x.TVTransactionId);


            return result;
        }
        /// <summary>
        /// Gets the active radio tranasction.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IRadioTransaction> getActiveRadioTranasction(ADitEntities db, int orderId)
        {
            var result = (from s in db.RadioTransactions
                    where s.OrderId == orderId
                    select new RadioTransactionModel
                    {
                        RadioTransactionId = s.RadioTransactionId,
                        TransactionStatusCode = s.TransactionStatusCode,
                        ApconApprovalTypeId = s.ApconApprovalTypeId,
                        AiringInstruction = s.AiringInstruction,

                        ApconApprovalAmount = s.ApconApprovalAmount,
                        ApconApprovalNumber = s.ApconApprovalNumber,
                        ApconApprovalTypePriceId = s.ApconApprovalTypePriceId,
                        FinalAmount = s.FinalAmount,
                        IsHaveApconApproval = s.IsHaveApconApproval,
                        ScriptDescription = s.ScriptDescription,
                        ScriptingDigitalFileId = s.ScriptDigitalFileId,
                        DateCreated = s.DateCreated,
                        ProductionDigitalFileId = s.MaterialDigitalFileId,
                        IsHaveMaterial = s.IsHaveMaterial,
                        //OrderNumber = s.OrderNumber,
                        OrderTitle = s.OrderTitle,
                        UserId = s.UserId,
                        ScriptingAmount = s.ScriptingAmount,
                        ProductionAmount = s.ProductionAmount,
                    }
                ).OrderBy(x => x.RadioTransactionId);
            return result;
        }
        /// <summary>
        /// Gets the active online transaction.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IOnlineTransaction> getActiveOnlineTransaction(ADitEntities db, int orderId)
        {
            var result = (from d in db.OnlineTransactions
                where d.OrderId == orderId

                // where d.Is.Equals(true)
                select new OnlineTransactionModel
                {
                    OnlineTransactionId = d.OnlineTransactionId,
                    OrderId = d.OrderId,
                    OrderTitle = d.OrderTitle,
                    OnlinePurposeId = d.OnlinePurposeId,
                    OnlinePlatformId = d.OnlinePlatformId,
                    OnlinePlatformPriceId = d.OnlinePlatformPriceId,
                    OnlinePlatformAmount = d.OnlinePlatformAmount,
                    AdditionalInformation = d.AdditionalInformation,
                    IsHaveArtWork = d.IsHaveArtWork,
                    ArtWorkPriceId = d.ArtWorkPriceId,
                    ArtWorkAmount = d.ArtWorkAmount ?? 0,
                    ArtworkDigitalFileId = d.ArtworkDigitalFileId,
                    DateCreated = d.DateCreated,
                    OnlineExtraServiceAmount = d.OnlineExtraServiceAmount,
                    TransactionStatusCode = d.TransactionStatusCode,
                    Price = d.Price
                }).OrderBy(x => x.OnlineTransactionId);
            return result;
        }
        /// <summary>
        /// Gets the active pm transaction.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IPrintTransaction> GetActivePmTransaction(ADitEntities db, int orderId)
        {
            var result = (from s in db.PrintTransactions
                    where s.OrderId == orderId
                    where s.TransactionStatusCode.Equals("A")
                    select new PrintTransactionModel
                    {
                        PrintTransactionId = s.PrintTransactionId,
                        OrderId = s.OrderId,
                        IsHaveMaterial = s.IsHaveMaterial,
                        MaterialDigitalFileId = s.MaterialDigitalFileId,
                        ApconApprovalNumber = s.ApconApprovalNumber,
                        ApconApprovalTypeId = s.ApconApprovalTypeId,
                        ApconApprovalTypePriceId = s.ApconApprovalTypePriceId,
                        ApconApprovalAmount = s.ApconApprovalAmount,
                        PrintCategoryId = s.PrintCategoryId,
                        DesignElementId = s.DesignElementId,
                        DesignElementPriceId = s.DesignElementPriceId,
                        DesignAmount = s.DesignAmount,
                        DurationTypeCode = s.DurationTypeCode,

                        DateCreated = s.DateCreated,
                        TransactionStatusCode = s.TransactionStatusCode,
                        OrderTitle = s.OrderTitle,
                        UserId = s.UserId,
                        TotalPrice = s.TotalPrice,
                    }
                ).OrderBy(x => x.PrintTransactionId);
            return result;
        }
        /// <summary>
        /// Gets the active branding transaction.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="OrderId">The order identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IBrandingTransaction> GetActiveBrandingTransaction(ADitEntities db, int OrderId)
        {
            var result = (from d in db.BrandingTransactions
                where d.TransactionStatusCode == "A"
                where d.OrderId == OrderId
                join f in db.BrandingTransactionDesignElements on d.BrandingTransactionId equals f.BrandingTransactionId
                join g in db.BrandingTransactionMaterials on d.BrandingTransactionId equals g.BrandingTransactionId
                select new BrandingTransactionModel
                {
                    OrderTitle = d.OrderTitle,
                    AdditionalInformation = d.AdditionalInformation,
                    BrandingTransactionId = d.BrandingTransactionId,
                    DateCreated = d.DateCreated,
                    DateModified = d.DateModified,
                    OrderId = d.OrderId,
                    OtherColor = d.OtherColor,
                    TransactionStatusCode = d.TransactionStatusCode,
                    UserId = d.UserId,
                    BrandingMaterialAmount = g.BrandingMaterialAmount,
                    DesignElementAmount = f.DesignElementAmount,
                }).OrderBy(x => x.BrandingTransactionId);
            return result;
        }

        /// <summary>
        /// Gets the order fulfilment statuses.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="statusCode">The status code.</param>
        /// <returns></returns>
        internal static IEnumerable<IOrderFulfilmentStatus> GetOrderFulfilmentStatuses(ADitEntities db,
            string statusCode)
        {
            var result = (from d in db.FulfilmentStatusRules
                    where d.FromStatusId == statusCode
                    join g in db.FulfilmentStatus on d.ToStatusId equals g.FulfilmentStatusCode
                    select new OrderFulfilmentStatusModel
                    {
                        Description = g.Description,
                        FulfilmentStatusCode = g.FulfilmentStatusCode
                    }
                ).OrderBy(x => x.FulfilmentStatusCode);
            return result;
        }

        /// <summary>
        /// Gets the order fulfilment status code.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="statusCode">The status code.</param>
        /// <returns></returns>
        internal static IOrderFulfilmentStatus GetOrderFulfilmentStatusCode(ADitEntities db, string statusCode)
        {
            var result = (from d in db.FulfilmentStatus
                    where d.Description == statusCode
                    select new OrderFulfilmentStatusModel
                    {
                        Description = d.Description,
                        FulfilmentStatusCode = d.FulfilmentStatusCode
                    }
                ).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Gets the order fulfilment status rule.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IFulfilmentStatusRule> GetOrderFulfilmentStatusRule(ADitEntities db)
        {
            var result = (from b in db.FulfilmentStatusRules
                    select new FulfilmentStatusRuleModel
                    {
                        FulfilmentStatusId = b.FulfilmentStatusRuleId,
                        FromStatusId = b.FromStatusId,
                        ToStatusId = b.ToStatusId
                    }
                ).OrderBy(x => x.FulfilmentStatusId);
            return result;
        }
        /// <summary>
        /// Gets all orders.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IOrder> GetAllOrders(ADitEntities db)
        {
            var result = (from b in db.Orders
                    where b.OrderStatusCode == "P"
                    select new OrderModel
                    {
                        DateCreated = b.DateCreated,
                        DateModified = b.DateModified,
                        OrderId = b.OrderId,
                        OrderNumber = b.OrderNumber,
                        OrderStatus = b.OrderStatusCode,
                        UserId = b.UserId
                    }
                ).OrderBy(x => x.OrderId);
            return result;
        }

        /// <summary>
        /// Gets the scriptng pending fulfilment payments.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IFulfilmentPayment> GetScriptngPendingFulfilmentPayments(ADitEntities db,
            int userId)
        {
            var result = (from b in db.OrderFulfilments
                    where b.CreatedByUserId == userId
                    join c in db.FulfilmentScriptingPayments on b.OrderFulfilmentId equals c.OrderFulfilmentId into
                        fulfilmentPayment
                    from fufil in fulfilmentPayment.DefaultIfEmpty()
                    where fufil.FulfilmentPaymentStatus == "AP"
                    join s in db.ServiceTypes on b.ServiceCode equals s.ServiceTypeCode into service
                    from serviceCode in service.DefaultIfEmpty()
                    join o in db.Orders on b.OrderId equals o.OrderId into order
                    from orderCode in order.DefaultIfEmpty()
                    select new FulfilmentPaymentModel
                    {
                        OrderNumber = orderCode.OrderNumber,
                        orderPaymentId = fufil.FulfilmentScriptingPaymentId,
                        Price = fufil.Price??0,
                        OrderTitle = serviceCode.Description
                    }
                ).OrderBy(x => x.orderPaymentId);

            return result;
        }

        /// <summary>
        /// Gets the production pending fulfilment payments.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IFulfilmentPayment> GetProductionPendingFulfilmentPayments(ADitEntities db,
            int userId)
        {
            var result = (from b in db.OrderFulfilments
                    where b.CreatedByUserId == userId
                    join c in db.FulfilmentProductionPayments on b.OrderFulfilmentId equals c.OrderFulfilmentId into
                        fulfilmentPayment
                    from fufil in fulfilmentPayment.DefaultIfEmpty()
                    where fufil.FulfilmentPaymentStatus == "AP"
                    join s in db.ServiceTypes on b.ServiceCode equals s.ServiceTypeCode into service
                    from serviceCode in service.DefaultIfEmpty()
                    join o in db.Orders on b.OrderId equals o.OrderId into order
                    from orderCode in order.DefaultIfEmpty()
                    select new FulfilmentPaymentModel
                    {
                        OrderNumber = orderCode.OrderNumber,
                        orderPaymentId = fufil.FulfilmentProductionPaymentId,
                        Price = fufil.Price??0,
                        OrderTitle = serviceCode.Description
                    }
                ).OrderBy(x => x.orderPaymentId);

            return result;
        }






        /// <summary>
        /// Gets the fulfilment order by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="orderFulfilmentId">The order fulfilment identifier.</param>
        /// <returns></returns>
        internal static IOrderFulfilment GetFulfilmentOrderById(ADitEntities db, int orderFulfilmentId)
        {
            var result = (from b in db.OrderFulfilments
                join o in db.FulfilmentStatus on b.FulfilmentStatusCode equals o.FulfilmentStatusCode
              
                join p in db.ServiceTypes on b.ServiceCode equals p.ServiceTypeCode
                where b.OrderFulfilmentId == orderFulfilmentId
                select new OrderFulfilmentModel
                {
                    CreatedByUserId = b.CreatedByUserId,
                    DateCreated = b.DateCreated,
                    FufilmentStatusCode = b.FulfilmentStatusCode,
                    OrderFulfilmentId = b.OrderFulfilmentId,
                    OrderId = b.OrderId,
                    ServiceCode = p.ShortDescription,
                    ServiceTransactionId = b.ServiceTransactionId,
                   FufilmentStatusDescription=o.Description
                }).FirstOrDefault();

            return result;
        }

        /// <summary>
        /// Gets the order number by order identifier.
        /// </summary>
        /// <param name="OrderId">The order identifier.</param>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IOrder GetOrderNumberByOrderId(int OrderId, ADitEntities db)
        {
            var result = (from d in db.Orders
                    where d.OrderId == OrderId
                    select new OrderModel
                    {
                        OrderNumber = d.OrderNumber
                    }
                ).FirstOrDefault();

            return result;
        }


        /// <summary>
    }
}