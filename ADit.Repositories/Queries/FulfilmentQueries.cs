using ADit.Interfaces;
using ADit.Repositories.DataAccess;
using ADit.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADit.Repositories.Queries
{
    internal static class FulfilmentQueries
    {
        /// <summary>
        /// Gets the fulfilment orders.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IOrderFulfilment> GetFulfilmentOrders(ADitEntities db)
        {
            var result = (from b in db.OrderFulfilments
                join o in db.FulfilmentStatus on b.FulfilmentStatusCode equals o.FulfilmentStatusCode
                join p in db.ServiceTypes on b.ServiceCode equals p.ServiceTypeCode
                select new OrderFulfilmentModel
                {
                    CreatedByUserId = b.CreatedByUserId,
                    DateCreated = b.DateCreated,
                    FufilmentStatusCode = b.FulfilmentStatusCode,
                    FufilmentStatusDescription = o.Description,
                    OrderFulfilmentId = b.OrderFulfilmentId,
                    OrderId = b.OrderId,
                    ServiceCode = p.ServiceTypeCode,
                    ServiceTypeDescription = p.ShortDescription,
                    ServiceTransactionId = b.ServiceTransactionId,
                }).OrderBy(x => x.ServiceTransactionId);

            return result;
        }




        /// <summary>
        /// Gets the fulfilment orders by code.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="fufilmentCode">The fufilment code.</param>
        /// <returns></returns>
        internal static IEnumerable<IOrderFulfilment> GetFulfilmentOrdersByCode(ADitEntities db,string fulfilmentCode)
        {
            var result = (from b in db.OrderFulfilments
                          where b.FulfilmentStatusCode==fulfilmentCode
                          join o in db.FulfilmentStatus on b.FulfilmentStatusCode equals o.FulfilmentStatusCode
                          join p in db.ServiceTypes on b.ServiceCode equals p.ServiceTypeCode
                         
                          select new OrderFulfilmentModel
                          {
                              CreatedByUserId = b.CreatedByUserId,
                              DateCreated = b.DateCreated,
                              FufilmentStatusCode = b.FulfilmentStatusCode,
                              FufilmentStatusDescription =o.Description,
                              OrderFulfilmentId = b.OrderFulfilmentId,
                              OrderId = b.OrderId,
                              ServiceCode = p.ServiceTypeCode,
                              ServiceTypeDescription = p.ShortDescription,
                              ServiceTransactionId = b.ServiceTransactionId,
                          }).OrderBy(x => x.ServiceTransactionId);

            return result;
        }

        /// <summary>
        /// Gets the fulfilment orders by code.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="fulfilmentCodeList">The fulfilment code list.</param>
        /// <returns>IEnumerable&lt;IOrderFulfilment&gt;.</returns>
        internal static IEnumerable<IOrderFulfilment> GetFulfilmentOrdersByCode(ADitEntities db, IList<string> fulfilmentCodeList)
        {
            var result = (from b in db.OrderFulfilments
                 where fulfilmentCodeList.Contains(b.FulfilmentStatusCode)
                join o in db.FulfilmentStatus on b.FulfilmentStatusCode equals o.FulfilmentStatusCode
                join p in db.ServiceTypes on b.ServiceCode equals p.ServiceTypeCode

                select new OrderFulfilmentModel
                {
                    CreatedByUserId = b.CreatedByUserId,
                    DateCreated = b.DateCreated,
                    FufilmentStatusCode = b.FulfilmentStatusCode,
                    FufilmentStatusDescription = o.Description,
                    OrderFulfilmentId = b.OrderFulfilmentId,
                    OrderId = b.OrderId,
                    ServiceCode = p.ServiceTypeCode,
                    ServiceTypeDescription = p.ShortDescription,
                    ServiceTransactionId = b.ServiceTransactionId,
                }).OrderBy(x => x.ServiceTransactionId);

            return result;
        }











        /// <summary>
        /// Gets the submitted fulfilment.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="">The .</param>
        /// <returns></returns>
        internal static IEnumerable<IOrderFulfilment> GetSubmittedFulfilment(ADitEntities db)
        {
            var result = (from b in db.OrderFulfilments
                          where b.FulfilmentStatusCode == "S"
                          join o in db.FulfilmentStatus on b.FulfilmentStatusCode equals o.FulfilmentStatusCode
                          join p in db.ServiceTypes on b.ServiceCode equals p.ServiceTypeCode

                          select new OrderFulfilmentModel
                          {
                              CreatedByUserId = b.CreatedByUserId,
                              DateCreated = b.DateCreated,
                              FufilmentStatusCode = b.FulfilmentStatusCode,
                              FufilmentStatusDescription = o.Description,
                              OrderFulfilmentId = b.OrderFulfilmentId,
                              OrderId = b.OrderId,
                              ServiceCode = p.ServiceTypeCode,
                              ServiceTypeDescription = p.ShortDescription,
                              ServiceTransactionId = b.ServiceTransactionId,
                          }).OrderBy(x => x.ServiceTransactionId);

            return result;
        }

        internal static IEnumerable<IFulfilmentStatusSummaryModel> GetFulfilmentSummary(ADitEntities db)
        {
            var result = (from b in db.FulfilmentStatus
                       
                          join o in db.OrderFulfilments on b.FulfilmentStatusCode equals o.FulfilmentStatusCode into statuscount
                        



                          select new FulfilmentStatusSummaryModel
                          {

                              FulfilmentStatus = b.FulfilmentStatusCode,
                              FulfilmentStatusDescription=b.Description,
                              OrdersPerStatusCount =statuscount.OrderBy(x=>x.FulfilmentStatusCode).Count(),
                          }).OrderBy(x => x.FulfilmentStatus);

            return result;
        }







        /// <summary>
        /// Gets the fulfilment service summary by status code.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="status">The status.</param>
        /// <returns></returns>
        internal static IEnumerable<IFulfilmentServiceSummaryModel> GetFulfilmentServiceSummaryByStatusCode(ADitEntities db,string status)
        {
            var result = (from s in db.ServiceTypes
                          join o in db.OrderFulfilments on s.ServiceTypeCode equals o.ServiceCode
                          where o.FulfilmentStatusCode.Equals(status)
                         group  s by s.Description into fulfilemtServiceSummary

                          


                          select new FulfilmentServiceSummaryModel
                          {
                            ServiceCodeDescription= fulfilemtServiceSummary.Key,
                              OrderByServiceCodeCount= fulfilemtServiceSummary.Count()
                             
                          }).OrderBy(x => x.ServiceCodeDescription);

            return result;
        }

        /// <summary>
        /// Gets the fulfilment orders by fulfilment identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="orderfulmentId">The orderfulment identifier.</param>
        /// <returns>IOrderFulfilment.</returns>
        internal static IOrderFulfilment GetFulfilmentOrdersByFulfilmentId(ADitEntities db, int orderfulmentId)
        {
            var result = (from b in db.OrderFulfilments
                where b.OrderFulfilmentId == orderfulmentId
                          join o in db.FulfilmentStatus on b.FulfilmentStatusCode equals o.FulfilmentStatusCode
                join p in db.ServiceTypes on b.ServiceCode equals p.ServiceTypeCode

                select new OrderFulfilmentModel
                {
                    CreatedByUserId = b.CreatedByUserId,
                    DateCreated = b.DateCreated,
                    FufilmentStatusCode = o.Description,
                    OrderFulfilmentId = b.OrderFulfilmentId,
                    OrderId = b.OrderId,
                    ServiceCode = p.ShortDescription,
                    ServiceTransactionId = b.ServiceTransactionId,
                }).FirstOrDefault();

            return result;
        }






    }
}