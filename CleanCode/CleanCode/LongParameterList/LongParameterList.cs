
using System;
using System.Collections.Generic;

namespace CleanCode.LongParameterList
{
    #region Wrong
    public class LongParameterListWrong
    {
        public IEnumerable<Reservation> GetReservations(
           DateTime dateFrom, DateTime dateTo,
           User user, int locationId,
           LocationType locationType, int? customerId = null)
        {
            if (dateFrom >= DateTime.Now)
                throw new ArgumentNullException("dateFrom");
            if (dateTo <= DateTime.Now)
                throw new ArgumentNullException("dateTo");

            throw new NotImplementedException();
        }

        public IEnumerable<Reservation> GetUpcomingReservations(
            DateTime dateFrom, DateTime dateTo,
            User user, int locationId,
            LocationType locationType)
        {
            if (dateFrom >= DateTime.Now)
                throw new ArgumentNullException("dateFrom");
            if (dateTo <= DateTime.Now)
                throw new ArgumentNullException("dateTo");

            throw new NotImplementedException();
        }

        private static Tuple<DateTime, DateTime> GetReservationDateRange(DateTime dateFrom, DateTime dateTo, ReservationDefinition sd)
        {
            if (dateFrom >= DateTime.Now)
                throw new ArgumentNullException("dateFrom");
            if (dateTo <= DateTime.Now)
                throw new ArgumentNullException("dateTo");

            throw new NotImplementedException();
        }

        public void CreateReservation(DateTime dateFrom, DateTime dateTo, int locationId)
        {
            if (dateFrom >= DateTime.Now)
                throw new ArgumentNullException("dateFrom");
            if (dateTo <= DateTime.Now)
                throw new ArgumentNullException("dateTo");

            throw new NotImplementedException();
        }
    }
    #endregion

    #region Right
    public class LongParameterList
    {
        public IEnumerable<Reservation> GetReservations(ReservationsQuery query)
        {
            if (query.DateRange.DateFrom >= DateTime.Now)
                throw new ArgumentNullException("dateFrom");
            if (query.DateRange.DateTo <= DateTime.Now)
                throw new ArgumentNullException("dateTo");

            throw new NotImplementedException();
        }

        public IEnumerable<Reservation> GetUpcomingReservations(ReservationsQuery query)
        {
            if (query.DateRange.DateFrom >= DateTime.Now)
                throw new ArgumentNullException("dateFrom");
            if (query.DateRange.DateTo <= DateTime.Now)
                throw new ArgumentNullException("dateTo");

            throw new NotImplementedException();
        }

        private static Tuple<DateTime, DateTime> GetReservationDateRange(DateRange dateRange, ReservationDefinition reservationDefinition)
        {
            if (dateRange.DateFrom >= DateTime.Now)
                throw new ArgumentNullException("dateFrom");
            if (dateRange.DateTo <= DateTime.Now)
                throw new ArgumentNullException("dateTo");

            throw new NotImplementedException();
        }

        public void CreateReservation(DateRange dateRange, int locationId)
        {
            if (dateRange.DateFrom >= DateTime.Now)
                throw new ArgumentNullException("dateFrom");
            if (dateRange.DateTo <= DateTime.Now)
                throw new ArgumentNullException("dateTo");

            throw new NotImplementedException();
        }

        public class DateRange
        {
            private DateTime _dateFrom;
            private DateTime _dateTo;

            public DateRange(DateTime dateFrom, DateTime dateTo)
            {
                _dateFrom = dateFrom;
                _dateTo = dateTo;
            }

            public DateTime DateFrom
            {
                get => _dateFrom;
            }

            public DateTime DateTo
            {
                get => _dateTo;
            }

        }

        public class ReservationsQuery
        {
            private User _user;
            private LocationType _locationType;
            private DateRange _dateRange;
            private int _locationId;
            private int? _customerId;

            public ReservationsQuery(User user, LocationType locationType, DateRange dateRange, int locationId, int? customerId)
            {
                _user = user;
                _locationType = locationType;
                _dateRange = dateRange;
                _locationId = locationId;
                _customerId = customerId;
            }

            public DateRange DateRange
            {
                get => _dateRange; 
            }
            public int LocationId
            {
                get => _locationId; 
            }
            public LocationType LocationType
            {
                get => _locationType; 
            }
            public User User
            {
                get => _user; 
            }
            public int? CustomerId
            {
                get => _customerId;
            }
        }
    }
    #endregion

    #region helpers
    internal class ReservationDefinition
    {
    }

    public class LocationType
    {
    }

    public class User
    {
        public object Id { get; set; }
    }

    public class Reservation
    {
    }
    #endregion
}
